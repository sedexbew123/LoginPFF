using Logica;
using Presentacion.View.Interfaces;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Presenter
{
    public class TasaDolarPresenter
    {
        private readonly ITasaDolarView _view;
        private readonly L_Tasas _logica;

        private DataTable _dtTasas;           
        private DataTable _dtTasasFiltradas;   

        private const int TamanoPagina = 15;
        private int _paginaActual = 1;

        public TasaDolarPresenter(ITasaDolarView view, L_Tasas logica)
        {
            _view = view;
            _logica = logica;

            _view.ViewLoaded += async (s, e) => await ViewLoaded_Accion();
            _view.EditarTasa += async (s, e) => await EditarTasa_Accion();
            _view.FiltrarTasas += (s, e) => FiltrarTasas_Accion();
            _view.PaginaSiguienteClick += PaginaSiguienteClick_Accion;
            _view.PaginaAnteriorClick += PaginaAnteriorClick_Accion;
        }

        private void PaginaAnteriorClick_Accion(object sender, EventArgs e)
        {
            if (_paginaActual <= 1) return;
            _paginaActual--;
            MostrarPaginaActual();
        }

        private void PaginaSiguienteClick_Accion(object sender, EventArgs e)
        {
            if (_paginaActual >= ObtenerTotalPaginas()) return;
            _paginaActual++;
            MostrarPaginaActual();
        }

        private async Task ViewLoaded_Accion()
        {
            try
            {
                await ActualizarTasasApiAsync();
                await CargarGridAsync();
            }
            catch (Exception ex)
            {
                _view.MostrarEstadoApi("Error al inicializar la pantalla.", EstadoApi.Error);
                System.Diagnostics.Debug.WriteLine("[TasaDolarPresenter] OnViewLoaded: " + ex.Message);
            }
        }

        private async Task ActualizarTasasApiAsync()
        {
            try
            {
                _view.MostrarEstadoApi("Verificando tasas del día...", EstadoApi.Cargando);

                using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(20)))
                {
                    var (actualizado, mensaje) = await _logica.ActualizarTasasDesdeApi(cts.Token);
                    _view.MostrarEstadoApi(mensaje, actualizado ? EstadoApi.Exito : EstadoApi.AlDia);
                }
            }
            catch (OperationCanceledException)
            {
                _view.MostrarEstadoApi("Tiempo de espera agotado. Usando tasas guardadas.", EstadoApi.Error);
            }
            catch (Exception ex)
            {
                _view.MostrarEstadoApi("No se pudo conectar a la API.", EstadoApi.Error);
                System.Diagnostics.Debug.WriteLine("[TasaDolarPresenter] API: " + ex.Message);
            }
        }

        private async Task CargarGridAsync()
        {
            try
            {
                _dtTasas = await _logica.ListarTasas();
                _dtTasasFiltradas = _dtTasas;
                _paginaActual = 1;
                MostrarPaginaActual();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar las tasas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrarTasas_Accion()
        {
            if (_dtTasas == null) return;

            try
            {
                string filtro =
                    $"Descripcion LIKE '%{EscaparFiltro(_view.DescripcionBuscar)}%' " +
                    $"AND NombreMoneda LIKE '%{EscaparFiltro(_view.MonedaBuscar)}%'";

                DataView dv = new DataView(_dtTasas) { RowFilter = filtro };
                _dtTasasFiltradas = dv.ToTable();
                _paginaActual = 1;
                MostrarPaginaActual();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("[TasaDolarPresenter] Filtro: " + ex.Message);
            }
        }

        private void MostrarPaginaActual()
        {
            if (_dtTasasFiltradas == null) return;

            int totalPaginas = ObtenerTotalPaginas();
            if (_paginaActual > totalPaginas) _paginaActual = totalPaginas;
            if (_paginaActual < 1) _paginaActual = 1;

            DataTable dtPagina = ObtenerPagina(_dtTasasFiltradas, _paginaActual, TamanoPagina);

            _view.CargarTasas(dtPagina);
            _view.ActualizarPaginacionClientes(_paginaActual, totalPaginas);
        }

        private static DataTable ObtenerPagina(DataTable origen, int pagina, int tamanoPagina)
        {
            DataTable resultado = origen.Clone();

            var filas = origen.AsEnumerable()
                               .Skip((pagina - 1) * tamanoPagina)
                               .Take(tamanoPagina);

            foreach (DataRow fila in filas)
                resultado.ImportRow(fila);

            return resultado;
        }

        private int ObtenerTotalPaginas()
        {
            if (_dtTasasFiltradas == null || _dtTasasFiltradas.Rows.Count == 0) return 1;
            return (int)Math.Ceiling(_dtTasasFiltradas.Rows.Count / (double)TamanoPagina);
        }

        private static string EscaparFiltro(string valor) => (valor ?? string.Empty).Trim().Replace("'", "''");

        private async Task EditarTasa_Accion()
        {
            using (var vista = new View.Forms.CambioMoneda())
            {
                var presenter = new CambioMonedaPresenter(vista, _logica);
                vista.ShowDialog();
            }

            await CargarGridAsync();
        }
    }
}