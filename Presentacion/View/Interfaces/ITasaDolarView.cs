using System;
using System.Data;

namespace Presentacion.View.Interfaces
{
    public enum EstadoApi
    {
        Cargando,
        Exito,
        AlDia,
        Error
    }
    public interface ITasaDolarView
    {
        string DescripcionBuscar { get; set; }
        string MonedaBuscar { get; set; }

        string Moneda { get; set; }
        string Descripcion { get; set; }
        decimal Valor { get; set; }
        DateTime Fecha { get; set; }

        void CargarTasas(DataTable dt);
        void MostrarEstadoApi(string mensaje, EstadoApi estado);

        void ActualizarPaginacionClientes(int paginaActual, int totalPaginas);

        event EventHandler PaginaSiguienteClick;
        event EventHandler PaginaAnteriorClick;
        event EventHandler ViewLoaded;
        event EventHandler EditarTasa;
        event EventHandler FiltrarTasas;
    }


}
