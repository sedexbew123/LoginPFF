using Logica;
using Presentacion.View.Interfaces;
using System;
using System.Threading.Tasks;

namespace Presentacion.Presenter
{
    public class DatosConsultaDeudaPresenter
    {
        private readonly IDatosConsultaDeudaView _view;
        private readonly L_Creditos _logica;
        private readonly string _cedula;
        private readonly int _idCredito;

        public DatosConsultaDeudaPresenter(
            IDatosConsultaDeudaView view,
            string cedula,
             int idCredito,
            L_Creditos logica)
        {
            _view = view;
            _logica = logica;
            _cedula = cedula;

            _view.Cerrar += Cerrar_Accion;
            _view.CargarDeudas += async (s, e) => await CargarDeudas_Accion();
            _idCredito = idCredito;
        }

        private void Cerrar_Accion(object sender, EventArgs e)
        {
            _view.CerrarVista();
        }

        private async Task CargarDeudas_Accion()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_cedula)) return;

                _view.MostrarCargando();

                await Task.Delay(400);

                var (cliente, detalle, total, meses) = await _logica.ObtenerDetalleDeuda(_cedula, _idCredito);

                if (cliente == null)
                {
                    System.Windows.Forms.MessageBox.Show("No se encontraron deudas activas para este cliente.");
                    _view.CerrarVista();
                    return;
                }

                _view.LabelCedula = cliente.Cedula;
                _view.LabelNombre = cliente.Nombres;
                _view.LabelApellido = cliente.Apellidos;
                _view.LabelCreditoTotal = $"{total.ToString("N2")} $";
                decimal deudaActual = Convert.ToDecimal(total);

                if (deudaActual <= 0)
                {
                    _view.MesesSinPagar = "Al día (Sin deudas)";
                }
                else
                {
                    int diasTranscurridos = meses;

                    if (diasTranscurridos == 0)
                    {
                        _view.MesesSinPagar = "Crédito otorgado hoy";
                    }
                    else
                    {
                        _view.MesesSinPagar = $"{diasTranscurridos} día(s) de atraso";
                    }
                }

                _view.DataSource = detalle;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error cargando deudas: " + ex.Message);
            }
            finally
            {
                _view.OcultarCargando();
            }
        }
    }
}
