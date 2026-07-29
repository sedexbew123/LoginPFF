using System;

namespace Presentacion.View.Interfaces
{
    public interface ICargoProductoView
    {
        int CategoriaIdSeleccionada { get; }
        string ProductoCodigoSeleccionado { get; }
        int CantidadSeleccionada { get; }
        object CategoriasDataSource { set; }
        object ProductosDataSource { set; }

        void LimpiarCampos();
        void MostrarMensaje(string mensaje, bool esError);
        void ActualizarPaginacion(int paginaActual, int totalPaginas);

        event EventHandler CargarDatos;
        event EventHandler CategoriaChanged;
        event EventHandler RegistrarCargoClick;
        event EventHandler PaginaSiguienteClick;
        event EventHandler PaginaAnteriorClick;
    }
}
