using Presentacion.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.View.Forms
{
    public partial class NuevoEmpleado : Form, Interfaces.INuevoEmpleadoView
    {
        #region

        public string CedulaOriginal 
        { 
            get; set; 
        }

        public bool ModoEdicion
        {
            get => _modoEdicion;
            set
            {
                _modoEdicion = value;
                lblRegistroEmpleado.Text = value ? "Editar Empleado" : "Nuevo Empleado";
                btnRegistrar.Text = value ? "Guardar cambios" : "Registrar";
            }
        }
        private bool _modoEdicion;

        public string Usuario
        {
            get => txtUsuario.Text.Trim();
            set => txtUsuario.Text = value;
        }
        public string Contrasena
        {
            get => txtContraseña.Text.Trim();
            set => txtContraseña.Text = value;
        }
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

        public string Correo
        {
            get => txtCorreo.Text.Trim();
            set => txtCorreo.Text = value;
        }

        public string Direccion
        {
            get => txtDireccion.Text.Trim();
            set => txtDireccion.Text = value;
        }

        public string Telefono
        {
            get => txtTelefono.Text.Trim();
            set => txtTelefono.Text = value;
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

                if (value == null || value.Length == 0)
                {
                    picFotoEmpleado.Image = null;

                    picFotoEmpleado.BorderStyle = BorderStyle.FixedSingle;
                    return;
                }

                try
                {
                    using (var ms = new System.IO.MemoryStream(value))
                    {
                        picFotoEmpleado.BorderStyle = BorderStyle.None;

                        picFotoEmpleado.SizeMode = PictureBoxSizeMode.Zoom;
                        picFotoEmpleado.Image = Image.FromStream(ms);
                    }
                }
                catch
                {
                    picFotoEmpleado.Image = null;
                    picFotoEmpleado.BorderStyle = BorderStyle.FixedSingle;
                }
            }
        }
        #endregion

        public NuevoEmpleado()
        {
            InitializeComponent();
            Eventos();

            if (pnlContenedorDatos != null) pnlContenedorDatos.Visible = false;
            if (pnlCarga != null)
            {
                pnlCarga.Visible = true;
                pnlCarga.BringToFront();
            }
        
        }

        private void Eventos()
        {

            this.Load += (s, e) => VistaCargando?.Invoke(this, EventArgs.Empty);
            btnCerrar.Click += (s, e) => Cancelar?.Invoke(this, EventArgs.Empty);
            btnCancelar.Click += (s, e) => Cancelar?.Invoke(this, EventArgs.Empty);
            btnAgregarImagen.Click += (s, e) => AgregarImagen?.Invoke(this, EventArgs.Empty);
            btnRegistrar.Click += (s, e) => RegistrarEmpleado?.Invoke(this, EventArgs.Empty);
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
        }

        public void BloquearCedula(bool bloquear)
        {
            txtCedula.ReadOnly = bloquear;
        }

        public void BloquearUsuario(bool bloquear)
        {
            txtUsuario.ReadOnly = bloquear;
        }

        public void MostrarCampoContraseña(bool mostrar)
        {
            txtContraseña.Visible = mostrar;
            lblContraseña.Visible = mostrar;
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

        public void CerrarVista()
        {
            this.Close();
        }

        public event EventHandler VistaCargando;
        public event EventHandler RegistrarEmpleado;
        public event EventHandler Cancelar;
        public event EventHandler AgregarImagen;
        public event EventHandler TomarFoto;
    }
}
