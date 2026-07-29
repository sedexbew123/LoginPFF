using Entidades;
using Logica;
using Presentacion.View.Forms;
using Presentacion.View.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Presenter
{
    public class NuevoEmpleadoPresenter
    {
        private readonly INuevoEmpleadoView _view;
        private readonly L_Empleados _logica = new L_Empleados();
        private readonly bool _esEdicion;
        private readonly string _cedulaOriginal;

        public NuevoEmpleadoPresenter(INuevoEmpleadoView view)
        {
            _view = view;
            _esEdicion = false;
            _view.ModoEdicion = false;
            _view.MostrarCampoContraseña(true);
            SuscribirEventos();
        }

        public NuevoEmpleadoPresenter(INuevoEmpleadoView view, string cedula)
        {
            _view = view;
            _esEdicion = true;
            _cedulaOriginal = cedula;
            _view.ModoEdicion = true;
            _view.CedulaOriginal = cedula;
            _view.MostrarCampoContraseña(false);
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _view.VistaCargando += async (s, e) => await VistaCargando_Accion();
            _view.RegistrarEmpleado += RegistrarEmpleado_Accion;
            _view.Cancelar += Cancelar_Accion;
            _view.AgregarImagen += AgregarImagen_Accion;
            _view.TomarFoto += TomarFoto_Accion;
        }

        private void TomarFoto_Accion(object sender, EventArgs e)
        {
            var vista = new CapturaFoto();
            var presenter = new CapturaFotoPresenter(vista);

            if (vista.ShowDialog() == DialogResult.OK)
            {
                _view.FotoEmpleado = vista.FotoCapturada;
            }
        }

        private void AgregarImagen_Accion(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";
                dialogo.Title = "Seleccionar foto del empleado";

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    _view.FotoEmpleado = System.IO.File.ReadAllBytes(dialogo.FileName);
                }
            }
        }

        private void Cancelar_Accion(object sender, EventArgs e)
        {
            _view.CerrarVista();
        }

        private async void RegistrarEmpleado_Accion(object sender, EventArgs e)
        {
            if (_esEdicion)
                await GuardarEdicion();
            else
                await GuardarNuevo();
        }

        private async Task GuardarNuevo()
        {
            var nuevoEmpleado = new Usuarios
            {
                User = _view.Usuario,
                Cedula = _view.Cedula,
                Nombre = _view.Nombre,
                Apellido = _view.Apellido,
                Direccion = _view.Direccion,
                Correo = _view.Correo,
                Telefono = _view.Telefono,
                Foto = _view.FotoEmpleado
            };

            var resultado = await _logica.RegistrarEmpleado(nuevoEmpleado, _view.Contrasena);

            if (resultado.Estado)
            {
                _view.MostrarMensaje(resultado.Mensaje, "Éxito", MessageBoxIcon.Information);
                CerrarComoExitoso();
            }
            else
            {
                _view.MostrarMensaje(resultado.Mensaje, "Error", MessageBoxIcon.Warning);
            }
        }

        private async Task GuardarEdicion()
        {
            var empleadoEditado = new Usuarios
            {
                Cedula = _cedulaOriginal,
                Nombre = _view.Nombre,
                Apellido = _view.Apellido,
                Direccion = _view.Direccion,
                Correo = _view.Correo,
                Telefono = _view.Telefono,
                Foto = _view.FotoEmpleado
            };

            var resultado = await _logica.ActualizarEmpleado(empleadoEditado);

            if (resultado.Estado)
            {
                _view.MostrarMensaje(resultado.Mensaje, "Éxito", MessageBoxIcon.Information);
                CerrarComoExitoso();
            }
            else
            {
                _view.MostrarMensaje(resultado.Mensaje, "Error", MessageBoxIcon.Warning);
            }
        }

        private void CerrarComoExitoso()
        {
            if (_view is Form form)
                form.DialogResult = DialogResult.OK;
            _view.CerrarVista();
        }

        private async Task VistaCargando_Accion()
        {
            if (_esEdicion)
            {
                try
                { 
                    _view.MostrarCargando();

                    _view.BloquearCedula(true);
                    _view.BloquearUsuario(true);

                    await Task.Delay(400); 

                    var resultado = await _logica.ObtenerEmpleado(_cedulaOriginal);
                    if (resultado.Estado && resultado.Datos is Usuarios empleado)
                    {
                        _view.Usuario = empleado.User;
                        _view.Cedula = empleado.Cedula;
                        _view.Nombre = empleado.Nombre;
                        _view.Apellido = empleado.Apellido;
                        _view.Direccion = empleado.Direccion;
                        _view.Correo = empleado.Correo;
                        _view.Telefono = empleado.Telefono;
                        _view.FotoEmpleado = empleado.Foto;
                    }
                    else
                    {
                        _view.MostrarMensaje(resultado.Mensaje, "Error", MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    _view.MostrarMensaje($"Error de carga: {ex.Message}", "Error Crítico", MessageBoxIcon.Error);
                }
                finally
                {
                    
                    _view.OcultarCargando();
                }
            }
            else
            {
                _view.OcultarCargando();
            }
        }
    }
}