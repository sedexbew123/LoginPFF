using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Inventario
    {
        private readonly D_ConexionBD conexion = new D_ConexionBD();

        public async Task<bool> RegistrarProducto(Productos producto, RespuestaBD respuesta)
        {
            const string query =
                "INSERT INTO Productos (Codigo, Nombre, IdCategoria, Precio, StockActual, Estado) " +
                "VALUES (@Codigo, @Nombre, @IdCategoria, @Precio, @StockActual, @Estado)";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Codigo", producto.Codigo);
                        comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                        comando.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                        comando.Parameters.AddWithValue("@Precio", producto.Precio);
                        comando.Parameters.AddWithValue("@StockActual", producto.StockActual);
                        comando.Parameters.AddWithValue("@Estado", producto.Estado);
                        return await comando.ExecuteNonQueryAsync() > 0;
                    }
                }       
            }
            catch (SqlException ex)
            {
                respuesta.Mensaje = ex.Number == 2627
                    ? "El código de producto ya existe."
                    : "Error en la base de datos: " + ex.Message;
                return false;
            }
        }

        public async Task<bool> ActualizarProducto(Productos producto, RespuestaBD respuesta)
        {
            const string query = @"UPDATE Productos SET Nombre = @Nombre, IdCategoria = @IdCategoria,
                                  Precio = @Precio, StockActual = @StockActual, Estado = @Estado WHERE Codigo = @Codigo";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Codigo", producto.Codigo);
                        comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                        comando.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                        comando.Parameters.AddWithValue("@Precio", producto.Precio);
                        comando.Parameters.AddWithValue("@StockActual", producto.StockActual);
                        comando.Parameters.AddWithValue("@Estado", producto.Estado);

                        return await comando.ExecuteNonQueryAsync() > 0;
                    }
                }
                
            }
            catch (SqlException ex)
            {
                respuesta.Mensaje = "Error SQL: " + ex.Message;
                return false;
            }
        }


        public async Task<bool> EliminarProducto(string codigo, RespuestaBD respuesta)
        {
            const string queryVerificarCredito = @"SELECT COUNT(*) FROM DetalleCredito WHERE CodigoProducto = @Codigo";

            const string queryVerificarInventario = @"SELECT 
            (SELECT COUNT(*) FROM CargosInventario WHERE CodigoProducto = @Codigo) +
            (SELECT COUNT(*) FROM DescargosInventario WHERE CodigoProducto = @Codigo)
        AS TotalMovimientos";

            const string queryBorrarCargos = @"DELETE FROM CargosInventario WHERE CodigoProducto = @Codigo";

            const string queryBorrarDescargos = @"DELETE FROM DescargosInventario WHERE CodigoProducto = @Codigo";

            const string queryBajaLogica = @"UPDATE Productos SET Estado = 'Inactivo' WHERE Codigo = @Codigo";

            const string queryEliminarFisico = @"DELETE FROM Productos WHERE Codigo = @Codigo";

            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlTransaction tx = conexion.BeginTransaction())
                    {
                        try
                        {
                            int enCredito;
                            using (SqlCommand comando = new SqlCommand(queryVerificarCredito, conexion, tx))
                            {
                                comando.Parameters.AddWithValue("@Codigo", codigo);
                                enCredito = Convert.ToInt32(await comando.ExecuteScalarAsync());
                            }

                            if (enCredito > 0)
                            {
                                using (SqlCommand comando = new SqlCommand(queryBajaLogica, conexion, tx))
                                {
                                    comando.Parameters.AddWithValue("@Codigo", codigo);
                                    await comando.ExecuteNonQueryAsync();
                                }
                                tx.Commit();
                                respuesta.Mensaje = "BAJA_LOGICA";
                                return true;
                            }

                            int enInventario;
                            using (SqlCommand comando = new SqlCommand(queryVerificarInventario, conexion, tx))
                            {
                                comando.Parameters.AddWithValue("@Codigo", codigo);
                                enInventario = Convert.ToInt32(await comando.ExecuteScalarAsync());
                            }

                            if (enInventario > 0)
                            {
                                using (SqlCommand comando = new SqlCommand(queryBorrarDescargos, conexion, tx))
                                {
                                    comando.Parameters.AddWithValue("@Codigo", codigo);
                                    await comando.ExecuteNonQueryAsync();
                                }
                                using (SqlCommand cmd = new SqlCommand(queryBorrarCargos, conexion, tx))
                                {
                                    cmd.Parameters.AddWithValue("@Codigo", codigo);
                                    await cmd.ExecuteNonQueryAsync();
                                }
                            }

                            using (SqlCommand comando = new SqlCommand(queryEliminarFisico, conexion, tx))
                            {
                                comando.Parameters.AddWithValue("@Codigo", codigo);
                                int filas = await comando.ExecuteNonQueryAsync();

                                if (filas == 0)
                                {
                                    tx.Rollback();
                                    respuesta.Mensaje = "No se encontró el producto.";
                                    return false;
                                }
                            }

                            tx.Commit();
                            return true;
                        }
                        catch
                        {
                            tx.Rollback();
                            throw;
                        }
                    }
                }     
            }
            catch (SqlException ex)
            {
                respuesta.Mensaje = "Error al eliminar: " + ex.Message;
                return false;
            }
        }

        public async Task<List<Productos>> ObtenerProductos()
        {
            var lista = new List<Productos>();

            const string query = @"SELECT p.Codigo, p.Nombre, p.IdCategoria, 
               c.NombreCategoria AS Categoria, p.Precio, p.StockActual, p.Estado FROM Productos p 
               INNER JOIN Categorias c ON p.IdCategoria = c.IdCategoria";

            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader dr = await comando.ExecuteReaderAsync())
                        {
                            while (dr.Read())
                                lista.Add(new Productos
                                {
                                    Codigo = dr["Codigo"].ToString(),
                                    Nombre = dr["Nombre"].ToString(),
                                    IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                    NombreCategoria = dr["Categoria"].ToString(),
                                    Precio = Convert.ToDecimal(dr["Precio"]),
                                    StockActual = Convert.ToInt32(dr["StockActual"]),
                                    Estado = dr["Estado"].ToString()
                                });
                        }
                    }
                }   
            }
            catch 
            {

            }
            return lista;
        }

        public async Task<Productos> ObtenerProductoPorCodigo(string codigo)
        {
            const string query = @"SELECT p.Codigo, p.Nombre, p.IdCategoria, c.NombreCategoria AS Categoria, p.Precio, 
                                   p.StockActual, p.Estado FROM Productos p INNER JOIN Categorias c ON 
                                   p.IdCategoria = c.IdCategoria WHERE p.Codigo = @Codigo";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Codigo", codigo);
                        using (SqlDataReader dr = await comando.ExecuteReaderAsync())
                            if (dr.Read()) return MapearProducto(dr);
                    }
                }
            }
            catch
            {

            }
            return null;
        }

        public async Task<bool> RegistrarCargo(CargoInventario cargo, RespuestaBD respuesta)
        {

            const string insertCargo ="INSERT INTO CargosInventario (CodigoProducto, Cantidad, Fecha) " +
                                      "VALUES (@Codigo, @Cantidad, @Fecha)";

            const string updateStock ="UPDATE Productos SET StockActual = StockActual + @Cantidad WHERE Codigo = @Codigo";

            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    SqlTransaction trx = conexion.BeginTransaction();
                    try
                    {
                        using (SqlCommand comando1 = new SqlCommand(insertCargo, conexion, trx))
                        {
                            comando1.Parameters.AddWithValue("@Codigo", cargo.CodigoProducto);
                            comando1.Parameters.AddWithValue("@Cantidad", cargo.Cantidad);
                            comando1.Parameters.AddWithValue("@Fecha", cargo.Fecha);
                            await comando1.ExecuteNonQueryAsync();
                        }
                        using (SqlCommand comando2 = new SqlCommand(updateStock, conexion, trx))
                        {
                            comando2.Parameters.AddWithValue("@Cantidad", cargo.Cantidad);
                            comando2.Parameters.AddWithValue("@Codigo", cargo.CodigoProducto);
                            await comando2.ExecuteNonQueryAsync();
                        }
                        trx.Commit();
                        return true;
                    }
                    catch
                    {
                        trx.Rollback();
                        throw;
                    }
                }
            }
            catch (SqlException ex)
            {
                respuesta.Mensaje = "Error al registrar cargo: " + ex.Message;
                return false;
            }
        }

        public async Task<List<CargoInventario>> ObtenerCargos()
        {
            var lista = new List<CargoInventario>();

            const string query = @"SELECT c.Id, c.CodigoProducto, p.Nombre AS NombreProducto, c.Cantidad, c.Fecha
                                   FROM CargosInventario c INNER JOIN Productos p ON c.CodigoProducto = p.Codigo
                                   ORDER BY c.Fecha DESC";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader dr = await comando.ExecuteReaderAsync())
                            while (dr.Read())
                                lista.Add(new CargoInventario
                                {
                                    Id = Convert.ToInt32(dr["Id"]),
                                    CodigoProducto = dr["CodigoProducto"].ToString(),
                                    NombreProducto = dr["NombreProducto"].ToString(),
                                    Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                    Fecha = Convert.ToDateTime(dr["Fecha"])
                                });

                    }
                }
            }
            catch
            {

            }
            return lista;
        }

        public async Task<bool> RegistrarDescargo(DescargoInventario descargo, RespuestaBD respuesta)
        {
            const string checkStock ="SELECT StockActual FROM Productos WHERE Codigo = @Codigo";

            const string insertDescargo ="INSERT INTO DescargosInventario (CodigoProducto, Cantidad, IdMotivo, Fecha) " +
                "VALUES (@Codigo, @Cantidad, @IdMotivo, @Fecha)";

            const string updateStock ="UPDATE Productos SET StockActual = StockActual - @Cantidad WHERE Codigo = @Codigo";

            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    int stockActual = 0;
                    using (SqlCommand comandoCheck = new SqlCommand(checkStock, conexion))
                    {
                        comandoCheck.Parameters.AddWithValue("@Codigo", descargo.CodigoProducto);
                        object resultado = await comandoCheck.ExecuteScalarAsync();
                        if (resultado == null || resultado == DBNull.Value)
                        {
                            respuesta.Mensaje = "Producto no encontrado.";
                            return false;
                        }
                        stockActual = Convert.ToInt32(resultado);
                    }

                    if (stockActual < descargo.Cantidad)
                    {
                        respuesta.Mensaje = $"Stock insuficiente. Disponible: {stockActual} unidades.";
                        return false;
                    }

                    SqlTransaction trx = conexion.BeginTransaction();
                    try
                    {
                        using (SqlCommand comando1 = new SqlCommand(insertDescargo, conexion, trx))
                        {
                            comando1.Parameters.AddWithValue("@Codigo", descargo.CodigoProducto);
                            comando1.Parameters.AddWithValue("@Cantidad", descargo.Cantidad);
                            comando1.Parameters.AddWithValue("@IdMotivo", descargo.IdMotivo);
                            comando1.Parameters.AddWithValue("@Fecha", descargo.Fecha);
                            await comando1.ExecuteNonQueryAsync();
                        }
                        using (SqlCommand comando2 = new SqlCommand(updateStock, conexion, trx))
                        {
                            comando2.Parameters.AddWithValue("@Cantidad", descargo.Cantidad);
                            comando2.Parameters.AddWithValue("@Codigo", descargo.CodigoProducto);
                            await comando2.ExecuteNonQueryAsync();
                        }
                        trx.Commit();
                        return true;
                    }
                    catch
                    {
                        trx.Rollback();
                        throw;
                    }
                }
            }
            catch (SqlException ex)
            {
                respuesta.Mensaje = "Error al registrar descargo: " + ex.Message;
                return false;
            }
        }

        public async Task<List<DescargoInventario>> ObtenerDescargos()
        {
            var lista = new List<DescargoInventario>();
            const string query = @"SELECT d.Id, d.CodigoProducto, d.NombreProducto, d.Cantidad, d.IdMotivo,  
                                   m.Descripcion AS Motivo, d.Fecha, c.NombreCategoria FROM DescargosInventario d
                                   INNER JOIN MotivosDescargo m ON d.IdMotivo = m.IdMotivo
                                   INNER JOIN Productos p ON d.CodigoProducto = p.Codigo
                                   INNER JOIN Categorias c ON p.IdCategoria = c.IdCategoria
                                   ORDER BY d.Fecha DESC";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader dr = await comando.ExecuteReaderAsync())
                            while (dr.Read())
                                lista.Add(new DescargoInventario
                                {
                                    Id = Convert.ToInt32(dr["Id"]),
                                    CodigoProducto = dr["CodigoProducto"].ToString(),
                                    NombreProducto = dr["NombreProducto"].ToString(),
                                    Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                    IdMotivo = Convert.ToInt32(dr["IdMotivo"]),
                                    Motivo = dr["Motivo"].ToString(),
                                    NombreCategoria = dr["NombreCategoria"].ToString(),
                                    Fecha = Convert.ToDateTime(dr["Fecha"])
                                });
                    }
                }
            }
            catch 
            {

            }
            return lista;
        }

        private Productos MapearProducto(SqlDataReader dr)
        {
            try
            {
                return new Productos
                {
                    Codigo = dr["Codigo"].ToString(),
                    Nombre = dr["Nombre"].ToString(),
                    NombreCategoria = dr["Categoria"].ToString(),
                    Precio = Convert.ToDecimal(dr["Precio"]),
                    StockActual = Convert.ToInt32(dr["StockActual"]),
                    Estado = dr["Estado"].ToString()
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mapear el producto desde la base de datos: " + ex.Message, ex);
            }
        }

        public async Task<DataTable> ObtenerCategoriasActivas()
        {
            var dt = new DataTable();
            const string query = "SELECT IdCategoria, NombreCategoria FROM Categorias WHERE Estado = 1";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader dr = await comando.ExecuteReaderAsync())
                        {
                            dt.Load(dr);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return dt;
        }

        public async Task<bool> RegistrarCategoria(string nombreCategoria, string descripcion, RespuestaBD respuesta)
        {
            const string query = @"INSERT INTO Categorias (NombreCategoria, Descripcion, Estado) 
                           VALUES (@Nombre, @Descripcion, 1)";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", nombreCategoria);
                        comando.Parameters.AddWithValue("@Descripcion", descripcion ?? "");
                        return await comando.ExecuteNonQueryAsync() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                respuesta.Mensaje = ex.Number == 2627
                    ? "Ya existe una categoría con ese nombre."
                    : "Error al guardar categoría: " + ex.Message;
                return false;
            }
        }

        public async Task<DataTable> ObtenerCategoriasListado()
        {
            var dt = new DataTable();
            const string query = @"SELECT NombreCategoria AS Nombre, ISNULL(Descripcion, '') AS Descripcion
                                   FROM Categorias WHERE Estado = 1 ORDER BY NombreCategoria";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader dr = await comando.ExecuteReaderAsync())
                        {
                            dt.Load(dr);
                        }    
                    }
                }
            }
            catch 
            { 

            }
            return dt;
        }

        public async Task<bool> ActualizarCategoria(string nombreActual, string nombreNuevo,
                                            string descripcion, RespuestaBD respuesta)
        {
            const string query = @"UPDATE Categorias SET NombreCategoria = @NombreNuevo, Descripcion = @Descripcion 
                                   WHERE NombreCategoria = @NombreActual";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@NombreNuevo", nombreNuevo);
                        comando.Parameters.AddWithValue("@Descripcion", descripcion ?? "");
                        comando.Parameters.AddWithValue("@NombreActual", nombreActual);

                        int filas = await comando.ExecuteNonQueryAsync();
                        if (filas > 0) return true;

                        respuesta.Mensaje = "No se encontró la categoría a actualizar.";
                        return false;
                    }
                }
                
            }
            catch (SqlException ex)
            {
                respuesta.Mensaje = ex.Number == 2627
                    ? "Ya existe una categoría con ese nombre."
                    : "Error al actualizar categoría: " + ex.Message;
                return false;
            }
        }

        public async Task<bool> EliminarCategoria(string nombreCategoria, RespuestaBD respuesta)
        {
            const string query = "UPDATE Categorias SET Estado = 0 WHERE NombreCategoria = @Nombre";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", nombreCategoria);

                        int filas = await comando.ExecuteNonQueryAsync();
                        if (filas > 0) return true;

                        respuesta.Mensaje = "No se encontró la categoría.";
                        return false;
                    }
                }
                
            }
            catch (SqlException ex)
            {
                respuesta.Mensaje = "Error al eliminar categoría: " + ex.Message;
                return false;
            }
        }

        public async Task<bool> RegistrarMotivo(string descripcion, string detalles, RespuestaBD respuesta)
        {
            const string query = @"INSERT INTO MotivosDescargo (Descripcion, Detalles, Estado) 
                                   VALUES (@Descripcion, @Detalles, 1)";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Descripcion", descripcion);
                        comando.Parameters.AddWithValue("@Detalles", detalles ?? "");
                        return await comando.ExecuteNonQueryAsync() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                respuesta.Mensaje = "Error al guardar motivo: " + ex.Message;
                return false;
            }
        }

        public async Task<DataTable> ObtenerMotivosListado()
        {
            var dt = new DataTable();
            const string query = @"SELECT Descripcion AS Nombre, ISNULL(Detalles, '') AS Descripcion
                                   FROM MotivosDescargo WHERE Estado = 1 ORDER BY Descripcion";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader dr = await comando.ExecuteReaderAsync())
                        {
                            dt.Load(dr);
                        }      
                    }  
                } 
            }
            catch 
            { 

            }
            return dt;
        }

        public async Task<bool> ActualizarMotivo(string descripcionActual, string descripcionNueva,
                                         string detalles, RespuestaBD respuesta)
        {
            const string query = @"UPDATE MotivosDescargo SET Descripcion = @DescripcionNueva, Detalles = @Detalles 
                                   WHERE Descripcion = @DescripcionActual";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@DescripcionNueva", descripcionNueva);
                        comando.Parameters.AddWithValue("@Detalles", detalles ?? "");
                        comando.Parameters.AddWithValue("@DescripcionActual", descripcionActual);

                        int filas = await comando.ExecuteNonQueryAsync();
                        if (filas > 0) return true;

                        respuesta.Mensaje = "No se encontró el motivo a actualizar.";
                        return false;
                    }
                } 
            }
            catch (SqlException ex)
            {
                respuesta.Mensaje = "Error al actualizar motivo: " + ex.Message;
                return false;
            }
        }

        public async Task<bool> EliminarMotivo(string descripcion, RespuestaBD respuesta)
        {
            const string query = "UPDATE MotivosDescargo SET Estado = 0 WHERE Descripcion = @Descripcion";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Descripcion", descripcion);

                        int filas = await comando.ExecuteNonQueryAsync();
                        if (filas > 0) return true;

                        respuesta.Mensaje = "No se encontró el motivo.";
                        return false;
                    }
                }
                
            }
            catch (SqlException ex)
            {
                respuesta.Mensaje = "Error al eliminar motivo: " + ex.Message;
                return false;
            }
        }

        public async Task<List<MotivosDescargo>> ObtenerMotivos()
        {
            var lista = new List<MotivosDescargo>();
            const string query = "SELECT IdMotivo, Descripcion FROM MotivosDescargo WHERE Estado = 1";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader dr = await comando.ExecuteReaderAsync())
                        {
                            while (dr.Read())
                                lista.Add(new MotivosDescargo
                                {
                                    IdMotivo = Convert.ToInt32(dr["IdMotivo"]),
                                    Descripcion = dr["Descripcion"].ToString()
                                });
                        }
                            
                    }
                }
            }
            catch
            {

            }
            return lista;
        }

        public async Task<List<OperacionInventario>> ObtenerHistorialOperaciones()
        {
            var lista = new List<OperacionInventario>();
            const string query = @"SELECT c.Fecha, p.Nombre AS Producto, cat.NombreCategoria AS Categoria,
                                  'Cargo' AS Tipo, c.Cantidad, '' AS Motivo FROM CargosInventario c
                                   INNER JOIN Productos    p   ON c.CodigoProducto = p.Codigo
                                   INNER JOIN Categorias   cat ON p.IdCategoria    = cat.IdCategoria
                                   UNION ALL
                                   SELECT d.Fecha, p.Nombre AS Producto, cat.NombreCategoria AS Categoria,
                                   'Descargo' AS Tipo, d.Cantidad, m.Descripcion AS Motivo
                                   FROM DescargosInventario d INNER JOIN Productos p ON d.CodigoProducto = p.Codigo
                                   INNER JOIN Categorias cat ON p.IdCategoria = cat.IdCategoria
                                   INNER JOIN MotivosDescargo m ON d.IdMotivo = m.IdMotivo ORDER BY Fecha DESC";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader dr = await comando.ExecuteReaderAsync())
                        {
                            while (dr.Read())
                                lista.Add(new OperacionInventario
                                {
                                    Fecha = Convert.ToDateTime(dr["Fecha"]),
                                    Producto = dr["Producto"].ToString(),
                                    Categoria = dr["Categoria"].ToString(),
                                    Tipo = dr["Tipo"].ToString(),
                                    Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                    Motivo = dr["Motivo"].ToString()
                                });
                        }
                    }
                }
            }
            catch
            {

            }
            return lista;
        }

        public async Task<List<Productos>> ObtenerProductosPorCategoria(int idCategoria)
        {
            var lista = new List<Productos>();
            const string query = @"SELECT Codigo, Nombre, IdCategoria, Precio, StockActual, Estado
                                   FROM Productos WHERE IdCategoria = @IdCategoria AND Estado = 'Activo'";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdCategoria", idCategoria);
                        using (SqlDataReader dr = await comando.ExecuteReaderAsync())
                        {
                            while (dr.Read())
                                lista.Add(new Productos
                                {
                                    Codigo = dr["Codigo"].ToString(),
                                    Nombre = dr["Nombre"].ToString(),
                                    IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                    Precio = Convert.ToDecimal(dr["Precio"]),
                                    StockActual = Convert.ToInt32(dr["StockActual"]),
                                    Estado = dr["Estado"].ToString()
                                });
                        }
                    }
                }
            }
            catch
            {

            }
            return lista;
        }

        public async Task<List<Productos>> ObtenerProductosActivos()
        {
            var lista = new List<Productos>();
            const string query = @"SELECT Codigo, Nombre, IdCategoria, Precio, StockActual, Estado
                           FROM Productos WHERE Estado = 'Activo'";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader dr = await comando.ExecuteReaderAsync())
                        {
                            while (dr.Read())
                                lista.Add(new Productos
                                {
                                    Codigo = dr["Codigo"].ToString(),
                                    Nombre = dr["Nombre"].ToString(),
                                    IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                    Precio = Convert.ToDecimal(dr["Precio"]),
                                    StockActual = Convert.ToInt32(dr["StockActual"]),
                                    Estado = dr["Estado"].ToString()
                                });
                        }
                    }  
                } 
            }
            catch 
            { 

            }
            return lista;
        }

        public async Task<List<Productos>> ObtenerProductosSinInactivos()
        {
            var lista = new List<Productos>();
            const string query = @"SELECT p.Codigo, p.Nombre, p.IdCategoria, c.NombreCategoria AS Categoria, 
                                   p.Precio, p.StockActual, p.Estado FROM Productos p 
                                   INNER JOIN Categorias c ON p.IdCategoria = c.IdCategoria
                                   WHERE  p.Estado <> 'Inactivo'";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader dr = await comando.ExecuteReaderAsync())
                        {
                            while (dr.Read())
                                lista.Add(new Productos
                                {
                                    Codigo = dr["Codigo"].ToString(),
                                    Nombre = dr["Nombre"].ToString(),
                                    IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                    NombreCategoria = dr["Categoria"].ToString(),
                                    Precio = Convert.ToDecimal(dr["Precio"]),
                                    StockActual = Convert.ToInt32(dr["StockActual"]),
                                    Estado = dr["Estado"].ToString()
                                });
                        }
                    }
                }  
            }
            catch 
            { 

            }
            return lista;
        }
    }
}