using System;

namespace Presentacion.View.Interfaces
{
    public interface ICapturaFotoView
    {
        byte[] FotoCapturada { get; set; }

        void MostrarListaCamaras(string[] nombresCamaras);
        void MostrarFramePreview(System.Drawing.Bitmap frame);
        void MostrarFotoCapturada(System.Drawing.Bitmap foto);
        void MostrarMensaje(string mensaje, string titulo, System.Windows.Forms.MessageBoxIcon icono);
        void CerrarVista(bool exito);
        int CamaraSeleccionada { get; }
        bool EnModoPreview { get; set; }

        event EventHandler VistaCargando;
        event EventHandler<int> CamaraCambiada;
        event EventHandler CapturarClick;
        event EventHandler ReintentarClick;
        event EventHandler AceptarClick;
        event EventHandler CancelarClick;
        event EventHandler VistaCerrando;
    }
}

