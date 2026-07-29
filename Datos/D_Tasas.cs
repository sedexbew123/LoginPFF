using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Tasas
    {
        private readonly D_ConexionBD conexion = new D_ConexionBD();

        public async Task<DateTime?> ObtenerUltimaFechaRegistrada()
        {
            try
            {
                string query = "SELECT MAX(FechaRegistro) FROM TasasCambio";

                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        object result = await comando.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToDateTime(result);
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al obtener última fecha: " + ex.Message);
                return null;
            }
        }

        public async Task<bool> ExisteTasaPorFecha(int idMoneda, DateTime fecha)
        {
            string query = @"SELECT COUNT(*) FROM TasasCambio WHERE IdMoneda = @id 
                             AND CAST(FechaRegistro AS DATE) = @fecha";
            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@id", idMoneda);
                    comando.Parameters.AddWithValue("@fecha", fecha.Date);

                    int count = (int)await comando.ExecuteScalarAsync();
                    return count > 0;
                }
            }
        }

        public async Task<bool> GuardarTasa(int idMoneda, decimal valor, DateTime fecha)
        {
            string queryVerificar = @"SELECT COUNT(*) FROM TasasCambio WHERE IdMoneda = @id 
                                      AND CAST(FechaRegistro AS DATE) = CAST(@fecha AS DATE)";
            using (SqlConnection conexion = await this.conexion.ConectarAsync())
            {
                using (SqlCommand comando = new SqlCommand(queryVerificar, conexion))
                {
                    comando.Parameters.AddWithValue("@id", idMoneda);
                    comando.Parameters.AddWithValue("@fecha", fecha.Date);
                    int count = (int)await comando.ExecuteScalarAsync();

                    if (count > 0) return false;
                }

                string queryInsert = @"INSERT INTO TasasCambio (IdMoneda, ValorTasa, FechaRegistro)
                     VALUES (@id, @valor, GETDATE())";

                using (SqlCommand comandoIns = new SqlCommand(queryInsert, conexion))
                {
                    comandoIns.Parameters.AddWithValue("@id", idMoneda);
                    comandoIns.Parameters.AddWithValue("@valor", valor);

                    await comandoIns.ExecuteNonQueryAsync();
                }
                return true;
            }
        }

        public async Task<decimal?> ObtenerUltimaTasa(int idMoneda)
        {
            try
            {
                string query = "SELECT TOP 1 ValorTasa FROM TasasCambio WHERE IdMoneda = @id ORDER BY FechaRegistro DESC";
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.Add("@id", SqlDbType.Int).Value = idMoneda;
                        var result = await comando.ExecuteScalarAsync();
                        return result != DBNull.Value && result != null ? Convert.ToDecimal(result) : (decimal?)null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener última tasa: " + ex.Message);
            }
        }

        public async Task<DataTable> ListarTasas()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"SELECT t.IdTasa, t.IdMoneda, t.ValorTasa, t.FechaRegistro, m.Nombre AS NombreMoneda, m.Descripcion
                                   FROM TasasCambio t INNER JOIN Monedas m ON t.IdMoneda = m.IdMoneda 
                                   ORDER BY t.FechaRegistro DESC";
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader reader = await comando.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar tasas: " + ex.Message);
            }
        }
        
        public async Task<DataTable> ObtenerMonedas()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT IdMoneda, Nombre, Descripcion FROM Monedas ORDER BY Nombre";
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))  
                    { 
                        using (SqlDataReader reader = await comando.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener monedas: " + ex.Message);
            }
        }

        public async Task<bool> ActualizarTasa(int idMoneda, decimal valor, DateTime fecha)
        {
            try
            {
                string query = @"UPDATE TasasCambio SET ValorTasa = @valor WHERE IdMoneda = @id 
                                 AND CAST(FechaRegistro AS DATE) = CAST(@fecha AS DATE)";
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@id", idMoneda);
                        comando.Parameters.AddWithValue("@valor", valor);
                        comando.Parameters.AddWithValue("@fecha", fecha.Date);
                        int rows = await comando.ExecuteNonQueryAsync();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar tasa: " + ex.Message);
            }
        }
        
        public async Task<(decimal Tasa, int IdTasa)> ObtenerTasaVigenteConIdAsync(int idMoneda)
        {
            try
            {
                string query = @"SELECT TOP 1 IdTasa, ValorTasa FROM TasasCambio
                                 WHERE IdMoneda = @IdMoneda ORDER BY FechaRegistro DESC";
                using (SqlConnection conexion = await this.conexion.ConectarAsync())    
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdMoneda", idMoneda);

                        using (SqlDataReader dr = await comando.ExecuteReaderAsync())
                        {
                            if (await dr.ReadAsync())
                            {
                                int    idTasa = Convert.ToInt32(dr["IdTasa"]);
                                decimal tasa  = Convert.ToDecimal(dr["ValorTasa"]);
                                return (tasa, idTasa);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    $"[D_Tasas.ObtenerTasaVigenteConId] {ex.Message}");
            }
            return (0m, 0);
        }
    }
}
