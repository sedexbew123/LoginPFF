using System;
using System.Data;

namespace Presentacion.View.Interfaces
{
    public interface ICambioMonedaView
    {
        int IdMonedaSeleccionada { get; }
        string MonedaSeleccionada { get; set; }
        string MontoTexto { get; set; }
        decimal MontoValidado { get; }

        void CargarMonedas(DataTable dt);
        void MostrarMensaje(string mensaje, bool esError);
        void CerrarVista();


        event EventHandler ViewLoaded;
        event EventHandler GuardarTasa;
        event EventHandler Cancelar;
    }
}
