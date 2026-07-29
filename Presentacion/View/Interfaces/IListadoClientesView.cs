using Entidades;
using System;
using System.Collections.Generic;

namespace Presentacion.View.Interfaces
{
    public interface IListadoClientesView
    {

        int Cedula { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        string TextoBusqueda { get; }
        Clientes ClienteSeleccionado { get; }

        void LlenarListadoClientes(List<Clientes> clientes);

        void ActualizarPaginacionClientes(int paginaActual, int totalPaginas);
        void MostrarMensaje(string mensaje, bool esError);

        event EventHandler PaginaSiguienteClick;
        event EventHandler PaginaAnteriorClick;
        event EventHandler EliminarClienteClick;
        event EventHandler EditarClienteClick;
        event EventHandler VisualizarClientesClick;
        event EventHandler CargarClientes;
        event EventHandler FiltrarClientes;

    }
}
