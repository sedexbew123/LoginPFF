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
    public class AsignarCreditoPresenter
    {
        private readonly IAsignarCreditoView _view;
        private readonly L_Creditos _logica;
        private readonly List<ItemCredito> _items = new List<ItemCredito>();

        public AsignarCreditoPresenter(IAsignarCreditoView view, L_Creditos logica)
        {
            _view = view;
            _logica = logica;

            _view.CedulaTextChanged += async (s, e) => await CedulaChanged_Accion();
            _view.AgregarCreditoClick += (s, e) => AgregarCredito_Accion();
            _view.AsignarCreditoClick += async (s, e) => await AsignarCredito_Accion();
        }

        private async Task CedulaChanged_Accion()
        {
            string cedula = _view.Cedula.Trim();
            if (cedula.Length < 6)
            {
                _view.Nombre = string.Empty;
                _view.Apellido = string.Empty;
                return;
            }
            try
            {
                var cliente = await _logica.BuscarPorCedula(cedula);
                _view.Nombre = cliente?.Nombres ?? string.Empty;
                _view.Apellido = cliente?.Apellidos ?? string.Empty;
            }
            catch
            {

            }
        }

        private void AgregarCredito_Accion()
        {
            using (var frm = new AgregarDeuda(_logica))
            {
                var presenter = new AgregarDeudaPresenter(frm, _logica, _items);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK
                    && presenter.ItemSeleccionado != null)
                {
                    var item = presenter.ItemSeleccionado;
                    _items.Add(item);
                    _view.AgregarItemAlGrid(
                        item.Cantidad.ToString(),
                        item.NombreProducto,
                        item.Categoria,
                        item.Subtotal.ToString("N2") + " $");
                    _view.TotalPrecio = _items.Sum(i => i.Subtotal);
                }
            }
        }

        private async Task AsignarCredito_Accion()
        {
            if (string.IsNullOrWhiteSpace(_view.Cedula))
            {
                _view.MostrarMensaje("Ingrese la cédula del cliente.", true);
                return;
            }
            if (string.IsNullOrWhiteSpace(_view.Nombre))
            {
                _view.MostrarMensaje("Cliente no encontrado. Verifique la cédula.", true);
                return;
            }
            if (_items.Count == 0)
            {
                _view.MostrarMensaje("Agregue al menos un producto al crédito.", true);
                return;
            }

            try
            {
                var (exito, mensaje) = await _logica.AsignarCredito(
                    _view.Cedula,
                    _items,
                    Entidades.SesionUsuario.UsuarioLogueado.Id  
                );

                if (exito)
                {
                    _items.Clear();
                    _view.LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje("Error inesperado: " + ex.Message, true);
            }
        }
    }
}