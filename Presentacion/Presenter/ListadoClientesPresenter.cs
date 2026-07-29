using Logica;
using Presentacion.View.Forms;
using Presentacion.View.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Presenter
{
    public class ListadoClientesPresenter
    {
        private readonly IListadoClientesView _view;
        private readonly L_Clientes _logica = new L_Clientes();

        private int _paginaActual = 1;
        private int _totalPaginas = 1;
        private int _clientePorPagina = 10;

        public ListadoClientesPresenter(IListadoClientesView view, L_Clientes clientes)
        {
            _view = view;
            _logica = clientes;
            _view.EditarClienteClick += EditarClienteClick_Accion;
            _view.VisualizarClientesClick += VisualizarClientesClick_Accion;
            _view.EliminarClienteClick += EliminarClienteClick_Accion;
            _view.CargarClientes += async (s, e) => await CargarTabla();
            _view.PaginaSiguienteClick += PaginaSiguienteClick_Accion;
            _view.PaginaAnteriorClick += PaginaAnteriorClick_Accion;
            _view.FiltrarClientes += FiltrarClientes_Accion;
        }

        private async void PaginaSiguienteClick_Accion(object sender, EventArgs e)
        {
            if (_paginaActual < _totalPaginas)
            {
                _paginaActual++;
                await CargarTabla();
            }
        }

        private async void PaginaAnteriorClick_Accion(object sender, EventArgs e)
        {
            if (_paginaActual > 1)
            {
                _paginaActual--;
                await CargarTabla();
            }
        }

        private void VisualizarClientesClick_Accion(object sender, EventArgs e)
        {
            var cliente = _view.ClienteSeleccionado;
            if (cliente == null)
            {
                _view.MostrarMensaje("Seleccione un cliente", true);
                return;
            }

            using (var frmVisualizar = new VisualizarClientes(cliente.Cedula))
            {
                frmVisualizar.ShowDialog();
            }
        }

        private async void FiltrarClientes_Accion(object sender, EventArgs e)
        {
            _paginaActual = 1;
            await CargarTabla();
        }

        private async Task CargarTabla()
        {
            try
            {
                var resultado = await _logica.Listar(_paginaActual, _clientePorPagina, _view.TextoBusqueda);
                _totalPaginas = resultado.TotalPaginas;

                _view.LlenarListadoClientes(resultado.clientes);
                _view.ActualizarPaginacionClientes(_paginaActual, _totalPaginas);
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje("Error al cargar clientes: " + ex.Message, true);
            }
        }

        private async void EditarClienteClick_Accion(object sender, EventArgs e)
        {
            var cliente = _view.ClienteSeleccionado;
            if (cliente == null)
            {
                _view.MostrarMensaje("Seleccione un cliente", true);
                return;
            }

            using (var frmEditar = new EditarClientes(cliente))
            {
                if (frmEditar.ShowDialog() == DialogResult.OK)
                {
                    await CargarTabla();
                }
            }
        }

        private async void EliminarClienteClick_Accion(object sender, EventArgs e)
        {
            var seleccionado = _view.ClienteSeleccionado;
            if (seleccionado == null) return;

            if (MessageBox.Show($"¿Eliminar a {seleccionado.Nombres}?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var respuesta = await _logica.Eliminar(seleccionado.Cedula);
                _view.MostrarMensaje(respuesta.Mensaje, !respuesta.Estado);
                if (respuesta.Estado) await CargarTabla();
            }
        }
    }
}