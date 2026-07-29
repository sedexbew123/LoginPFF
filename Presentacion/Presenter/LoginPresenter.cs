using AutoUpdaterDotNET;
using DocumentFormat.OpenXml.Drawing.Charts;
using Logica;
using Presentacion.View.Forms;
using Presentacion.View.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Presenter
{
    public class LoginPresenter
    {
        private readonly ILoginView _view;
        private readonly L_Usuarios _logica;

        public LoginPresenter(ILoginView view, L_Usuarios logica)
        {
            _view = view;
            _logica = logica;

            _view.LoginLoad += LoginLoad_Disparado;

            _view.Cerrar += Cerrar_Accion;
            _view.ArrastrarFormulario += ArrastrarFormulario_Accion;
            _view.IniciarSesion += IniciarSesion_Accion;
            _view.MostrarContraseña += MostrarContraseña_Accion;
            _view.RecuperarCuenta += RecuperarCuenta_Accion;
            _view.VolverAlInicio += VolverAlInicio_Accion;
            _view.Siguiente += Siguiente_Accion;
        }

        private void LoginLoad_Disparado(object sender, EventArgs e)
        {

            AutoUpdater.AppTitle = "Sistema CrediTrack";
            AutoUpdater.UpdateFormSize = new System.Drawing.Size(800, 600);
            AutoUpdater.Start("https://raw.githubusercontent.com/sedexbew123/CrediTrack-Versiones/main/Update.xml");

        }

        private void VolverAlInicio_Accion(object sender, EventArgs e)
        {
            _view.OcultarPanelOpciones();
        }

        private void RecuperarCuenta_Accion(object sender, EventArgs e)
        {
            _view.MostrarPanelOpciones();
        }

        private void MostrarContraseña_Accion(object sender, EventArgs e)
        {
            _view.SecurityContraseña = !_view.SecurityContraseña;
        }

        private async void IniciarSesion_Accion(object sender, EventArgs e)
        {
            _view.MostrarEstado("Validando Credenciales", TipoMensaje.Normal);
            await Task.Delay(1000);

            if (string.IsNullOrWhiteSpace(_view.Usuario) || string.IsNullOrWhiteSpace(_view.Contraseña))
            {
                _view.MostrarEstado("Campos obligatorios", TipoMensaje.Error);
                return;
            }

            var resultado = await _logica.IniciarSesion(_view.Usuario, _view.Contraseña);

            if (resultado.Estado)
            {
                Entidades.SesionUsuario.UsuarioLogueado = (Entidades.Usuarios)resultado.Datos;
                ((Form)_view).DialogResult = DialogResult.OK;
                _view.OcultarVista();
            }
            else
            {
                _view.MostrarEstado($"{resultado.Mensaje}", TipoMensaje.Error);
            }
        }

        private void ArrastrarFormulario_Accion(object sender, EventArgs e)
        {
            _view.MoverFormulario();
        }

        private void Siguiente_Accion(object sender, EventArgs e)
        {
            if (_view.MostrarOpciones)
            {
                EjecutarNavegacionRecuperacion();
                return;
            }
        }

        private void EjecutarNavegacionRecuperacion()
        {
            string seleccion = _view.OpcionRecuperacion;

            if (string.IsNullOrEmpty(seleccion))
            {
                _view.MostrarEstado("Por favor, seleccione una opción", TipoMensaje.Error);
                return;
            }

            if (seleccion == "Usuario")
            {
                _view.OcultarVista();
                using (RecuperarUsuario frmUsuario = new RecuperarUsuario())
                {
                    frmUsuario.ShowDialog();
                }
            }
            else if (seleccion == "Contraseña")
            {
                _view.OcultarVista();
                using (RecuperarContraseña frmPass = new RecuperarContraseña())
                {
                    frmPass.ShowDialog();
                }
            }

            _view.OcultarPanelOpciones();

            _view.Usuario = string.Empty;
            _view.Contraseña = string.Empty;
            _view.MostrarEstado(string.Empty, TipoMensaje.Normal);

            var loginForm = _view as Form;
            if (loginForm != null && !loginForm.IsDisposed)
            {
                loginForm.Show();
            }
        }

        private void Cerrar_Accion(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
