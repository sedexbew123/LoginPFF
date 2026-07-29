using Presentacion.Helpers;
using System;
using System.Windows.Forms;

namespace Presentacion.View.Forms
{
    public partial class CambiarContraseña : Form, Interfaces.ICambiarContraseñaView
    {
        private Presenter.CambiarContraseñaPresenter _presenter;

        #region Propiedades

        public string ContraseñaActual
        {
            get => txtContraseñaActual.Text;
            set => txtContraseñaActual.Text = value;
        }
        public string NuevaContraseña
        {
            get => txtContraseñaNueva.Text;
            set => txtContraseñaNueva.Text = value;
        }
        public string ConfirmarContraseña
        {
            get => txtConfirmarContraseña.Text;
            set => txtConfirmarContraseña.Text = value;
        }

        public bool SecurityContraseñaActual
        {
            get => txtContraseñaActual.UseSystemPasswordChar;
            set => txtContraseñaActual.UseSystemPasswordChar = value;
        }
        public bool SecurityNuevaContraseña
        {
            get => txtContraseñaNueva.UseSystemPasswordChar;
            set => txtContraseñaNueva.UseSystemPasswordChar = value;
        }
        public bool SecurityConfirmarContraseña
        {
            get => txtConfirmarContraseña.UseSystemPasswordChar;
            set => txtConfirmarContraseña.UseSystemPasswordChar = value;
        }

        #endregion

        public CambiarContraseña()
        {
            InitializeComponent();
            Eventos();
            _presenter = new Presenter.CambiarContraseñaPresenter(this);
        }

        private void Eventos()
        {
            btnCerrar.Click += (s, e) => Cerrar?.Invoke(this, EventArgs.Empty);
            btnCambiar.Click += delegate { CambiarContraseñaActual?.Invoke(this, EventArgs.Empty); };
            chkMostrar.CheckedChanged += delegate { MostrarContraseña?.Invoke(this, EventArgs.Empty); };
        }

        private void CambiarContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                btnCerrar.PerformClick();
            }
        }
        public void MostrarMensaje(string mensaje, bool esError)
        {
            MessageBox.Show(mensaje, "Contraseña Actualizada", MessageBoxButtons.OK,
                            esError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
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

        public event EventHandler Cerrar;
        public event EventHandler CambiarContraseñaActual;
        public event EventHandler MostrarContraseña;
    }
}
