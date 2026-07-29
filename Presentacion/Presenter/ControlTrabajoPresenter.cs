using Presentacion.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Presenter
{
    public class ControlTrabajoPresenter
    {
        private readonly IControlTrabajoView _view;

        private static readonly string[] NombresMeses =
        {
            "Enero","Febrero","Marzo","Abril","Mayo","Junio",
            "Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre"
        };
        public ControlTrabajoPresenter(IControlTrabajoView view)
        {
            _view = view;

            _view.FiltroFechaCambiado += FiltroFechaCambiado_Accion;
            _view.PaginaAnteriorClick += PaginaAnteriorClick_Accion;
            _view.PaginaSiguienteClick += PaginaSiguienteClick_Accion;
            _view.FiltrarClientes += FiltrarClientes_Accion;
            _view.AgregarServicio += AgregarServicio_Accion;
        }

        private void AgregarServicio_Accion(object sender, EventArgs e)
        {
           var vistaNuevoServicio = new View.Forms.NuevoServicio();

           var presenterNuevoServicio = new NuevoServicioPresenter(vistaNuevoServicio);

            vistaNuevoServicio.ShowDialog();
        }

        private void FiltrarClientes_Accion(object sender, EventArgs e)
        {
           
        }

        private void PaginaSiguienteClick_Accion(object sender, EventArgs e)
        {
           
        }

        private void PaginaAnteriorClick_Accion(object sender, EventArgs e)
        {
           
        }

        private void FiltroFechaCambiado_Accion(object sender, EventArgs e)
        {
           
        }
    }
}
