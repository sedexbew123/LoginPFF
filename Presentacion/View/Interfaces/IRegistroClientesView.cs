using System;

namespace Presentacion.View.Interfaces
{
    public interface IRegistroClientesView
    {
        string Cedula { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        string Telefono { get; set; }
        string Correo { get; set; }
        string Direccion { get; set; }
        bool MostrarFotoGuardada { set; }
        void MostrarMensaje(string mensaje, bool esError);
        void LimpiarCampos();

        event EventHandler RegistrarClienteClick;
        event EventHandler LimpiarCamposClientesClick;
        event EventHandler AgregarImagen;
        event EventHandler TomarFoto;
    }
}
