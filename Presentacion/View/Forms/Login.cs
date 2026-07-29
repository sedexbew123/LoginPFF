using Presentacion.Helpers;
using Presentacion.View.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.View.Forms
{
    public partial class Login : Form, ILoginView
    {

        #region Propiedades
        public string Usuario
        {
            get => txtUsuario.Text;
            set => txtUsuario.Text = value;
        }

        public string Contraseña
        {
            get => txtContraseña.Text;
            set => txtContraseña.Text = value;
        }

        public bool SecurityContraseña
        {
            get => txtContraseña.UseSystemPasswordChar;
            set => txtContraseña.UseSystemPasswordChar = value;
        }

        public bool MostrarOpciones
        {
            get => pnlMostrarRecuperacion.Visible;
            set => pnlMostrarRecuperacion.Visible = value;
        }

        #endregion
        public Login()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            AsociarEventos();
            this.ActiveControl = lblInicio;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {

                if (pnlMostrarRecuperacion.Visible)
                {
                    btnSiguiente.PerformClick();
                    return true;
                }
                else
                {

                    btnIngresar.PerformClick();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Helpers.AnimateWindows.Start(this, 350, Helpers.AnimateWindows.AnimateWindowsFlags.AW_ACTIVATE | AnimateWindows.AnimateWindowsFlags.AW_BLEND);

            this.Invalidate(true);
        }

        public void MoverFormulario()
        {
            Helpers.MoveForm.ReleaseCapture();
            Helpers.MoveForm.SendMessage(this.Handle, 0x112, new IntPtr(0xf012), IntPtr.Zero);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void AsociarEventos()
        {
            this.Load += delegate { LoginLoad.Invoke(this, EventArgs.Empty); };
            picLogo.MouseDown += delegate { ArrastrarFormulario?.Invoke(this, EventArgs.Empty); };
            picUsuario.MouseDown += delegate { ArrastrarFormulario?.Invoke(this, EventArgs.Empty); };
            picContraseña.MouseDown += delegate { ArrastrarFormulario?.Invoke(this, EventArgs.Empty); };
            this.MouseDown += delegate { ArrastrarFormulario?.Invoke(this, EventArgs.Empty); };
            lblInicio.MouseDown += delegate { ArrastrarFormulario?.Invoke(this, EventArgs.Empty); };

            chkMostrar.CheckedChanged += delegate { MostrarContraseña?.Invoke(this, EventArgs.Empty); };
            btnCerrar.Click += delegate { Cerrar?.Invoke(this, EventArgs.Empty); };
            btnIngresar.Click += delegate { IniciarSesion?.Invoke(this, EventArgs.Empty); };
            llbRecuperarCuenta.Click += delegate { RecuperarCuenta?.Invoke(this, EventArgs.Empty); };
            llbVolver.Click += delegate { VolverAlInicio?.Invoke(this, EventArgs.Empty); };
            btnSiguiente.Click += delegate { Siguiente?.Invoke(this, EventArgs.Empty); };

        }
        public void MostrarPanelOpciones()
        {
            this.SuspendLayout();
            pnlMostrarRecuperacion.Visible = true;
            this.ResumeLayout(true);
            this.Update();
        }

        public void OcultarPanelOpciones()
        {
            this.SuspendLayout();
            pnlMostrarRecuperacion.Visible = false;
            this.ResumeLayout(true);
            this.Update();
        }

        public void MostrarEstado(string mensaje, TipoMensaje tipo)
        {
            lblEstado.Text = mensaje;

            if (string.IsNullOrWhiteSpace(mensaje))
            {
                lblEstado.Visible = false;
                return;
            }
            lblEstado.Visible = true;
            switch (tipo)
            {
                case TipoMensaje.Exito:
                    lblEstado.ForeColor = Color.Green;
                    break;
                case TipoMensaje.Error:
                    lblEstado.ForeColor = Color.Red;
                    break;
                case TipoMensaje.Normal:
                    lblEstado.ForeColor = Color.Black;
                    break;
            }
        }

        public string OpcionRecuperacion => cboxOpciones.SelectedItem?.ToString();

        public void OcultarVista()
        {
            this.Hide();
        }

        public event EventHandler IniciarSesion;
        public event EventHandler MostrarContraseña;
        public event EventHandler Cerrar;
        public event EventHandler RecuperarCuenta;
        public event EventHandler VolverAlInicio;
        public event EventHandler ArrastrarFormulario;
        public event EventHandler Siguiente;

        public event EventHandler LoginLoad;
    }
}

