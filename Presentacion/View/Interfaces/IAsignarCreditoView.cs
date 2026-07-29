using System;

namespace Presentacion.View.Interfaces
{
    public interface IAsignarCreditoView
    {
        string Cedula { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        decimal TotalPrecio { get; set; }
        DateTime FechaLimite { get; set; }
        void AgregarItemAlGrid(string cantidad, string producto,
                               string categoria, string precio);
        void EliminarItemSeleccionado();
        int ObtenerIndiceSeleccionado();

        void MostrarMensaje(string mensaje, bool esError = false);
        void LimpiarCampos();

        event EventHandler AgregarCreditoClick;
        event EventHandler AsignarCreditoClick;
        event EventHandler CedulaTextChanged;
    }
}