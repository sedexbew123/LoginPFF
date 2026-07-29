using Presentacion.View.Interfaces;
using System;
using System.Windows.Forms;

namespace Presentacion.View.UserControls
{
    public partial class CargoProductos : UserControl, ICargoProductoView
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
        public int Cantidad
        {
            get => dGVDatos.CurrentRow != null && int.TryParse(
                        dGVDatos.CurrentRow.Cells["Cantidad"].Value?.ToString(),
                        out int val) ? val : 0;
            set { }
        }
        
        public int CantidadSeleccionada => (int)numCantidad.Value;
        #endregion
        public CargoProductos()
        {
            InitializeComponent();
            Eventos();

            EnableDoubleBuffer(this);
            EnableDoubleBuffer(dGVDatos);
        }

        public int CategoriaIdSeleccionada
       => cmbCategoria.SelectedValue is int id ? id : 0;

        public string ProductoCodigoSeleccionado
        {
            get
            {
                if (dGVDatos.CurrentRow == null) return string.Empty;
                try
                {
                    return dGVDatos.CurrentRow.Cells["Codigo"].Value?.ToString() ?? string.Empty;
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        private bool _cargandoCategorias = false;

        public object CategoriasDataSource
        {
            set
            {
                _cargandoCategorias = true;
                cmbCategoria.BeginUpdate();
                try
                {
                    cmbCategoria.DataSource = null;
                    cmbCategoria.DisplayMember = "NombreCategoria";
                    cmbCategoria.ValueMember = "IdCategoria";
                    cmbCategoria.DataSource = value;
                }
                finally
                {
                    cmbCategoria.EndUpdate();
                    _cargandoCategorias = false;
                }
            }
        }

        public object ProductosDataSource
        {
            set
            {
                dGVDatos.DataSource = value;
            }
        }


        private void Eventos()
        {
            cmbCategoria.SelectedIndexChanged += (s, e) =>
            {
                if (!_cargandoCategorias && cmbCategoria.DataSource != null && cmbCategoria.SelectedValue != null)
                    CategoriaChanged?.Invoke(this, EventArgs.Empty);
            };
            btnRegistrarCargo.Click += (s, e) => RegistrarCargoClick?.Invoke(this, EventArgs.Empty);
            btnDelante.Click += (s, e) => PaginaSiguienteClick?.Invoke(this, EventArgs.Empty);
            btnAtras.Click += (s, e) => PaginaAnteriorClick?.Invoke(this, EventArgs.Empty);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                btnRegistrarCargo.PerformClick(); 
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


        public void LimpiarCampos()
        {
            numCantidad.Value = 1;
            dGVDatos.ClearSelection();
        }

        public void ActualizarPaginacion(int paginaActual, int totalPaginas)
        {
            lblPaginas.Text = paginaActual.ToString() + " - " + totalPaginas.ToString();

            btnAtras.Enabled = paginaActual > 1;
            btnDelante.Enabled = paginaActual < totalPaginas;
        }

        public void MostrarMensaje(string mensaje, bool esError)
            => MessageBox.Show(mensaje, "Cargo de Inventario", MessageBoxButtons.OK,
                   esError ? MessageBoxIcon.Error : MessageBoxIcon.Information);

        private void EnableDoubleBuffer(Control c)
            => typeof(Control).GetProperty("DoubleBuffered",
                   System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
               .SetValue(c, true);

        public event EventHandler CargarDatos;
        public event EventHandler CategoriaChanged;
        public event EventHandler RegistrarCargoClick;
        public event EventHandler PaginaSiguienteClick;
        public event EventHandler PaginaAnteriorClick;
       
    }
}
