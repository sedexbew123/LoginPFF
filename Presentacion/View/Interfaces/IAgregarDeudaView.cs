using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.View.Interfaces
{
    public interface IAgregarDeudaView
    {
        string FiltroTexto { get; }
        string CategoriaSeleccionada { get; }
        int Cantidad { get; set; }

        Dictionary<string, object> ObtenerFilaSeleccionada();
        void CargarCategorias(List<string> categorias);
        void CargarProductos(DataTable dt);
        void MostrarMensaje(string mensaje, bool esError);
        void CerrarVista(DialogResult resultado);

        void MostrarCargando();
        void OcultarCargando();

        event EventHandler ViewLoaded;
        event EventHandler Cerrar;
        event EventHandler AgregarDeudaNueva;
        event EventHandler CancelarDeuda;
        event EventHandler FiltroCambiado;
    }
}
