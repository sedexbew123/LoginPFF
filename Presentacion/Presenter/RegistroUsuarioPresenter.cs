using Logica;
using Presentacion.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Presenter
{
    public class RegistroUsuarioPresenter
    {
        private readonly IRegistroUsuarioView _view;
        private readonly L_Usuarios _logica;

        public RegistroUsuarioPresenter(IRegistroUsuarioView view, L_Usuarios logica)
        {
            _view = view;
            _logica = logica;

            _view.VistaListaParaCargar += async (s, e) => await CargarDatosUsuario();
            _view.EditarUsuario += async (s, e) => await EditarUsuario_Accion();
            _view.VolverAlLogin += VolverAlLogin_Accion;

            Task task = CargarDatosUsuario();
        }

        private async Task CargarDatosUsuario()
        {
            try
            {
                _view.MostrarCargando();

                await Task.Delay(400); 

                var usuario = await _logica.ObtenerInformacionUsuarioUnico();
                if (usuario != null)
                {
                    _view.Nombre = usuario.Nombre;
                    _view.Apellido = usuario.Apellido;
                    _view.Cedula = usuario.Cedula;
                    _view.Correo = usuario.Correo;
                    _view.Direccion = usuario.Direccion;
                    _view.Telefono = usuario.Telefono;
                }
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje($"Error al obtener datos del perfil: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
            finally
            {
                _view.OcultarCargando(); 
            }
        }

        private void VolverAlLogin_Accion(object sender, EventArgs e)
        {
            _view.CerrarVista();
        }

        private async Task EditarUsuario_Accion()
        {
            try
            {
                _view.MostrarCargando();

                var usuario = new Entidades.Usuarios
                {
                    Nombre = _view.Nombre,
                    Apellido = _view.Apellido,
                    Cedula = _view.Cedula,
                    Correo = _view.Correo,
                    Direccion = _view.Direccion,
                    Telefono = _view.Telefono
                };

                var resultado = await _logica.ActualizarInformacionUsuario(usuario);

                _view.MostrarMensaje(
                    resultado.Mensaje,
                    resultado.Estado ? "Éxito" : "Error",
                    resultado.Estado ? MessageBoxIcon.Information : MessageBoxIcon.Error
                );

                if (resultado.Estado)
                {
                    _view.NotificarEdicionExitosa();
                    _view.CerrarVista();
                }
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje($"Error al actualizar: {ex.Message}", "Error Crítico", MessageBoxIcon.Error);
            }
            finally
            {
                _view.OcultarCargando();
            }
        }

    }
}
