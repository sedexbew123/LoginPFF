using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Logica
{
    public class L_Pagos
    {
        private readonly D_Pagos DPagos = new D_Pagos();
        private readonly L_Tasas LTasas = new L_Tasas();

        public async Task<DataTable> ObtenerClientesConDeudaAsync(int mes, int año)
        {
            DataTable dt = await DPagos.ListarClientesConDeudaAsync(mes, año);
            if (dt == null) return new DataTable();

            if (!dt.Columns.Contains("Monto")) dt.Columns.Add("Monto", typeof(string));
            if (!dt.Columns.Contains("MontoBs")) dt.Columns.Add("MontoBs", typeof(string));
            if (!dt.Columns.Contains("Estado")) dt.Columns.Add("Estado", typeof(string));

            var tasaUsd = await LTasas.ObtenerTasaConIdAsync(2); 

            foreach (DataRow fila in dt.Rows)
            {
                decimal montoTotal = Convert.ToDecimal(fila["MontoTotal"]);
                decimal saldoPendiente = Convert.ToDecimal(fila["SaldoPendiente"]);

                fila["Monto"] = saldoPendiente.ToString("N2");
                fila["MontoBs"] = (saldoPendiente * tasaUsd.Tasa).ToString("N2");
                fila["Estado"] = CalcularEstado(montoTotal, saldoPendiente);
            }
            return dt;
        }


        public async Task<DataTable> ObtenerHistorialPagosAsync(int mes, int año)
        {
            DataTable dt = await DPagos.ListarHistorialPagosAsync(mes, año);
            return dt ?? new DataTable();
        }

        public async Task<DataTable> ObtenerHistorialPagosPorRangoAsync(DateTime desde, DateTime hasta)
        {
            DataTable dt = await DPagos.ListarHistorialPagosPorRangoAsync(desde, hasta);
            return dt ?? new DataTable();
        }
        public async Task<DataTable> ObtenerGananciasMensualesAsync(int mes, int año)
        {
            DataTable dt = await DPagos.ObtenerGananciasMensualesAsync(mes, año);
            return dt ?? new DataTable();
        }
       
        public async Task<bool> EliminarPagoAsync(int idCredito)
        {
            if (idCredito <= 0)
                throw new ArgumentException("ID de crédito inválido.");
            return await DPagos.EliminarPagosDeCreditoAsync(idCredito);
        }

        public static string CalcularEstado(decimal montoTotal, decimal saldoPendiente)
        {
            if (saldoPendiente <= 0) return "Pagado";
            if (saldoPendiente < montoTotal) return "Parcial";
            return "Debe";
        }

        public async Task<int> RegistrarPagoAsync(Pagos pago, decimal saldoPendiente)
        {
            if (pago.IdCredito <= 0 || pago.Monto <= 0)
                throw new ArgumentException("Datos de pago inválidos.");

            if (pago.TipoPago == "Abono" && pago.Monto > saldoPendiente)
                throw new ArgumentException(
                    $"El abono ({pago.Monto:N2}) supera el saldo pendiente ({saldoPendiente:N2}).");

            bool esCompleto = pago.TipoPago == "Completo"
                || Math.Round(pago.Monto, 2) >= Math.Round(saldoPendiente, 2);

            pago.Estado = esCompleto ? "Pagado" : "Parcial";

            int idPago = await DPagos.GuardarPagoAsync(pago);
            if (idPago <= 0)
                throw new InvalidOperationException("No se pudo guardar el pago en la base de datos.");

            if (esCompleto)
            {
                await DPagos.ActualizarEstadoCreditoAsync(pago.IdCredito, "Pagado");

                await DPagos.EliminarDetallesCreditoAsync(pago.IdCredito);
            }

            return idPago;
        }
    }
}