using System;
using System.Windows.Forms;

namespace Presentacion.View.Interfaces
{
    public interface IVisualizarEmpleadoView
    {
        string Cedula { set; }
        string Nombre { set; }
        string Apellido { set; }
        string Telefono { set; }
        string Direccion { set; }
        string Correo { set; }
        byte[] FotoEmpleado { set; }

        void CerrarVista();

        void MostrarCargando();
        void OcultarCargando();

        event EventHandler VistaCargando;
        event EventHandler Volver;
    }
}