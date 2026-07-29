using System;

namespace Presentacion.View.Interfaces
{
    public interface IPagosView
    {
        string MesSeleccionado { get; }
        int AñoSeleccionado { get; set; }
        string TextoBusqueda { get; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        int Cedula { get; set; }
        string Telefono { get; }
        decimal Monto { get; set; }
        DateTime FechaPago { get; set; }
        string Estado { get; set; }
        int IdCredito { get; }
        int IdCliente { get; }
        decimal SaldoPendiente { get; }
        object DataSource { set; }
        void ActualizarPaginacionClientes(int paginaActual, int totalPaginas);
        void MostrarMensaje(string mensaje, bool esError);

        event EventHandler PaginaSiguienteClick;
        event EventHandler PaginaAnteriorClick;
        event EventHandler FiltrarDeudas;
        event EventHandler FiltroFechaCambiado;
        event EventHandler ActualizarPago;
        event EventHandler EliminarPago;
        event EventHandler CargarDeudas;
        event EventHandler EnviarComprobanteWhatsAppClick;
    }
}
