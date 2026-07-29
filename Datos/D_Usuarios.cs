using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Usuarios
    {
        private readonly D_ConexionBD conexion = new D_ConexionBD();

        public async Task<Usuarios> IniciarSesion(string usuario, string contraseña)
        {
            const string query = @"SELECT u.id, u.usuario, u.idRol, u.permitirIngreso, p.cedula,
                       p.nombre, p.apellido, p.correo, p.direccion, p.telefono, r.nombreRol
                       FROM Usuarios u INNER JOIN Roles r ON r.idRol = u.idRol
                       INNER JOIN PerfilUsuario p ON p.idUsuario = u.id
                       WHERE u.usuario = @Usuario AND u.contraseña = @Contraseña;";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.Add("@Usuario", SqlDbType.NVarChar, 50).Value = usuario;
                        comando.Parameters.Add("@Contraseña", SqlDbType.NVarChar, 150).Value = contraseña;

                        using (SqlDataReader reader = await comando.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new Usuarios
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                                    User = reader.GetString(reader.GetOrdinal("usuario")),
                                    IdRol = reader.GetInt32(reader.GetOrdinal("idRol")),
                                    NombreRol = reader.GetString(reader.GetOrdinal("nombreRol")),
                                    PermitirIngreso = reader.GetBoolean(reader.GetOrdinal("permitirIngreso")),
                                    Cedula = reader.GetString(reader.GetOrdinal("cedula")),
                                    Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                    Apellido = reader.GetString(reader.GetOrdinal("apellido")),
                                    Correo = reader.GetString(reader.GetOrdinal("correo")),
                                    Direccion = reader.GetString(reader.GetOrdinal("direccion")),
                                    Telefono = reader.GetString(reader.GetOrdinal("telefono"))
                                };
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> VerificarContraseña(string hashActual, int idUsuario)
        {
            const string query ="SELECT COUNT(*) FROM Usuarios WHERE contraseña = @contraseña AND id = @id";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@contraseña", hashActual);
                        comando.Parameters.AddWithValue("@id", idUsuario);
                        int count = Convert.ToInt32(await comando.ExecuteScalarAsync());
                        return count > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> ActualizarContraseña(string hashNuevo, int idUsuario)
        {
            const string query = "UPDATE Usuarios SET contraseña = @contraseña WHERE id = @id";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@contraseña", hashNuevo);
                        comando.Parameters.AddWithValue("@id", idUsuario);
                        int filas = await comando.ExecuteNonQueryAsync();
                        return filas > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Usuarios> ObtenerUsuarioUnico()
        {
            const string query = "SELECT nombre, apellido, cedula, correo, direccion, telefono FROM PerfilUsuario WHERE idUsuario = 1";
            Usuarios usuario = null;

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = await comando.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            usuario = new Usuarios
                            {
                                Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                Apellido = reader.GetString(reader.GetOrdinal("apellido")),
                                Cedula = reader.GetString(reader.GetOrdinal("cedula")),
                                Correo = reader.GetString(reader.GetOrdinal("correo")),
                                Direccion = reader.GetString(reader.GetOrdinal("direccion")),
                                Telefono = reader.GetString(reader.GetOrdinal("telefono"))
                            };
                        }
                    }
                }
            }
            return usuario;
        }

        public async Task<int?> ObtenerIdPorEmail(string correo)
        {
            const string query = @"SELECT u.id FROM Usuarios u INNER JOIN PerfilUsuario p ON p.idUsuario = u.id
                                   WHERE p.correo = @Correo;";

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@Correo", SqlDbType.NVarChar, 250).Value = correo;
                    var resultado = await comando.ExecuteScalarAsync();
                    return resultado == null ? null : (int?)Convert.ToInt32(resultado);
                }
            }
        }

        public async Task<int> InsertarTokenRecuperacion(int idUsuario, string tokenHash, DateTime fechaExp)
        {
            const string query = "INSERT INTO RecuperacionClave(idUsuario,tokenHash,fechaExp) VALUES (@idUsuario, @tokenHash, @fechaExp);";

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                    comando.Parameters.Add("@tokenHash", SqlDbType.Char, 64).Value = tokenHash;
                    comando.Parameters.Add("@fechaExp", SqlDbType.DateTime2).Value = fechaExp;

                    return await comando.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int?> ValidarToken(string token)
        {
            const string query = "SELECT idUsuario FROM RecuperacionClave WHERE tokenHash = @tokenHash AND fechaExp > GETDATE() AND usado = 0;";

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@tokenHash", SqlDbType.Char, 64).Value = token;

                    var resultado = await comando.ExecuteScalarAsync();
                    return resultado == null ? null : (int?)Convert.ToInt32(resultado);
                }
            }
        }

        public async Task<int> RestablecerContraseña(int id, string nuevaContraseña, string tokenUsado)
        {
            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            {
                using (SqlTransaction transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        string query = "UPDATE RecuperacionClave SET usado = 1 WHERE tokenHash = @TokenHash;";
                        using (SqlCommand comandoToken = new SqlCommand(query, conexion, transaction))
                        {
                            comandoToken.Parameters.Add("@TokenHash", SqlDbType.Char, 64).Value = tokenUsado;
                            await comandoToken.ExecuteNonQueryAsync();
                        }

                        string queryUsuario = "UPDATE usuarios SET contraseña = @NuevaContraseña WHERE id = @Id;";
                        int filasAfectadas = 0;

                        using (SqlCommand comandoUsuario = new SqlCommand(queryUsuario, conexion, transaction))
                        {
                            comandoUsuario.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                            comandoUsuario.Parameters.Add("@NuevaContraseña", SqlDbType.NVarChar, 250).Value = nuevaContraseña;

                            filasAfectadas = await comandoUsuario.ExecuteNonQueryAsync();
                        }

                        transaction.Commit();

                        return filasAfectadas;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public async Task<int> RestablecerUsuario(int id, string nuevoUsuario, string tokenUsado)
        {

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            {
                using (SqlTransaction transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        string queryToken = "UPDATE RecuperacionClave SET usado = 1 WHERE tokenHash = @TokenHash;";
                        using (SqlCommand cmdToken = new SqlCommand(queryToken, conexion, transaction))
                        {
                            cmdToken.Parameters.Add("@TokenHash", SqlDbType.Char, 64).Value = tokenUsado;
                            await cmdToken.ExecuteNonQueryAsync();
                        }

                        string queryUsuario = "UPDATE Usuarios SET usuario = @NuevoUsuario WHERE id = @Id;";
                        int filas = 0;
                        using (SqlCommand cmdUsuario = new SqlCommand(queryUsuario, conexion, transaction))
                        {
                            cmdUsuario.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                            cmdUsuario.Parameters.Add("@NuevoUsuario", SqlDbType.NVarChar, 50).Value = nuevoUsuario;
                            filas = await cmdUsuario.ExecuteNonQueryAsync();
                        }

                        transaction.Commit();
                        return filas;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public async Task<bool> ActualizarUsuario(Usuarios usuario)
        {
            const string query = @"UPDATE PerfilUsuario SET nombre = @nombre, apellido = @apellido,
                                   cedula = @cedula, correo = @correo, direccion = @direccion,
                                   telefono = @telefono WHERE idUsuario = 1";
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.Add("@nombre", SqlDbType.NVarChar, 100).Value = usuario.Nombre;
                        comando.Parameters.Add("@apellido", SqlDbType.NVarChar, 100).Value = usuario.Apellido;
                        comando.Parameters.Add("@cedula", SqlDbType.NVarChar, 20).Value = usuario.Cedula;
                        comando.Parameters.Add("@correo", SqlDbType.NVarChar, 250).Value = usuario.Correo;
                        comando.Parameters.Add("@direccion", SqlDbType.NVarChar, 250).Value = usuario.Direccion;
                        comando.Parameters.Add("@telefono", SqlDbType.NVarChar, 20).Value = usuario.Telefono;

                        int filas = await comando.ExecuteNonQueryAsync();
                        return filas > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}