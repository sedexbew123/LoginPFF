using Entidades;
using Logica;
using Presentacion.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentacion.Presenter
{
    public class CargoProductoPresenter
    {
        private readonly ICargoProductoView _view;
        private readonly L_Inventario _logica;

        private List<Productos> _productosMostrados = new List<Productos>();
        private int _paginaActual = 1;
        private const int RegistrosPorPagina = 10;

        public CargoProductoPresenter(ICargoProductoView view, L_Inventario logica)
        {
            _view = view;
            _logica = logica;

            _view.CargarDatos += async (s, e) => await CargarDatos();
            _view.CategoriaChanged += async (s, e) => await FiltrarProductosPorCategoria();
            _view.RegistrarCargoClick += async (s, e) => await RegistrarCargo();
            _view.PaginaSiguienteClick += (s, e) => CambiarPagina(1);
            _view.PaginaAnteriorClick += (s, e) => CambiarPagina(-1);
        }

        private async Task CargarDatos()
        {
            var categorias = await _logica.ObtenerCategoriasParaFiltro();
            _view.CategoriasDataSource = categorias;

            await CargarProductos(0);
        }

        private async Task FiltrarProductosPorCategoria()
        {
            int idCategoria = _view.CategoriaIdSeleccionada;
            await CargarProductos(idCategoria);
        }

        private async Task CargarProductos(int idCategoria)
        {
            _productosMostrados = idCategoria > 0
                ? await _logica.ListarProductosPorCategoria(idCategoria)
                : await _logica.ListarProductosActivos();

            _paginaActual = 1;
            MostrarPagina();
        }

        private async Task RegistrarCargo()
        {
            string codigo = _view.ProductoCodigoSeleccionado;
            int cantidad = _view.CantidadSeleccionada;

            if (string.IsNullOrEmpty(codigo))
            {
                _view.MostrarMensaje("Debe seleccionar un producto de la tabla.", true);
                return;
            }
            if (cantidad <= 0)
            {
                _view.MostrarMensaje("La cantidad debe ser mayor a cero.", true);
                return;
            }

            var resultado = await _logica.RegistrarCargo(codigo, cantidad);
            _view.MostrarMensaje(resultado.Mensaje, !resultado.Estado);

            if (resultado.Estado)
            {
                _view.LimpiarCampos();
                await CargarProductos(_view.CategoriaIdSeleccionada);
            }
        }

        private void CambiarPagina(int delta)
        {
            int total = Math.Max(1, (int)Math.Ceiling(_productosMostrados.Count / (double)RegistrosPorPagina));
            _paginaActual = Math.Max(1, Math.Min(_paginaActual + delta, total));
            MostrarPagina();
        }

        private void MostrarPagina()
        {
            int total = Math.Max(1, (int)Math.Ceiling(_productosMostrados.Count / (double)RegistrosPorPagina));
            var pagina = _productosMostrados
                .Skip((_paginaActual - 1) * RegistrosPorPagina)
                .Take(RegistrosPorPagina)
                .ToList();

            _view.ProductosDataSource = pagina;
            _view.ActualizarPaginacion(_paginaActual, total);
        }
    }
}
