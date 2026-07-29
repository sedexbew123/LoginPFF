using System;
using System.Reflection;
using System.Windows.Forms;

namespace Presentacion.View.UserControls
{

    public partial class ListadoPagos : UserControl, Interfaces.IListadoPagosView
    {
        #region IListadoPagosView – Filtros

        public string MesSeleccionado => KcmMes.SelectedItem?.ToString() ?? "";

        public int AñoSeleccionado
        {
            get => (int)KnudAño.Value;
            set => KnudAño.Value = value;
        }

        public string TextoBusqueda => KtxtFiltro.Text;

        #endregion

        #region IListadoPagosView – Fila seleccionada

        public string Nombre
        {
            get => dGVDatos.CurrentRow?.Cells["colNombre"].Value?.ToString() ?? "";
            set { }
        }

        public string Apellido
        {
            get => dGVDatos.CurrentRow?.Cells["colApellido"].Value?.ToString() ?? "";
            set { }
        }

        public decimal Pago
        {
            get => decimal.TryParse(
                       dGVDatos.CurrentRow?.Cells["colMonto"].Value?.ToString(),
                       out decimal v) ? v : 0m;
            set { }
        }

        public decimal PagoBs
        {
            get => decimal.TryParse(
                       dGVDatos.CurrentRow?.Cells["colMontoBs"].Value?.ToString(),
                       out decimal v) ? v : 0m;
            set { }
        }

        public DateTime FechaPago
        {
            get => DateTime.TryParse(
                       dGVDatos.CurrentRow?.Cells["colFecha"].Value?.ToString(),
                       out DateTime v) ? v : DateTime.MinValue;
            set { }
        }

        public string TipoPago
        {
            get => dGVDatos.CurrentRow?.Cells["colTipoPago"].Value?.ToString() ?? "";
            set { }
        }

        public string Moneda
        {
            get => dGVDatos.CurrentRow?.Cells["colMoneda"].Value?.ToString() ?? "";
            set { }
        }

        #endregion

        public object DataSource
        {
            set => dGVDatos.DataSource = value;
        }

        public ListadoPagos()
        {
            InitializeComponent();
            ConfigurarColumnasDGV();
            SuscribirEventos();
            EnableDoubleBuffer(dGVDatos);
        }


        private void ConfigurarColumnasDGV()
        {
            dGVDatos.AutoGenerateColumns = false;
            dGVDatos.Columns.Clear();

            dGVDatos.Columns.Add(CrearColumna("colNombre", "Nombre", "Nombre", 200));
            dGVDatos.Columns.Add(CrearColumna("colApellido", "Apellido", "Apellido", 180));
            dGVDatos.Columns.Add(CrearColumna("colMonto", "Monto", "Monto", 100, "N2"));
            dGVDatos.Columns.Add(CrearColumna("colMoneda", "Moneda", "NombreMoneda", 90));
            dGVDatos.Columns.Add(CrearColumna("colMontoBs", "Total Bs", "MontoBs", 120, "N2"));
            dGVDatos.Columns.Add(CrearColumna("colTipoPago", "Tipo", "TipoPago", 80));
            dGVDatos.Columns.Add(CrearColumna("colFecha", "Fecha de Pago", "FechaPago", 120, "dd/MM/yyyy"));
        }

        private static DataGridViewTextBoxColumn CrearColumna(
            string name, string header, string dataProperty,
            int width, string format = null)
        {
            var col = new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataPropertyName = dataProperty,
                Width = width,
                ReadOnly = true
            };
            if (!string.IsNullOrEmpty(format))
                col.DefaultCellStyle.Format = format;
            return col;
        }

        private void SuscribirEventos()
        {
            KcmMes.SelectedIndexChanged += (s, e) => FiltroFechaCambiado?.Invoke(this, EventArgs.Empty);
            KnudAño.ValueChanged += (s, e) => FiltroFechaCambiado?.Invoke(this, EventArgs.Empty);
            KtxtFiltro.TextChanged += delegate { FiltrarPagos?.Invoke(this, EventArgs.Empty); };
            btnDelante.Click += delegate { PaginaSiguienteClick?.Invoke(this, EventArgs.Empty); };
            btnAtras.Click += delegate { PaginaAnteriorClick?.Invoke(this, EventArgs.Empty); };
        }

        public void MostrarGanancias(decimal totalUsd, decimal totalEur, decimal totalBs)
        {
            lblUSD.Text = $"{totalUsd:N2} $";
            lblEUR.Text = $"{totalEur:N2} €";
            lblBs.Text = $"{totalBs:N2}";
        }

        public void ActualizarPaginacion(int paginaActual, int totalPaginas)
        {
            lblPaginas.Text = $"{paginaActual} - {totalPaginas}";
            btnAtras.Enabled = paginaActual > 1;
            btnDelante.Enabled = paginaActual < totalPaginas;
        }

        private static readonly string[] NombresMeses =
        {
            "Enero","Febrero","Marzo","Abril","Mayo","Junio",
            "Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre"
        };

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (KcmMes.Items.Count == 0)
                KcmMes.Items.AddRange(NombresMeses);

            KcmMes.SelectedIndex = DateTime.Now.Month - 1;
            KnudAño.Value = DateTime.Now.Year;
            CargarPagos?.Invoke(this, EventArgs.Empty);
        }

        private static void EnableDoubleBuffer(Control control) =>
            typeof(Control)
                .GetProperty("DoubleBuffered",
                    BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(control, true);

        public event EventHandler PaginaSiguienteClick;
        public event EventHandler PaginaAnteriorClick;
        public event EventHandler FiltroFechaCambiado;
        public event EventHandler CargarPagos;
        public event EventHandler FiltrarPagos;
    }
}