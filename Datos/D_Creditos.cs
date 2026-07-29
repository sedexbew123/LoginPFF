using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Creditos
    {
        private readonly D_ConexionBD conexion = new D_ConexionBD();

        public async Task<Clientes> BuscarPorCedula(string cedula)
        {
            string query = "SELECT TOP 1 Cedula, Nombres, Apellidos FROM Clientes WHERE Cedula = @Cedula";
            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Cedula", cedula);
                    using (SqlDataReader dr = await comando.ExecuteReaderAsync())
                    {
                        if (dr.Read())
                            return new Clientes
                            {
                                Cedula = dr["Cedula"].ToString(),
                                Nombres = dr["Nombres"].ToString(),
                                Apellidos = dr["Apellidos"].ToString()
                            };
                        return null;
                    }
                }
            }
        }

        public async Task<List<string>> ObtenerCategorias()
        {
            var lista = new List<string>();

            string query = @"SELECT NombreCategoria FROM Categorias WHERE Estado = 1 ORDER BY NombreCategoria";

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader dr = await comando.ExecuteReaderAsync())
                        while (dr.Read()) lista.Add(dr["NombreCategoria"].ToString());
                }
            }
            return lista;
        }

        public async Task<DataTable> ObtenerProductos(string nombre, string categoria)
        {
            DataTable dt = new DataTable();

            string query = @"SELECT p.Codigo, p.Nombre, ISNULL(cat.NombreCategoria,'Sin categoría') AS Categoria,
                             p.Precio, p.StockActual AS Existencia FROM Productos p LEFT JOIN Categorias cat
                             ON p.IdCategoria = cat.IdCategoria WHERE p.Estado = 'Activo' AND p.StockActual > 0
                             AND (@Nombre = '' OR p.Nombre LIKE '%' + @Nombre + '%') AND (@Cat = '' OR @Cat = 'Todos'
                             OR cat.NombreCategoria = @Cat) ORDER BY p.Nombre";

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", nombre ?? "");
                    comando.Parameters.AddWithValue("@Cat", categoria ?? "");
                    using (SqlDataReader dr = await comando.ExecuteReaderAsync())
                            dt.Load(dr);
                }
            }
            return dt;
        }

        public async Task<(bool exito, string mensaje)> AsignarCredito(string cedula, List<ItemCredito> items, decimal total, int idUsuario)
        {
            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            {
                using (SqlTransaction trx = conexion.BeginTransaction())
                {
                    try
                    {
                        int idCliente = await GetIdCliente(conexion, trx, cedula);
                        if (idCliente <= 0) return (false, "Cliente no encontrado.");

                        int idCreditoExistente = 0;
                        DateTime? fechaUltimoCredito = null;

                        using (SqlCommand cmdUltimo = new SqlCommand(@"
                    SELECT TOP 1 IdCredito, FechaCredito 
                    FROM Creditos 
                    WHERE IdCliente = @IdCliente AND Estado = 'Activo'
                    ORDER BY FechaCredito DESC", conexion, trx))
                        {
                            cmdUltimo.Parameters.AddWithValue("@IdCliente", idCliente);
                            using (var dr = await cmdUltimo.ExecuteReaderAsync())
                            {
                                if (await dr.ReadAsync())
                                {
                                    idCreditoExistente = Convert.ToInt32(dr["IdCredito"]);
                                    fechaUltimoCredito = Convert.ToDateTime(dr["FechaCredito"]);
                                }
                            }
                        }

                        int idCredito;
                        bool dentroDeLaSemana = fechaUltimoCredito.HasValue
                            && (DateTime.Now - fechaUltimoCredito.Value).TotalDays < 7;

                        if (dentroDeLaSemana && idCreditoExistente > 0)
                        {
                            idCredito = idCreditoExistente;
                            await ActualizarMontoCredito(conexion, trx, idCredito, total);
                        }
                        else
                        {
                            idCredito = await CrearCredito(conexion, trx, idCliente, total, idUsuario); // <-- aquí
                        }

                        foreach (var item in items)
                        {
                            await InsertarDetalle(conexion, trx, idCredito, item);
                            await ReducirStock(conexion, trx, item.CodigoProducto, item.Cantidad);
                        }

                        trx.Commit();
                        return (true, dentroDeLaSemana
                            ? "Producto(s) agregado(s) al crédito vigente."
                            : "Crédito nuevo asignado correctamente.");
                    }
                    catch (Exception ex)
                    {
                        trx.Rollback();
                        return (false, "Error al asignar crédito: " + ex.Message);
                    }
                }
            }
        }

        private async Task ActualizarMontoCredito(SqlConnection conexion, SqlTransaction trx, int idCredito, decimal montoAdicional)
        {
            using (SqlCommand comando = new SqlCommand(
                "UPDATE Creditos SET MontoTotal = MontoTotal + @monto WHERE IdCredito = @id", conexion, trx))
            {
                comando.Parameters.AddWithValue("@monto", montoAdicional);
                comando.Parameters.AddWithValue("@id", idCredito);
                await comando.ExecuteNonQueryAsync();
            }
        }

        public async Task<DataTable> ObtenerResumenDeudas(string filtro, string ordenSQL)
        {
            DataTable dt = new DataTable();
            string query = $@"SELECT cr.IdCredito, c.Nombres AS Nombre, c.Apellidos AS Apellido, c.Cedula,
                    cr.MontoTotal - ISNULL((SELECT SUM(p.Monto)     
                    FROM Pagos p WHERE p.IdCredito = cr.IdCredito), 0) AS Monto,
                    cr.FechaCredito AS Fecha,
                    ISNULL(u.usuario, 'No registrado') AS RegistradoPor,
                    ISNULL(r.nombreRol, '-') AS Rol
                    FROM Clientes c 
                    INNER JOIN Creditos cr ON c.id_cliente = cr.IdCliente
                    LEFT JOIN Usuarios u ON cr.IdUsuario = u.id
                    LEFT JOIN Roles r ON u.idRol = r.idRol
                    WHERE cr.Estado = 'Activo' AND (@F = '' OR c.Nombres LIKE '%' + @F + '%'
                    OR c.Apellidos LIKE '%' + @F + '%' OR c.Cedula LIKE '%' + @F + '%')
                    AND (cr.MontoTotal - ISNULL((SELECT SUM(p.Monto) FROM Pagos p 
                    WHERE p.IdCredito = cr.IdCredito), 0)) > 0 ORDER BY {ordenSQL}";

            using (SqlConnection conexion = await this.conexion.ConectarAsync())   
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@F", filtro ?? "");
                        using (SqlDataReader r = await comando.ExecuteReaderAsync())
                        dt.Load(r);
                }
            }
            return dt;
        }

        public async Task<(int totalClientes, decimal creditoTotal, int totalProductos)> ObtenerEstadisticasDeudas()
        {
            string query = @"SELECT (SELECT COUNT(DISTINCT IdCliente) FROM Creditos 
                             WHERE Estado = 'Activo') AS TotalClientes, (SELECT ISNULL(SUM(sub.Saldo), 0) FROM (
                             SELECT cr.MontoTotal - ISNULL((SELECT SUM(p.Monto) FROM Pagos p 
                             WHERE p.IdCredito = cr.IdCredito), 0) AS Saldo FROM Creditos cr 
                             WHERE cr.Estado = 'Activo') sub) AS CreditoTotal, (SELECT COUNT(*) 
                             FROM DetalleCredito dc INNER JOIN Creditos cr ON dc.IdCredito = cr.IdCredito
                             WHERE cr.Estado = 'Activo') AS TotalProductos";

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader r = await comando.ExecuteReaderAsync())
                    {
                        if (r.Read())
                            return (Convert.ToInt32(r["TotalClientes"]),
                                    Convert.ToDecimal(r["CreditoTotal"]),
                                    Convert.ToInt32(r["TotalProductos"]));
                    }
                }
                
            }  
            return (0, 0, 0);
        }

        private async Task<int> GetIdCliente(SqlConnection conexion, SqlTransaction trx, string cedula)
        {
            using (SqlCommand comando = new SqlCommand(
                "SELECT id_cliente FROM Clientes WHERE Cedula = @c", conexion, trx))
            {
                comando.Parameters.AddWithValue("@c", cedula);
                var dr = await comando.ExecuteScalarAsync();
                return dr != null && dr != DBNull.Value ? Convert.ToInt32(dr) : 0;
            }
        }

        private async Task<int> CrearCredito(SqlConnection conexion, SqlTransaction trx, int idCliente, decimal montoTotal, int idUsuario)
        {
            using (SqlCommand comando = new SqlCommand(@"
        INSERT INTO Creditos (IdCliente, FechaCredito, MontoTotal, Estado, IdUsuario)
        OUTPUT INSERTED.IdCredito VALUES (@id, GETDATE(), @monto, 'Activo', @idUsuario)", conexion, trx))
            {
                comando.Parameters.AddWithValue("@id", idCliente);
                comando.Parameters.AddWithValue("@monto", montoTotal);
                comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                return Convert.ToInt32(await comando.ExecuteScalarAsync());
            }
        }

        private async Task InsertarDetalle(SqlConnection conexion, SqlTransaction trx, int idCredito, ItemCredito item)
        {
            using (SqlCommand comando = new SqlCommand(@"
                INSERT INTO DetalleCredito (IdCredito, CodigoProducto, Cantidad, PrecioUnitario, Fecha)
                VALUES (@idCredito, @codigo, @cant, @precio, GETDATE())", conexion, trx))
            {
                comando.Parameters.AddWithValue("@idCredito", idCredito);
                comando.Parameters.AddWithValue("@codigo", item.CodigoProducto);
                comando.Parameters.AddWithValue("@cant", item.Cantidad);
                comando.Parameters.AddWithValue("@precio", item.PrecioUnitario);
                await comando.ExecuteNonQueryAsync();
            }
        }

        private async Task ReducirStock(SqlConnection conexion, SqlTransaction trx, string codigoProducto, int cantidad)
        {
            using (SqlCommand comando = new SqlCommand(@"
                UPDATE Productos SET StockActual = StockActual - @cant WHERE Codigo = @cod AND StockActual >= @cant", conexion, trx))
            {
                comando.Parameters.AddWithValue("@cant", cantidad);
                comando.Parameters.AddWithValue("@cod", codigoProducto);
                await comando.ExecuteNonQueryAsync();
            }
        }

        public async Task<(Clientes cliente, DataTable detalles, decimal total, int meses)>
        ObtenerDetalleDeuda(string cedula, int idCredito)
        {
            string cedulaLimpia = cedula.Trim();

            Clientes cliente = null;
            DataTable dtProductos = new DataTable();
            decimal totalDeuda = 0;
            int mesesSinPagar = 0;

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            {
                string sqlCliente = "SELECT id_cliente, Cedula, Nombres, Apellidos FROM Clientes WHERE RTRIM(Cedula) = @Cedula";
                int idClienteReal = 0;

                using (SqlCommand cmdCliente = new SqlCommand(sqlCliente, conexion))
                {
                    cmdCliente.Parameters.AddWithValue("@Cedula", cedulaLimpia);

                    using (SqlDataReader reader = await cmdCliente.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            cliente = new Clientes
                            {
                                id_cliente = Convert.ToInt32(reader["id_cliente"]),
                                Cedula = reader["Cedula"].ToString(),
                                Nombres = reader["Nombres"].ToString(),
                                Apellidos = reader["Apellidos"].ToString()
                            };
                            idClienteReal = cliente.id_cliente;
                        }
                    }
                }

                if (cliente == null)
                {
                    return (null, dtProductos, 0, 0);
                }


                string sqlTotal = idCredito > 0? @"SELECT ISNULL(cr.MontoTotal - ISNULL(
                (SELECT SUM(p.Monto) FROM Pagos p WHERE p.IdCredito = cr.IdCredito), 0), 0) 
                FROM Creditos cr WHERE cr.IdCredito = @IdCredito"
                : @"SELECT ISNULL(SUM(sub.Saldo), 0) FROM (SELECT cr.MontoTotal - ISNULL((
                SELECT SUM(p.Monto) FROM Pagos p WHERE p.IdCredito = cr.IdCredito), 0) AS Saldo
                FROM Creditos cr WHERE cr.IdCliente = @IdCliente AND cr.Estado = 'Activo') sub";

                using (SqlCommand cmdTotal = new SqlCommand(sqlTotal, conexion))
                {
                    if (idCredito > 0)
                        cmdTotal.Parameters.AddWithValue("@IdCredito", idCredito);
                    else
                        cmdTotal.Parameters.AddWithValue("@IdCliente", idClienteReal);

                    totalDeuda = Convert.ToDecimal(await cmdTotal.ExecuteScalarAsync());
                }

                string sqlProductos = idCredito > 0? @"SELECT dc.Cantidad, p.Nombre AS Producto, 
                cat.NombreCategoria AS Categoria, dc.PrecioUnitario AS Monto, dc.Fecha
                FROM DetalleCredito dc INNER JOIN Creditos cr ON dc.IdCredito = cr.IdCredito
                INNER JOIN Productos p ON dc.CodigoProducto = p.Codigo
                INNER JOIN Categorias cat ON p.IdCategoria = cat.IdCategoria WHERE cr.IdCredito = @IdCredito
                ORDER BY dc.Fecha DESC"
                : @"SELECT dc.Cantidad, p.Nombre AS Producto, cat.NombreCategoria AS Categoria,     
                dc.PrecioUnitario AS Monto, dc.Fecha FROM DetalleCredito dc 
                INNER JOIN Creditos cr ON dc.IdCredito = cr.IdCredito
                INNER JOIN Productos p ON dc.CodigoProducto = p.Codigo
                INNER JOIN Categorias cat ON p.IdCategoria = cat.IdCategoria
                WHERE cr.IdCliente = @IdCliente AND cr.Estado = 'Activo' ORDER BY dc.Fecha DESC";

                using (SqlCommand cmdProductos = new SqlCommand(sqlProductos, conexion))
                {
                    if (idCredito > 0)
                        cmdProductos.Parameters.AddWithValue("@IdCredito", idCredito);
                    else
                        cmdProductos.Parameters.AddWithValue("@IdCliente", idClienteReal);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmdProductos))
                        adapter.Fill(dtProductos);
                }

                string sqlMeses = idCredito > 0? @"SELECT ISNULL(DATEDIFF(day, FechaCredito, GETDATE()), 0) 
                FROM Creditos WHERE IdCredito = @IdCredito"
                : @"SELECT ISNULL(DATEDIFF(day, MIN(FechaCredito), GETDATE()), 0) 
                FROM Creditos WHERE IdCliente = @IdCliente AND Estado = 'Activo'";

                using (SqlCommand cmdMeses = new SqlCommand(sqlMeses, conexion))
                {
                    if (idCredito > 0)
                        cmdMeses.Parameters.AddWithValue("@IdCredito", idCredito);
                    else
                        cmdMeses.Parameters.AddWithValue("@IdCliente", idClienteReal);

                    mesesSinPagar = Convert.ToInt32(await cmdMeses.ExecuteScalarAsync());
                }
            }
            return (cliente, dtProductos, totalDeuda, mesesSinPagar);
        }
    }
}