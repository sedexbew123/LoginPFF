using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Clientes
    {
        private readonly D_ConexionBD conexion = new D_ConexionBD();

        public async Task<bool> RegistrarCliente(Clientes cliente, RespuestaBD respuesta)
        {
            const string query = "INSERT INTO Clientes (Cedula, Nombres, Apellidos, Telefono, Correo, Direccion, Foto) " +
                                 "VALUES (@Cedula, @Nombres, @Apellidos, @Telefono, @Correo, @Direccion, @Foto)";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                        comando.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                        comando.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                        comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                        comando.Parameters.AddWithValue("@Correo", cliente.Correo);
                        comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                        comando.Parameters.Add("@Foto", System.Data.SqlDbType.VarBinary, -1).Value =
                            (object)cliente.Foto ?? DBNull.Value;

                        return await comando.ExecuteNonQueryAsync() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    respuesta.Mensaje = "El número de cédula ya se encuentra registrado para otro cliente.";
                }
                else
                {
                    respuesta.Mensaje = "Error en la base de datos: " + ex.Message;
                }
                return false;
            }
        }

        public async Task<Clientes> ObtenerClientePorCedula(string cedula)
        {
            const string query = "SELECT Cedula, Nombres, Apellidos, Telefono, Correo, Direccion, Foto " +
                                 "FROM Clientes WHERE Cedula = @Cedula";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.Add("@Cedula", System.Data.SqlDbType.NVarChar).Value = cedula;

                        using (SqlDataReader dr = await comando.ExecuteReaderAsync())
                        {
                            if (await dr.ReadAsync())
                            {
                                return new Clientes
                                {
                                    Cedula = dr["Cedula"].ToString(),
                                    Nombres = dr["Nombres"].ToString(),
                                    Apellidos = dr["Apellidos"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    Correo = dr["Correo"].ToString(),
                                    Direccion = dr["Direccion"].ToString(),
                                    Foto = dr["Foto"] == DBNull.Value ? null : (byte[])dr["Foto"]
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el cliente: " + ex.Message);
            }
            return null;
        }

        public async Task<bool> ActualizarCliente(Clientes cliente, RespuestaBD respuesta)
        {
            const string query = @"UPDATE Clientes SET Nombres = @Nombres, Apellidos = @Apellidos, Telefono = @Telefono, 
                       Correo = @Correo, Direccion = @Direccion, Foto = @Foto WHERE Cedula = @Cedula";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                        comando.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                        comando.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                        comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                        comando.Parameters.AddWithValue("@Correo", cliente.Correo);
                        comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                        comando.Parameters.Add("@Foto", System.Data.SqlDbType.VarBinary, -1).Value =
                            (object)cliente.Foto ?? DBNull.Value;

                        int filas = await comando.ExecuteNonQueryAsync();
                        if (filas > 0) return true;

                        respuesta.Mensaje = "No se encontró el cliente.";
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                respuesta.Mensaje = "Error SQL: " + ex.Message;
                return false;
            }
        }

        public async Task<bool> EliminarCliente(string cedula, RespuestaBD respuesta)
        {
            const string query = "DELETE FROM Clientes WHERE Cedula = @Cedula";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Cedula", cedula);
                        int filas = await comando.ExecuteNonQueryAsync();
                        return filas > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    respuesta.Mensaje = "No se puede eliminar: El cliente tiene historial de créditos o ventas.";
                else
                    respuesta.Mensaje = "Error al eliminar: " + ex.Message;
                return false;
            }
        }

        public async Task<int> ObtenerTotalClientes(string filtro = " ")
        {
            string query = "SELECT COUNT(*) FROM Clientes ";
            try
            {
                if (!string.IsNullOrWhiteSpace(filtro) && filtro.Trim() != "")
                {
                    query += " WHERE Cedula LIKE @Filtro OR Nombres LIKE @Filtro OR Apellidos LIKE @Filtro";
                }

                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        if (!string.IsNullOrWhiteSpace(filtro))
                        {

                            comando.Parameters.Add("@Filtro", System.Data.SqlDbType.NVarChar, 255).Value = "%" + filtro + "%";
                        }

                        var ejecucion = await comando.ExecuteScalarAsync();
                        return Convert.ToInt32(ejecucion);
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<List<Clientes>> ObtenerClientes(int offset, int limite, string filtro = " ")
        {
            List<Clientes> lista = new List<Clientes>();

            string query = "SELECT Cedula, Nombres, Apellidos, Telefono, Correo, Direccion FROM Clientes";

            if (!string.IsNullOrWhiteSpace(filtro) && filtro.Trim() != "")
            {
                query += " WHERE Cedula LIKE @Filtro OR Nombres LIKE @Filtro OR Apellidos LIKE @Filtro ";
            }
            query += " ORDER BY Cedula OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY;";

            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        if (!string.IsNullOrWhiteSpace(filtro) && filtro.Trim() != "")
                        {
                            comando.Parameters.Add("@Filtro", System.Data.SqlDbType.NVarChar).Value = "%" + filtro.Trim() + "%";
                        }
                        comando.Parameters.Add("@Offset", System.Data.SqlDbType.Int).Value = offset;
                        comando.Parameters.Add("@Limit", System.Data.SqlDbType.Int).Value = limite;

                        using (SqlDataReader dr = await comando.ExecuteReaderAsync())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new Clientes
                                {
                                    Cedula = dr["Cedula"].ToString(),
                                    Nombres = dr["Nombres"].ToString(),
                                    Apellidos = dr["Apellidos"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    Correo = dr["Correo"].ToString(),
                                    Direccion = dr["Direccion"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la consulta de datos: " + ex.Message);
            }
            return lista;
        }
    }
}