using System;
using System.Windows.Forms;

namespace Presentacion.View.Interfaces
{
    public interface INuevoEmpleadoView
    {
        string CedulaOriginal { get; set; }

        string Usuario { get; set; }
        string Contrasena { get; set; }
        string Cedula { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        string Direccion { get; set; }
        string Correo { get; set; }
        string Telefono { get; set; }
        byte[] FotoEmpleado { get; set; }

        bool ModoEdicion { get; set; }
        void BloquearCedula(bool bloquear);
        void BloquearUsuario(bool bloquear);
        void MostrarCampoContraseña(bool mostrar);
        void MostrarMensaje(string mensaje, string titulo, MessageBoxIcon icono);
        void CerrarVista();

        void MostrarCargando();
        void OcultarCargando();

        event EventHandler VistaCargando;
        event EventHandler RegistrarEmpleado;
        event EventHandler Cancelar;
        event EventHandler AgregarImagen;
        event EventHandler TomarFoto;
    }
}