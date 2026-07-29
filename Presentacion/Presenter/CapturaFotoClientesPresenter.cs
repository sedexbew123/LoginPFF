using AForge.Video;
using AForge.Video.DirectShow;
using Presentacion.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Presenter
{
    public class CapturaFotoClientesPresenter
    {
        private readonly ICapturaFotoClientesView _view;
        private FilterInfoCollection _camaras;
        private VideoCaptureDevice _dispositivoActual;
        private Bitmap _ultimoFrame;
        private Bitmap _fotoCongelada;

        public CapturaFotoClientesPresenter(ICapturaFotoClientesView view)
        {
            _view = view;

            _view.VistaCargando += VistaCargando_Accion;
            _view.CamaraCambiada += CamaraCambiada_Accion;
            _view.CapturarClick += CapturarClick_Accion;
            _view.ReintentarClick += ReintentarClick_Accion;
            _view.AceptarClick += AceptarClick_Accion;
            _view.CancelarClick += CancelarClick_Accion;
            _view.VistaCerrando += VistaCerrando_Accion;
        }

        private void VistaCargando_Accion(object sender, EventArgs e)
        {
            try
            {
                _camaras = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (_camaras.Count == 0)
                {
                    _view.MostrarMensaje(
                        "No se detectó ninguna cámara conectada.",
                        "Sin cámara",
                        MessageBoxIcon.Warning);
                    return;
                }

                string[] nombres = new string[_camaras.Count];
                for (int i = 0; i < _camaras.Count; i++)
                    nombres[i] = _camaras[i].Name;

                _view.MostrarListaCamaras(nombres);
                IniciarCamara(0);
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje(
                    "No se pudo acceder a la cámara: " + ex.Message,
                    "Error",
                    MessageBoxIcon.Error);
            }
        }

        private void CamaraCambiada_Accion(object sender, int indice)
        {
            IniciarCamara(indice);
        }

        private void IniciarCamara(int indice)
        {
            if (_camaras == null || indice < 0 || indice >= _camaras.Count) return;

            DetenerCamara();

            var nuevoDispositivo = new VideoCaptureDevice(_camaras[indice].MonikerString);
            nuevoDispositivo.NewFrame += Dispositivo_NewFrame;

            _dispositivoActual = nuevoDispositivo;
            _dispositivoActual.Start();

            _view.EnModoPreview = true;
        }

        private void Dispositivo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (!ReferenceEquals(sender, _dispositivoActual))
                return;

            Bitmap frame;
            try
            {
                frame = (Bitmap)eventArgs.Frame.Clone();
            }
            catch
            {
                return;
            }

            if (!(_view is Control control) || control.IsDisposed || !control.IsHandleCreated)
            {
                frame.Dispose();
                return;
            }

            try
            {
                control.BeginInvoke(new Action(() =>
                {
                    if (control.IsDisposed || !ReferenceEquals(sender, _dispositivoActual))
                    {
                        frame.Dispose();
                        return;
                    }

                    try
                    {
                        _ultimoFrame?.Dispose();
                        _ultimoFrame = (Bitmap)frame.Clone();
                        _view.MostrarFramePreview(frame);
                    }
                    catch (ArgumentException)
                    {
                        frame.Dispose();
                    }
                }));
            }
            catch (InvalidOperationException)
            {
                frame.Dispose();
            }

        }

        private void CapturarClick_Accion(object sender, EventArgs e)
        {
            if (_ultimoFrame == null)
            {
                _view.MostrarMensaje("Aún no hay imagen de la cámara para capturar.", "Aviso", MessageBoxIcon.Warning);
                return;
            }

            _fotoCongelada?.Dispose();
            _fotoCongelada = (Bitmap)_ultimoFrame.Clone();

            DetenerCamara();

            _view.EnModoPreview = false;
            _view.MostrarFotoCapturada(_fotoCongelada);
        }

        private void ReintentarClick_Accion(object sender, EventArgs e)
        {
            _fotoCongelada?.Dispose();
            _fotoCongelada = null;

            IniciarCamara(_view.CamaraSeleccionada);
        }

        private void AceptarClick_Accion(object sender, EventArgs e)
        {
            if (_fotoCongelada == null)
            {
                _view.MostrarMensaje("Capture una foto antes de aceptar.", "Aviso", MessageBoxIcon.Warning);
                return;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                _fotoCongelada.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                _view.FotoCapturada = ms.ToArray();
            }

            DetenerCamara();
            _view.CerrarVista(true);
        }

        private void CancelarClick_Accion(object sender, EventArgs e)
        {
            DetenerCamara();
            _view.CerrarVista(false);
        }

        private void VistaCerrando_Accion(object sender, EventArgs e)
        {
            DetenerCamara();
            _ultimoFrame?.Dispose();
            _ultimoFrame = null;
            _fotoCongelada?.Dispose();
            _fotoCongelada = null;
        }

        private void DetenerCamara()
        {
            var dispositivoPrevio = _dispositivoActual;
            _dispositivoActual = null;

            if (dispositivoPrevio != null)
            {
                dispositivoPrevio.NewFrame -= Dispositivo_NewFrame;

                if (dispositivoPrevio.IsRunning)
                {
                    dispositivoPrevio.SignalToStop();
                    dispositivoPrevio.WaitForStop();
                }
            }
        }
    }
}
