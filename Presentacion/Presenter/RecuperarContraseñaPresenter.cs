using Logica;
using Presentacion.View.Forms;
using Presentacion.View.Interfaces;
using System;

namespace Presentacion.Presenter
{
    public class RecuperarContraseñaPresenter
    {
        private readonly IRecuperarContraseñaView _view;
        private readonly L_Usuarios _logica = new L_Usuarios();

        public RecuperarContraseñaPresenter(IRecuperarContraseñaView view)
        {
            _view = view;
            _view.Cerrar += Cerrar_Accion;
            _view.ArrastrarFormulario += ArrastrarFormulario_Accion;
            _view.VolverAlInicio += VolverAlInicio_Accion;
            _view.EnviarCodigo += EnviarCodigo_Accion;
        }

        private void VolverAlInicio_Accion(object sender, EventArgs e)
        {
            _view.CerrarVista();
        }

        private void ArrastrarFormulario_Accion(object sender, EventArgs e)
        {
            _view.MoverFormulario();
        }

        private void Cerrar_Accion(object sender, EventArgs e)
        {
            _view.CerrarVista();
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

            var resultado = await _logica.SolicitarRecuperacion(correo);

            if (resultado.Estado)
            {
                _view.MostrarEstado(resultado.Mensaje, TipoMensaje.Exito);
                _view.OcultarVista();
                using (TokenContraseña tokenForm = new TokenContraseña())
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

    }
}
