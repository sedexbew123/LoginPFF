using System;

namespace Presentacion.View.Interfaces
{
    public interface IInformesView
    {
        string ReporteSeleccionado { get; }
        string CedulaCliente { get; }
        DateTime FechaDesde { get; }
        DateTime FechaHasta { get; }

        bool SelectorClienteHabilitado { set; }

        void MostrarMensaje(string mensaje, bool esError);

        event EventHandler ReporteElegido;
        event EventHandler ExportarPDF;
        event EventHandler ExportarExcel;
    }
}
