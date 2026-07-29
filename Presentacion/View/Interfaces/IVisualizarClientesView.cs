using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.View.Interfaces
{
    public interface IVisualizarClientesView
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
