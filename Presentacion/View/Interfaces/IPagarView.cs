using System;

namespace Presentacion.View.Interfaces
{
    public interface IPagarView
    {
        string Nombre { set; }
        string Apellido { set; }
        string Cedula { set; }
        int IdCredito { get; set; }
        decimal SaldoPendiente { get; set; }
        string TipoPago { get; }
        int IdMoneda { get; }
        string MontoExtranjeroTexto { get; set; }
        decimal MontoExtranjeroValidado { get; }
        string MontoBsTexto { get; set; }

        void ConfigurarMontoSoloLectura(bool soloLectura);
        void MostrarMensaje(string mensaje);
        void CerrarVista(bool exitoso);

        event EventHandler TipoPagoCambiado;
        event EventHandler MonedaCambiada;
        event EventHandler MontoExtranjeroCambiado;
        event EventHandler RegistrarPago;
        event EventHandler Cancelar;
    }
}
