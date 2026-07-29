using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.View.Interfaces
{
    public interface IGestionEmpleadosView
    {
        string Cedula { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        string TextoBusqueda { get; }

        void LlenarListadoEmpleados(List<Usuarios> empleados);
        void ActualizarPaginacionEmpleados(int paginaActual, int totalPaginas);
        void MostrarMensaje(string mensaje, bool esError);

        event EventHandler PaginaSiguienteClick;
        event EventHandler PaginaAnteriorClick;
        event EventHandler EliminarEmpleadosClick;
        event EventHandler EditarEmpleadosClick;
        event EventHandler AgregarEmpleadosClick;
        event EventHandler VisualizarEmpleadosClick;
        event EventHandler CargarEmpleados;
        event EventHandler FiltrarEmpleados;
    }
}