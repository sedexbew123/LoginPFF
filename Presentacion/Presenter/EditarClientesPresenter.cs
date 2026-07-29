using Entidades;
using Logica;
using Presentacion.View.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Presenter
{
    public class EditarClientesPresenter
    {
        private readonly IEditarClientesView _view;
        private readonly L_Clientes logica = new L_Clientes();
        private byte[] _fotoCliente;

        public EditarClientesPresenter(IEditarClientesView view, L_Clientes logica)
        {
            _view = view;

            _view.Cerrar += Cerrar_Accion;
            _view.EditarCliente += EditarCliente_Accion;
            _view.Cancelar += Cancelar_Accion;
            _view.AgregarImagen += AgregarImagen_Accion;
            _view.TomarFoto += TomarFoto_Accion;
            this.logica = logica;
        }

        private void TomarFoto_Accion(object sender, EventArgs e)
        {
            using (var frmCaptura = new View.Forms.CapturaFotoClientes())
            {
                var presenterCaptura = new CapturaFotoClientesPresenter(frmCaptura);
                if (frmCaptura.ShowDialog() == DialogResult.OK && frmCaptura.FotoCapturada != null)
                {
                    _fotoCliente = frmCaptura.FotoCapturada;
                    _view.FotoEmpleado = _fotoCliente;      
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
                        _view.FotoEmpleado = _fotoCliente;  
                        _view.MostrarFotoGuardada = true;
                    }
                    catch (Exception ex)
                    {
                        _view.MostrarMensaje("No se pudo cargar la imagen: " + ex.Message);
                    }
                }
            }
        }

        private void Cerrar_Accion(object sender, EventArgs e)
        {
            _view.CerrarVista();
        }
        public async void InicializarFormulario(string cedula)
        {
            try
            {
                _view.MostrarCargando();
                await CargarFotoAsync(cedula);
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje("Error al inicializar los datos: " + ex.Message);
            }
            finally
            {
                _view.OcultarCargando();
            }
        }

        private async void EditarCliente_Accion(object sender, EventArgs e)
        {
            try
            {
                _view.MostrarCargando();

                await Task.Delay(400);

                var clienteEditado = new Clientes
                {
                    Cedula = _view.Cedula.ToString(),
                    Nombres = _view.Nombre,
                    Apellidos = _view.Apellido,
                    Telefono = _view.Telefono.ToString(),
                    Correo = _view.Correo,
                    Direccion = _view.Direccion,
                    Foto = _fotoCliente
                };

                var resultado = await logica.Editar(clienteEditado);

                if (resultado.Estado)
                {
                    _fotoCliente = null;
                    _view.MostrarFotoGuardada = false;

                    
                    _view.OcultarCargando();

                    MessageBox.Show(resultado.Mensaje, "Cliente actualizado con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _view.CerrarVista();
                }
                else
                {
                    _view.OcultarCargando();
                    MessageBox.Show(resultado.Mensaje, "Error al actualizar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _view.OcultarCargando();
                _view.MostrarMensaje("Ocurrió un error inesperado: " + ex.Message);
            }
        }

        public async Task CargarFotoAsync(string cedula)
        {
            {
                try
                {
                    _view.MostrarCargando();
                    var cliente = await logica.ObtenerCliente(cedula);
                    if (cliente != null && cliente.Foto != null)
                    {
                        _fotoCliente = cliente.Foto;
                        _view.FotoEmpleado = _fotoCliente;
                    }
                }
                catch (Exception ex)
                {
                    _view.MostrarMensaje("Error al cargar la foto: " + ex.Message);
                }
                finally
                {
                    _view.OcultarCargando();
                }
            }
        }

        private void Cancelar_Accion(object sender, EventArgs e)
        {
            _view.CerrarVista();
        }
    }
}