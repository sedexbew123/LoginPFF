using Presentacion.Presenter;
using System;
using System.Windows.Forms;

namespace Presentacion.View.UserControls
{
    public partial class Informes : UserControl, Interfaces.IInformesView
    {
        #region
        public string ReporteSeleccionado => cmbReportes.SelectedItem?.ToString() ?? string.Empty;
        public string CedulaCliente => cmbClientes.SelectedValue?.ToString() ?? string.Empty;
        public DateTime FechaDesde => dTPDesde.Value;
        public DateTime FechaHasta => dTPHasta.Value;

        public bool SelectorClienteHabilitado
        {
            set
            {
                cmbClientes.Enabled = value;
                lblBuscar.Visible = value;
                cmbClientes.Visible = value;
                if (!value) cmbClientes.SelectedIndex = -1;
            }
        }
        #endregion
        public Informes()
        {
            InitializeComponent();
            ConfigurarComboReportes();
            AsignarEventos();
            _ = new InformesPresenter(this);
            _ = CargarClientesAsync();
        }

        private void ConfigurarComboReportes()
        {
            cmbReportes.Items.Clear();
            cmbReportes.Items.Add("Consulta de Deudas");
            cmbReportes.Items.Add("Estado de Cuenta Individual");
            cmbReportes.Items.Add("Consulta de Pagos");
            cmbReportes.Items.Add("Servicios Actuales");
            cmbReportes.Items.Add("Historial de Servicios Realizados");
            cmbReportes.Items.Add("Productos Actuales");
            cmbReportes.Items.Add("Historial de Cargos y Descargos");
            cmbReportes.SelectedIndex = 0;
        }

        private void AsignarEventos()
        {
            cmbReportes.SelectedIndexChanged += (s, e) => ReporteElegido?.Invoke(this, EventArgs.Empty);
            btnPDF.Click += (s, e) => ExportarPDF?.Invoke(this, EventArgs.Empty);
            btnExcel.Click += (s, e) => ExportarExcel?.Invoke(this, EventArgs.Empty);
        }

        public void MostrarMensaje(string mensaje, bool esError)
        {
            MessageBox.Show(mensaje, "Módulo de Reportes", MessageBoxButtons.OK,
                esError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }

        private async System.Threading.Tasks.Task CargarClientesAsync()
        {
            try
            {
                var logica = new Logica.L_Clientes();
                var (clientes, _) = await logica.Listar(1, 999);
                cmbClientes.DataSource = clientes;
                cmbClientes.DisplayMember = "NombreCompletoConCedula";
                cmbClientes.ValueMember = "Cedula";
                cmbClientes.SelectedIndex = -1;
            }
            catch { }
        }

        public event EventHandler ReporteElegido;
        public event EventHandler ExportarPDF;
        public event EventHandler ExportarExcel;
    }
}
