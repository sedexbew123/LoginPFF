using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Empleados
    {
        private readonly D_ConexionBD conexion = new D_ConexionBD();

        private Usuarios MapearUsuario(SqlDataReader reader)
        {
            return new Usuarios
            {
                Id = reader.GetInt32(reader.GetOrdinal("id")),
                User = reader.GetString(reader.GetOrdinal("usuario")),
                Cedula = reader.GetString(reader.GetOrdinal("cedula")),
                Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                Apellido = reader.GetString(reader.GetOrdinal("apellido")),
                Correo = reader.GetString(reader.GetOrdinal("correo")),
                Direccion = reader.GetString(reader.GetOrdinal("direccion")),
                Telefono = reader.GetString(reader.GetOrdinal("telefono")),
                IdRol = reader.GetInt32(reader.GetOrdinal("idRol")),
                NombreRol = reader.GetString(reader.GetOrdinal("nombreRol")),
                PermitirIngreso = reader.GetBoolean(reader.GetOrdinal("permitirIngreso")),
                Foto = reader.IsDBNull(reader.GetOrdinal("foto"))
                                      ? null
                                      : (byte[])reader["foto"]
            };
        }

        public async Task<(List<Usuarios> Datos, int TotalRegistros)> ListarEmpleados(
            string filtro, int pagina, int registrosPorPagina)
        {
            const string query = @"SELECT  u.id, u.usuario, u.idRol, u.permitirIngreso,
                        p.cedula, p.nombre, p.apellido, p.correo, p.direccion, p.telefono, p.foto,
                        r.nombreRol, COUNT(*) OVER() AS TotalRegistros FROM Usuarios u
                        INNER JOIN PerfilUsuario p ON p.idUsuario = u.id INNER JOIN Roles r ON r.idRol = u.idRol
                        WHERE u.idRol = @IdRolEmpleado AND (@Filtro IS NULL OR @Filtro = ''
                        OR p.nombre   LIKE '%' + @Filtro + '%' OR p.apellido LIKE '%' + @Filtro + '%'
                        OR p.cedula   LIKE '%' + @Filtro + '%') ORDER BY p.apellido, p.nombre
                        OFFSET @Salto ROWS FETCH NEXT @Cantidad ROWS ONLY;";

            var lista = new List<Usuarios>();
            int total = 0;

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@IdRolEmpleado", SqlDbType.Int).Value = Rol.EMPLEADO;
                    comando.Parameters.Add("@Filtro", SqlDbType.NVarChar, 150).Value = (object)filtro ?? DBNull.Value;
                    comando.Parameters.Add("@Salto", SqlDbType.Int).Value = (pagina - 1) * registrosPorPagina;
                    comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = registrosPorPagina;

                    using (SqlDataReader reader = await comando.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lista.Add(MapearUsuario(reader));
                            total = reader.GetInt32(reader.GetOrdinal("TotalRegistros"));
                        }
                    }
                }
                return (lista, total);
            }
        }

        public async Task<Usuarios> ObtenerEmpleadoPorCedula(string cedula)
        {
            const string query = @"SELECT u.id, u.usuario, u.idRol, u.permitirIngreso,
                        p.cedula, p.nombre, p.apellido, p.correo, p.direccion, p.telefono, p.foto,
                        r.nombreRol FROM Usuarios u INNER JOIN PerfilUsuario p ON p.idUsuario = u.id
                        INNER JOIN Roles r ON r.idRol = u.idRol WHERE p.cedula = @Cedula;";

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@Cedula", SqlDbType.NVarChar, 20).Value = cedula;

                    using (SqlDataReader reader = await comando.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                            return MapearUsuario(reader);

                        return null;
                    }
                }
            }
            
        }

        public async Task<bool> ExisteUsuarioOCedula(string usuario, string cedula)
        {
            const string query = @"SELECT COUNT(*) FROM Usuarios u LEFT JOIN PerfilUsuario p ON p.idUsuario = u.id
                                   WHERE  u.usuario = @Usuario OR p.cedula = @Cedula;";

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@Usuario", SqlDbType.NVarChar, 50).Value = usuario;
                    comando.Parameters.Add("@Cedula", SqlDbType.NVarChar, 20).Value = cedula;
                    int count = Convert.ToInt32(await comando.ExecuteScalarAsync());
                    return count > 0;
                }
            }
            
        }

        public async Task<int> InsertarEmpleado(Usuarios empleado, string contraseñaHash)
        {
            const string queryUsuario = @"INSERT INTO Usuarios (usuario, contraseña, idRol, permitirIngreso)
                                          VALUES (@Usuario, @Contraseña, @IdRol, 1);
                                          SELECT CAST(SCOPE_IDENTITY() AS INT);";

            const string queryPerfil = @"INSERT INTO PerfilUsuario
                                        (idUsuario, cedula, nombre, apellido, correo, direccion, telefono, foto)
                                        VALUES
                                        (@IdUsuario, @Cedula, @Nombre, @Apellido, @Correo, @Direccion, @Telefono, @Foto);";

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            {
                using (SqlTransaction tx = conexion.BeginTransaction())
                {
                    try
                    {
                        int nuevoId;
                        using (SqlCommand comando = new SqlCommand(queryUsuario, conexion, tx))
                        {
                            comando.Parameters.Add("@Usuario", SqlDbType.NVarChar, 50).Value = empleado.User;
                            comando.Parameters.Add("@Contraseña", SqlDbType.NVarChar, 150).Value = contraseñaHash;
                            comando.Parameters.Add("@IdRol", SqlDbType.Int).Value = Rol.EMPLEADO;

                            nuevoId = Convert.ToInt32(await comando.ExecuteScalarAsync());
                        }

                        using (SqlCommand comando = new SqlCommand(queryPerfil, conexion, tx))
                        {
                            comando.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = nuevoId;
                            comando.Parameters.Add("@Cedula", SqlDbType.NVarChar, 20).Value = empleado.Cedula;
                            comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = empleado.Nombre;
                            comando.Parameters.Add("@Apellido", SqlDbType.NVarChar, 100).Value = empleado.Apellido;
                            comando.Parameters.Add("@Correo", SqlDbType.NVarChar, 250).Value = empleado.Correo;
                            comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 250).Value = empleado.Direccion;
                            comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 20).Value = empleado.Telefono;
                            comando.Parameters.Add("@Foto", SqlDbType.VarBinary).Value = (object)empleado.Foto ?? DBNull.Value;

                            await comando.ExecuteNonQueryAsync();
                        }

                        tx.Commit();
                        return nuevoId;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
            
        }

        public async Task<bool> ActualizarEmpleado(Usuarios empleado)
        {
            const string query = @"UPDATE p SET p.nombre = @Nombre, p.apellido  = @Apellido,
                    p.correo = @Correo, p.direccion = @Direccion, p.telefono  = @Telefono,
                    p.foto = @Foto FROM PerfilUsuario p INNER JOIN Usuarios u ON u.id = p.idUsuario
                    WHERE p.cedula = @Cedula;";

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@Cedula", SqlDbType.NVarChar, 20).Value = empleado.Cedula;
                    comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = empleado.Nombre;
                    comando.Parameters.Add("@Apellido", SqlDbType.NVarChar, 100).Value = empleado.Apellido;
                    comando.Parameters.Add("@Correo", SqlDbType.NVarChar, 250).Value = empleado.Correo;
                    comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 250).Value = empleado.Direccion;
                    comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 20).Value = empleado.Telefono;
                    comando.Parameters.Add("@Foto", SqlDbType.VarBinary).Value = (object)empleado.Foto ?? DBNull.Value;

                    int filas = await comando.ExecuteNonQueryAsync();
                    return filas > 0;
                }
            }
            
        }

        public async Task<bool> EliminarEmpleado(string cedula)
        {
            const string queryGetId = @"SELECT u.id FROM Usuarios u INNER JOIN PerfilUsuario p ON p.idUsuario = u.id
                                        WHERE p.cedula = @Cedula AND u.idRol <> @IdRolAdmin;";

            const string queryDeleteRecuperacion = @"DELETE FROM RecuperacionClave WHERE idUsuario = @IdUsuario;";

            const string queryDeleteUsuario = @"DELETE u FROM Usuarios u INNER JOIN PerfilUsuario p ON p.idUsuario = u.id
                                                WHERE p.cedula = @Cedula AND u.idRol <> @IdRolAdmin;";

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            {
                using (SqlTransaction tx = conexion.BeginTransaction())
                {
                    try
                    {
                        int idUsuario;
                        using (SqlCommand comando = new SqlCommand(queryGetId, conexion, tx))
                        {
                            comando.Parameters.Add("@Cedula", SqlDbType.NVarChar, 20).Value = cedula;
                            comando.Parameters.Add("@IdRolAdmin", SqlDbType.Int).Value = Rol.ADMINISTRADOR;

                            object result = await comando.ExecuteScalarAsync();
                            if (result == null) return false;
                            idUsuario = Convert.ToInt32(result);
                        }

                        using (SqlCommand comando = new SqlCommand(queryDeleteRecuperacion, conexion, tx))
                        {
                            comando.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario;
                            await comando.ExecuteNonQueryAsync();
                        }

                        using (SqlCommand comando = new SqlCommand(queryDeleteUsuario, conexion, tx))
                        {
                            comando.Parameters.Add("@Cedula", SqlDbType.NVarChar, 20).Value = cedula;
                            comando.Parameters.Add("@IdRolAdmin", SqlDbType.Int).Value = Rol.ADMINISTRADOR;
                            int filas = await comando.ExecuteNonQueryAsync();

                            tx.Commit();
                            return filas > 0;
                        }
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
            
        }

        public async Task<List<Usuarios>> ListarEmpleadosParaPermisos()
        {
            const string query = @"SELECT u.id, u.usuario, u.permitirIngreso, p.correo
                                   FROM Usuarios u INNER JOIN PerfilUsuario p ON p.idUsuario = u.id
                                   WHERE u.idRol = @IdRolEmpleado ORDER BY u.usuario;";

            var lista = new List<Usuarios>();

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@IdRolEmpleado", SqlDbType.Int).Value = Rol.EMPLEADO;

                    using (SqlDataReader reader = await comando.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lista.Add(new Usuarios
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                User = reader.GetString(reader.GetOrdinal("usuario")),
                                Correo = reader.GetString(reader.GetOrdinal("correo")),
                                PermitirIngreso = reader.GetBoolean(reader.GetOrdinal("permitirIngreso"))
                            });
                        }
                    }
                }
                return lista;
            }
        }

        public async Task<bool> ActualizarPermisoIngreso(int idUsuario, bool permitir)
        {
            const string query = @"UPDATE Usuarios SET permitirIngreso = @Permitir
                                   WHERE id = @Id AND idRol <> @IdRolAdmin;";

            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@Id", SqlDbType.Int).Value = idUsuario;
                    comando.Parameters.Add("@Permitir", SqlDbType.Bit).Value = permitir;
                    comando.Parameters.Add("@IdRolAdmin", SqlDbType.Int).Value = Rol.ADMINISTRADOR;

                    int filas = await comando.ExecuteNonQueryAsync();
                    return filas > 0;
                }
            }  
        }
    }
}
