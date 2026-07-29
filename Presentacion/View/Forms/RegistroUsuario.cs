using Logica;
using Presentacion.Helpers;
using System;
using System.Windows.Forms;

namespace Presentacion.View.Forms
{
    public partial class RegistroUsuario : Form, Interfaces.IRegistroUsuarioView
    {
        private Presenter.RegistroUsuarioPresenter _presenter;
        #region
        public string Nombre
        {
            get => KtxtNombre.Text;
            set => KtxtNombre.Text = value;
        }
        public string Apellido
        {
            get => KtxtApellido.Text;
            set => KtxtApellido.Text = value;
        }
        public string Cedula
        {
            get => KtxtCedula.Text;
            set => KtxtCedula.Text = value;
        }
        public string Telefono
        {
            get => KtxtTelefono.Text;
            set => KtxtTelefono.Text = value;
        }
        public string Correo
        {
            get => KtxtCorreo.Text;
            set => KtxtCorreo.Text = value;
        }
        public string Direccion
        {
            get => KtxtDireccion.Text;
            set => KtxtDireccion.Text = value;
        }


        #endregion
        public RegistroUsuario()
        {
            InitializeComponent();
            Eventos();
            this.ActiveControl = lblRegistro;

            if (pnlContenedorDatos != null) pnlContenedorDatos.Visible = false;
            if (pnlCarga != null)
            {
                pnlCarga.Visible = true;
                pnlCarga.BringToFront();
            }

            _presenter = new Presenter.RegistroUsuarioPresenter(this, new L_Usuarios());
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Helpers.AnimateWindows.Start(this, 350, Helpers.AnimateWindows.AnimateWindowsFlags.AW_ACTIVATE | AnimateWindows.AnimateWindowsFlags.AW_BLEND);

            this.Invalidate(true);

            VistaListaParaCargar?.Invoke(this, EventArgs.Empty);
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

        public void CerrarVista()
        {
            this.Close();
        }

        public void NotificarEdicionExitosa()
        {
            UsuarioEditadoExitosamente?.Invoke(this, EventArgs.Empty);
        }

        private void Eventos()
        {
            KbtnRegistrar.Click += delegate { EditarUsuario?.Invoke(this, EventArgs.Empty); };
            llbVolver.Click += delegate { VolverAlLogin?.Invoke(this, EventArgs.Empty); };

            KtxtNombre.KeyPress += SoloLetras_KeyPress;
            KtxtApellido.KeyPress += SoloLetras_KeyPress;

            KtxtNombre.TextChanged += QuitarNumeros_TextChanged;
            KtxtApellido.TextChanged += QuitarNumeros_TextChanged;
        }

        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void QuitarNumeros_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                int cursorPosition = textBox.SelectionStart;
                string textoFiltrado = "";

                foreach (char c in textBox.Text)
                {
                    if (char.IsLetter(c) || char.IsWhiteSpace(c))
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

        public void MostrarMensaje(string mensaje, string titulo, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);
        }

        public event EventHandler EditarUsuario;
        public event EventHandler VolverAlLogin;
        public event EventHandler UsuarioEditadoExitosamente;
        public event EventHandler VistaListaParaCargar;
    }
}
