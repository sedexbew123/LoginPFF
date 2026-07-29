using Entidades;
using Logica;
using Presentacion.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.Presenter
{

    public class AdministrarPermisosPresenter
    {
        private readonly IAdministrarPermisosView _view;
        private readonly L_Empleados _logica = new L_Empleados();

        private DataTable _tabla;

        private const int COL_USUARIO = 0;

        public AdministrarPermisosPresenter(IAdministrarPermisosView view)
        {
            _view = view;

            _view.VistaCargando += VistaCargando_Accion;
            _view.GuardarCambios += GuardarCambios_Accion;
            _view.Eliminar += Eliminar_Accion;
            _view.Cancelar += Cancelar_Accion;
        }

        private void Cancelar_Accion(object sender, EventArgs e)
        {
            _view.CerrarVista(DialogResult.Cancel);
        }

        private async void VistaCargando_Accion(object sender, EventArgs e)
        {
            var resultado = await _logica.ListarEmpleadosParaPermisos();

            if (!resultado.Estado)
            {
                _view.MostrarMensaje(resultado.Mensaje, "Error", MessageBoxIcon.Error);
                return;
            }

            var empleados = (List<Usuarios>)resultado.Datos;
            _tabla = ConstruirTabla(empleados);
            _view.UsuariosPermisosDataSource = _tabla;
        }

        private DataTable ConstruirTabla(List<Usuarios> empleados)
        {
            var tabla = new DataTable();
            tabla.Columns.Add("ClmId", typeof(int));
            tabla.Columns.Add("ClmUsuarios", typeof(string));
            tabla.Columns.Add("ClmCorreo", typeof(string));
            tabla.Columns.Add("ClmAutorizacion", typeof(bool));

            foreach (var emp in empleados)
            {
                tabla.Rows.Add(emp.Id, emp.User, emp.Correo, emp.PermitirIngreso);
            }

            return tabla;
        }

        private async void GuardarCambios_Accion(object sender, EventArgs e)
        {
            await CambiarPermisoDeSeleccionado(permitir: true, mensajeExito: "Se permitió el ingreso del empleado.");
        }

        private async void Eliminar_Accion(object sender, EventArgs e)
        {
            var filaSeleccionada = ObtenerFilaSeleccionada();
            string usuario = filaSeleccionada != null ? filaSeleccionada.Cells[COL_USUARIO].Value?.ToString() : null;

            var confirmacion = MessageBox.Show(
                $"¿Está seguro que desea restringir el ingreso de '{usuario}'? Podrá volver a permitírselo seleccionándolo y presionando Premitir.",
                "Confirmar restricción de acceso",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            await CambiarPermisoDeSeleccionado(permitir: false, mensajeExito: "Se restringió el ingreso del empleado.");
        }

        private async System.Threading.Tasks.Task CambiarPermisoDeSeleccionado(bool permitir, string mensajeExito)
        {
            if (_view.FilasTabla.Count == 0)
            {
                _view.MostrarMensaje("No hay empleados en la lista.", "Aviso", MessageBoxIcon.Warning);
                return;
            }

            var filaSeleccionada = ObtenerFilaSeleccionada();
            if (filaSeleccionada == null)
            {
                _view.MostrarMensaje("Seleccione un empleado de la lista.", "Aviso", MessageBoxIcon.Warning);
                return;
            }

            string usuario = filaSeleccionada.Cells[COL_USUARIO].Value?.ToString();
            int idUsuario = ObtenerIdPorUsuario(usuario);

            if (idUsuario == 0)
            {
                _view.MostrarMensaje("No se pudo identificar al empleado seleccionado.", "Error", MessageBoxIcon.Error);
                return;
            }

            var resultado = await _logica.ActualizarPermisoIngreso(idUsuario, permitir);

            _view.MostrarMensaje(
                resultado.Estado ? mensajeExito : resultado.Mensaje,
                resultado.Estado ? "Éxito" : "Error",
                resultado.Estado ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (resultado.Estado)
                VistaCargando_Accion(this, EventArgs.Empty);
        }

        private int ObtenerIdPorUsuario(string usuario)
        {
            if (_tabla == null || string.IsNullOrEmpty(usuario)) return 0;

            foreach (DataRow fila in _tabla.Rows)
            {
                if (fila["ClmUsuarios"]?.ToString() == usuario)
                    return Convert.ToInt32(fila["ClmId"]);
            }
            return 0;
        }

        private DataGridViewRow ObtenerFilaSeleccionada()
        {
            foreach (DataGridViewRow fila in _view.FilasTabla)
            {
                if (fila.Selected) return fila;
            }
            return null;
        }
    }
}
