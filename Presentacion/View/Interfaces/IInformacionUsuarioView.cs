using System;
using System.Windows.Forms;

namespace Presentacion.View.Interfaces
{
    public interface IInformacionUsuarioView
    {
        string Cedula { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        string Telefono { get; set; }
        string Correo { get; set; }
        string Direccion { get; set; }

        void AbrirGmailBorrador(string destinatario, string asunto, string urlFinal);
        void MostrarMensaje(string mensaje, string titulo, MessageBoxIcon icono);

        event EventHandler SolicitarCorreoSoporte;
        event EventHandler EditarInformacion;
        event EventHandler AdministrarPermisos;
        event EventHandler MostrarInformacion;
        event EventHandler ReportarFallaClick;
        event EventHandler SolicitarLicenciaClick;
    }
}
