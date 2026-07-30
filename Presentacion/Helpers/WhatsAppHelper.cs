using System;
using System.Diagnostics;
using System.Net;

namespace Presentacion.Helpers
{
    public static class WhatsAppHelper
    {
        /// <summary>
        /// Abre WhatsApp (Web o App) con un número y un mensaje predefinido.
        /// </summary>
        /// <param name="numeroTelefono">Número de teléfono con código de país (ej: "584141234567")</param>
        /// <param name="mensaje">Mensaje a enviar</param>
        /// 

        public static void EnviarMensaje(string numeroTelefono, string mensaje)
        {
            if (string.IsNullOrWhiteSpace(numeroTelefono))
                throw new ArgumentException("El número de teléfono no puede estar vacío.");

            string numeroLimpio = LimpiarNumeroTelefono(numeroTelefono);

            // Formato internacional para Venezuela si no tiene prefijo
            if (numeroLimpio.StartsWith("0"))
            {
                numeroLimpio = "58" + numeroLimpio.Substring(1);
            }
            else if (!numeroLimpio.StartsWith("58") && numeroLimpio.Length == 10)
            {
                numeroLimpio = "58" + numeroLimpio;
            }

            string mensajeCodificado = WebUtility.UrlEncode(mensaje);

            // 👇 URI del protocolo nativo de la app de escritorio
            string urlApp = $"whatsapp://send?phone={numeroLimpio}&text={mensajeCodificado}";

            // 👇 URL web de respaldo (WhatsApp Web / landing page)
            string urlWeb = $"https://api.whatsapp.com/send?phone={numeroLimpio}&text={mensajeCodificado}";

            // 1. Intentar abrir directamente la app de escritorio
            if (!TryAbrirUrl(urlApp))
            {
                // 2. Si la app no está instalada (no hay handler para "whatsapp://"), usar la web
                TryAbrirUrl(urlWeb);
            }
        }

        private static bool TryAbrirUrl(string url)
        {
            try
            {
                using (var proceso = Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                }))
                {
                    return proceso != null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"No se pudo abrir '{url}': {ex.Message}");
                return false;
            }
        }

        private static string LimpiarNumeroTelefono(string telefono)
        {
            return System.Text.RegularExpressions.Regex.Replace(telefono, @"[^\d]", "");
        }
    }


    public static class PlantillasWhatsApp
    {
        public static string MensajeRecordatorioDeuda(string nombreCliente, decimal montoDolares, decimal totalBolivares, DateTime? fechaLimite)
        {
            // Verificamos si la fecha ya pasó comparándola con la fecha actual (solo fecha sin hora)
            bool estaVencida = fechaLimite.HasValue && fechaLimite.Value.Date < DateTime.Now.Date;

            if (estaVencida)
            {
                int diasVencidos = (DateTime.Now.Date - fechaLimite.Value.Date).Days;

                return $"Hola, *{nombreCliente}*. 👋\n\n" +
                       $"Le escribimos para recordarle que su cuenta presenta un **saldo vencido** por un monto de **${montoDolares:F2}** ({totalBolivares:N2} Bs.).\n\n" +
                       $"⚠️ *Estado:* Vencida desde el **{fechaLimite.Value:dd/MM/yyyy}** (hace {diasVencidos} días).\n\n" +
                       $"Le agradecemos comunicarse con nosotros para coordinar la cancelación del saldo pendiente. ¡Muchas gracias!";
            }
            else
            {
                string fechaTexto = fechaLimite.HasValue ? fechaLimite.Value.ToString("dd/MM/yyyy") : "la brevedad";

                return $"Hola, *{nombreCliente}*. 👋\n\n" +
                       $"Le recordamos que mantiene un saldo pendiente por un monto de **${montoDolares:F2}** ({totalBolivares:N2} Bs.).\n\n" +
                       $"📅 *Fecha límite de pago:* {fechaTexto}.\n\n" +
                       $"Quedamos a su disposición para cualquier duda sobre sus consumos o pagos. ¡Feliz día!";
            }
        }

        public static string MensajeComprobantePago(string nombreCliente, decimal montoAbonado, decimal saldoRestante, DateTime fechaPago)
        {
            // Si la fecha viniera en DateTime.MinValue por defecto, usamos la fecha/hora actual
            string fechaFormateada = (fechaPago == DateTime.MinValue ? DateTime.Now : fechaPago).ToString("dd/MM/yyyy");

            string estadoSaldo = saldoRestante > 0
                ? $"Su saldo restante es de **${saldoRestante:F2}**."
                : "Su cuenta ha quedado completamente **solventada**. ¡Muchas gracias!";

            return $"Hola, *{nombreCliente}*. 👋\n\n" +
                   $"Hemos registrado exitosamente su pago/abono por un monto de **${montoAbonado:F2}** el día **{fechaFormateada}**.\n\n" +
                   $"{estadoSaldo}\n\n" +
                   $"¡Gracias por su preferencia!";
        }

        // ==========================================
        // 2. SOPORTE TÉCNICO Y SISTEMA (CrediTrack)
        // ==========================================

        /// <summary>
        /// Mensaje enviado por el usuario/administrador para reportar una falla o duda del software.
        /// </summary>
        public static string MensajeReportarFalla(string nombreUsuario, string moduloAfectado, string descripcionFalla)
        {
            return $"🛠️ *REPORTE DE FALLA / ASISTENCIA TÉCNICA*\n\n" +
                   $"• *Sistema:* CrediTrack\n" +
                   $"• *Usuario/Empresa:* {nombreUsuario}\n" +
                   $"• *Módulo afectado:* {moduloAfectado}\n\n" +
                   $"📝 *Descripción del problema:*\n{descripcionFalla}\n\n" +
                   $"Quedo atento a su respuesta para la revisión. Gracias.";
        }

        /// <summary>
        /// Mensaje para solicitar o renovar la licencia/pago del sistema administrativo.
        /// </summary>
        public static string MensajePagoLicenciaSistema(string nombreEmpresa, string planOPeriodo)
        {
            return $"💳 *SOLICITUD DE PAGO / RENOVACIÓN DE LICENCIA*\n\n" +
                   $"Hola, equipo de soporte técnico. 👋\n\n" +
                   $"Les escribo de parte de *{nombreEmpresa}* referente al sistema **CrediTrack**.\n" +
                   $"Deseamos realizar el pago correspondiente a la licencia (**{planOPeriodo}**).\n\n" +
                   $"Por favor, indíquenme los métodos de pago disponibles o datos bancarios actualizados para procesar la transferencia. ¡Gracias!";
        }
    }
}
