using System;

namespace Presentacion.View.Interfaces
{
    public interface IListadoPagosView
    {
        string MesSeleccionado { get; }
        int AñoSeleccionado { get; set; }
        string TextoBusqueda { get; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        decimal Pago { get; set; }
        decimal PagoBs { get; set; }
        DateTime FechaPago { get; set; }
        string TipoPago { get; set; }
        string Moneda { get; set; }
        object DataSource { set; }
        void ActualizarPaginacion(int paginaActual, int totalPaginas);

        void MostrarGanancias(decimal totalUsd, decimal totalEur, decimal totalBs);

        event EventHandler PaginaSiguienteClick;
        event EventHandler PaginaAnteriorClick;
        event EventHandler FiltroFechaCambiado;
        event EventHandler CargarPagos;
        event EventHandler FiltrarPagos;
    }
}
