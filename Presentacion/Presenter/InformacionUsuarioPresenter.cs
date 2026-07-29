using Logica;
using Presentacion.Helpers;
using Presentacion.View.Forms;
using Presentacion.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Presenter
{
    public class InformacionUsuarioPresenter
    {
        private readonly IInformacionUsuarioView _view;
        private readonly L_Usuarios _usuarios;

        private const string NumeroTelefonoSoporte = "584243782309";
        public InformacionUsuarioPresenter(IInformacionUsuarioView view, L_Usuarios usuarios)
        {
            _view = view;
            _usuarios = usuarios;

            _view.EditarInformacion += EditarInformacion_Accion;
            _view.MostrarInformacion += MostrarInformacion_Accion;
            _view.AdministrarPermisos += AdministrarPermisos_Accion;
            _view.SolicitarCorreoSoporte += SolicitarCorreoSoporte_Accion;

            _view.ReportarFallaClick += ReportarFalla_Accion;
            _view.SolicitarLicenciaClick += SolicitarLicencia_Accion;
        }
        private void ReportarFalla_Accion(object sender, EventArgs e)
        {
            try
            {
                string nombreUsuario = $"{_view.Nombre} {_view.Apellido}".Trim();
                if (string.IsNullOrWhiteSpace(nombreUsuario))
                {
                    nombreUsuario = "Usuario Administrador";
                }

                string modulo = "Información de Usuario / General";
                string detalle = "Deseo consultar / reportar un inconveniente técnico en el sistema.";

                // Construye el mensaje desde la plantilla
                string mensaje = PlantillasWhatsApp.MensajeReportarFalla(nombreUsuario, modulo, detalle);

                // Abre WhatsApp usando el Helper
                WhatsAppHelper.EnviarMensaje(NumeroTelefonoSoporte, mensaje);
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje("No se pudo abrir WhatsApp: " + ex.Message, "Error", MessageBoxIcon.Error);
            }
        }

        private void SolicitarLicencia_Accion(object sender, EventArgs e)
        {
            try
            {
                string nombreUsuario = $"{_view.Nombre} {_view.Apellido}".Trim();
                if (string.IsNullOrWhiteSpace(nombreUsuario))
                {
                    nombreUsuario = "Cliente CrediTrack";
                }

                string plan = "Renovación / Licencia del Sistema";

                // Construye el mensaje desde la plantilla
                string mensaje = PlantillasWhatsApp.MensajePagoLicenciaSistema(nombreUsuario, plan);

                // Abre WhatsApp usando el Helper
                WhatsAppHelper.EnviarMensaje(NumeroTelefonoSoporte, mensaje);
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje("No se pudo abrir WhatsApp: " + ex.Message, "Error", MessageBoxIcon.Error);
            }
        }
        private void SolicitarCorreoSoporte_Accion(object sender, EventArgs e)
        {
            string destinatario = "creditrack.oficial@gmail.com";
            string asunto = "Soporte Técnico - Sistema CrediTrack";

            string cuerpoMensaje = "Estimado Equipo de Soporte de CrediTrack,\n\n" +
                                   "Me pongo en contacto con ustedes para reportar una incidencia en el uso del sistema administrativo.\n\n" +
                                   "Agradezco de antemano su atención para la revisión de los siguientes detalles:\n" +
                                   "- Módulo afectado: \n" +
                                   "- Descripción de la situación: \n\n" +
                                   "Atentamente,";

            string asuntoEscapado = Uri.EscapeDataString(asunto);
            string cuerpoEscapado = Uri.EscapeDataString(cuerpoMensaje);

            string urlGmailBorrador = $"https://mail.google.com/mail/?extsrc=mailto&url=mailto:{destinatario}?subject={asuntoEscapado}%26body={cuerpoEscapado}";

            _view.AbrirGmailBorrador(destinatario, asunto, urlGmailBorrador);
        }

        private void AdministrarPermisos_Accion(object sender, EventArgs e)
        {
            var vista = new AdministrarPermisos();

            var presenter = new AdministrarPermisosPresenter(vista);

            vista.ShowDialog();
        }

        private async Task CargarDatosUsuario()
        {
            var usuario = await _usuarios.ObtenerInformacionUsuarioUnico();
            if (usuario == null) return;

            _view.Nombre = usuario.Nombre;
            _view.Apellido = usuario.Apellido;
            _view.Cedula = usuario.Cedula;
            _view.Telefono = usuario.Telefono;
            _view.Correo = usuario.Correo;
            _view.Direccion = usuario.Direccion;
        }

        private async void MostrarInformacion_Accion(object sender, EventArgs e)
        {
            try
            {
                var usuario = await _usuarios.ObtenerInformacionUsuarioUnico();
                if (usuario != null)
                {
                    _view.Nombre = usuario.Nombre;
                    _view.Apellido = usuario.Apellido;
                    _view.Cedula = usuario.Cedula;
                    _view.Telefono = usuario.Telefono;
                    _view.Correo = usuario.Correo;
                    _view.Direccion = usuario.Direccion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el perfil: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditarInformacion_Accion(object sender, EventArgs e)
        {
            using (RegistroUsuario frmRegistroUsuario = new RegistroUsuario())
            {

                frmRegistroUsuario.UsuarioEditadoExitosamente += async (s, args) =>
                {
                    await CargarDatosUsuario();
                };
                frmRegistroUsuario.ShowDialog();
            }
        }
    }
}
