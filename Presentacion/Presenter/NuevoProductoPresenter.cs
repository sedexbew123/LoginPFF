using Entidades;
using Logica;
using Presentacion.View.Interfaces;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Presenter
{
    public class NuevoProductoPresenter
    {
        private readonly INuevoProductoView _view;
        private readonly L_Inventario _logica;
        private readonly Productos _productoEditar;
        private readonly bool _modoEdicion;

        public NuevoProductoPresenter(INuevoProductoView view, L_Inventario logica)
        {
            _view = view;
            _logica = logica;
            _modoEdicion = false;

            SuscribirEventos();
        }

        public NuevoProductoPresenter(INuevoProductoView view, L_Inventario logica, Productos producto)
        {
            _view = view;
            _logica = logica;
            _productoEditar = producto;
            _modoEdicion = true;

            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _view.VistaCargando += VistaCargando_Accion;
            _view.RegistrarProducto += RegistrarClick_Accion;
            _view.Cancelar += Cancelar_Accion;
        }

        private void Cancelar_Accion(object sender, EventArgs e)
        {
            _view.CerrarVista(DialogResult.Cancel);
        }

        private async void VistaCargando_Accion(object sender, EventArgs e)
        {
            try
            {

                if (_modoEdicion)
                {
                    _view.MostrarCargando();
                    await Task.Delay(400); 
                }

                DataTable dtCategorias = await _logica.ObtenerCategoriasActivas();
                _view.CategoriasDataSource = dtCategorias;

                _view.IdCategoriaSeleccionada = null;

                if (_modoEdicion && _productoEditar != null)
                {
                    _view.BloquearCodigo(true);

                    _view.Codigo = _productoEditar.Codigo;
                    _view.NombreProducto = _productoEditar.Nombre;
                    _view.IdCategoriaSeleccionada = _productoEditar.IdCategoria;
                    _view.Precio = (decimal)_productoEditar.Precio;
                    _view.StockActual = _productoEditar.StockActual;
                }
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje($"Error al cargar catálogos: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
            finally
            {
                if (_modoEdicion)
                {
                    _view.OcultarCargando();
                }
            }
        }

        private async void RegistrarClick_Accion(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_view.Codigo) || string.IsNullOrWhiteSpace(_view.NombreProducto))
            {
                _view.MostrarMensaje("Por favor complete los campos obligatorios.", "Validación", MessageBoxIcon.Warning);
                return;
            }

            if (_view.IdCategoriaSeleccionada == null)
            {
                _view.MostrarMensaje("Por favor, seleccione una categoría válida.", "Validación", MessageBoxIcon.Warning);
                return;
            }

            var producto = new Productos
            {
                Codigo = _view.Codigo.ToUpper(),
                Nombre = _view.NombreProducto,
                IdCategoria = Convert.ToInt32(_view.IdCategoriaSeleccionada),
                NombreCategoria = _view.NombreCategoriaSeleccionada,
                Precio = _view.Precio,
                StockActual = _view.StockActual,
                Estado = "Activo"
            };

            try
            {
                Solicitud respuesta = _modoEdicion
                    ? await _logica.Editar(producto)
                    : await _logica.GuardarProducto(producto);

                if (respuesta.Estado)
                {
                    _view.MostrarMensaje(respuesta.Mensaje, "Inventario", MessageBoxIcon.Information);
                    _view.CerrarVista(DialogResult.OK);
                }
                else
                {
                    _view.MostrarMensaje(respuesta.Mensaje, "Error", MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje($"Error en la transacción: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }
    }
}
