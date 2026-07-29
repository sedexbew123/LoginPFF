using Logica;
using Presentacion.View.Forms;
using Presentacion.View.Interfaces;
using System;

namespace Presentacion.Presenter
{
    public class RecuperarUsuarioPresenter
    {
        private readonly IRecuperarUsuarioView _view;
        private readonly L_Usuarios _logica = new L_Usuarios();

        public RecuperarUsuarioPresenter(IRecuperarUsuarioView view)
        {
            _view = view;
            _view.Cerrar += Cerrar_Accion;
            _view.ArrastrarFormulario += ArrastrarFormulario_Accion;
            _view.VolverAlInicio += VolverAlInicio_Accion;
            _view.EnviarCodigo += EnviarCodigo_Accion;
        }

        private async void EnviarCodigo_Accion(object sender, EventArgs e)
        {
            string correo = _view.Correo?.Trim();

            if (string.IsNullOrWhiteSpace(correo))
            {
                _view.MostrarEstado("Por favor ingrese su correo electrónico.", TipoMensaje.Error);
                return;
            }

            _view.MostrarEstado("Enviando código de recuperación...", TipoMensaje.Normal);

            var resultado = await _logica.SolicitarRecuperacionUsuario(correo);

            if (resultado.Estado)
            {
                _view.MostrarEstado(resultado.Mensaje, TipoMensaje.Exito);
                _view.OcultarVista();

                using (TokenUsuario tokenForm = new TokenUsuario())
                {
                    tokenForm.ShowDialog();
                }

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
        private void Cerrar_Accion(object sender, EventArgs e)
        {
            _view.CerrarVista();
        }
        private void VolverAlInicio_Accion(object sender, EventArgs e)
        {
            _view.CerrarVista();
        }
    }
}