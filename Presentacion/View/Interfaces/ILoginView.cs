using System;

namespace Presentacion.View.Interfaces
{
    public enum TipoMensaje
    {
        Exito,
        Error,
        Normal
    }
    public interface ILoginView
    {
        string Usuario { get; set; }
        string Contraseña { get; set; }
        bool SecurityContraseña { get; set; }
        bool MostrarOpciones { get; set; }
        void MoverFormulario();
        void MostrarEstado(string mensaje, TipoMensaje tipo);
        string OpcionRecuperacion { get; }
        void MostrarPanelOpciones();
        void OcultarPanelOpciones();
        void OcultarVista();

        event EventHandler IniciarSesion;
        event EventHandler MostrarContraseña;
        event EventHandler Cerrar;
        event EventHandler RecuperarCuenta;
        event EventHandler VolverAlInicio;
        event EventHandler ArrastrarFormulario;
        event EventHandler Siguiente;

        event EventHandler LoginLoad;
    }
}
