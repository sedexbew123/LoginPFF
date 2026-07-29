using Entidades;
using Logica;
using Presentacion.View.Forms;
using Presentacion.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Presenter
{
    public class GestionEmpleadosPresenter
    {
        private readonly IGestionEmpleadosView _view;
        private readonly L_Empleados _logica = new L_Empleados();

        private int _paginaActual = 1;
        private int _totalPaginas = 1;
        private const int REGISTROS_POR_PAGINA = 10;

        public GestionEmpleadosPresenter(IGestionEmpleadosView view)
        {
            _view = view;
            _view.EditarEmpleadosClick += EditarClienteClick_Accion;
            _view.EliminarEmpleadosClick += EliminarClienteClick_Accion;
            _view.AgregarEmpleadosClick += AgregarEmpleadosClick_Accion;
            _view.VisualizarEmpleadosClick += VisualizarEmpleadosClick_Accion;
            _view.CargarEmpleados += (s, e) => CargarTabla();
            _view.PaginaSiguienteClick += PaginaSiguienteClick_Accion;
            _view.PaginaAnteriorClick += PaginaAnteriorClick_Accion;
            _view.FiltrarEmpleados += FiltrarClientes_Accion;
        }

        private async void FiltrarClientes_Accion(object sender, EventArgs e)
        {
            _paginaActual = 1;
            await CargarTablaAsync();
        }

        private async void PaginaAnteriorClick_Accion(object sender, EventArgs e)
        {
            if (_paginaActual <= 1) return;
            _paginaActual--;
            await CargarTablaAsync();
        }

        private async void PaginaSiguienteClick_Accion(object sender, EventArgs e)
        {
            if (_paginaActual >= _totalPaginas) return;
            _paginaActual++;
            await CargarTablaAsync();
        }

        private async void CargarTabla()
        {
            await CargarTablaAsync();
        }

        private async Task CargarTablaAsync()
        {
            var resultado = await _logica.ListarEmpleados(_view.TextoBusqueda, _paginaActual, REGISTROS_POR_PAGINA);

            if (!resultado.Estado)
            {
                _view.MostrarMensaje(resultado.Mensaje, true);
                return;
            }

            var datos = (ResultadoPaginado<Usuarios>)resultado.Datos;
            List<Usuarios> empleados = datos.Datos;
            _totalPaginas = datos.TotalPaginas;
            _paginaActual = datos.PaginaActual;

            _view.LlenarListadoEmpleados(empleados);
            _view.ActualizarPaginacionEmpleados(_paginaActual, _totalPaginas);
        }

        private void VisualizarEmpleadosClick_Accion(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_view.Cedula))
            {
                _view.MostrarMensaje("Seleccione un empleado de la lista.", true);
                return;
            }

            var vista = new VisualizarEmpleados();
            var presenter = new VisualizarEmpleadosPresenter(vista, _view.Cedula);
            vista.ShowDialog();
        }

        private void AgregarEmpleadosClick_Accion(object sender, EventArgs e)
        {
            var vista = new NuevoEmpleado();
            var presenter = new NuevoEmpleadoPresenter(vista);
            var resultado = vista.ShowDialog();

            if (resultado == DialogResult.OK)
                CargarTabla();
        }

        private async void EliminarClienteClick_Accion(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_view.Cedula))
            {
                _view.MostrarMensaje("Seleccione un empleado de la lista.", true);
                return;
            }

            var confirmacion = MessageBox.Show(
                $"¿Está seguro que desea eliminar a {_view.Nombre} {_view.Apellido}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            var resultado = await _logica.EliminarEmpleado(_view.Cedula);
            _view.MostrarMensaje(resultado.Mensaje, !resultado.Estado);

            if (resultado.Estado)
                await CargarTablaAsync();
        }

        private void EditarClienteClick_Accion(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_view.Cedula))
            {
                _view.MostrarMensaje("Seleccione un empleado de la lista.", true);
                return;
            }

            var vista = new NuevoEmpleado();
            var presenter = new NuevoEmpleadoPresenter(vista, _view.Cedula);
            var resultado = vista.ShowDialog();

            if (resultado == DialogResult.OK)
                CargarTabla();
        }
    }
}
