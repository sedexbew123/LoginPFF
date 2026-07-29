using Logica;
using Presentacion.View.Forms;
using Presentacion.View.Interfaces;
using System;
using System.Windows.Forms;

namespace Presentacion.Presenter
{
    public class MenuPrincipalPresenter
    {
        private readonly IMenuPrincipalView _view;

        public MenuPrincipalPresenter(IMenuPrincipalView vista)
        {
            _view = vista;
            _view.HomeClick += AbrirPantallaHome_Accion; ;
            _view.InformacionUsuarioClick += AbrirPantallaInformacionUsuario_Accion;
            _view.EmpleadosClick += AbrirPantallaEmpleados_Accion;
            _view.CambiarContraseñaClick += AbrirPantallaCambiarContraseña_Accion;
            _view.RegistroClientesClick += AbrirPantallaRegistroClientes_Accion;
            _view.ListadoClientesClick += AbrirPantallaListadoClientes_Accion;
            _view.AsignarCreditoClick += AbrirPantallaAsignarCredito_Accion;
            _view.EstadoDeudaClick += AbrirPantallaEstadoDeuda_Accion;
            _view.GestionPagosClick += AbrirPantallaGestionPagos_Accion;
            _view.ListadoPagosClick += AbrirPantallaListadoPagos_Accion;
            _view.ConfiguracionServiciosClick += AbrirPantallaConfiguracionServicios_Accion;
            _view.ControlTrabajoClick += AbrirPantallaControlTrabajo_Accion;
            _view.RegistroProductosClick += AbrirPantallaRegistroProductos_Accion;
            _view.CategoriaClick += AbrirPantallaCategoria_Accion;
            _view.CargoProductosClick += AbrirPantallaCargoProductos_Accion;
            _view.DescargoProductosClick += AbrirPantallaDescargoProductos_Accion;
            _view.DetallesProductosClick += AbrirPantallaDetallesProductos_Accion;
            _view.TasaClick += AbrirPantallaTasa_Accion;
            _view.InformesClick += AbrirPantallaInformes_Accion;
            _view.AcercaDeClick += AbrirPantallaAcercaDe_Accion;
            _view.CerrarSesionClick += AbrirPantallaCerrarSesion_Accion;
        }

        private void AbrirPantallaControlTrabajo_Accion(object sender, EventArgs e)
        {
            var vistaControlTrabajo = new Presentacion.View.UserControls.ControlTrabajo();

            var presenterControlTrabajo = new ControlTrabajoPresenter(vistaControlTrabajo);

            _view.AbrirFormulario(vistaControlTrabajo);

        }

        private void AbrirPantallaConfiguracionServicios_Accion(object sender, EventArgs e)
        {
            var vistaCategoriaServicios = new Presentacion.View.UserControls.ConfiguracionServicio();

            var presenterCategoriaServicios = new ConfiguracionServiciosPresenter(vistaCategoriaServicios);
            
            _view.AbrirFormulario(vistaCategoriaServicios);
        }

        private void AbrirPantallaCategoria_Accion(object sender, EventArgs e)
        {
            var vistaCategoria = new Presentacion.View.UserControls.Categoria();

            L_Inventario logica = new L_Inventario();

            var presenterCategoria = new CategoriaPresenter(vistaCategoria, logica);

            _view.AbrirFormulario(vistaCategoria);
        }

        private void AbrirPantallaEmpleados_Accion(object sender, EventArgs e)
        {
            var vistaEmpleados = new Presentacion.View.UserControls.GestionEmpleados();

            var presenterEmpleados = new GestionEmpleadosPresenter(vistaEmpleados);

            _view.AbrirFormulario(vistaEmpleados);
        }

        private void AbrirPantallaInformacionUsuario_Accion(object sender, EventArgs e)
        {
            var vistaInformacionUsuario = new Presentacion.View.UserControls.InformacionUsuario();

            L_Usuarios usuarios = new L_Usuarios();

            var presenterInformacionUsuario = new InformacionUsuarioPresenter(vistaInformacionUsuario, usuarios);

            _view.AbrirFormulario(vistaInformacionUsuario);
        }

        private void AbrirPantallaInformes_Accion(object sender, EventArgs e)
        {
            var VistaInformes = new Presentacion.View.UserControls.Informes();
            _view.AbrirFormulario(VistaInformes);
        }

        private void AbrirPantallaTasa_Accion(object sender, EventArgs e)
        {
            var ucTasas = new Presentacion.View.UserControls.TasaDolar();


            var presenter = new TasaDolarPresenter(ucTasas, new L_Tasas());

            _view.AbrirFormulario(ucTasas);
        }

        private void AbrirPantallaAcercaDe_Accion(object sender, EventArgs e)
        {
            var VistaAcercaDe = new Presentacion.View.UserControls.AcercaDeDEF();

            L_Usuarios usuarios = new L_Usuarios();

            _view.AbrirFormulario(VistaAcercaDe);
        }

        private void AbrirPantallaDetallesProductos_Accion(object sender, EventArgs e)
        {
            var VistaDetallesProductos = new Presentacion.View.UserControls.ProductosDetallados();

            L_Inventario inventario = new L_Inventario();

            var presenterDetallesProductos = new ProductosDetalladosPresenter(VistaDetallesProductos, inventario);

            _view.AbrirFormulario(VistaDetallesProductos);
        }

        private void AbrirPantallaDescargoProductos_Accion(object sender, EventArgs e)
        {
            var vistaDescargoProductos = new Presentacion.View.UserControls.DescargoProductos();

            L_Inventario inventario = new L_Inventario();

            var presenterDescargoProductos = new DescargoProductoPresenter(vistaDescargoProductos, inventario);

            _view.AbrirFormulario(vistaDescargoProductos);
        }

        private void AbrirPantallaCargoProductos_Accion(object sender, EventArgs e)
        {
            var vistaCargoProductos = new Presentacion.View.UserControls.CargoProductos();

            L_Inventario inventario = new L_Inventario();

            var presenterCargoProductos = new CargoProductoPresenter(vistaCargoProductos, inventario);

            _view.AbrirFormulario(vistaCargoProductos);
        }

        private void AbrirPantallaRegistroProductos_Accion(object sender, EventArgs e)
        {
            var vistaRegistroProductos = new Presentacion.View.UserControls.RegistroProductos();

            L_Inventario inventario = new L_Inventario();

            var presenterRegistroProductos = new RegistroProductoPresenter(vistaRegistroProductos, inventario);

            _view.AbrirFormulario(vistaRegistroProductos);
        }

        private void AbrirPantallaGestionPagos_Accion(object sender, EventArgs e)
        {
            var VistaPagos = new Presentacion.View.UserControls.Pagos();

            L_Usuarios usuarios = new L_Usuarios();

            var presenterPagos = new PagosPresenter(VistaPagos);

            _view.AbrirFormulario(VistaPagos);
        }

        private void AbrirPantallaListadoPagos_Accion(object sender, EventArgs e)
        {
            var vistaListadoPagos = new Presentacion.View.UserControls.ListadoPagos();

            L_Pagos pagos = new L_Pagos();

            var presenterListadoPagos = new ListadoPagosPresenter(vistaListadoPagos, pagos);

            _view.AbrirFormulario(vistaListadoPagos);
        }

        private void AbrirPantallaEstadoDeuda_Accion(object sender, EventArgs e)
        {
            var vistaConsultaDeuda = new Presentacion.View.UserControls.ConsultaDeuda();

            L_Creditos usuarios = new L_Creditos();

            var presenterConsultaDeuda = new ConsultaDeudaPresenter(vistaConsultaDeuda, usuarios);

            _view.AbrirFormulario(vistaConsultaDeuda);
        }

        private void AbrirPantallaCambiarContraseña_Accion(object sender, EventArgs e)
        {
            var vista = new CambiarContraseña();

            var logica = new L_Usuarios();

            var presenter = new CambiarContraseña();

            vista.ShowDialog();
        }

        private void AbrirPantallaAsignarCredito_Accion(object sender, EventArgs e)
        {
            var vistaAsignarCredito = new Presentacion.View.UserControls.AsignarCredito();

            L_Creditos creditos = new L_Creditos();

            var presenterAsignarCredito = new AsignarCreditoPresenter(vistaAsignarCredito, creditos);

            _view.AbrirFormulario(vistaAsignarCredito);
        }

        private void AbrirPantallaCerrarSesion_Accion(object sender, EventArgs e)
        {
            Entidades.SesionUsuario.UsuarioLogueado = null;
            ((Form)_view).Close();
        }

        private void AbrirPantallaListadoClientes_Accion(object sender, EventArgs e)
        {
            var vistaListadoClientes = new Presentacion.View.UserControls.ListadoClientes();

            L_Clientes clientes = new L_Clientes();

            var presenterListadoClientes = new ListadoClientesPresenter(vistaListadoClientes, clientes);

            _view.AbrirFormulario(vistaListadoClientes);

        }

        private void AbrirPantallaRegistroClientes_Accion(object sender, EventArgs e)
        {
            var vistaRegistroClientes = new Presentacion.View.UserControls.RegistroClientes();

            L_Clientes clientes = new L_Clientes();

            var presenterClientes = new RegistroClientesPresenter(vistaRegistroClientes, clientes);

            _view.AbrirFormulario(vistaRegistroClientes);
        }

        private void AbrirPantallaHome_Accion(object sender, EventArgs e)
        {
            var vistaHome = new Presentacion.View.UserControls.Inicio();

            _view.AbrirFormulario(vistaHome);
        }
    }
}