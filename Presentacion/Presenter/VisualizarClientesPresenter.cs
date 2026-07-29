using Logica;
using Presentacion.View.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Presenter
{
    public class VisualizarClientesPresenter
    {
        private readonly IVisualizarClientesView _view;
        private readonly L_Clientes _logica;
        private readonly string _cedula;

        public VisualizarClientesPresenter(IVisualizarClientesView view, L_Clientes logica, string cedula)
        {
            _view = view;
            _logica = logica;
            _cedula = cedula;
            _view.VistaCargando += async (s, e) => await VistaCargando_Accion();
            _view.Volver += Volver_Accion;
        }

        private async Task VistaCargando_Accion()
        {
            try
            {
                _view.MostrarCargando();

                await Task.Delay(400);

                var cliente = await _logica.ObtenerCliente(_cedula);
                if (cliente == null)
                {
                    MessageBox.Show("No se encontró información del cliente.");
                    _view.CerrarVista();
                    return;
                }

                _view.Cedula = cliente.Cedula;
                _view.Nombre = cliente.Nombres;
                _view.Apellido = cliente.Apellidos;
                _view.Telefono = cliente.Telefono;
                _view.Correo = cliente.Correo;
                _view.Direccion = cliente.Direccion;
                _view.FotoEmpleado = cliente.Foto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del cliente: " + ex.Message);
            }
            finally
            {
                _view.OcultarCargando();
            }
        }

        private void Volver_Accion(object sender, EventArgs e)
        {
            _view.CerrarVista();
        }
    }
}