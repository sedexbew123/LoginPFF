using Entidades;
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
    public class VisualizarEmpleadosPresenter
    {
        private readonly IVisualizarEmpleadoView _view;
        private readonly L_Empleados _logica = new L_Empleados();
        private readonly string _cedula;

        public VisualizarEmpleadosPresenter(IVisualizarEmpleadoView view, string cedula)
        {
            _view = view;
            _cedula = cedula;

            _view.VistaCargando += async (s, e) => await VistaCargando_Accion();
            _view.Volver += Volver_Accion;
        }

        private async Task VistaCargando_Accion()
        {
            try
            {
                _view.MostrarCargando();

                await Task.Delay(400);

                var resultado = await _logica.ObtenerEmpleado(_cedula);

                if (!resultado.Estado || !(resultado.Datos is Usuarios empleado))
                {
                    MessageBox.Show(resultado.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _view.CerrarVista();
                    return;
                }

                _view.Cedula = empleado.Cedula;
                _view.Nombre = empleado.Nombre;
                _view.Apellido = empleado.Apellido;
                _view.Telefono = empleado.Telefono;
                _view.Direccion = empleado.Direccion;
                _view.Correo = empleado.Correo;
                _view.FotoEmpleado = empleado.Foto;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al procesar la información: {ex.Message}",
                                "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _view.CerrarVista();
            }
            finally
            {
                _view.OcultarCargando();
            }
        }

        private void Volver_Accion(object sender, EventArgs e)
        {
            _view.CerrarVista();
        }
    }
}
