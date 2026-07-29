using Presentacion.Helpers;
using Presentacion.View.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.View.Forms
{
    public partial class RecuperarContraseña : Form, Interfaces.IRecuperarContraseñaView
    {
        private Presenter.RecuperarContraseñaPresenter _presenter;

        #region Propiedades
        public string Correo
        {
            get => KtxtCorreo.Text;
            set => KtxtCorreo.Text = value;
        }
        #endregion

        public RecuperarContraseña()
        {
            InitializeComponent();
            AsociarEventos();
            this.ActiveControl = lblOlvido;
            _presenter = new Presenter.RecuperarContraseñaPresenter(this);
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
        private void AsociarEventos()
        {
            picLogo.MouseDown += delegate { ArrastrarFormulario?.Invoke(this, EventArgs.Empty); };
            this.MouseDown += delegate { ArrastrarFormulario?.Invoke(this, EventArgs.Empty); };
            lblOlvido.MouseDown += delegate { ArrastrarFormulario?.Invoke(this, EventArgs.Empty); };
            KbtnSiguiente.Click += delegate { EnviarCodigo?.Invoke(this, EventArgs.Empty); };
            llbVolver.Click += delegate { VolverAlInicio?.Invoke(this, EventArgs.Empty); };
            btnCerrar.Click += delegate { Cerrar?.Invoke(this, EventArgs.Empty); };
        }
        private void RecuperarContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                btnCerrar.PerformClick();
            }
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
        public void CerrarVista()
        {
            this.Close();
        }
        public void OcultarVista()
        {
            this.Hide();
        }

        public event EventHandler EnviarCodigo;
        public event EventHandler Cerrar;
        public event EventHandler VolverAlInicio;
        public event EventHandler ArrastrarFormulario;
    }
}
