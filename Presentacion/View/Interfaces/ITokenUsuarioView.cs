using System;

namespace Presentacion.View.Interfaces
{

    public interface ITokenUsuarioView
    {
        string Codigo { get; set; }
        string NuevoUsuario { get; set; }
        string ConfirmarUsuario { get; set; }
        bool MostrarOpciones { get; set; }
        void CerrarVista();
        void MoverFormulario();
        void MostrarPanelOpciones();
        void MostrarEstado(string mensaje, TipoMensaje tipo);

        event EventHandler ValidarCodigo;
        event EventHandler CambiarUsuario;
        event EventHandler ArrastrarFormulario;
        event EventHandler VolverAlInicio;
    }
}