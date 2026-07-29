using Presentacion.Helpers;
using Presentacion.View.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.View.Forms
{
    public partial class TokenUsuario : Form, Interfaces.ITokenUsuarioView
    {
        private Presenter.TokenUsuarioPresenter _presenter;

        #region
        public string Codigo
        {
            get => KtxtCodigo.Text;
            set => KtxtCodigo.Text = value;
        }
        public string NuevoUsuario
        {
            get => KtxtNuevoUsuario.Text;
            set => KtxtNuevoUsuario.Text = value;
        }
        public string ConfirmarUsuario
        {
            get => KtxtConfirmarUsuario.Text;
            set => KtxtConfirmarUsuario.Text = value;
        }
        public bool MostrarOpciones
        {
            get => pnlMostrar.Visible;
            set => pnlMostrar.Visible = value;
        }

        #endregion

        public TokenUsuario()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            AsociarEventos();
            _presenter = new Presenter.TokenUsuarioPresenter(this);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (pnlMostrar.Visible)
                {
                    KbtnConfirmar.PerformClick();
                    return true; 
                }
                else
                {
                    KbtnValidar.PerformClick();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helpers.AnimateWindows.Start(this, 350, AnimateWindows.AnimateWindowsFlags.AW_ACTIVATE | AnimateWindows.AnimateWindowsFlags.AW_BLEND);
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
            picLogo.MouseDown += delegate { ArrastrarFormulario?.Invoke(this, EventArgs.Empty); };
            this.MouseDown += delegate { ArrastrarFormulario?.Invoke(this, EventArgs.Empty); };
            KbtnValidar.Click += delegate { ValidarCodigo?.Invoke(this, EventArgs.Empty); };
            KbtnConfirmar.Click += delegate { CambiarUsuario?.Invoke(this, EventArgs.Empty); };
            llbVolver.Click += delegate { VolverAlInicio?.Invoke(this, EventArgs.Empty); };
        }
        public void MostrarPanelOpciones()
        {
            this.SuspendLayout(); 
            pnlMostrar.Visible = true;
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
                case TipoMensaje.Exito: lblEstado.ForeColor = Color.Green; break;
                case TipoMensaje.Error: lblEstado.ForeColor = Color.Red; break;
                case TipoMensaje.Normal: lblEstado.ForeColor = Color.Black; break;
            }
        }

        public void CerrarVista()
        {
            this.Close();
        }

        public event EventHandler ValidarCodigo;
        public event EventHandler CambiarUsuario;
        public event EventHandler VolverAlInicio;
        public event EventHandler ArrastrarFormulario;
    }
}
