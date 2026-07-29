using Entidades;
using Logica;
using Presentacion.Helpers;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Presentacion.View.Forms
{
    public partial class EditarClientes : Form, Interfaces.IEditarClientesView
    {
        private Presenter.EditarClientesPresenter _presenter;

        #region
        public int Cedula
        {
            get => int.Parse(txtCedula.Text);
            set => txtCedula.Text = value.ToString();
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
        public byte[] FotoEmpleado
        {
            get
            {
                if (picFotoEmpleado.Image == null) return null;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (Bitmap bmp = new Bitmap(picFotoEmpleado.Image))
                    {
                        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    return ms.ToArray();
                }
            }
            set
            {
                picFotoEmpleado.Image?.Dispose();

                // CASO 1: Si no hay foto o viene vacía (Opcional)
                if (value == null || value.Length == 0)
                {
                    picFotoEmpleado.Image = null;

                    // ACTIVAMOS EL BORDE para delimitar el cuadro vacío
                    picFotoEmpleado.BorderStyle = BorderStyle.FixedSingle;
                    return;
                }

                try
                {
                    using (var ms = new System.IO.MemoryStream(value))
                    {
                        // DESACTIVAMOS EL BORDE para que la foto no se corte ni se vea estirada
                        picFotoEmpleado.BorderStyle = BorderStyle.None;

                        picFotoEmpleado.SizeMode = PictureBoxSizeMode.Zoom;
                        picFotoEmpleado.Image = Image.FromStream(ms);
                    }
                }
                catch
                {
                    picFotoEmpleado.Image = null;
                    // Si hay error, regresamos al estado con borde
                    picFotoEmpleado.BorderStyle = BorderStyle.FixedSingle;
                }
            }
        }
        public bool MostrarFotoGuardada
        {
            set
            {
                lblFotoGuardada.Visible = value;
            }
        }

        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        #endregion
        private readonly Clientes _cliente;
        public EditarClientes(Clientes cliente)
        {
            InitializeComponent();
            Eventos();
            _presenter = new Presenter.EditarClientesPresenter(this, new Logica.L_Clientes());
            _cliente = cliente;
            CargarDatosEnCampos();
            _presenter.InicializarFormulario(_cliente.Cedula);
        }

        private void Eventos()
        {

            btnCerrar.Click += delegate { Cerrar?.Invoke(this, EventArgs.Empty); };
            btnEditar.Click += delegate { EditarCliente?.Invoke(this, EventArgs.Empty); };
            btnCancelar.Click += delegate { Cancelar?.Invoke(this, EventArgs.Empty); };
            btnAgregarImagen.Click += (s, e) => AgregarImagen?.Invoke(this, EventArgs.Empty);
            btnTomarFoto.Click += (s, e) => TomarFoto?.Invoke(this, EventArgs.Empty);

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
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Enter)
            {
                btnEditar.PerformClick();
                return true;
            }

            if (keyData == Keys.Escape)
            {
                btnCerrar.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        public void MostrarCargando()
        {
            pnlContenidoDatos.Visible = false;

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
            pnlContenidoDatos.Visible = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Helpers.AnimateWindows.Start(this, 350, Helpers.AnimateWindows.AnimateWindowsFlags.AW_ACTIVATE | AnimateWindows.AnimateWindowsFlags.AW_BLEND);

            this.Invalidate(true);
        }

        private void CargarDatosEnCampos()
        {
            txtCedula.Text = _cliente.Cedula;
            txtNombre.Text = _cliente.Nombres;
            txtApellido.Text = _cliente.Apellidos;
            txtTelefono.Text = _cliente.Telefono;
            txtCorreo.Text = _cliente.Correo;
            txtDireccion.Text = _cliente.Direccion;
            txtCedula.ReadOnly = true;
            FotoEmpleado = _cliente.Foto;
        }

        public void CerrarVista()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public event EventHandler Cerrar;
        public event EventHandler EditarCliente;
        public event EventHandler Cancelar;
        public event EventHandler AgregarImagen;
        public event EventHandler TomarFoto;
    }
}
