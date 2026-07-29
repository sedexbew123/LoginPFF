using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.View.UserControls
{
    public partial class ProductosDetallados : UserControl, Interfaces.IProductosDetalladosView
    {
        #region

        public string MesSeleccionado => KcmMes.SelectedItem?.ToString() ?? "";

        public int AñoSeleccionado
        {
            get => (int)KnudAño.Value;
            set => KnudAño.Value = value;
        }

        public string TipoOperacion => KcmTipo.SelectedItem?.ToString() ?? "";

        public DateTime Fecha
        {
            get => DateTime.TryParse(
                       dGVDatos.CurrentRow?.Cells["Fecha"].Value?.ToString(),
                       out DateTime val) ? val : DateTime.MinValue;
            set { }
        }
        public string Producto
        {
            get => dGVDatos.CurrentRow?.Cells["Producto"].Value?.ToString() ?? string.Empty;
            set { }
        }
        public string Categoria
        {
            get => dGVDatos.CurrentRow?.Cells["Categoria"].Value?.ToString() ?? string.Empty;
            set { }
        }
        public string Tipo
        {
            get => dGVDatos.CurrentRow?.Cells["Tipo"].Value?.ToString() ?? string.Empty;
            set { }
        }
        public int Cantidad
        {
            get => int.TryParse(
                       dGVDatos.CurrentRow?.Cells["Cantidad"].Value?.ToString(),
                       out int val) ? val : 0;
            set { }
        }
        public string Motivo
        {
            get => dGVDatos.CurrentRow?.Cells["Motivo"].Value?.ToString() ?? string.Empty;
            set { }
        }
        public string TextoBusqueda => KtxtFiltro.Text;
        #endregion
        public ProductosDetallados()
        {
            InitializeComponent();
            Eventos();

            EnableDoubleBuffer(this);
            EnableDoubleBuffer(dGVDatos);
            EnableDoubleBuffer(KnudAño);
        }

        public object HistorialDataSource
        {
            set
            {
                dGVDatos.SuspendLayout();
                try
                {

                    dGVDatos.DataSource = value;
                }
                finally
                {
                    dGVDatos.ResumeLayout();
                }
            }
        }


        public Clientes ClienteSeleccionado
        {
            get
            {
                if (dGVDatos.CurrentRow != null)
                    return (Clientes)dGVDatos.CurrentRow.DataBoundItem;
                return null;
            }
        }

        private void Eventos()
        {
            KcmMes.SelectedIndexChanged += (s, e) => { if (!_inicializando) FiltroFechaCambiado?.Invoke(this, EventArgs.Empty); };
            KnudAño.ValueChanged += (s, e) => { if (!_inicializando) FiltroFechaCambiado?.Invoke(this, EventArgs.Empty); };

            KcmTipo.SelectedIndexChanged += (s, e) => { if (!_inicializando) FiltroTipoChanged?.Invoke(this, EventArgs.Empty); };
            KtxtFiltro.TextChanged += (s, e) => { if (!_inicializando) FiltrarTexto?.Invoke(this, EventArgs.Empty); };
            btnDelante.Click += (s, e) => PaginaSiguienteClick?.Invoke(this, EventArgs.Empty);
            btnAtras.Click += (s, e) => PaginaAnteriorClick?.Invoke(this, EventArgs.Empty);
        }
        public void LlenarListadoClientes(List<Clientes> clientes)
        {
            dGVDatos.DataSource = clientes;
        }

        private static readonly string[] NombresMeses =
{
    "Enero","Febrero","Marzo","Abril","Mayo","Junio",
    "Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre"
};

        private bool _inicializando = true;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            dGVDatos.AutoGenerateColumns = false;

            if (dGVDatos.Columns.Count >= 5)
            {
                dGVDatos.Columns[0].DataPropertyName = "Fecha";
                dGVDatos.Columns[1].DataPropertyName = "Producto";
                dGVDatos.Columns[2].DataPropertyName = "Categoria";
                dGVDatos.Columns[3].DataPropertyName = "Tipo";
                dGVDatos.Columns[4].DataPropertyName = "Cantidad";
                dGVDatos.Columns[5].DataPropertyName = "Motivo";
            }


            KcmTipo.Items.Clear();
            KcmTipo.Items.Add("Todos");
            KcmTipo.Items.Add("Cargo");
            KcmTipo.Items.Add("Descargo");

            if (KcmMes.Items.Count == 0)
                KcmMes.Items.AddRange(NombresMeses);

            KcmMes.SelectedIndex = DateTime.Now.Month - 1;
            KnudAño.Value = DateTime.Now.Year;


            _inicializando = false;
            CargarHistorial?.Invoke(this, EventArgs.Empty);
        }

        public void ActualizarPaginacion(int paginaActual, int totalPaginas)
        {
            lblPaginas.Text = $"{paginaActual} - {totalPaginas}";
            btnAtras.Enabled = paginaActual > 1;
            btnDelante.Enabled = paginaActual < totalPaginas;
        }

        private void EnableDoubleBuffer(Control c)
        {
            typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(c, true);

            if (c is NumericUpDown nud)
            {
                var metodo = typeof(Control).GetMethod("SetStyle",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                metodo?.Invoke(nud, new object[] {
            System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer
            | System.Windows.Forms.ControlStyles.AllPaintingInWmPaint
            | System.Windows.Forms.ControlStyles.UserPaint,
            true
        });
            }
        }

        public event EventHandler CargarHistorial;
        public event EventHandler FiltroTipoChanged;
        public event EventHandler FiltrarTexto;
        public event EventHandler FiltroFechaCambiado;
        public event EventHandler PaginaSiguienteClick;
        public event EventHandler PaginaAnteriorClick;
    }
}
