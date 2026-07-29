using Logica;
using Presentacion.View.Interfaces;
using System;
using System.Threading.Tasks;

namespace Presentacion.Presenter
{
    public class TokenUsuarioPresenter
    {
        private readonly ITokenUsuarioView _view;
        private readonly L_Usuarios _logica = new L_Usuarios();
        private string _tokenValidado = string.Empty;

        public TokenUsuarioPresenter(ITokenUsuarioView view)
        {
            _view = view;
            _view.ArrastrarFormulario += ArrastrarFormulario_Accion;
            _view.VolverAlInicio += VolverAlInicio_Accion;
            _view.ValidarCodigo += ValidarCodigo_Accion;
            _view.CambiarUsuario += CambiarUsuario_Accion;
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
                _view.MostrarEstado("Código válido. Ingrese su nuevo usuario.", TipoMensaje.Exito);
                _view.MostrarPanelOpciones();
            }
            else
            {
                _view.MostrarEstado(resultado.Mensaje, TipoMensaje.Error);
            }
        }

        private async void CambiarUsuario_Accion(object sender, EventArgs e)
        {
            string usuario1 = _view.NuevoUsuario?.Trim();
            string usuario2 = _view.ConfirmarUsuario?.Trim();

            if (string.IsNullOrWhiteSpace(usuario1) || string.IsNullOrWhiteSpace(usuario2))
            {
                _view.MostrarEstado("Todos los campos son obligatorios.", TipoMensaje.Error);
                return;
            }

            if (usuario1 != usuario2)
            {
                _view.MostrarEstado("Los usuarios no coinciden.", TipoMensaje.Error);
                return;
            }

            _view.MostrarEstado("Cambiando usuario...", TipoMensaje.Normal);
            var resultado = await _logica.RestablecerUsuario(usuario1, usuario2, _tokenValidado);

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
