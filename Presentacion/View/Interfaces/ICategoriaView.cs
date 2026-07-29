using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.View.Interfaces
{
    public interface ICategoriaView
    {
        string CategoriaNombre { get; set; }
        string CategoriaDescripcion { get; set; }
        object CategoriasDataSource { set; }
        bool CategoriaEdicion { get; set; }


        string MotivoNombre { get; set; }
        string MotivoDescripcion { get; set; }
        object MotivosDataSource { set; }
        bool MotivoEdicion { get; set; }

        void LimpiarCamposCategoria();
        void LimpiarCamposMotivo();
        void MostrarMensaje(string mensaje, bool isError = false);
        bool ConfirmarAccion(string mensaje);

        event EventHandler GuardarCategoria;
        event EventHandler EliminarCategoria;
        event EventHandler SeleccionarCategoria;

        event EventHandler GuardarMotivo;
        event EventHandler EliminarMotivo;
        event EventHandler SeleccionarMotivo;
    }
}
