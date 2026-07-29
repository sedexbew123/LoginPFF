using System;
using System.Windows.Forms;

namespace Presentacion.View.Interfaces
{
    public interface IRegistroUsuarioView
    {
        string Nombre { get; set; }
        string Apellido { get; set; }
        string Cedula { get; set; }
        string Telefono { get; set; }
        string Correo { get; set; }
        string Direccion { get; set; }
        void CerrarVista();
        void NotificarEdicionExitosa();
        void MostrarMensaje(string mensaje, string titulo, MessageBoxIcon icono);
        void MostrarCargando();
        void OcultarCargando();

        event EventHandler EditarUsuario;
        event EventHandler VolverAlLogin;
        event EventHandler UsuarioEditadoExitosamente;
        event EventHandler VistaListaParaCargar;
    }
}
