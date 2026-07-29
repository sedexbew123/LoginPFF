using Logica;
using Presentacion.View.Forms;
using Presentacion.View.Interfaces;
using System;
using System.IO;
using System.Windows.Forms;

namespace Presentacion.Presenter
{
    public class RegistroClientesPresenter
    {
        private readonly IRegistroClientesView _view;
        private readonly L_Clientes _logica;
        private byte[] _fotoCliente;

        public RegistroClientesPresenter(IRegistroClientesView view, L_Clientes clientes)
        {
            _view = view;
            _logica = clientes;
            _view.RegistrarClienteClick += RegistrarClienteClick_Accion;
            _view.LimpiarCamposClientesClick += LimpiarCamposClientes_Accion;
            _view.AgregarImagen += AgregarImagen_Accion;
            _view.TomarFoto += TomarFoto_Accion;
        }

        private void TomarFoto_Accion(object sender, EventArgs e)
        {
            using (var frmCaptura = new View.Forms.CapturaFotoClientes())
            {
                var presenterCaptura = new CapturaFotoClientesPresenter(frmCaptura);

                if (frmCaptura.ShowDialog() == DialogResult.OK && frmCaptura.FotoCapturada != null)
                {
                    _fotoCliente = frmCaptura.FotoCapturada;
                    _view.MostrarFotoGuardada = true;
                }
            }
        }

        private void AgregarImagen_Accion(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imágenes (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Seleccionar foto del cliente";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _fotoCliente = File.ReadAllBytes(ofd.FileName);
                        _view.MostrarFotoGuardada = true;
                    }
                    catch (Exception ex)
                    {
                        _view.MostrarMensaje("No se pudo cargar la imagen: " + ex.Message, false);
                    }
                }
            }
        }

        private void LimpiarCamposClientes_Accion(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private async void RegistrarClienteClick_Accion(object sender, EventArgs e)
        {
            var cliente = new Entidades.Clientes
            {
                Cedula = _view.Cedula,
                Nombres = _view.Nombre,
                Apellidos = _view.Apellido,
                Telefono = _view.Telefono,
                Correo = _view.Correo,
                Direccion = _view.Direccion,
                Foto = _fotoCliente
            };

            var respuesta = await _logica.GuardarCliente(cliente);
            _view.MostrarMensaje(respuesta.Mensaje, respuesta.Estado);

            if (respuesta.Estado)
            {
                _view.LimpiarCampos();
                _fotoCliente = null;
                _view.MostrarFotoGuardada = false;
            }
        }

        private void LimpiarCampos()
        {
            _view.Cedula = string.Empty;
            _view.Nombre = string.Empty;
            _view.Apellido = string.Empty;
            _view.Telefono = string.Empty;
            _view.Correo = string.Empty;
            _view.Direccion = string.Empty;
            _fotoCliente = null;
            _view.MostrarFotoGuardada = false;
        }
    }
}
