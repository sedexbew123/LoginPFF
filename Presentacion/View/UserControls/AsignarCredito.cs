using Presentacion.View.Interfaces;
using System;
using System.Windows.Forms;

namespace Presentacion.View.UserControls
{
    public partial class AsignarCredito : UserControl, IAsignarCreditoView
    {
        #region
        public string Cedula
        {
            get => txtCedula.Text.Trim();
            set => txtCedula.Text = value;
        }
        public string Nombre
        {
            get => txtNombre.Text.Trim();
            set => txtNombre.Text = value;
        }
        public string Apellido
        {
            get => txtApellido.Text.Trim();
            set => txtApellido.Text = value;
        }
        public DateTime FechaLimite
        {
            get => dtpFechaLimite.Value;
            set => dtpFechaLimite.Value = value;
        }

        public decimal TotalPrecio { get => nUDMontoTotal.Value; set => nUDMontoTotal.Value = value; }
        public DataGridView DgvProductos => dGVDatos;

        #endregion
        public AsignarCredito()
        {
            InitializeComponent();
            Eventos();
            InicializarTabla();

            EnableDoubleBuffer(tLPInformacionBasica);
            EnableDoubleBuffer(dGVDatos);
            EnableDoubleBuffer(tLPDatos);

            this.nUDMontoTotal.Enabled = false;
            this.nUDMontoTotal.BackColor = System.Drawing.Color.White;
            this.nUDMontoTotal.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);

            dtpFechaLimite.MinDate = DateTime.Today;
            dtpFechaLimite.Value = DateTime.Today;
        }

        private void InicializarTabla()
        {
            if (dGVDatos.Columns.Count == 0)
            {
                dGVDatos.Columns.Add("Cantidad", "Cantidad");
                dGVDatos.Columns.Add("Producto", "Producto");
                dGVDatos.Columns.Add("Categoria", "Categoría");
                dGVDatos.Columns.Add("Precio", "Precio Unitario");
            }
        }

        private void Eventos()
        {
            btnAgregar.Click += delegate { AgregarCreditoClick?.Invoke(this, EventArgs.Empty); };
            btnAsignar.Click += delegate { AsignarCreditoClick?.Invoke(this, EventArgs.Empty); };
            txtCedula.TextChanged += delegate { CedulaTextChanged?.Invoke(this, EventArgs.Empty); };
            txtCedula.KeyPress += SoloNumeros_KeyPress;
            txtCedula.TextChanged += QuitarLetrasCedula_TextChanged;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;

            if (msg.Msg == WM_KEYDOWN || msg.Msg == WM_SYSKEYDOWN)
            {
                Keys teclaPura = keyData & Keys.KeyCode;

                if (teclaPura == Keys.F5)
                {
                    btnAgregar.PerformClick();
                    return true;
                }

                if (teclaPura == Keys.F6)
                {
                    btnAsignar.PerformClick();
                    return true; 
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void QuitarLetrasCedula_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                int cursorPosition = textBox.SelectionStart;
                string textoFiltrado = "";

                foreach (char c in textBox.Text)
                {
                    if (char.IsDigit(c))
                    {
                        textoFiltrado += c;
                    }
                }

                if (textBox.Text != textoFiltrado)
                {
                    textBox.Text = textoFiltrado;
                    textBox.SelectionStart = Math.Max(0, cursorPosition - 1);
                }
            }
        }

        public void MostrarMensaje(string mensaje, bool esError = false)
        {
            MessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK,
                esError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }

        public void AgregarItemAlGrid(string cantidad, string producto,
                               string categoria, string precio)
        {
            dGVDatos.Rows.Add(cantidad, producto, categoria, precio);
        }

        public void EliminarItemSeleccionado()
        {
            int idx = ObtenerIndiceSeleccionado();
            if (idx >= 0 && idx < dGVDatos.Rows.Count && !dGVDatos.Rows[idx].IsNewRow)
                dGVDatos.Rows.RemoveAt(idx);
        }

        public int ObtenerIndiceSeleccionado()
            => dGVDatos.CurrentRow?.Index ?? -1;

        public void LimpiarCampos()
        {
            txtCedula.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            TotalPrecio = 0;
            dGVDatos.Rows.Clear();
            dtpFechaLimite.Value = DateTime.Now;
        }
        private void EnableDoubleBuffer(Control control)
        {
            typeof(Control).GetProperty("DoubleBuffered",
                                        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(control, true);
        }

        public event EventHandler AgregarCreditoClick;
        public event EventHandler AsignarCreditoClick;
        public event EventHandler CedulaTextChanged;
    }
}
