using Logica;
using Presentacion.Helpers;
using Presentacion.View.Forms;
using Presentacion.View.Interfaces;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Presentacion.Presenter
{
    public class ConsultaDeudaPresenter
    {
        private readonly IConsultaDeudaView _view;
        private readonly L_Creditos _logica;
        private DataTable _tablaCompleta = new DataTable();
        private int _paginaActual = 1;
        private const int RegistrosPorPagina = 10;

        public ConsultaDeudaPresenter(IConsultaDeudaView view, L_Creditos logica)
        {
            _logica = logica;
            _view = view;

            _view.CargarDeudas += async (s, e) => await CargarDatos_Accion();
            _view.BuscarDeuda += async (s, e) => await CargarDatos_Accion();
            _view.VerDetalleCliente += (s, e) => VerDetalle_Accion();
            _view.PaginaSiguienteClick += (s, e) => CambiarPagina(1);
            _view.PaginaAnteriorClick += (s, e) => CambiarPagina(-1);

            _view.EnviarWhatsAppClick += EnviarWhatsApp_Accion;
        }

        private void EnviarWhatsApp_Accion(object sender, EventArgs e)
        {
            try
            {
                string nombreCompleto = $"{_view.Nombre} {_view.Apellido}".Trim();
                string telefono = _view.Telefono;

                if (string.IsNullOrWhiteSpace(telefono))
                {
                    _view.MostrarMensaje("El cliente seleccionado no posee un número de teléfono registrado.", true);
                    return;
                }

                // Generar el mensaje usando las plantillas
                string mensaje = PlantillasWhatsApp.MensajeRecordatorioDeuda(
                    nombreCompleto,
                    _view.Monto,
                    0m, // Puedes cambiarlo si tienes el total formateado en Bs
                    _view.FechaLimite
                );

                // Enviar mensaje con el Helper
                WhatsAppHelper.EnviarMensaje(telefono, mensaje);
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje("Ocurrió un error al abrir WhatsApp: " + ex.Message, true);
            }
        }

        private async Task CargarDatos_Accion()
        {
            try
            {
                _tablaCompleta = await _logica.ObtenerResumenDeudas(
                    _view.TextoBusqueda,
                    _view.CriterioOrden);

                var (totalClientes, creditoTotal, totalProductos) =
                    await _logica.ObtenerEstadisticasDeudas();

                _view.TotalClientes = totalClientes;
                _view.CreditoTotal = creditoTotal;
                _view.TotalProductos = totalProductos;

                _paginaActual = 1;
                MostrarPagina();
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje("Error al cargar deudas: " + ex.Message, true);
            }
        }

        private void CambiarPagina(int delta)
        {
            int total = Math.Max(1, (int)Math.Ceiling(
                _tablaCompleta.Rows.Count / (double)RegistrosPorPagina));

            _paginaActual = Math.Max(1, Math.Min(_paginaActual + delta, total));
            MostrarPagina();
        }

        private void MostrarPagina()
        {
            int total = Math.Max(1, (int)Math.Ceiling(
                _tablaCompleta.Rows.Count / (double)RegistrosPorPagina));

            var filas = _tablaCompleta.AsEnumerable()
                .Skip((_paginaActual - 1) * RegistrosPorPagina)
                .Take(RegistrosPorPagina);

            _view.DataSource = filas.Any()
                ? filas.CopyToDataTable()
                : _tablaCompleta.Clone();

            _view.ActualizarPaginacionClientes(_paginaActual, total);
        }

        private void VerDetalle_Accion()
        {
            if (string.IsNullOrEmpty(_view.Cedula))
            {
                _view.MostrarMensaje("Seleccione un cliente de la lista.", true);
                return;
            }

            using (var frm = new DatosConsultaDeuda(_view.Cedula, _view.IdCredito))
            {
                frm.ShowDialog();
            }
        }
    }
}