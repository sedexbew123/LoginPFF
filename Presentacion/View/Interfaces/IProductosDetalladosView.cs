using System;

namespace Presentacion.View.Interfaces
{
    public interface IProductosDetalladosView
    {
        string MesSeleccionado { get; }
        int AñoSeleccionado { get; set; }
        string TipoOperacion { get; }
        string TextoBusqueda { get; }

        object HistorialDataSource { set; }

        void ActualizarPaginacion(int paginaActual, int totalPaginas);

        event EventHandler CargarHistorial;
        event EventHandler FiltroFechaCambiado;
        event EventHandler FiltroTipoChanged;
        event EventHandler FiltrarTexto;
        event EventHandler PaginaSiguienteClick;
        event EventHandler PaginaAnteriorClick;
    }
}
