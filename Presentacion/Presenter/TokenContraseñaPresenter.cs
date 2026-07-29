using Logica;
using Presentacion.View.Interfaces;
using System;
using System.Threading.Tasks;

namespace Presentacion.Presenter
{
    public class TokenContraseñaPresenter
    {
        private readonly ITokenContraseñaView _view;
        private readonly L_Usuarios _logica = new L_Usuarios();
        private string _tokenValidado = string.Empty;

        public TokenContraseñaPresenter(ITokenContraseñaView view)
        {
            _view = view;

            _view.ArrastrarFormulario += ArrastrarFormulario_Accion;
            _view.VolverAlInicio += VolverAlInicio_Accion;
            _view.ValidarCodigo += ValidarCodigo_Accion;
            _view.CambiarContraseña += CambiarContraseña_Accion;
            _view.MostrarContraseña += MostrarContraseña_Accion;
        }

        private void MostrarContraseña_Accion(object sender, EventArgs e)
        {
            _view.SecurityContraseña = !_view.SecurityContraseña;
            _view.SecurityContraseña2 = !_view.SecurityContraseña2;
        }

        private async void ValidarCodigo_Accion(object sender, EventArgs e)
        {
            string codigo = _view.Codigo?.Trim();

            if (string.IsNullOrWhiteSpace(codigo))
            {
                _view.MostrarEstado("Por favor ingrese el código recibido.", TipoMensaje.Error);
                return;
            }

            _view.MostrarEstado("Validando código...", TipoMensaje.Normal);
            var resultado = await _logica.ValidarTokenRecuperacion(codigo);

            if (resultado.Estado)
            {
                _tokenValidado = codigo;
                _view.MostrarEstado("Código válido. Ingrese su nueva contraseña.", TipoMensaje.Exito);
                _view.MostrarPanelOpciones();
            }
            else
            {
                _view.MostrarEstado(resultado.Mensaje, TipoMensaje.Error);
            }
        }

        private async void CambiarContraseña_Accion(object sender, EventArgs e)
        {
            string pass1 = _view.Contraseña1?.Trim();
            string pass2 = _view.Contraseña2?.Trim();

            if (string.IsNullOrWhiteSpace(pass1) || string.IsNullOrWhiteSpace(pass2))
            {
                _view.MostrarEstado("Todos los campos son obligatorios.", TipoMensaje.Error);
                return;
            }

            if (pass1 != pass2)
            {
                _view.MostrarEstado("Las contraseñas no coinciden.", TipoMensaje.Error);
                return;
            }

            _view.MostrarEstado("Cambiando contraseña...", TipoMensaje.Normal);
            var resultado = await _logica.RestablecerContraseña(pass1, _tokenValidado);

            if (resultado.Estado)
            {
                _view.MostrarEstado(resultado.Mensaje, TipoMensaje.Exito);
                await Task.Delay(1500);
                _view.CerrarVista();
            }
            else
            {
                _view.MostrarEstado(resultado.Mensaje, TipoMensaje.Error);
            }
        }



        private void ArrastrarFormulario_Accion(object sender, EventArgs e)
        {
            _view.MoverFormulario();
        }
        private void VolverAlInicio_Accion(object sender, EventArgs e)
        {
            _view.CerrarVista();
        }
    }
}