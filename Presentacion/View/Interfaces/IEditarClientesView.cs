using System;
using System.Windows.Forms;

namespace Presentacion.View.Interfaces
{
    public interface IEditarClientesView
    {
        int Cedula { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        string Telefono { get; set; }
        string Correo { get; set; }
        string Direccion { get; set; }
        byte[] FotoEmpleado { get; set; }

        bool MostrarFotoGuardada { set; }   
        void MostrarMensaje(string mensaje); 

        void CerrarVista();
        void MostrarCargando();
        void OcultarCargando();

        event EventHandler Cerrar;
        event EventHandler EditarCliente;
        event EventHandler Cancelar;
        event EventHandler AgregarImagen;
        event EventHandler TomarFoto;
    }
}
