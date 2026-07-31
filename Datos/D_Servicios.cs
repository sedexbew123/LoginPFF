using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Servicios
    {
        private readonly D_ConexionBD conexion = new D_ConexionBD();

        #region Tipos de Servicio

        public async Task<List<TipoServicioListado>> ObtenerTiposAsync()
        {
            var lista = new List<TipoServicioListado>();
            const string query = @"
                SELECT  t.IdTipoServicio,
                        t.Nombre,
                        t.Estado,
                        (SELECT COUNT(*) FROM Servicios s WHERE s.IdTipoServicio = t.IdTipoServicio) AS CantidadServicios
                FROM TiposServicio t  
                ORDER BY t.Nombre";

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            using (SqlCommand comando = new SqlCommand(query, conexion))
            using (SqlDataReader dr = await comando.ExecuteReaderAsync())
            {
                while (await dr.ReadAsync())
                {
                    lista.Add(new TipoServicioListado
                    {
                        IdTipoServicio = Convert.ToInt32(dr["IdTipoServicio"]),
                        Tipo = dr["Nombre"].ToString(),
                        Servicio = Convert.ToInt32(dr["CantidadServicios"]),
                        Estado = Convert.ToBoolean(dr["Estado"]) ? "Activo" : "Inactivo"
                    });
                }
            }
            return lista;
        }

        public async Task<List<TipoServicio>> ObtenerTiposActivosAsync()
        {
            var lista = new List<TipoServicio>();
            const string query = "SELECT IdTipoServicio, Nombre, Estado, Descripcion FROM TiposServicio WHERE Estado = 1 ORDER BY Nombre";

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            using (SqlCommand comando = new SqlCommand(query, conexion))
            using (SqlDataReader dr = await comando.ExecuteReaderAsync())
            {
                while (await dr.ReadAsync())
                {
                    lista.Add(new TipoServicio
                    {
                        IdTipoServicio = Convert.ToInt32(dr["IdTipoServicio"]),
                        Nombre = dr["Nombre"].ToString(),
                        Estado = Convert.ToBoolean(dr["Estado"]),
                        Descripcion = dr["Descripcion"] as string
                    });
                }
            }
            return lista;
        }

        public async Task<TipoServicio> ObtenerTipoPorIdAsync(int idTipoServicio)
        {
            const string query = "SELECT IdTipoServicio, Nombre, Estado, Descripcion FROM TiposServicio WHERE IdTipoServicio = @Id";

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@Id", idTipoServicio);
                using (SqlDataReader dr = await comando.ExecuteReaderAsync())
                {
                    if (await dr.ReadAsync())
                    {
                        return new TipoServicio
                        {
                            IdTipoServicio = Convert.ToInt32(dr["IdTipoServicio"]),
                            Nombre = dr["Nombre"].ToString(),
                            Estado = Convert.ToBoolean(dr["Estado"]),
                            Descripcion = dr["Descripcion"] as string
                        };
                    }
                }
            }
            return null;
        }

        public async Task<bool> ExisteTipoPorNombreAsync(string nombre, int idTipoExcluir)
        {
            const string query = "SELECT COUNT(*) FROM TiposServicio WHERE Nombre = @Nombre AND IdTipoServicio <> @IdExcluir";
            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@IdExcluir", idTipoExcluir);
                return Convert.ToInt32(await comando.ExecuteScalarAsync()) > 0;
            }
        }

        public async Task<bool> InsertarTipoAsync(TipoServicio tipo)
        {
            const string query = @"INSERT INTO TiposServicio (Nombre, Estado, Descripcion)
                                    VALUES (@Nombre, @Estado, @Descripcion)";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", tipo.Nombre);
                    comando.Parameters.AddWithValue("@Estado", tipo.Estado);
                    comando.Parameters.AddWithValue("@Descripcion", (object)tipo.Descripcion ?? DBNull.Value);
                    return await comando.ExecuteNonQueryAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                Log("InsertarTipo", ex);
                return false;
            }
        }

        public async Task<bool> ActualizarTipoAsync(TipoServicio tipo)
        {
            const string query = @"UPDATE TiposServicio
                                    SET Nombre = @Nombre, Estado = @Estado, Descripcion = @Descripcion
                                    WHERE IdTipoServicio = @Id";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", tipo.Nombre);
                    comando.Parameters.AddWithValue("@Estado", tipo.Estado);
                    comando.Parameters.AddWithValue("@Descripcion", (object)tipo.Descripcion ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@Id", tipo.IdTipoServicio);
                    return await comando.ExecuteNonQueryAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                Log("ActualizarTipo", ex);
                return false;
            }
        }

        public async Task<bool> TipoTieneServiciosAsync(int idTipoServicio)
        {
            const string query = "SELECT COUNT(*) FROM Servicios WHERE IdTipoServicio = @Id";
            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@Id", idTipoServicio);
                return Convert.ToInt32(await comando.ExecuteScalarAsync()) > 0;
            }
        }

        public async Task<bool> DesactivarTipoAsync(int idTipoServicio)
        {
            const string query = "UPDATE TiposServicio SET Estado = 0 WHERE IdTipoServicio = @Id";
            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@Id", idTipoServicio);
                return await comando.ExecuteNonQueryAsync() > 0;
            }
        }

        public async Task<bool> EliminarTipoAsync(int idTipoServicio)
        {
            const string query = "DELETE FROM TiposServicio WHERE IdTipoServicio = @Id";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Id", idTipoServicio);
                    return await comando.ExecuteNonQueryAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                Log("EliminarTipo", ex);
                return false;
            }
        }

        #endregion

        #region Servicios

        public async Task<List<ServicioListado>> ObtenerServiciosAsync()
        {
            var lista = new List<ServicioListado>();
            const string query = @"
                SELECT s.IdServicio, s.Nombre, t.Nombre AS TipoNombre, s.Precio
                FROM Servicios s
                INNER JOIN TiposServicio t ON t.IdTipoServicio = s.IdTipoServicio
                WHERE s.Estado = 1
                ORDER BY s.Nombre";

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            using (SqlCommand comando = new SqlCommand(query, conexion))
            using (SqlDataReader dr = await comando.ExecuteReaderAsync())
            {
                while (await dr.ReadAsync())
                {
                    lista.Add(new ServicioListado
                    {
                        IdServicio = Convert.ToInt32(dr["IdServicio"]),
                        Servicio = dr["Nombre"].ToString(),
                        Tipo = dr["TipoNombre"].ToString(),
                        Precio = Convert.ToDecimal(dr["Precio"])
                    });
                }
            }
            return lista;
        }

        public async Task<List<Servicio>> ObtenerServiciosActivosAsync()
        {
            var lista = new List<Servicio>();
            const string query = @"
                SELECT s.IdServicio, s.Nombre, s.IdTipoServicio, t.Nombre AS TipoNombre,
                       s.Precio, s.Descripcion, s.Estado
                FROM Servicios s
                INNER JOIN TiposServicio t ON t.IdTipoServicio = s.IdTipoServicio
                WHERE s.Estado = 1
                ORDER BY s.Nombre";

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            using (SqlCommand comando = new SqlCommand(query, conexion))
            using (SqlDataReader dr = await comando.ExecuteReaderAsync())
            {
                while (await dr.ReadAsync())
                {
                    lista.Add(new Servicio
                    {
                        IdServicio = Convert.ToInt32(dr["IdServicio"]),
                        Nombre = dr["Nombre"].ToString(),
                        IdTipoServicio = Convert.ToInt32(dr["IdTipoServicio"]),
                        TipoNombre = dr["TipoNombre"].ToString(),
                        Precio = Convert.ToDecimal(dr["Precio"]),
                        Descripcion = dr["Descripcion"] as string,
                        Estado = Convert.ToBoolean(dr["Estado"])
                    });
                }
            }
            return lista;
        }

        public async Task<Servicio> ObtenerServicioPorIdAsync(int idServicio)
        {
            const string query = @"
                SELECT s.IdServicio, s.Nombre, s.IdTipoServicio, t.Nombre AS TipoNombre,
                       s.Precio, s.Descripcion, s.Estado
                FROM Servicios s
                INNER JOIN TiposServicio t ON t.IdTipoServicio = s.IdTipoServicio
                WHERE s.IdServicio = @Id";

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@Id", idServicio);
                using (SqlDataReader dr = await comando.ExecuteReaderAsync())
                {
                    if (await dr.ReadAsync())
                    {
                        return new Servicio
                        {
                            IdServicio = Convert.ToInt32(dr["IdServicio"]),
                            Nombre = dr["Nombre"].ToString(),
                            IdTipoServicio = Convert.ToInt32(dr["IdTipoServicio"]),
                            TipoNombre = dr["TipoNombre"].ToString(),
                            Precio = Convert.ToDecimal(dr["Precio"]),
                            Descripcion = dr["Descripcion"] as string,
                            Estado = Convert.ToBoolean(dr["Estado"])
                        };
                    }
                }
            }
            return null;
        }

        public async Task<bool> InsertarServicioAsync(Servicio servicio)
        {
            const string query = @"INSERT INTO Servicios (Nombre, IdTipoServicio, Precio, Descripcion, Estado)
                                    VALUES (@Nombre, @IdTipoServicio, @Precio, @Descripcion, 1)";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", servicio.Nombre);
                    comando.Parameters.AddWithValue("@IdTipoServicio", servicio.IdTipoServicio);
                    comando.Parameters.AddWithValue("@Precio", servicio.Precio);
                    comando.Parameters.AddWithValue("@Descripcion", (object)servicio.Descripcion ?? DBNull.Value);
                    return await comando.ExecuteNonQueryAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                Log("InsertarServicio", ex);
                return false;
            }
        }

        public async Task<bool> ActualizarServicioAsync(Servicio servicio)
        {
            const string query = @"UPDATE Servicios
                                    SET Nombre = @Nombre, IdTipoServicio = @IdTipoServicio,
                                        Precio = @Precio, Descripcion = @Descripcion
                                    WHERE IdServicio = @Id";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", servicio.Nombre);
                    comando.Parameters.AddWithValue("@IdTipoServicio", servicio.IdTipoServicio);
                    comando.Parameters.AddWithValue("@Precio", servicio.Precio);
                    comando.Parameters.AddWithValue("@Descripcion", (object)servicio.Descripcion ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@Id", servicio.IdServicio);
                    return await comando.ExecuteNonQueryAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                Log("ActualizarServicio", ex);
                return false;
            }
        }

        public async Task<bool> ServicioTieneHistorialAsync(int idServicio)
        {
            const string query = "SELECT COUNT(*) FROM ServiciosRealizados WHERE IdServicio = @Id";
            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@Id", idServicio);
                return Convert.ToInt32(await comando.ExecuteScalarAsync()) > 0;
            }
        }

        public async Task<bool> DesactivarServicioAsync(int idServicio)
        {
            const string query = "UPDATE Servicios SET Estado = 0 WHERE IdServicio = @Id";
            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@Id", idServicio);
                return await comando.ExecuteNonQueryAsync() > 0;
            }
        }

        public async Task<bool> EliminarServicioAsync(int idServicio)
        {
            const string query = "DELETE FROM Servicios WHERE IdServicio = @Id";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Id", idServicio);
                    return await comando.ExecuteNonQueryAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                Log("EliminarServicio", ex);
                return false;
            }
        }

        #endregion

        #region Servicios Realizados

        public async Task<bool> RegistrarServicioRealizadoAsync(ServicioRealizado sr)
        {
            const string query = @"
                INSERT INTO ServiciosRealizados
                    (IdCliente, IdServicio, MontoDolares, MontoBolivares, FechaServicio, DarCredito, IdCredito)
                VALUES
                    (@IdCliente, @IdServicio, @MontoDolares, @MontoBolivares, @FechaServicio, @DarCredito, @IdCredito)";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdCliente", sr.IdCliente);
                    comando.Parameters.AddWithValue("@IdServicio", sr.IdServicio);
                    comando.Parameters.AddWithValue("@MontoDolares", sr.MontoDolares);
                    comando.Parameters.AddWithValue("@MontoBolivares", sr.MontoBolivares);
                    comando.Parameters.AddWithValue("@FechaServicio", sr.FechaServicio);
                    comando.Parameters.AddWithValue("@DarCredito", sr.DarCredito);
                    comando.Parameters.AddWithValue("@IdCredito", (object)sr.IdCredito ?? DBNull.Value);
                    return await comando.ExecuteNonQueryAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                Log("RegistrarServicioRealizado", ex);
                return false;
            }
        }

        public async Task<(List<ServicioRealizadoListado> lista, int totalRegistros)> ObtenerServiciosRealizadosAsync(
            string textoBusqueda, string mes, int año, int pagina, int tamañoPagina)
        {
            var lista = new List<ServicioRealizadoListado>();
            int numeroMes = ObtenerNumeroMes(mes);
            int totalRegistros = 0;

            const string query = @"
                SELECT
                    sr.IdServicioRealizado,
                    c.Nombres, c.Apellidos, c.Cedula,
                    s.Nombre AS Servicio,
                    sr.MontoDolares,
                    sr.MontoBolivares,
                    sr.FechaServicio,
                    CASE
                        WHEN sr.DarCredito = 0 THEN 'Pagado'
                        WHEN cr.Estado = 'Pagado' THEN 'Pagado'
                        WHEN cr.FechaLimite IS NOT NULL
                             AND cr.FechaLimite < CAST(GETDATE() AS DATE)
                             AND (cr.MontoTotal - ISNULL(pagado.TotalPagado, 0)) > 0 THEN 'Vencida'
                        WHEN ISNULL(pagado.TotalPagado, 0) > 0
                             AND (cr.MontoTotal - ISNULL(pagado.TotalPagado, 0)) > 0 THEN 'Parcial'
                        ELSE 'Debe'
                    END AS Estado,
                    COUNT(*) OVER() AS TotalRegistros
                FROM ServiciosRealizados sr
                INNER JOIN Clientes c ON c.id_cliente = sr.IdCliente
                INNER JOIN Servicios s ON s.IdServicio = sr.IdServicio
                LEFT JOIN Creditos cr ON cr.IdCredito = sr.IdCredito
                OUTER APPLY (
                    SELECT SUM(p.Monto) AS TotalPagado FROM Pagos p WHERE p.IdCredito = cr.IdCredito
                ) pagado
                WHERE (@Texto = ''
                       OR c.Nombres LIKE '%' + @Texto + '%'
                       OR c.Apellidos LIKE '%' + @Texto + '%'
                       OR c.Cedula LIKE '%' + @Texto + '%')
                  AND (@Mes = 0 OR MONTH(sr.FechaServicio) = @Mes)
                  AND YEAR(sr.FechaServicio) = @Año
                ORDER BY sr.FechaServicio DESC
                OFFSET @Salto ROWS FETCH NEXT @TamañoPagina ROWS ONLY";

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@Texto", textoBusqueda ?? "");
                comando.Parameters.AddWithValue("@Mes", numeroMes);
                comando.Parameters.AddWithValue("@Año", año);
                comando.Parameters.AddWithValue("@Salto", (pagina - 1) * tamañoPagina);
                comando.Parameters.AddWithValue("@TamañoPagina", tamañoPagina);

                using (SqlDataReader dr = await comando.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        totalRegistros = Convert.ToInt32(dr["TotalRegistros"]);
                        lista.Add(new ServicioRealizadoListado
                        {
                            IdServicioRealizado = Convert.ToInt32(dr["IdServicioRealizado"]),
                            Nombre = dr["Nombres"].ToString(),
                            Apellido = dr["Apellidos"].ToString(),
                            Cedula = dr["Cedula"].ToString(),
                            Servicio = dr["Servicio"].ToString(),
                            Monto = Convert.ToDecimal(dr["MontoDolares"]),
                            TotalBs = Convert.ToDecimal(dr["MontoBolivares"]),
                            Fecha = Convert.ToDateTime(dr["FechaServicio"]),
                            Estado = dr["Estado"].ToString()
                        });
                    }
                }
            }
            return (lista, totalRegistros);
        }

        public async Task<List<ServicioRealizadoListado>> ObtenerServiciosRealizadosPorRangoAsync(DateTime desde, DateTime hasta)
        {
            var lista = new List<ServicioRealizadoListado>();

            const string query = @"
        SELECT
            sr.IdServicioRealizado,
            c.Nombres, c.Apellidos, c.Cedula,
            s.Nombre AS Servicio,
            sr.MontoDolares,
            sr.MontoBolivares,
            sr.FechaServicio,
            CASE
                WHEN sr.DarCredito = 0 THEN 'Pagado'
                WHEN cr.Estado = 'Pagado' THEN 'Pagado'
                WHEN cr.FechaLimite IS NOT NULL
                     AND cr.FechaLimite < CAST(GETDATE() AS DATE)
                     AND (cr.MontoTotal - ISNULL(pagado.TotalPagado, 0)) > 0 THEN 'Vencida'
                WHEN ISNULL(pagado.TotalPagado, 0) > 0
                     AND (cr.MontoTotal - ISNULL(pagado.TotalPagado, 0)) > 0 THEN 'Parcial'
                ELSE 'Debe'
            END AS Estado
        FROM ServiciosRealizados sr
        INNER JOIN Clientes c ON c.id_cliente = sr.IdCliente
        INNER JOIN Servicios s ON s.IdServicio = sr.IdServicio
        LEFT JOIN Creditos cr ON cr.IdCredito = sr.IdCredito
        OUTER APPLY (
            SELECT SUM(p.Monto) AS TotalPagado FROM Pagos p WHERE p.IdCredito = cr.IdCredito
        ) pagado
        WHERE sr.FechaServicio BETWEEN @Desde AND @Hasta
        ORDER BY sr.FechaServicio DESC";

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@Desde", desde);
                comando.Parameters.AddWithValue("@Hasta", hasta);

                using (SqlDataReader dr = await comando.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        lista.Add(new ServicioRealizadoListado
                        {
                            IdServicioRealizado = Convert.ToInt32(dr["IdServicioRealizado"]),
                            Nombre = dr["Nombres"].ToString(),
                            Apellido = dr["Apellidos"].ToString(),
                            Cedula = dr["Cedula"].ToString(),
                            Servicio = dr["Servicio"].ToString(),
                            Monto = Convert.ToDecimal(dr["MontoDolares"]),
                            TotalBs = Convert.ToDecimal(dr["MontoBolivares"]),
                            Fecha = Convert.ToDateTime(dr["FechaServicio"]),
                            Estado = dr["Estado"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        private int ObtenerNumeroMes(string nombreMes)
        {
            string[] meses = { "enero","febrero","marzo","abril","mayo","junio",
                                "julio","agosto","septiembre","octubre","noviembre","diciembre" };
            if (string.IsNullOrWhiteSpace(nombreMes)) return 0;
            int index = Array.FindIndex(meses, m => m.Equals(nombreMes, StringComparison.OrdinalIgnoreCase));
            return index >= 0 ? index + 1 : 0;
        }

        #endregion

        private static void Log(string origen, Exception ex) =>
            System.Diagnostics.Debug.WriteLine($"[D_Servicios.{origen}] {ex.Message}");
    }
}   