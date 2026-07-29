using System;

namespace Presentacion.View.Interfaces
{
    public interface ICambiarContraseñaView
    {
        string ContraseñaActual { get; set; }
        string NuevaContraseña { get; set; }
        string ConfirmarContraseña { get; set; }
        bool SecurityContraseñaActual { get; set; }
        bool SecurityNuevaContraseña { get; set; }
        bool SecurityConfirmarContraseña { get; set; }
        void MostrarMensaje(string mensaje, bool esError);
        void CerrarVista();

        event EventHandler Cerrar;
        event EventHandler CambiarContraseñaActual;
        event EventHandler MostrarContraseña;
    }
}