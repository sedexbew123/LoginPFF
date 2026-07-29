using Entidades;
using Logica;
using Presentacion.View.Forms;
using Presentacion.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentacion.Presenter
{
    public class DescargoProductoPresenter
    {
        private readonly IDescargoProductoView _view;
        private readonly L_Inventario _logica;

        private List<Productos> _productosMostrados = new List<Productos>();
        private int _paginaActual = 1;
        private const int RegistrosPorPagina = 10;

        public DescargoProductoPresenter(IDescargoProductoView view, L_Inventario logica)
        {
            _view = view;
            _logica = logica;

            _view.CargarDatos += async (s, e) => await CargarDatos();
            _view.CategoriaChanged += async (s, e) => await FiltrarProductos();
            _view.RegistrarDescargoClick += async (s, e) => await RegistrarDescargo();
            _view.PaginaSiguienteClick += (s, e) => CambiarPagina(1);
            _view.PaginaAnteriorClick += (s, e) => CambiarPagina(-1);
        }

        private async Task CargarDatos()
        {
            var tareaCategorias = _logica.ObtenerCategoriasParaFiltro();
            var tareaMotivos = _logica.ListarMotivos();
            var tareaProductos = _logica.ListarProductosActivos();

            await Task.WhenAll(tareaCategorias, tareaMotivos, tareaProductos);

            _view.SuspendUI();
            try
            {
                _view.CategoriasDataSource = tareaCategorias.Result;
                _view.MotivosDataSource = tareaMotivos.Result;

                _productosMostrados = tareaProductos.Result;
                _paginaActual = 1;
                MostrarPagina();
            }
            finally
            {
                _view.ResumeUI();
            }
        }

        private async Task FiltrarProductos()
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

        private async Task RegistrarDescargo()
        {
            string codigo = _view.ProductoCodigoSeleccionado;
            int cantidad = _view.CantidadSeleccionada;
            int idMotivo = _view.IdMotivoSeleccionado;

            if (string.IsNullOrEmpty(codigo))
            {
                _view.MostrarMensaje("Debe seleccionar un producto.", true);
                return;
            }
            if (cantidad <= 0)
            {
                _view.MostrarMensaje("La cantidad debe ser mayor a cero.", true);
                return;
            }
            if (idMotivo <= 0)
            {
                _view.MostrarMensaje("Debe seleccionar el motivo del descargo.", true);
                return;
            }

            var resultado = await _logica.RegistrarDescargo(codigo, cantidad, idMotivo);
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
