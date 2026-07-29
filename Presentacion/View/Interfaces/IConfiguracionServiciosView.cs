using System;
using System.Threading.Tasks;

namespace Presentacion.View.Interfaces
{
    public interface IConfiguracionServiciosView
    {
        string ServicioNombre { get; set; }
        string ServicioTipo { get; set; }
        decimal ServicioPrecio { get; set; }
        string ServicioDescripcion { get; set; }
        object ServiciosDataSource { set; }
        object TiposComboBoxDataSource { set; }
        bool ServicioEdicion { get; set; }


        string TipoNombre { get; set; }
        bool TipoEstado { get; set; }
        string TipoDescripcion { get; set; }
        object TiposDataSource { set; }
        bool TipoEdicion { get; set; }


        void LimpiarCamposServicio();
        void LimpiarCamposTipo();
        void MostrarMensaje(string mensaje, bool isError = false);
        bool ConfirmarAccion(string mensaje);

        event EventHandler GuardarServicio;
        event EventHandler EliminarServicio;
        event EventHandler SeleccionarServicio;

        event EventHandler GuardarTipo;
        event EventHandler EliminarTipo;
        event EventHandler SeleccionarTipo;
    }
}