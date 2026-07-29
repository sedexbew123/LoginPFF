using Presentacion.View.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.View.UserControls
{
    public partial class RegistroClientes : UserControl, IRegistroClientesView
    {

        #region Propiedades

        public string Cedula
        {
            get => txtCedula.Text;
            set => txtCedula.Text = value;
        }

        public string Nombre
        {
            get => txtNombre.Text;
            set => txtNombre.Text = value;
        }

        public string Apellido
        {
            get => txtApellido.Text;
            set => txtApellido.Text = value;
        }

        public string Telefono
        {
            get => txtTelefono.Text;
            set => txtTelefono.Text = value;
        }

        public string Correo
        {
            get => txtCorreo.Text;
            set => txtCorreo.Text = value;
        }
        public string Direccion
        {
            get => txtDireccion.Text;
            set => txtDireccion.Text = value;
        }
        public bool MostrarFotoGuardada
        {
            set => lblEstadoFoto.Visible = value;
        }
        #endregion

        #region Atributos
        private TextBox txtTrampa;
        #endregion
        public RegistroClientes()
        {
            InitializeComponent();
            Eventos();

            lblEstadoFoto.Visible = false;

            txtTrampa = new TextBox()
            {
                Location = new Point(-100, -100),
                TabIndex = 0,
                TabStop = true
            };

            this.Controls.Add(txtTrampa);

            EnableDoubleBuffer(tLPInformacionBasica);
            EnableDoubleBuffer(tLPInformacionContacto);
        }

        private void Eventos()
        {
            btnRegistrar.Click += (s, e) => RegistrarClienteClick?.Invoke(this, EventArgs.Empty);
            btnCancelar.Click += (s, e) => LimpiarCamposClientesClick?.Invoke(this, EventArgs.Empty);
            btnAgregarImagen.Click += (s, e) => AgregarImagen?.Invoke(this, EventArgs.Empty);
            btnTomarFoto.Click += (s, e) => TomarFoto?.Invoke(this, EventArgs.Empty);

            txtCedula.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            };

            txtTelefono.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            };

            txtNombre.KeyPress += (s, e) =>
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            };

            txtApellido.KeyPress += (s, e) =>
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            };

            txtCorreo.CharacterCasing = CharacterCasing.Lower;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                btnCancelar.PerformClick();
                return true;
            }

            if (keyData == Keys.Enter && !(this.ActiveControl is TextBox textBox && textBox.Multiline))
            {
                btnRegistrar.PerformClick(); 
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void LimpiarCampos()
        {
            txtCedula.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();

            lblEstadoFoto.Visible = false;
        }

        public void MostrarMensaje(string mensaje, bool esExito)
        {
            MessageBox.Show(mensaje, "Registro Clientes", MessageBoxButtons.OK,
                esExito ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }

        private void EnableDoubleBuffer(Control control)
        {
            typeof(Control).GetProperty("DoubleBuffered",
                                        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(control, true);
        }

        public event EventHandler RegistrarClienteClick;
        public event EventHandler LimpiarCamposClientesClick;
        public event EventHandler AgregarImagen;
        public event EventHandler TomarFoto;
    }
}
