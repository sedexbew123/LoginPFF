using Logica;
using Presentacion.Helpers;
using Presentacion.View.Forms;
using Presentacion.View.Interfaces;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Presenter
{
    public class PagosPresenter
    {
        private readonly IPagosView _view;
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

        public PagosPresenter(IPagosView view)
        {
            _view = view;

            _view.CargarDeudas += (s, e) => CargarTablaAsync();
            _view.FiltroFechaCambiado += (s, e) => CargarTablaAsync();
            _view.FiltrarDeudas += (s, e) => FiltrarYPaginar();
            _view.ActualizarPago += ActualizarPago_Accion;
            _view.EliminarPago += EliminarPago_Accion;
            _view.PaginaSiguienteClick += (s, e) => CambiarPagina(+1);
            _view.PaginaAnteriorClick += (s, e) => CambiarPagina(-1);
            _view.EnviarComprobanteWhatsAppClick += EnviarComprobanteWhatsApp_Accion;
        }
        private void EnviarComprobanteWhatsApp_Accion(object sender, EventArgs e)
        {
            try
            {
                if (_view.IdCredito == 0)
                {
                    _view.MostrarMensaje("Seleccione un registro de la lista.", true);
                    return;
                }

                string telefono = _view.Telefono;
                if (string.IsNullOrWhiteSpace(telefono))
                {
                    _view.MostrarMensaje("El cliente seleccionado no posee un número de teléfono registrado.", true);
                    return;
                }

                string nombreCompleto = $"{_view.Nombre} {_view.Apellido}".Trim();

                // Se arma el mensaje llamando a tu plantilla de comprobantes de pago
                string mensaje = PlantillasWhatsApp.MensajeComprobantePago(
                    nombreCompleto,
                    _view.Monto,          // Monto o abono registrado
                    _view.SaldoPendiente,  // Restante por pagar
                    _view.FechaPago
                );

                // Envío directo con el protocolo nativo whatsapp://
                WhatsAppHelper.EnviarMensaje(telefono, mensaje);
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje("Error al intentar abrir WhatsApp: " + ex.Message, true);
            }
        }

        private async void CargarTablaAsync()
        {
            int mes = ObtenerNumeroMes(_view.MesSeleccionado);
            int año = _view.AñoSeleccionado;

            _tablaOriginal = await _logica.ObtenerClientesConDeudaAsync(mes, año);
            FiltrarYPaginar();
        }

        private static int ObtenerNumeroMes(string nombre)
        {
            int idx = Array.IndexOf(NombresMeses, nombre?.Trim() ?? "");
            return idx >= 0 ? idx + 1 : 0;  
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

            _view.ActualizarPaginacionClientes(_paginaActual, totalPaginas);
        }

        private void CambiarPagina(int delta)
        {
            if (_tablaFiltrada == null) return;

            int totalPaginas = Math.Max(1,
                (int)Math.Ceiling(_tablaFiltrada.Rows.Count / (double)PageSize));

            _paginaActual = Math.Max(1, Math.Min(_paginaActual + delta, totalPaginas));
            MostrarPaginaActual();
        }

        private void ActualizarPago_Accion(object sender, EventArgs e)
        {
            if (_view.IdCredito == 0)
            {
                MessageBox.Show("Seleccione un cliente de la lista.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var vista = new Pagar();
            var presenter = new PagarPresenter(vista, new L_Tasas(), _logica);

            vista.IdCredito = _view.IdCredito;
            vista.SaldoPendiente = _view.SaldoPendiente;
            vista.Nombre = _view.Nombre;
            vista.Apellido = _view.Apellido;
            vista.Cedula = _view.Cedula.ToString();

            if (vista.ShowDialog() == DialogResult.OK)
                CargarTablaAsync();
        }

        private async void EliminarPago_Accion(object sender, EventArgs e)
        {
            if (_view.IdCredito == 0)
            {
                MessageBox.Show("Seleccione un cliente de la lista.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Eliminar todos los pagos de {_view.Nombre} {_view.Apellido}?\n" +
                $"El crédito volverá al estado 'Activo'.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            bool ok = await _logica.EliminarPagoAsync(_view.IdCredito);

            MessageBox.Show(
                ok ? "Pagos eliminados correctamente."
                   : "Error al eliminar los pagos.",
                ok ? "Éxito" : "Error",
                MessageBoxButtons.OK,
                ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (ok) CargarTablaAsync();
        }
    }
}
