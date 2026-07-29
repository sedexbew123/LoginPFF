using System;

namespace Presentacion.View.Interfaces
{

    public interface IRecuperarUsuarioView
    {
        string Correo { get; set; }
        void CerrarVista();
        void OcultarVista();
        void MoverFormulario();
        void MostrarEstado(string mensaje, TipoMensaje tipo);
        event EventHandler EnviarCodigo;
        event EventHandler Cerrar;
        event EventHandler ArrastrarFormulario;
        event EventHandler VolverAlInicio;
    }
}
