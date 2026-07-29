using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_ConfiguracionApi
    {
        private readonly D_ConexionBD conexion = new D_ConexionBD();

        public async Task<int?> MinutosDesdeUltimaConsultaApi()
        {
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    string query = @"SELECT DATEDIFF(MINUTE, Valor, GETDATE()) FROM ConfiguracionApi WHERE Clave = 'UltimaConsultaApi'";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        object result = await comando.ExecuteScalarAsync();
                        return result != null && result != DBNull.Value
                            ? Convert.ToInt32(result)
                            : (int?)null;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("[D_ConfiguracionApi] " + ex.Message);
                return null;
            }
        }

        public async Task RegistrarConsultaApi()
        {
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    string query = @"IF EXISTS (SELECT 1 FROM ConfiguracionApi WHERE Clave = 'UltimaConsultaApi')
                                     UPDATE ConfiguracionApi SET Valor = GETDATE() WHERE Clave = 'UltimaConsultaApi'
                                     ELSE
                                     INSERT INTO ConfiguracionApi (Clave, Valor) VALUES ('UltimaConsultaApi', GETDATE())";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        await comando.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("[D_ConfiguracionApi] " + ex.Message);
            }
        }
    }
}
