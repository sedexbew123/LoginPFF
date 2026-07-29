using Entidades;
using Logica;
using Presentacion.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentacion.Presenter
{
    public class ProductosDetalladosPresenter
    {
        private readonly IProductosDetalladosView _view;
        private readonly L_Inventario _logica = new L_Inventario();
        private List<OperacionInventario> _historialCompleto = new List<OperacionInventario>();
        private List<OperacionInventario> _historialFiltrado = new List<OperacionInventario>();
        private int _paginaActual = 1;
        private const int RegistrosPorPagina = 10;

        private static readonly string[] NombresMeses =
        {
            "Enero","Febrero","Marzo","Abril","Mayo","Junio",
            "Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre"
        };

        public ProductosDetalladosPresenter(IProductosDetalladosView view, L_Inventario logica)
        {
            _view = view;
            _logica = logica;

            _view.CargarHistorial += async (s, e) => await CargarHistorial();
            _view.FiltroTipoChanged += (s, e) => AplicarFiltros();
            _view.FiltrarTexto += (s, e) => AplicarFiltros();
            _view.PaginaSiguienteClick += (s, e) => CambiarPagina(1);
            _view.PaginaAnteriorClick += (s, e) => CambiarPagina(-1);
            _view.FiltroFechaCambiado += FiltroFechaCambiado_Accion;
        }

        private void FiltroFechaCambiado_Accion(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private async Task CargarHistorial()
        {
            _historialCompleto = await _logica.ListarHistorialOperaciones();
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            if (_historialCompleto == null) return;

            string tipo = _view.TipoOperacion;
            if (string.Equals(tipo, "Todos", StringComparison.OrdinalIgnoreCase))
                tipo = string.Empty;

            string texto = (_view.TextoBusqueda ?? string.Empty).ToLower();

            int mes = ObtenerNumeroMes(_view.MesSeleccionado);
            int año = _view.AñoSeleccionado;

            _historialFiltrado = _historialCompleto
                .Where(o =>
                    (string.IsNullOrEmpty(tipo) || o.Tipo == tipo) &&
                    (string.IsNullOrEmpty(texto) ||
                     o.Producto.ToLower().Contains(texto) ||
                     o.Categoria.ToLower().Contains(texto)) &&
                    (mes == 0 || o.Fecha.Month == mes) &&
                    (año <= 0 || o.Fecha.Year == año))
                .ToList();

            _paginaActual = 1;
            MostrarPagina();
        }

        private static int ObtenerNumeroMes(string nombre)
        {
            int idx = Array.IndexOf(NombresMeses, nombre?.Trim() ?? "");
            return idx >= 0 ? idx + 1 : 0;
        }

        private void CambiarPagina(int delta)
        {
            int total = Math.Max(1,
                (int)Math.Ceiling(_historialFiltrado.Count / (double)RegistrosPorPagina));
            _paginaActual = Math.Max(1, Math.Min(_paginaActual + delta, total));
            MostrarPagina();
        }

        private void MostrarPagina()
        {
            int total = Math.Max(1,
                (int)Math.Ceiling(_historialFiltrado.Count / (double)RegistrosPorPagina));
            var pagina = _historialFiltrado
                .Skip((_paginaActual - 1) * RegistrosPorPagina)
                .Take(RegistrosPorPagina).ToList();

            _view.HistorialDataSource = pagina;
            _view.ActualizarPaginacion(_paginaActual, total);
        }
    }
}