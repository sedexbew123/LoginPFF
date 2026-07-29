using Presentacion.Helpers;
using Presentacion.View.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.View.Forms
{
    public partial class TokenContraseña : Form, Interfaces.ITokenContraseñaView
    {
        private Presenter.TokenContraseñaPresenter _presenter;

        #region Propiedades

        public string Codigo
        {
            get => KtxtCodigo.Text;
            set => KtxtCodigo.Text = value;
        }

        public string Contraseña1
        {
            get => KtxtContraseña1.Text;
            set => KtxtContraseña1.Text = value;
        }
        public string Contraseña2
        {
            get => ktxtContraseña2.Text;
            set => ktxtContraseña2.Text = value;
        }
        public bool SecurityContraseña
        {
            get => KtxtContraseña1.UseSystemPasswordChar;
            set
            {
                KtxtContraseña1.UseSystemPasswordChar = value;
                KtxtContraseña1.PasswordChar = value ? '●' : '\0';
            }
        }
        public bool SecurityContraseña2
        {
            get => ktxtContraseña2.UseSystemPasswordChar;
            set
            {
                ktxtContraseña2.UseSystemPasswordChar = value;
                ktxtContraseña2.PasswordChar = value ? '●' : '\0';
            }
        }
        public bool MostrarOpciones
        {
            get => pnlMostrar.Visible;
            set => pnlMostrar.Visible = value;
        }

        #endregion
        public TokenContraseña()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            AsociarEventos();
            this.ActiveControl = lblOlvido;
            _presenter = new Presenter.TokenContraseñaPresenter(this);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (pnlMostrar.Visible)
                {
                    KbtnCambiar.PerformClick();
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

            Helpers.AnimateWindows.Start(this, 350, Helpers.AnimateWindows.AnimateWindowsFlags.AW_ACTIVATE | AnimateWindows.AnimateWindowsFlags.AW_BLEND);

            this.Invalidate(true);
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

        public void CerrarVista()
        {
            this.Close();
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
            KbtnValidar.Click += delegate { ValidarCodigo?.Invoke(this, EventArgs.Empty); };
            KbtnCambiar.Click += delegate { CambiarContraseña?.Invoke(this, EventArgs.Empty); };
            chkMostrar.CheckedChanged += delegate { MostrarContraseña?.Invoke(this, EventArgs.Empty); };
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

        public event EventHandler CambiarContraseña;
        public event EventHandler ValidarCodigo;
        public event EventHandler MostrarContraseña;
        public event EventHandler VolverAlInicio;
        public event EventHandler ArrastrarFormulario;
    }
}
