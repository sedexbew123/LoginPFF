using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Pagos
    {
        private readonly D_ConexionBD conexion = new D_ConexionBD();

        public async Task<DataTable> ListarClientesConDeudaAsync(int mes, int año)
        {
            return await EjecutarSpAsync("sp_ListarClientesConDeuda", comando =>
            {
                comando.Parameters.AddWithValue("@Mes", mes == 0 ? (object)DBNull.Value : mes);
                comando.Parameters.AddWithValue("@Año", año == 0 ? (object)DBNull.Value : año);
            });
        }

        public async Task<DataTable> ListarHistorialPagosAsync(int mes, int año)
        {
            return await EjecutarSpAsync("sp_ListarHistorialPagos", comando =>
            {
                comando.Parameters.AddWithValue("@Mes", mes == 0 ? (object)DBNull.Value : mes);
                comando.Parameters.AddWithValue("@Año", año == 0 ? (object)DBNull.Value : año);
            });
        }

        public async Task<DataTable> ListarHistorialPagosPorRangoAsync(DateTime desde, DateTime hasta)
        {
            return await EjecutarSpAsync("sp_ListarHistorialPagosPorRango", comando =>
            {
                comando.Parameters.AddWithValue("@FechaDesde", desde);
                comando.Parameters.AddWithValue("@FechaHasta", hasta);
            });
        }

        public async Task<DataTable> ObtenerGananciasMensualesAsync(int mes, int año)
        {
            return await EjecutarSpAsync("sp_GananciasMensuales", comando =>
            {
                comando.Parameters.AddWithValue("@Mes", mes == 0 ? (object)DBNull.Value : mes);
                comando.Parameters.AddWithValue("@Año", año == 0 ? (object)DBNull.Value : año);
            });
        }

        public async Task<int> GuardarPagoAsync(Pagos pago)
        {
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand("sp_InsertarPago", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.AddWithValue("@IdCredito", pago.IdCredito);
                        comando.Parameters.AddWithValue("@Monto", pago.Monto);
                        comando.Parameters.AddWithValue("@MontoOriginal", pago.MontoOriginal);
                        comando.Parameters.AddWithValue("@MontoBs", pago.MontoBs);
                        comando.Parameters.AddWithValue("@FechaPago", pago.FechaPago);
                        comando.Parameters.AddWithValue("@Estado", pago.Estado);
                        comando.Parameters.AddWithValue("@TipoPago", pago.TipoPago);
                        comando.Parameters.AddWithValue("@Observacion",
                            string.IsNullOrWhiteSpace(pago.Observacion)
                                ? (object)DBNull.Value
                                : pago.Observacion);
                        comando.Parameters.AddWithValue("@IdUsuario", pago.IdUsuario);
                        comando.Parameters.AddWithValue("@IdMoneda", pago.IdMoneda);
                        comando.Parameters.AddWithValue("@IdTasa",
                            pago.IdTasa.HasValue
                                ? (object)pago.IdTasa.Value
                                : DBNull.Value);

                        var pIdPago = new SqlParameter("@IdPago", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        comando.Parameters.Add(pIdPago);

                        await comando.ExecuteNonQueryAsync();

                        if (pIdPago.Value == null || pIdPago.Value == DBNull.Value)
                        {
                            System.Diagnostics.Debug.WriteLine(
                                "[D_Pagos.GuardarPago] El SP no devolvió @IdPago. " +
                                "Revisar la lógica interna de sp_InsertarPago (posible validación silenciosa).");
                            return -1;
                        }

                        return Convert.ToInt32(pIdPago.Value);
                    }
                }
            }
            catch (SqlException ex)
            {
                Log("GuardarPago", ex);
                System.Diagnostics.Debug.WriteLine($"ERROR SQL REAL [{ex.Number}]: {ex.Message}");
                return -1;
            }
            catch (Exception ex)
            {
                Log("GuardarPago", ex);
                System.Diagnostics.Debug.WriteLine("ERROR SQL REAL: " + ex.Message);
                return -1;
            }
        }

        public async Task<bool> ActualizarEstadoCreditoAsync(int idCredito, string nuevoEstado)
        {
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())    
                { 
                    using (SqlCommand comando = new SqlCommand( "UPDATE Creditos SET Estado = @Estado WHERE IdCredito = @Id", conexion))
                    {
                        comando.Parameters.AddWithValue("@Estado", nuevoEstado);
                        comando.Parameters.AddWithValue("@Id", idCredito);
                        return await comando.ExecuteNonQueryAsync() > 0;
                    }
                }   
            }
            catch (Exception ex)
            {
                Log("ActualizarEstadoCredito", ex);
                return false;
            }
        }

        public async Task<bool> EliminarPagosDeCreditoAsync(int idCredito)
        {
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())     
                { 
                    using (SqlCommand comando = new SqlCommand("sp_EliminarPagosCredito", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@IdCredito", idCredito);
                        await comando.ExecuteNonQueryAsync();
                        return true;
                    }
                }       
            }
            catch (Exception ex)
            {
                Log("EliminarPagosDeCredito", ex);
                return false;
            }
        }

        private async Task<DataTable> EjecutarSpAsync(string spName, Action<SqlCommand> parametros)
        {
            var tabla = new DataTable();
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(spName, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        parametros(comando);

                        using (SqlDataReader dr = await comando.ExecuteReaderAsync())
                        {
                            tabla.Load(dr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(spName, ex);
            }
            return tabla;
        }

        public async Task<bool> EliminarDetallesCreditoAsync(int idCredito)
        {
            try
            {
                using (SqlConnection conexion = await this.conexion.ConectarAsync())
                {
                    using (SqlCommand comando = new SqlCommand(
                    "DELETE FROM DetalleCredito WHERE IdCredito = @IdCredito", conexion))
                    {
                        comando.Parameters.AddWithValue("@IdCredito", idCredito);
                        await comando.ExecuteNonQueryAsync();
                        return true;
                    }
                }    
            }
            catch (Exception ex)
            {
                Log("EliminarDetallesCredito", ex);
                return false;
            }
        }

        private static void Log(string origen, Exception ex) => System.Diagnostics.Debug.WriteLine($"[D_Pagos.{origen}] {ex.Message}");
    }
}

