using System;
using System.Windows.Forms;

namespace Presentacion.View.Interfaces
{
    public interface IMenuPrincipalView
    {
        void AbrirFormulario(UserControl formulario);

        event EventHandler HomeClick;
        event EventHandler InformacionUsuarioClick;
        event EventHandler EmpleadosClick;
        event EventHandler CambiarContraseñaClick;
        event EventHandler RegistroClientesClick;
        event EventHandler ListadoClientesClick;
        event EventHandler AsignarCreditoClick;
        event EventHandler EstadoDeudaClick;
        event EventHandler GestionPagosClick;
        event EventHandler ListadoPagosClick;
        event EventHandler ConfiguracionServiciosClick;
        event EventHandler ControlTrabajoClick;
        event EventHandler RegistroProductosClick;
        event EventHandler CategoriaClick;
        event EventHandler CargoProductosClick;
        event EventHandler DescargoProductosClick;
        event EventHandler DetallesProductosClick;
        event EventHandler TasaClick;
        event EventHandler InformesClick;
        event EventHandler AcercaDeClick;
        event EventHandler CerrarSesionClick;

    }
}
