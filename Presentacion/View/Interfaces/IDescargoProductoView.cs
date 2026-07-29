using System;

namespace Presentacion.View.Interfaces
{
    public interface IDescargoProductoView
    {
        int CategoriaIdSeleccionada { get; }
        string ProductoCodigoSeleccionado { get; }
        int CantidadSeleccionada { get; }
        int IdMotivoSeleccionado { get; }

        void SuspendUI();
        void ResumeUI();

        object CategoriasDataSource { set; }
        object ProductosDataSource { set; }
        object HistorialDataSource { set; }
        object MotivosDataSource { set; }
        string CategoriaSeleccionada { get; }

        void LimpiarCampos();
        void MostrarMensaje(string mensaje, bool esError);
        void ActualizarPaginacion(int paginaActual, int totalPaginas);

        event EventHandler CargarDatos;
        event EventHandler CategoriaChanged;
        event EventHandler RegistrarDescargoClick;
        event EventHandler PaginaSiguienteClick;
        event EventHandler PaginaAnteriorClick;

    }
}
