using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.View.Interfaces
{
    public interface IControlTrabajoView
    {
        string MesSeleccionado {  get; }
        int AñoSeleccionado { get; set;  }
        string TextoBusqueda { get; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        int Cedula { get; set; }
        string Servicio { get; set; }
        decimal Monto { get; set; }
        decimal TotalBolivares { get; set; }
        DateTime Fecha { get; set; }
        string Estado { get; set; }

        object DataSource { set; }
        void ActualizarPaginacionClientes(int paginaActual, int totalPaginas);
        void MostrarMensaje(string mensaje, bool isError = false);

        event EventHandler PaginaSiguienteClick;
        event EventHandler PaginaAnteriorClick;
        event EventHandler FiltrarClientes;
        event EventHandler FiltroFechaCambiado;
        event EventHandler AgregarServicio;
        event EventHandler CargarServicios;
    }
}
