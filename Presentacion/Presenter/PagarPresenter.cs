using Logica;
using Presentacion.View.Interfaces;
using System;
using System.Globalization;

namespace Presentacion.Presenter
{
    public class PagarPresenter
    {
        private readonly IPagarView _view;
        private readonly L_Tasas _logicaTasas;
        private readonly L_Pagos _logicaPagos;

        private decimal _tasaActual = 0m;
        private int? _idTasaActual = null;
        private decimal _tasaUsdEnBs = 0m;
        private decimal _tasaEurEnBs = 0m;

        public PagarPresenter(IPagarView view, L_Tasas tasas, L_Pagos pagos)
        {
            _view = view;
            _logicaTasas = tasas;
            _logicaPagos = pagos;

            _view.TipoPagoCambiado += TipoPagoCambiado_Accion;
            _view.MonedaCambiada += (s, e) => CargarTasaYConvertirAsync();
            _view.MontoExtranjeroCambiado += (s, e) => AplicarConversion();
            _view.RegistrarPago += RegistrarPago_Accion;
            _view.Cancelar += (s, e) => _view.CerrarVista(false);
        }

        private void TipoPagoCambiado_Accion(object sender, EventArgs e)
        {
            if (_view.TipoPago == "Completo")
            {
                AplicarMontoCompleto();
            }
            else
            {
                _view.MontoExtranjeroTexto = string.Empty;
                _view.MontoBsTexto = string.Empty;
                _view.ConfigurarMontoSoloLectura(false);
            }
        }

        private void AplicarMontoCompleto()
        {
            if (_view.IdMoneda == 2)
            {
                _view.MontoExtranjeroTexto = _view.SaldoPendiente.ToString("N2");
                _view.ConfigurarMontoSoloLectura(true);
                AplicarConversion();
                return;
            }

            if (_view.IdMoneda == 1)
            {
                _view.MontoExtranjeroTexto = _tasaActual > 0
                    ? (_view.SaldoPendiente * _tasaActual).ToString("N2")
                    : string.Empty;

                _view.ConfigurarMontoSoloLectura(false);
                AplicarConversion();
                return;
            }

            if (_view.IdMoneda == 3)
            {
                decimal tasaEurUsd = ObtenerTasaEurUsd();
                _view.MontoExtranjeroTexto = tasaEurUsd > 0
                    ? (_view.SaldoPendiente / tasaEurUsd).ToString("N2")
                    : string.Empty;

                _view.ConfigurarMontoSoloLectura(false);
                AplicarConversion();
                return;
            }

            _view.MontoExtranjeroTexto = string.Empty;
            _view.ConfigurarMontoSoloLectura(false);
        }

        private async void CargarTasaYConvertirAsync()
        {
            _view.MontoBsTexto = "...";
            _tasaActual = 0m;
            _idTasaActual = null;

            try
            {
                var tasaUsd = await _logicaTasas.ObtenerTasaConIdAsync(2);
                var tasaEur = await _logicaTasas.ObtenerTasaConIdAsync(3); 
                _tasaUsdEnBs = tasaUsd.Tasa;
                _tasaEurEnBs = tasaEur.Tasa;

                if (_view.IdMoneda == 1)
                {
                    _tasaActual = _tasaUsdEnBs;
                }
                else if (_view.IdMoneda == 2)
                {
                    _tasaActual = _tasaUsdEnBs;
                }
                else if (_view.IdMoneda == 3)
                {
                    _tasaActual = _tasaEurEnBs;
                }

                if (_tasaActual == 0)
                {
                    _view.MostrarMensaje(
                        "No hay tasa de cambio registrada para esta moneda.\n" +
                        "Registra una en el módulo Tasa antes de continuar.");
                    _view.MontoBsTexto = "Sin tasa";
                    return;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("CargarTasa error: " + ex.Message);
                _view.MontoBsTexto = "Error";
                return;
            }
            if (_view.TipoPago == "Completo")
                AplicarMontoCompleto();
            else
                AplicarConversion();
        }

        private decimal ConvertirAUsd(decimal monto, int idMoneda, decimal tasa)
        {
            if (idMoneda == 2) return monto;             
            if (idMoneda == 1) return tasa > 0 ? monto / tasa : 0; 
            if (idMoneda == 3) return monto * ObtenerTasaEurUsd();
            return 0;
        }

        private void AplicarConversion()
        {
            decimal monto = _view.MontoExtranjeroValidado;

            if (monto <= 0)
            {
                _view.MontoBsTexto = "0,00";
                return;
            }

            if (_view.IdMoneda == 2)
            {
                _view.MontoBsTexto = _tasaActual > 0 ? (monto * _tasaActual).ToString("N2") : "Sin tasa";
                return;
            }

            if (_view.IdMoneda == 1)
            {
                if (_tasaActual <= 0) { _view.MontoBsTexto = "Sin tasa"; return; }
                decimal equivalenteUsd = monto / _tasaActual;
                _view.MontoBsTexto = equivalenteUsd.ToString("N2") + " $";
                return;
            }

            if (_view.IdMoneda == 3)
            {
                decimal tasaEurUsd = ObtenerTasaEurUsd();
                decimal equivalenteUsd = monto * tasaEurUsd;
                _view.MontoBsTexto = equivalenteUsd.ToString("N2") + " $";
                return;
            }
        }

        private async void RegistrarPago_Accion(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_view.TipoPago)) { _view.MostrarMensaje("Seleccione el tipo de pago."); return; }
            if (_view.IdMoneda == 0) { _view.MostrarMensaje("Seleccione la moneda del pago."); return; }
            if (_view.MontoExtranjeroValidado <= 0) { _view.MostrarMensaje("Ingrese un monto válido mayor a 0."); return; }
            if (_view.IdMoneda != 2 && _tasaActual <= 0)
            {
                _view.MostrarMensaje("No hay tasa de cambio disponible. Regístrela en el módulo Tasa.");
                return;
            }

            decimal montoOriginal = _view.MontoExtranjeroValidado;
            decimal montoUsd = ConvertirAUsd(montoOriginal, _view.IdMoneda, _tasaActual);

            if (Math.Round(montoUsd, 2) > _view.SaldoPendiente)
            {
                _view.MostrarMensaje(
                    $"El pago equivale a {montoUsd:N2} $ y supera la deuda pendiente ({_view.SaldoPendiente:N2} $).");
                return;
            }

            decimal montoBs = _view.IdMoneda == 1 ? montoOriginal : montoOriginal * _tasaActual;

            var pago = new Entidades.Pagos
            {
                IdCredito = _view.IdCredito,
                Monto = montoUsd,
                MontoOriginal = montoOriginal,
                MontoBs = montoBs,
                FechaPago = DateTime.Now,
                TipoPago = _view.TipoPago,
                IdMoneda = _view.IdMoneda,
                IdTasa = _idTasaActual,
                Estado = _view.TipoPago == "Completo" ? "Pagado" : "Parcial",
                IdUsuario = Entidades.SesionUsuario.UsuarioLogueado.Id
            };

            try
            {
                int idPago = await _logicaPagos.RegistrarPagoAsync(pago, _view.SaldoPendiente);
                _view.MostrarMensaje("¡Pago registrado exitosamente!");
                _view.CerrarVista(true);
            }
            catch (ArgumentException argEx) { _view.MostrarMensaje(argEx.Message); }
            catch (Exception ex) { _view.MostrarMensaje("Error inesperado: " + ex.Message); }
        }

        private decimal ObtenerTasaEurUsd()
        {
            return _tasaEurEnBs > 0 && _tasaUsdEnBs > 0 ? _tasaEurEnBs / _tasaUsdEnBs : 0;
        }
    }
}