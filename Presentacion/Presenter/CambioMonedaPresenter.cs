using Logica;
using Presentacion.View.Interfaces;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Presentacion.Presenter
{
    public class CambioMonedaPresenter
    {
        private readonly ICambioMonedaView _view;
        private readonly L_Tasas _logica;

        public CambioMonedaPresenter(ICambioMonedaView view, L_Tasas logica)
        {
            _view = view;
            _logica = logica;

            _view.ViewLoaded += async (s, e) => await ViewLoaded_Accion();
            _view.GuardarTasa += async (s, e) => await GuardarTasa_Accion();
            _view.Cancelar += Cancelar_Accion;
        }

        private void Cancelar_Accion(object sender, EventArgs e)
        {
            _view.CerrarVista();
        }

        private async Task ViewLoaded_Accion()
        {
            try
            {
                DataTable dtMonedas = await _logica.ObtenerMonedas();

                DataView dv = dtMonedas.DefaultView;
                dv.RowFilter = "Nombre = 'Dólar' OR Nombre = 'Euro'";
                DataTable dtFiltrada = dv.ToTable();

                _view.CargarMonedas(dtFiltrada);
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje("Error al cargar las monedas: " + ex.Message, true);
            }
        }

        private async Task GuardarTasa_Accion()
        {
            if (_view.IdMonedaSeleccionada <= 0)
            {
                _view.MostrarMensaje("Seleccione una moneda.", true);
                return;
            }
            if (_view.MontoValidado <= 0)
            {
                _view.MostrarMensaje("Ingrese un valor de tasa válido (mayor a cero).", true);
                return;
            }
            try
            {
                var (exito, mensaje) = await _logica.GuardarOActualizarTasa(
                    _view.IdMonedaSeleccionada,
                    _view.MontoValidado,
                    DateTime.Today);

                _view.MostrarMensaje(mensaje, !exito);

                if (exito)
                {
                    _view.CerrarVista();
                }
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje("Error inesperado: " + ex.Message, true);
            }
        }
    }
}