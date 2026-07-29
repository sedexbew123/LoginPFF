using Presentacion.View.Interfaces;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.View.UserControls
{
    public partial class TasaDolar : UserControl, ITasaDolarView
    {
        #region

        public string DescripcionBuscar
        {
            get => KtxtDescripcion.Text;
            set => KtxtDescripcion.Text = value;
        }

        public string MonedaBuscar
        {
            get => KtxtMoneda.Text;
            set => KtxtMoneda.Text = value;
        }

        public string Moneda
        {
            get => dGVDatos.CurrentRow?.Cells["Moneda"]?.Value?.ToString() ?? string.Empty;
            set { }
        }

        public string Descripcion
        {
            get => dGVDatos.CurrentRow?.Cells["Descripcion"]?.Value?.ToString() ?? string.Empty;
            set { }
        }

        public decimal Valor
        {
            get => decimal.TryParse(
                       dGVDatos.CurrentRow?.Cells["Valor"]?.Value?.ToString(),
                       out decimal val) ? val : 0m;
            set { }
        }

        public DateTime Fecha
        {
            get => DateTime.TryParse(
                       dGVDatos.CurrentRow?.Cells["Fecha"]?.Value?.ToString(),
                       out DateTime fecha) ? fecha : DateTime.MinValue;
            set { }
        }

        #endregion

        public TasaDolar()
        {
            InitializeComponent();
            dGVDatos.AutoGenerateColumns = false;

            KtxtDescripcion.ReadOnly = false;
            KtxtDescripcion.Enabled = true;
            KtxtMoneda.ReadOnly = false;
            KtxtMoneda.Enabled = true;

            SuscribirEventos();

            EnableDoubleBuffer(tLPInformacionBasica);
            EnableDoubleBuffer(dGVDatos);

            dGVDatos.ScrollBars = ScrollBars.Both;
        }

        public class DGVSinFlicker : DataGridView
        {
            public DGVSinFlicker()
            {
                DoubleBuffered = true;
                SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            }
        }
        public void CargarTasas(DataTable dt)
        {
            if (dGVDatos.InvokeRequired)
            {
                dGVDatos.Invoke(new Action(() => CargarTasas(dt)));
                return;
            }

            dGVDatos.DataSource = dt;
            //dGVDatos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            dGVDatos.ClearSelection();
        }

        public void MostrarEstadoApi(string mensaje, EstadoApi estado)
        {
            if (lblEstadoApi == null) return;

            if (lblEstadoApi.InvokeRequired)
            {
                lblEstadoApi.Invoke(new Action(() => MostrarEstadoApi(mensaje, estado)));
                return;
            }

            lblEstadoApi.Text = mensaje;

            switch (estado)
            {
                case EstadoApi.Cargando: lblEstadoApi.ForeColor = Color.FromArgb(0, 102, 204); break;
                case EstadoApi.Exito: lblEstadoApi.ForeColor = Color.DarkGreen; break;
                case EstadoApi.AlDia: lblEstadoApi.ForeColor = Color.DimGray; break;
                case EstadoApi.Error: lblEstadoApi.ForeColor = Color.Firebrick; break;
            }
        }

        private void SuscribirEventos()
        {
            this.Load += (s, e) => ViewLoaded?.Invoke(this, EventArgs.Empty);

            btnEditar.Click += (s, e) => EditarTasa?.Invoke(this, EventArgs.Empty);

            KtxtDescripcion.TextChanged += (s, e) => FiltrarTasas?.Invoke(this, EventArgs.Empty);
            KtxtMoneda.TextChanged += (s, e) => FiltrarTasas?.Invoke(this, EventArgs.Empty);

            btnDelante.Click += delegate { PaginaSiguienteClick?.Invoke(this, EventArgs.Empty); };
            btnAtras.Click += delegate { PaginaAnteriorClick?.Invoke(this, EventArgs.Empty); };
        }

        public void ActualizarPaginacionClientes(int paginaActual, int totalPaginas)
        {
            lblPaginas.Text = paginaActual.ToString() + " - " + totalPaginas.ToString();

            btnAtras.Enabled = paginaActual > 1;
            btnDelante.Enabled = paginaActual < totalPaginas;
        }

        private void EnableDoubleBuffer(Control control)
        {
            typeof(Control).GetProperty("DoubleBuffered",
                                        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(control, true);
        }

        public event EventHandler PaginaSiguienteClick;
        public event EventHandler PaginaAnteriorClick;
        public event EventHandler ViewLoaded;
        public event EventHandler EditarTasa;
        public event EventHandler FiltrarTasas;
    }
}