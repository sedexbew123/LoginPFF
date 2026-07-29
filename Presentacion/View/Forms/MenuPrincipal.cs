using Presentacion.View.UserControls;
using System;
using System.Windows.Forms;

namespace Presentacion.View.Forms
{
    public partial class MenuPrincipal : Form, Interfaces.IMenuPrincipalView
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            DiseñoOriginal();

            Presentacion.Helpers.ControlAcceso.AplicarRestriccionesPorRol(
               btnInformes,
               btnInventario,
               btnEmpleados,
               btnInformacionUsuario
           );

            lblUsuario.Text = Entidades.SesionUsuario.UsuarioLogueado.User;
            lblRol.Text = Entidades.SesionUsuario.UsuarioLogueado.NombreRol;
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

        private void DiseñoOriginal()
        {
            pnlSubMenuUsuario.Visible = false;
            pnlSubMenuClientes.Visible = false;
            pnlSubMenuSistema.Visible = false;
            pnlSubMenuPagos.Visible = false;
            pnlSubMenuInventario.Visible = false;
            pnlSubMenuServicios.Visible = false;
            Eventos();
            HideSubMenu();
            AbrirFormulario(new Inicio());
        }

        private void HideSubMenu()
        {
            if (pnlSubMenuUsuario.Visible == true)
                pnlSubMenuUsuario.Visible = false;
            if (pnlSubMenuClientes.Visible == true)
                pnlSubMenuClientes.Visible = false;
            if (pnlSubMenuSistema.Visible == true)
                pnlSubMenuSistema.Visible = false;
            if (pnlSubMenuInventario.Visible == true)
                pnlSubMenuInventario.Visible = false;
            if (pnlSubMenuPagos.Visible == true)
                pnlSubMenuPagos.Visible = false;
            if (pnlSubMenuServicios.Visible == true)
                pnlSubMenuServicios.Visible = false;
        }

        private void Eventos()
        {
            picLogo.Click += (s, e) => ShowSubMenu(pnlSubMenuUsuario);
            btnClientes.Click += (s, e) => ShowSubMenu(pnlSubMenuClientes);
            btnSistema.Click += (s, e) => ShowSubMenu(pnlSubMenuSistema);
            btnPagos.Click += (s, e) => ShowSubMenu(pnlSubMenuPagos);
            btnInventario.Click += (s, e) => ShowSubMenu(pnlSubMenuInventario);
            btnServicios.Click += (s, e) => ShowSubMenu(pnlSubMenuServicios);
            btnInformes.Click += (s, e) => { HideSubMenu(); InformesClick?.Invoke(this, EventArgs.Empty); };
            btnAcercaDe.Click += (s, e) => { HideSubMenu(); AcercaDeClick?.Invoke(this, EventArgs.Empty); };
            btnTasa.Click += (s, e) => { HideSubMenu(); TasaClick?.Invoke(this, EventArgs.Empty); };

            btnInicio.Click += (s, e) => { HideSubMenu(); HomeClick?.Invoke(this, EventArgs.Empty); };
            btnInformacionUsuario.Click += (s, e) => { HideSubMenu(); InformacionUsuarioClick?.Invoke(this, EventArgs.Empty); };
            btnEmpleados.Click += (s, e) => { HideSubMenu(); EmpleadosClick?.Invoke(this, EventArgs.Empty); };
            btnCambiarContraseña.Click += (s, e) => { HideSubMenu(); CambiarContraseñaClick?.Invoke(this, EventArgs.Empty); };
            btnCerrarSesion.Click += (s, e) => { HideSubMenu(); CerrarSesionClick?.Invoke(this, EventArgs.Empty); };
            btnRegistro.Click += (s, e) => { HideSubMenu(); RegistroClientesClick?.Invoke(this, EventArgs.Empty); };
            btnListado.Click += (s, e) => { HideSubMenu(); ListadoClientesClick?.Invoke(this, EventArgs.Empty); };
            btnAsignarCredito.Click += (s, e) => { HideSubMenu(); AsignarCreditoClick?.Invoke(this, EventArgs.Empty); };
            btnEstadoDeuda.Click += (s, e) => { HideSubMenu(); EstadoDeudaClick?.Invoke(this, EventArgs.Empty); };
            btnGestionPagos.Click += (s, e) => { HideSubMenu(); GestionPagosClick?.Invoke(this, EventArgs.Empty); };
            btnListadoPago.Click += (s, e) => { HideSubMenu(); ListadoPagosClick?.Invoke(this, EventArgs.Empty); };
            btnConfiguracionServicios.Click += (s, e) => { HideSubMenu(); ConfiguracionServiciosClick?.Invoke(this, EventArgs.Empty); };
            btnControlTrabajo.Click += (s, e) => { HideSubMenu(); ControlTrabajoClick?.Invoke(this, EventArgs.Empty); };
            btnRegistroProductos.Click += (s, e) => { HideSubMenu(); RegistroProductosClick?.Invoke(this, EventArgs.Empty); };
            btnConfiguracion.Click += (s, e) => { HideSubMenu(); CategoriaClick?.Invoke(this, EventArgs.Empty); };
            btnCargoProductos.Click += (s, e) => { HideSubMenu(); CargoProductosClick?.Invoke(this, EventArgs.Empty); };
            btnDescargoProductos.Click += (s, e) => { HideSubMenu(); DescargoProductosClick?.Invoke(this, EventArgs.Empty); };
            btnDetalles.Click += (s, e) => { HideSubMenu(); DetallesProductosClick?.Invoke(this, EventArgs.Empty); };
        }

        private void ShowSubMenu(Panel panel)
        {
            if (panel.Visible == false)
            {
                HideSubMenu();
                panel.Visible = true;
            }
            else
            {
                panel.Visible = false;
            }
        }

        public void AbrirFormulario(UserControl formulario)
        {
            formulario.Visible = false;

            pnlContenedor.Controls.Clear();

            pnlContenedor.SuspendLayout();

            formulario.Dock = DockStyle.Fill;

            pnlContenedor.Controls.Add(formulario);

            pnlContenedor.ResumeLayout();

            formulario.Visible = true;
            formulario.BringToFront();
            formulario.Focus();
        }

        public event EventHandler HomeClick;
        public event EventHandler InformacionUsuarioClick;
        public event EventHandler EmpleadosClick;
        public event EventHandler CambiarContraseñaClick;
        public event EventHandler RegistroClientesClick;
        public event EventHandler ListadoClientesClick;
        public event EventHandler AsignarCreditoClick;
        public event EventHandler EstadoDeudaClick;
        public event EventHandler GestionPagosClick;
        public event EventHandler ListadoPagosClick;
        public event EventHandler ConfiguracionServiciosClick;
        public event EventHandler ControlTrabajoClick;
        public event EventHandler RegistroProductosClick;
        public event EventHandler CategoriaClick;
        public event EventHandler CargoProductosClick;
        public event EventHandler DescargoProductosClick;
        public event EventHandler DetallesProductosClick;
        public event EventHandler TasaClick;
        public event EventHandler InformesClick;
        public event EventHandler AcercaDeClick;
        public event EventHandler CerrarSesionClick;
    }
}



