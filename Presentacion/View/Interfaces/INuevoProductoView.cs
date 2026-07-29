using System;
using System.Windows.Forms;

namespace Presentacion.View.Interfaces
{
    public interface INuevoProductoView
    {
        string Codigo { get; set; }
        string NombreProducto { get; set; }
        object CategoriasDataSource { set; }
        int? IdCategoriaSeleccionada { get; set; }
        string NombreCategoriaSeleccionada { get; }
        decimal Precio { get; set; }
        int StockActual { get; set; }

        void BloquearCodigo(bool bloquear);
        void MostrarMensaje(string mensaje, string titulo, MessageBoxIcon icono);
        void CerrarVista(DialogResult resultado);
        void MostrarCargando();
        void OcultarCargando();

        event EventHandler VistaCargando;
        event EventHandler RegistrarProducto;
        event EventHandler Cancelar;
    }
}
