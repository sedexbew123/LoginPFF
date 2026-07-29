using Presentacion.View.Interfaces;
using System;
using System.Windows.Forms;

namespace Presentacion.View.UserControls
{
    public partial class DescargoProductos : UserControl, IDescargoProductoView
    {

        #region
        public DateTime Fecha
        {
            get => dGVDatos.CurrentRow != null && DateTime.TryParse(
                        dGVDatos.CurrentRow.Cells["Fecha"].Value?.ToString(),
                        out DateTime val) ? val : DateTime.MinValue;
            set { }
        }

        public string Producto
        {
            get => dGVDatos.CurrentRow != null ? dGVDatos.CurrentRow.Cells["Producto"].Value?.ToString() : string.Empty;
            set { }
        }
        public string Categoria
        {
            get => dGVDatos.CurrentRow != null ? dGVDatos.CurrentRow.Cells["Categoria"].Value?.ToString() : string.Empty;
            set { }
        }

        public string Motivo
        {
            get => dGVDatos.CurrentRow != null ? dGVDatos.CurrentRow.Cells["Motivo"].Value?.ToString() : string.Empty;
            set { }
        }

        public int Cantidad
        {
            get => dGVDatos.CurrentRow != null && int.TryParse(
                        dGVDatos.CurrentRow.Cells["Cantidad"].Value?.ToString(),
                        out int val) ? val : 0;
            set { }
        }

        public string CategoriaSeleccionada => cmbCategoria.SelectedValue?.ToString() ?? string.Empty;
        public string MotivoSeleccionado => cmbMotivo.SelectedItem?.ToString() ?? string.Empty;
        public int CantidadSeleccionada => (int)numCantidad.Value;
        #endregion
        public DescargoProductos()
        {
            InitializeComponent();
            Eventos();

            EnableDoubleBuffer(this);
            EnableDoubleBuffer(dGVDatos);
        }

        public void SuspendUI() => SuspendLayout();
        public void ResumeUI() => ResumeLayout(true);

        public int CategoriaIdSeleccionada
         => cmbCategoria.SelectedValue is int id ? id : 0;

        public string ProductoCodigoSeleccionado
        {
            get
            {
                if (dGVDatos.CurrentRow == null) return string.Empty;
                try { return dGVDatos.CurrentRow.Cells["Codigo"].Value?.ToString() ?? string.Empty; }
                catch { return string.Empty; }
            }
        }
        public int IdMotivoSeleccionado => cmbMotivo.SelectedValue is int id ? id : 0;



        public object CategoriasDataSource
        {
            set
            {
                cmbCategoria.BeginUpdate();
                cmbCategoria.DataSource = null;
                cmbCategoria.DisplayMember = "NombreCategoria";
                cmbCategoria.ValueMember = "IdCategoria";
                cmbCategoria.DataSource = value;
                cmbCategoria.EndUpdate();
            }
        }

        public object ProductosDataSource
        {
            set
            {
                dGVDatos.DataSource = value;
            }
        }

        public object HistorialDataSource
        {
            set
            {
                ConfigurarColumnasHistorialDescargo();
                dGVDatos.DataSource = null;
                dGVDatos.DataSource = value;
            }
        }

        public object MotivosDataSource
        {
            set
            {
                cmbMotivo.BeginUpdate();
                cmbMotivo.DataSource = null;
                cmbMotivo.DisplayMember = "Descripcion";
                cmbMotivo.ValueMember = "IdMotivo";
                cmbMotivo.DataSource = value;
                cmbMotivo.EndUpdate();
            }
        }

        private void Eventos()
        {
            cmbCategoria.SelectedIndexChanged += (s, e) =>
            {
                if (cmbCategoria.DataSource != null && cmbCategoria.SelectedValue != null)
                    CategoriaChanged?.Invoke(this, EventArgs.Empty);
            };
            btnDescargo.Click += (s, e) => RegistrarDescargoClick?.Invoke(this, EventArgs.Empty);
            btnDelante.Click += (s, e) => PaginaSiguienteClick?.Invoke(this, EventArgs.Empty);
            btnAtras.Click += (s, e) => PaginaAnteriorClick?.Invoke(this, EventArgs.Empty);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Delete && !(this.ActiveControl is TextBox))
            {
                btnDescargo.PerformClick(); 
                return true; 
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            dGVDatos.AutoGenerateColumns = false;

            if (dGVDatos.Columns.Count >= 3)
            {
                dGVDatos.Columns[0].DataPropertyName = "Codigo";
                dGVDatos.Columns[1].DataPropertyName = "Nombre";
                dGVDatos.Columns[2].DataPropertyName = "StockActual";
            }
            CargarDatos?.Invoke(this, EventArgs.Empty);
        }

        private void ConfigurarColumnasHistorialDescargo()
        {
            dGVDatos.AutoGenerateColumns = false;
            dGVDatos.Columns.Clear();

            dGVDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha",
                DataPropertyName = "Fecha",
                Width = 140
            });
            dGVDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Producto",
                DataPropertyName = "NombreProducto",
                Width = 160
            });
            dGVDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Categoría",
                DataPropertyName = "NombreCategoria",
                Width = 120
            });
            dGVDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Motivo",
                DataPropertyName = "Motivo",
                Width = 150
            });
            dGVDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Cantidad",
                DataPropertyName = "Cantidad",
                Width = 80
            });
        }
        public void LimpiarCampos()
        {
            numCantidad.Value = 1;
            cmbMotivo.SelectedIndex = -1;
            dGVDatos.ClearSelection();
        }

        public void ActualizarPaginacion(int paginaActual, int totalPaginas)
        {
            lblPaginas.Text = paginaActual.ToString() + " - " + totalPaginas.ToString();

            btnAtras.Enabled = paginaActual > 1;
            btnDelante.Enabled = paginaActual < totalPaginas;
        }

        public void MostrarMensaje(string mensaje, bool esError)
            => MessageBox.Show(mensaje, "Descargo de Inventario", MessageBoxButtons.OK,
                   esError ? MessageBoxIcon.Error : MessageBoxIcon.Information);

        private void EnableDoubleBuffer(Control c)
            => typeof(Control)
               .GetProperty("DoubleBuffered",
                   System.Reflection.BindingFlags.NonPublic |
                   System.Reflection.BindingFlags.Instance)
               .SetValue(c, true);

        public event EventHandler CargarDatos;
        public event EventHandler CategoriaChanged;
        public event EventHandler RegistrarDescargoClick;
        public event EventHandler PaginaSiguienteClick;
        public event EventHandler PaginaAnteriorClick;
    }
}