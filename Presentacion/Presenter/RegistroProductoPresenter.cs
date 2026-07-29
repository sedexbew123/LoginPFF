using Entidades;
using Logica;
using Presentacion.View.Forms;
using Presentacion.View.Interfaces;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Presenter
{
    public class RegistroProductoPresenter
    {
        private readonly IRegistroProductoView _view;
        private readonly L_Inventario _logica;

        private DataTable _tablaOriginal = new DataTable();
        private DataTable _tablaFiltrada = new DataTable();
        private int _paginaActual = 1;
        private const int RegistrosPorPagina = 10;

        public RegistroProductoPresenter(IRegistroProductoView view, L_Inventario inventario)
        {
            _view = view;
            _logica = inventario;

            _view.AgregarProductoClick += AgregarProducto_Accion;
            _view.EditarProductoClick += EditarProducto_Accion;
            _view.EliminarProductoClick += EliminarProducto_Accion;
            _view.CargarProductos += async (s, e) => await CargarTabla();
            _view.PaginaSiguienteClick += (s, e) => CambiarPagina(1);
            _view.PaginaAnteriorClick += (s, e) => CambiarPagina(-1);
            _view.FiltroFechaCambiado += FiltroFechaCambiado_Accion;
            _view.FiltrarProductos += FiltrarProductos_Accion;
        }

        private async System.Threading.Tasks.Task CargarTabla()
        {
            _tablaOriginal = await _logica.ListarTodosConPrecioBs();
            FiltrarYPaginar();
        }

        private void FiltrarProductos_Accion(object sender, EventArgs e)
        {
            FiltrarYPaginar();
        }

        private void FiltroFechaCambiado_Accion(object sender, EventArgs e)
        {
            FiltrarYPaginar();
        }


        private void FiltrarYPaginar()
        {
            if (_tablaOriginal == null) return;

            string texto = (_view.TextoBusqueda ?? "").Trim().ToLower();
            string estado = (_view.TipoOperacion ?? "").Trim();

            var rows = _tablaOriginal.AsEnumerable();

            if (!string.IsNullOrEmpty(texto))
                rows = rows.Where(r =>
                    r["Nombre"].ToString().ToLower().Contains(texto) ||
                    r["NombreCategoria"].ToString().ToLower().Contains(texto));

            if (!string.IsNullOrEmpty(estado) && !estado.Equals("Todos", StringComparison.OrdinalIgnoreCase))
                rows = rows.Where(r =>
                    r["EstadoVisual"].ToString().Equals(estado, StringComparison.OrdinalIgnoreCase));

            _tablaFiltrada = rows.Any()
                ? rows.CopyToDataTable()
                : _tablaOriginal.Clone();

            _paginaActual = 1;
            MostrarPagina();
        }

        private void CambiarPagina(int delta)
        {
            if (_tablaFiltrada == null) return;

            int total = Math.Max(1, (int)Math.Ceiling(_tablaFiltrada.Rows.Count / (double)RegistrosPorPagina));
            _paginaActual = Math.Max(1, Math.Min(_paginaActual + delta, total));
            MostrarPagina();
        }

        private void MostrarPagina()
        {
            if (_tablaFiltrada == null) return;

            int total = Math.Max(1, (int)Math.Ceiling(_tablaFiltrada.Rows.Count / (double)RegistrosPorPagina));

            var pagina = _tablaFiltrada.AsEnumerable()
                .Skip((_paginaActual - 1) * RegistrosPorPagina)
                .Take(RegistrosPorPagina);

            _view.DataSource = pagina.Any()
                ? pagina.CopyToDataTable()
                : _tablaFiltrada.Clone();

            _view.ActualizarPaginacionClientes(_paginaActual, total);
        }

        private void AgregarProducto_Accion(object sender, EventArgs e)
        {
            using (var frm = new NuevoProducto())
            {
                var presenter = new NuevoProductoPresenter(frm, _logica);
                if (frm.ShowDialog() == DialogResult.OK)
                    _ = CargarTabla();
            }
        }

        private void EditarProducto_Accion(object sender, EventArgs e)
        {
            var producto = _view.ProductoSeleccionado;
            if (producto == null)
            {
                _view.MostrarMensaje("Seleccione un producto de la lista.", true);
                return;
            }
            using (var frm = new NuevoProducto())
            {
                var presenter = new NuevoProductoPresenter(frm, _logica, producto);
                if (frm.ShowDialog() == DialogResult.OK)
                    _ = CargarTabla();
            }
        }

        private async void EliminarProducto_Accion(object sender, EventArgs e)
        {
            var producto = _view.ProductoSeleccionado;
            if (producto == null)
            {
                _view.MostrarMensaje("Seleccione un producto de la lista.", true);
                return;
            }

            var confirmacion = MessageBox.Show(
                $"¿Eliminar el producto \"{producto.Nombre}\"?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes) return;

            var respuesta = await _logica.Eliminar(producto.Codigo);
            _view.MostrarMensaje(respuesta.Mensaje, !respuesta.Estado);

            if (respuesta.Estado)
                await CargarTabla();
        }
    }
}
