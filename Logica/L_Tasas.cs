using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Logica
{
    public class L_Tasas
    {
        private readonly D_Tasas DTasas = new D_Tasas();
        private readonly D_ConfiguracionApi DConfiguracionApi = new D_ConfiguracionApi();
        private readonly D_TasasApi DTasasApi = new D_TasasApi();
        //private static readonly int IntervaloMinimoMinutos = 12 * 60;

        #region Operaciones de Base de Datos

        public async Task<(bool exito, string mensaje)> GuardarOActualizarTasa(int idMoneda, decimal valor, DateTime fecha)
        {
            bool existe = await DTasas.ExisteTasaPorFecha(idMoneda, fecha);
            if (existe)
            {
                return (false, "Esta moneda ya fue actualizada hoy. Solo se permite una actualización manual por día.");
            }

            bool guardado = await DTasas.GuardarTasa(idMoneda, valor, fecha);
            return guardado
                ? (true, "Tasa guardada correctamente.")
                : (false, "No se pudo guardar la tasa.");
        }

        public async Task<DataTable> ListarTasas()
        {
            return await DTasas.ListarTasas();
        }

        public async Task<DataTable> ObtenerMonedas()
        {
            return await DTasas.ObtenerMonedas();
        }

        #endregion

        #region Operaciones de API — DolarApi.com

        public async Task<(bool actualizado, string mensaje)> ActualizarTasasDesdeApi(CancellationToken ct = default)
        {
            int? minutosDesdeUltimaConsulta = await DConfiguracionApi.MinutosDesdeUltimaConsultaApi();
            /*if (minutosDesdeUltimaConsulta.HasValue && minutosDesdeUltimaConsulta.Value < IntervaloMinimoMinutos)
            {
                DateTime? ultimaFecha = await DTasas.ObtenerUltimaFechaRegistrada();
                string msgEspera = ultimaFecha.HasValue
                    ? $"Tasas al día. Último registro: {ultimaFecha.Value:dd/MM/yyyy}"
                    : "Tasas al día.";
                return (false, msgEspera);
            }*/

            await DConfiguracionApi.RegistrarConsultaApi();

            List<CotizacionApi> cotizaciones = await DTasasApi.ObtenerCotizaciones(ct);

            if (cotizaciones == null || cotizaciones.Count == 0)
            {
                DateTime? ultimaFecha = await DTasas.ObtenerUltimaFechaRegistrada();
                string sinConexion = ultimaFecha.HasValue
                    ? $"Sin conexión a la API. Último registro: {ultimaFecha.Value:dd/MM/yyyy}"
                    : "Sin conexión a la API.";
                return (false, sinConexion);
            }

            DateTime hoy = DateTime.Today;
            DataTable dtMonedas = await DTasas.ObtenerMonedas();
            int actualizadas = 0;

            foreach (CotizacionApi cotizacion in cotizaciones)
            {
                if (string.IsNullOrWhiteSpace(cotizacion.Moneda)) continue;

                DateTime fechaApi = ParseFechaApi(cotizacion.FechaActualizacion) ?? hoy;

                System.Diagnostics.Debug.WriteLine(
                    $"[API] Evaluando: {cotizacion.Moneda} | Promedio: {cotizacion.Promedio} | FechaApi: {fechaApi:dd/MM/yyyy}");

                DataRow[] rows = dtMonedas.Select(
                    $"Descripcion = '{cotizacion.Moneda.ToUpper()}'");

                if (rows.Length == 0 && !string.IsNullOrEmpty(cotizacion.Nombre))
                    rows = dtMonedas.Select($"Nombre LIKE '%{cotizacion.Nombre}%'");

                if (rows.Length == 0)
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"[API] No se encontró '{cotizacion.Moneda}' en la tabla Monedas.");
                    continue;
                }

                int idMoneda = Convert.ToInt32(rows[0]["IdMoneda"]);

                if (await DTasas.ExisteTasaPorFecha(idMoneda, fechaApi)) continue;

                decimal tasa = cotizacion.Promedio > 0 ? cotizacion.Promedio
                             : (cotizacion.Venta ?? 0) > 0 ? cotizacion.Venta.Value
                             : (cotizacion.Compra ?? 0);

                bool guardado = await DTasas.GuardarTasa(idMoneda, tasa, fechaApi);
                if (guardado) actualizadas++;
            }

            if (actualizadas > 0)
                return (true, $"Tasas actualizadas correctamente ({hoy:dd/MM/yyyy})");

            DateTime? ultima = await DTasas.ObtenerUltimaFechaRegistrada();
            string msg = ultima.HasValue
                ? $"Tasas al día. Último registro: {ultima.Value:dd/MM/yyyy}"
                : "No hay tasas guardadas.";
            return (false, msg);
        }

        #endregion

        public async Task<(decimal Tasa, int IdTasa)> ObtenerTasaConIdAsync(int idMoneda)
        {
            if (idMoneda == 1)
                return (1m, 0);

            return await DTasas.ObtenerTasaVigenteConIdAsync(idMoneda);
        }

        private static DateTime? ParseFechaApi(string fechaTexto)
        {
            if (string.IsNullOrWhiteSpace(fechaTexto)) return null;

            string soloFecha = fechaTexto.Length >= 10 ? fechaTexto.Substring(0, 10) : fechaTexto;

            return DateTime.TryParseExact(
                soloFecha, "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out DateTime fecha) ? fecha : (DateTime?)null;
        }
    }
}
