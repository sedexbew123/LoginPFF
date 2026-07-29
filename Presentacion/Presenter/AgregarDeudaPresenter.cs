using Entidades;
using Logica;
using Presentacion.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Presentacion.Presenter
{
    public class AgregarDeudaPresenter
    {
        private readonly IAgregarDeudaView _view;
        private readonly L_Creditos _logica;
        private readonly List<ItemCredito> _itemsActuales;

        public ItemCredito ItemSeleccionado { get; private set; }

        public AgregarDeudaPresenter(IAgregarDeudaView view, L_Creditos logica, List<ItemCredito> itemsActuales = null)
        {
            _view = view;
            _logica = logica;
            _itemsActuales = itemsActuales ?? new List<ItemCredito>();

            _view.ViewLoaded += async (s, e) => await ViewLoaded_Accion();
            _view.FiltroCambiado += async (s, e) => await FiltroCambiado_Accion();
            _view.AgregarDeudaNueva += AgregarDeuda_Accion;
            _view.CancelarDeuda += CancelarDeuda_Accion;
            _view.Cerrar += Cerrar_Accion;
        }

        private void Cerrar_Accion(object sender, EventArgs e)
        {
            _view.CerrarVista(System.Windows.Forms.DialogResult.Cancel);
        }

        private void CancelarDeuda_Accion(object sender, EventArgs e)
        {
            _view.CerrarVista(System.Windows.Forms.DialogResult.Cancel);
        }

        private async Task ViewLoaded_Accion()
        {
            try
            {
                _view.MostrarCargando();

                await Task.Delay(400);

                var categorias = await _logica.ObtenerCategorias();
                _view.CargarCategorias(categorias);

                DataTable dt = await _logica.ObtenerProductosFiltrados(
                    _view.FiltroTexto,
                    _view.CategoriaSeleccionada);

                AjustarStockReservado(dt);
                _view.CargarProductos(dt);
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje("Error al inicializar el formulario: " + ex.Message, true);
            }
            finally
            {
                _view.OcultarCargando();
            }
        }

        private async Task FiltroCambiado_Accion()
        {
            try
            {
                DataTable dt = await _logica.ObtenerProductosFiltrados(
                    _view.FiltroTexto,
                    _view.CategoriaSeleccionada);

                AjustarStockReservado(dt);
                _view.CargarProductos(dt);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("[AgregarDeudaPresenter] Filtro: " + ex.Message);
            }
        }

        private void AjustarStockReservado(DataTable dt)
        {
            if (_itemsActuales.Count == 0 || !dt.Columns.Contains("Existencia") || !dt.Columns.Contains("Codigo"))
                return;

            var reservas = _itemsActuales
                .GroupBy(i => i.CodigoProducto)
                .ToDictionary(g => g.Key, g => g.Sum(i => i.Cantidad));

            foreach (DataRow row in dt.Rows)
            {
                string codigo = row["Codigo"]?.ToString();
                if (!string.IsNullOrEmpty(codigo) && reservas.TryGetValue(codigo, out int cantidadReservada))
                {
                    int stockOriginal = Convert.ToInt32(row["Existencia"]);
                    row["Existencia"] = Math.Max(0, stockOriginal - cantidadReservada);
                }
            }
        }

        private void AgregarDeuda_Accion (object sender, EventArgs e)
        {
            var datos = _view.ObtenerFilaSeleccionada();
            if (datos == null)
            {
                _view.MostrarMensaje("Seleccione un producto de la lista.", true);
                return;
            }

            int cantidad = _view.Cantidad;
            if (cantidad <= 0)
            {
                _view.MostrarMensaje("La cantidad debe ser mayor a cero.", true);
                return;
            }

            int existencia = Convert.ToInt32(datos["Existencia"] ?? 0);
            if (cantidad > existencia)
            {
                _view.MostrarMensaje($"Stock insuficiente. Disponible: {existencia}.", true);
                return;
            }

            ItemSeleccionado = new ItemCredito
            {
                CodigoProducto = datos["Codigo"]?.ToString() ?? "",
                NombreProducto = datos["Producto"]?.ToString() ?? "",
                Categoria = datos["Categoria"]?.ToString() ?? "",
                Cantidad = cantidad,
                PrecioUnitario = Convert.ToDecimal(datos["Precio"] ?? 0)
            };

            _view.CerrarVista(System.Windows.Forms.DialogResult.OK);
        }
    }
}