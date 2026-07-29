using Logica;
using Presentacion.View.Interfaces;
using System;

namespace Presentacion.Presenter
{
    public class CambiarContraseñaPresenter
    {
        private readonly ICambiarContraseñaView _view;
        private readonly L_Usuarios _logica = new L_Usuarios();

        public CambiarContraseñaPresenter(ICambiarContraseñaView view)
        {
            _view = view;
            _logica = new L_Usuarios();
            _view.Cerrar += Cerrar_Accion;
            _view.CambiarContraseñaActual += CambiarContraseñaActual_Accion;
            _view.MostrarContraseña += MostrarContraseña_Accion;
        }

        private async void CambiarContraseñaActual_Accion(object sender, EventArgs e)
        {
            var resultado = await _logica.CambiarContraseña(
                _view.ContraseñaActual,
                _view.NuevaContraseña,
                _view.ConfirmarContraseña
            );

            _view.MostrarMensaje(resultado.Mensaje, !resultado.Estado);

            if (resultado.Estado)
                _view.CerrarVista();
        }

        private void MostrarContraseña_Accion(object sender, EventArgs e)
        {
            _view.SecurityContraseñaActual = !_view.SecurityContraseñaActual;
            _view.SecurityNuevaContraseña = !_view.SecurityNuevaContraseña;
            _view.SecurityConfirmarContraseña = !_view.SecurityConfirmarContraseña;
        }

        private void Cerrar_Accion(object sender, EventArgs e)
        {
            _view.CerrarVista();
        }
    }
}