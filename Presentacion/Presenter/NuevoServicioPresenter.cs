using Presentacion.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Presenter
{
    public class NuevoServicioPresenter
    {
        private readonly INuevoServicioView _view;

        public NuevoServicioPresenter(INuevoServicioView view)
        {
            _view = view;

            _view.RegistrarServicioRealizado += RegistrarServicioRealizado_Accion;
            _view.CedulaBusqueda += CedulaBusqueda_Accion;
            _view.CreditoCambiado += CreditoCambiado_Accion;
            _view.ServicioCambiado += ServicioCambiado_Accion;
            _view.Cancelar += Cancelar_Accion;
        }

        private void Cancelar_Accion(object sender, EventArgs e)
        {
            _view.CerrarVista(false);
        }

        private void ServicioCambiado_Accion(object sender, EventArgs e)
        {

        }

        private void CreditoCambiado_Accion(object sender, EventArgs e)
        {
            _view.FechaLimiteVisible = _view.DarCredito;


        }

        private void CedulaBusqueda_Accion(object sender, EventArgs e)
        {
            
        }

        private void RegistrarServicioRealizado_Accion(object sender, EventArgs e)
        {
            
        }
    }
}
