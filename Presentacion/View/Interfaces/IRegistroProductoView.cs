using Entidades;
using System;

namespace Presentacion.View.Interfaces
{
    public interface IRegistroProductoView
    {
        string TipoOperacion { get; }
        string TextoBusqueda { get; }
        string Nombre { get; set; }
        string Categoria { get; set; }
        decimal PrecioPrecio { get; set; }
        int Stock { get; set; }
        string Estado { get; set; }
        Productos ProductoSeleccionado { get; }
        object DataSource { set; }
        void MostrarMensaje(string mensaje, bool esError);
        void ActualizarPaginacionClientes(int paginaActual, int totalPaginas);

        event EventHandler PaginaSiguienteClick;
        event EventHandler PaginaAnteriorClick;
        event EventHandler FiltroFechaCambiado;
        event EventHandler EliminarProductoClick;
        event EventHandler EditarProductoClick;
        event EventHandler AgregarProductoClick;
        event EventHandler CargarProductos;
        event EventHandler FiltrarProductos;
    }
}
