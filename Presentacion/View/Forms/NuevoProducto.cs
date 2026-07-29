using Presentacion.Helpers;
using Presentacion.View.Interfaces;
using System;
using System.Windows.Forms;

namespace Presentacion.View.Forms
{
    public partial class NuevoProducto : Form, INuevoProductoView
    {
        #region
        public string Codigo
        {
            get => txtCodigo.Text.Trim();
            set => txtCodigo.Text = value;
        }
        public string NombreProducto
        {
            get => txtNombreProducto.Text.Trim();
            set => txtNombreProducto.Text = value;
        }

        public object CategoriasDataSource
        {
            set => CmbCategoria.DataSource = value;
        }

        public int? IdCategoriaSeleccionada
        {
            get => CmbCategoria.SelectedValue != null ? (int?)Convert.ToInt32(CmbCategoria.SelectedValue) : null;
            set => CmbCategoria.SelectedValue = value ?? -1;
        }
        public string NombreCategoriaSeleccionada => CmbCategoria.Text.Trim();

        public decimal Precio
        {
            get => nudPrecio.Value;
            set => nudPrecio.Value = value;
        }
        public int StockActual
        {
            get => (int)nudStockActual.Value;
            set => nudStockActual.Value = value;
        }

        #endregion

        public NuevoProducto()
        {
            InitializeComponent();
            ConfigurarColumnasCombobox();
            Eventos();

            if (pnlContenedorDatos != null) pnlContenedorDatos.Visible = true;
            if (pnlCarga != null) pnlCarga.Visible = false;
        }

        private void ConfigurarColumnasCombobox()
        {
            CmbCategoria.DisplayMember = "NombreCategoria";
            CmbCategoria.ValueMember = "IdCategoria";
        }

        private void Eventos()
        {

            this.Load += (s, e) => VistaCargando?.Invoke(this, EventArgs.Empty);
            btnRegistrar.Click += (s, e) => RegistrarProducto?.Invoke(this, EventArgs.Empty);
            btnCancelar.Click += (s, e) => Cancelar?.Invoke(this, EventArgs.Empty);
        }
        private void NuevoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                btnCancelar.PerformClick();
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btnRegistrar.PerformClick();
            }
        }
        public void BloquearCodigo(bool bloquear)
        {
            txtCodigo.ReadOnly = bloquear;
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
            if (pnlCarga != null) pnlCarga.Visible = false;
            if (pnlContenedorDatos != null) pnlContenedorDatos.Visible = true;
        }

        public void MostrarMensaje(string mensaje, string titulo, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Helpers.AnimateWindows.Start(this, 350, Helpers.AnimateWindows.AnimateWindowsFlags.AW_ACTIVATE | AnimateWindows.AnimateWindowsFlags.AW_BLEND);

            this.Invalidate(true);
        }

        public void CerrarVista(DialogResult resultado)
        {
            this.DialogResult = resultado;
            this.Close();
        }

        public event EventHandler VistaCargando;
        public event EventHandler RegistrarProducto;
        public event EventHandler Cancelar;
    }
}
