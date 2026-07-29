using System;

namespace Presentacion.View.Interfaces
{
    public interface IConsultaDeudaView
    {
        int IdCredito { get; }
        string Nombre { get; }
        string Apellido { get; }
        string Cedula { get; }
        string Telefono { get; }
        decimal Monto { get; }
        DateTime Fecha { get; }
        DateTime FechaLimite { get; }

        string TextoBusqueda { get; }
        string CriterioOrden { get; }

        object DataSource { set; }
        int TotalClientes { set; }
        decimal CreditoTotal { set; }
        int TotalProductos { set; }
        void MostrarMensaje(string mensaje, bool esError);
        void ActualizarPaginacionClientes(int paginaActual, int totalPaginas);

        event EventHandler PaginaSiguienteClick;
        event EventHandler PaginaAnteriorClick;
        event EventHandler BuscarDeuda;
        event EventHandler VerDetalleCliente;
        event EventHandler EnviarWhatsAppClick;
        event EventHandler CargarDeudas;
    }
}
