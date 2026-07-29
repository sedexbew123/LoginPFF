using System;

namespace Presentacion.View.Interfaces
{
    public interface ITokenContraseñaView
    {
        string Codigo { get; set; }
        string Contraseña1 { get; set; }
        string Contraseña2 { get; set; }
        bool SecurityContraseña { get; set; }
        bool SecurityContraseña2 { get; set; }

        bool MostrarOpciones { get; set; }
        void CerrarVista();
        void MostrarPanelOpciones();
        void MostrarEstado(string mensaje, TipoMensaje tipo);
        void MoverFormulario();

        event EventHandler CambiarContraseña;
        event EventHandler ValidarCodigo;
        event EventHandler MostrarContraseña;
        event EventHandler ArrastrarFormulario;
        event EventHandler VolverAlInicio;
    }
}
