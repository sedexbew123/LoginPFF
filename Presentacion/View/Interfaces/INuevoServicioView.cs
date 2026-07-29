using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.View.Interfaces
{
    public interface INuevoServicioView
    {
        int Cedula {  get; set; }
        string Nombre { set; }
        string Apellido { set; }

        string ServicioSeleccionado { get; }
        object ServiciosDataSource { set; }
        decimal MontoDolares { get; set;  }
        decimal MontoBolivares { get; set; }

        DateTime FechaServicio { get; }
        DateTime? FechaLimite { get; }

        bool DarCredito { get; set; }
        bool FechaLimiteVisible { set; }
        void MostrarMensaje(string mensaje, bool isError = false);
        void CerrarVista(bool exitoso);

        event EventHandler RegistrarServicioRealizado;
        event EventHandler CedulaBusqueda;
        event EventHandler CreditoCambiado;
        event EventHandler ServicioCambiado;
        event EventHandler Cancelar;

    }
}
