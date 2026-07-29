using System;
using System.Windows.Forms;

namespace Presentacion.View.Interfaces
{
    public interface IAdministrarPermisosView
    {

        object UsuariosPermisosDataSource { set; }

        DataGridViewRowCollection FilasTabla { get; }

        void ConfirmarEdicionPendiente();
        void MostrarMensaje(string mensaje, string titulo, MessageBoxIcon icono);
        void CerrarVista(DialogResult resultado);
        event EventHandler VistaCargando;
        event EventHandler GuardarCambios;
        event EventHandler Cancelar;
        event EventHandler Eliminar;
    }
}