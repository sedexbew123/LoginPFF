using System;

namespace Presentacion.View.Interfaces
{
    public interface IDatosConsultaDeudaView
    {
        string LabelCedula { set; }
        string LabelNombre { set; }
        string LabelApellido { set; }
        string LabelCreditoTotal { set; }
        string MesesSinPagar { set; }
        string FechaLimite { set; }

        object DataSource { set; }
        void CerrarVista();
        void MostrarCargando();
        void OcultarCargando();

        event EventHandler Cerrar;
        event EventHandler CargarDeudas;
    }
}
