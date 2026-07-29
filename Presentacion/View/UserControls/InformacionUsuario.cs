using System;
using System.Windows.Forms;

namespace Presentacion.View.UserControls
{
    public partial class InformacionUsuario : UserControl, Interfaces.IInformacionUsuarioView
    {


        #region
        public string Cedula
        {
            get => KtxtCedula.Text;
            set => KtxtCedula.Text = value;
        }

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
        public InformacionUsuario()
        {
            InitializeComponent();

            Eventos();

            EnableDoubleBuffer(tLPInformacionPersonal);
            EnableDoubleBuffer(tLPInformacionPersonal2);
        }
        private void Eventos()
        {
            btnEditar.Click += (s, e) => EditarInformacion?.Invoke(s, e);
            btnPermisos.Click += (s, e) => AdministrarPermisos?.Invoke(s, e);
            btnSoporte.Click += BtnSoporte_Click;
            itemReportarFalla.Click += delegate { ReportarFallaClick?.Invoke(this, EventArgs.Empty); };
            itemSolicitarLicencia.Click += delegate { SolicitarLicenciaClick?.Invoke(this, EventArgs.Empty); };
        

            this.Load += (s, e) => MostrarInformacion?.Invoke(s, e);
            llbCorreo.LinkClicked += (s, e) => SolicitarCorreoSoporte?.Invoke(this, EventArgs.Empty);
        }
        private void BtnSoporte_Click(object sender, EventArgs e)
        {
            // Muestra el ContextMenuStrip justo debajo del botón de soporte
            cmsSoporte.Show(btnSoporte, 0, btnSoporte.Height);
        }
        public void AbrirGmailBorrador(string destinatario, string asunto, string urlFinal)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = urlFinal, // Ejecuta directamente el string que mandó el presentador
                    UseShellExecute = true
                });
                llbCorreo.LinkVisited = true;
            }
            catch (Exception ex)
            {
                MostrarMensaje("No se pudo abrir el cliente de correo: " + ex.Message, "Error", MessageBoxIcon.Error);
            }
        }

        public void MostrarMensaje(string mensaje, string titulo, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);
        }

        private void EnableDoubleBuffer(Control control)
        {
            typeof(Control).GetProperty("DoubleBuffered",
                                        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(control, true);
        }


        public event EventHandler SolicitarCorreoSoporte;
        public event EventHandler EditarInformacion;
        public event EventHandler AdministrarPermisos;
        public event EventHandler MostrarInformacion;
        public event EventHandler ReportarFallaClick;
        public event EventHandler SolicitarLicenciaClick;
    }
}


