using Logica;
using Presentacion.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.View.Forms
{
    public partial class AgregarDeuda : Form, IAgregarDeudaView
    {

        private readonly L_Creditos _logica;

        #region 

        public string FiltroTexto => txtFiltrar.Text.Trim();
        public string CategoriaSeleccionada => KcmbCategoria.SelectedItem?.ToString() ?? "";
        public int Cantidad
        {
            get => (int)KnudCantidad.Value;
            set => KnudCantidad.Value = value;
        }

        #endregion

        private bool _actualizandoDesdeGrid = false;

        public AgregarDeuda(L_Creditos logica)
        {
            InitializeComponent();
            _logica = logica;
            Eventos();

            if (pnlContenedorDatos != null) pnlContenedorDatos.Visible = false;
            if (pnlCarga != null)
            {
                pnlCarga.Visible = true;
                pnlCarga.BringToFront();
            }
            this.ActiveControl = lblAgregarDeuda;
        }

        private void Eventos()
        {
            btnCerrar.Click += delegate { Cerrar?.Invoke(this, EventArgs.Empty); };
            KbtnSeleccionar.Click += delegate { AgregarDeudaNueva?.Invoke(this, EventArgs.Empty); };
            KbtnCancelar.Click += delegate { CancelarDeuda?.Invoke(this, EventArgs.Empty); };

            txtFiltrar.TextChanged += delegate
            {
                if (_actualizandoDesdeGrid) return; 
                FiltroCambiado?.Invoke(this, EventArgs.Empty);
            };

            KcmbCategoria.SelectedIndexChanged += delegate { FiltroCambiado?.Invoke(this, EventArgs.Empty); };
            dGVDatos.CellClick += DGVDatos_CellClick;
        }

        private void DGVDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dGVDatos.CurrentRow != null)
            {
                if (dGVDatos.CurrentRow.Cells["Nombre"]?.Value != null)
                {
                    _actualizandoDesdeGrid = true;
                    txtFiltrar.Text = dGVDatos.CurrentRow.Cells["Nombre"].Value.ToString();
                    _actualizandoDesdeGrid = false;
                }
            }
        }

        private void AgregarDeuda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                btnCerrar.PerformClick();
            }
            if (e.KeyCode == Keys.Delete && !(this.ActiveControl is TextBox))
            {
                e.Handled = true;
                KbtnCancelar.PerformClick();
            }
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                KbtnSeleccionar.PerformClick();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helpers.AnimateWindows.Start(this, 350,
                Helpers.AnimateWindows.AnimateWindowsFlags.AW_ACTIVATE |
                Helpers.AnimateWindows.AnimateWindowsFlags.AW_BLEND);
            this.Invalidate(true);

            ViewLoaded?.Invoke(this, EventArgs.Empty);
        }

        public void CargarCategorias(List<string> categorias)
        {
            KcmbCategoria.Items.Clear();
            KcmbCategoria.Items.Add("Todos");
            foreach (var c in categorias) KcmbCategoria.Items.Add(c);
            KcmbCategoria.SelectedIndex = 0;
        }

        public void CargarProductos(DataTable dt)
        {
            dGVDatos.AutoGenerateColumns = true;
            dGVDatos.DataSource = null;
            dGVDatos.DataSource = dt;

            dGVDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGVDatos.MultiSelect = false;
            dGVDatos.ReadOnly = true;
            dGVDatos.AllowUserToAddRows = false;

            if (dGVDatos.Columns["Codigo"] != null)
                dGVDatos.Columns["Codigo"].Visible = false;

            if (dGVDatos.Columns["Precio"] != null)
                dGVDatos.Columns["Precio"].DefaultCellStyle.Format = "N2";

            if (dGVDatos.Columns["Nombre"] != null) dGVDatos.Columns["Nombre"].HeaderText = "Nombre";
            if (dGVDatos.Columns["Categoria"] != null) dGVDatos.Columns["Categoria"].HeaderText = "Categoría";
            if (dGVDatos.Columns["Existencia"] != null) dGVDatos.Columns["Existencia"].HeaderText = "Stock";
        }

        public Dictionary<string, object> ObtenerFilaSeleccionada()
        {
            if (dGVDatos.CurrentRow == null) return null;

            return new Dictionary<string, object>
            {
                ["Codigo"] = dGVDatos.CurrentRow.Cells["Codigo"]?.Value,
                ["Producto"] = dGVDatos.CurrentRow.Cells["Nombre"]?.Value?.ToString(),
                ["Categoria"] = dGVDatos.CurrentRow.Cells["Categoria"]?.Value?.ToString(),
                ["Precio"] = dGVDatos.CurrentRow.Cells["Precio"]?.Value,
                ["Existencia"] = dGVDatos.CurrentRow.Cells["Existencia"]?.Value
            };
        }
        public void MostrarCargando()
        {
            if (pnlContenedorDatos != null) pnlContenedorDatos.Visible = false;

            if (pnlCarga != null)
            {
                pnlCarga.BringToFront();
                pnlCarga.Visible = true;
                pnlCarga.Update(); 
            }
        }
        public void OcultarCargando()
        {
            if (pnlCarga != null)
            {
                pnlCarga.Visible = false;
            }

            if (pnlContenedorDatos != null) pnlContenedorDatos.Visible = true;
        }

        public void MostrarMensaje(string mensaje, bool esError)
        {
            MessageBox.Show(mensaje, esError ? "Aviso" : "Información",
                MessageBoxButtons.OK,
                esError ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
        }

        public void CerrarVista(DialogResult resultado)
        {
            this.DialogResult = resultado;
            this.Close();
        }

        public event EventHandler ViewLoaded;
        public event EventHandler Cerrar;
        public event EventHandler AgregarDeudaNueva;
        public event EventHandler CancelarDeuda;
        public event EventHandler FiltroCambiado;
    }
}
