using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Helpers
{
    public static class ControlAcceso
    {

        public static void AplicarRestriccionesPorRol(
            Control btnInformes,
            Control btnInventario,
            Control btnEmpleados,
            Control btnInformacionUsuario)
        {
            if (!SesionUsuario.HaySesionActiva) return;

            bool esEmpleado = SesionUsuario.EsEmpleado;

            if (btnInformes != null) btnInformes.Visible = !esEmpleado;
            if (btnInventario != null) btnInventario.Visible = !esEmpleado;
            if (btnEmpleados != null) btnEmpleados.Visible = !esEmpleado;
            if (btnInformacionUsuario != null) btnInformacionUsuario.Visible = !esEmpleado;
        }
    }
}
