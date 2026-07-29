using Logica;
using Presentacion.View.Interfaces;
using System;
using System.Data;
using System.Linq;

namespace Presentacion.Presenter
{
    public class ListadoPagosPresenter
    {
        private readonly IListadoPagosView _view;
        private readonly L_Pagos _logica = new L_Pagos();

        private DataTable _tablaOriginal;
        private DataTable _tablaFiltrada;
        private int _paginaActual = 1;
        private const int PageSize = 10;

        private static readonly string[] NombresMeses =
        {
            "Enero","Febrero","Marzo","Abril","Mayo","Junio",
            "Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre"
        };

        public ListadoPagosPresenter(IListadoPagosView view, L_Pagos logica)
        {
            _view = view;
            _logica = logica;

            _view.CargarPagos += (s, e) => CargarTablaAsync();
            _view.FiltroFechaCambiado += (s, e) => CargarTablaAsync();
            _view.FiltrarPagos += (s, e) => FiltrarYPaginar();
            _view.PaginaSiguienteClick += (s, e) => CambiarPagina(+1);
            _view.PaginaAnteriorClick += (s, e) => CambiarPagina(-1);
        }

        private async void CargarTablaAsync()
        {
            int mes = ObtenerNumeroMes(_view.MesSeleccionado);
            int año = _view.AñoSeleccionado;

            var tareaHistorial = _logica.ObtenerHistorialPagosAsync(mes, año);
            var tareaGanancias = _logica.ObtenerGananciasMensualesAsync(mes, año);

            _tablaOriginal = await tareaHistorial;
            DataTable ganancias = await tareaGanancias;

            ActualizarResumenGanancias(ganancias);
            FiltrarYPaginar();
        }

        private void ActualizarResumenGanancias(DataTable ganancias)
        {
            decimal totalUsdReal = 0m; 
            decimal totalEurReal = 0m; 
            decimal totalBs = 0m;      

            foreach (DataRow fila in ganancias.Rows)
            {
                int idMoneda = Convert.ToInt32(fila["IdMoneda"]);     
                decimal montoOriginal = Convert.ToDecimal(fila["TotalMoneda"]);
                decimal totalBsDeEstaMoneda = Convert.ToDecimal(fila["TotalBs"]);

                switch (idMoneda)
                {
                    case 1: totalBs += montoOriginal; break;
                    case 2: totalUsdReal += montoOriginal; break; 
                    case 3: totalEurReal += montoOriginal; break; 
                                                                 
                }
            }

            _view.MostrarGanancias(totalUsdReal, totalEurReal, totalBs);
        }

        private void FiltrarYPaginar()
        {
            if (_tablaOriginal == null) return;

            string texto = (_view.TextoBusqueda ?? "").Trim().ToLower();
            var rows = _tablaOriginal.AsEnumerable();

            if (!string.IsNullOrEmpty(texto))
                rows = rows.Where(r =>
                    r["Nombre"].ToString().ToLower().Contains(texto) ||
                    r["Apellido"].ToString().ToLower().Contains(texto) ||
                    r["Cedula"].ToString().Contains(texto));

            _tablaFiltrada = rows.Any()
                ? rows.CopyToDataTable()
                : _tablaOriginal.Clone();

            _paginaActual = 1;
            MostrarPaginaActual();
        }

        private void MostrarPaginaActual()
        {
            if (_tablaFiltrada == null) return;

            int total = _tablaFiltrada.Rows.Count;
            int totalPaginas = Math.Max(1, (int)Math.Ceiling(total / (double)PageSize));

            var pagina = _tablaFiltrada.AsEnumerable()
                .Skip((_paginaActual - 1) * PageSize)
                .Take(PageSize);

            _view.DataSource = pagina.Any()
                ? pagina.CopyToDataTable()
                : _tablaFiltrada.Clone();

            _view.ActualizarPaginacion(_paginaActual, totalPaginas);
        }

        private void CambiarPagina(int delta)
        {
            if (_tablaFiltrada == null) return;

            int totalPaginas = Math.Max(1,
                (int)Math.Ceiling(_tablaFiltrada.Rows.Count / (double)PageSize));

            _paginaActual = Math.Max(1, Math.Min(_paginaActual + delta, totalPaginas));
            MostrarPaginaActual();
        }

        private static int ObtenerNumeroMes(string nombre)
        {
            int idx = Array.IndexOf(NombresMeses, nombre?.Trim() ?? "");
            return idx >= 0 ? idx + 1 : 0;
        }
    }
}
