using Presentacion.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Presenter
{
    public class ConfiguracionServiciosPresenter
    {
        private readonly IConfiguracionServiciosView _view;

        public ConfiguracionServiciosPresenter(IConfiguracionServiciosView view)
        {
            _view = view;

            _view.GuardarServicio += async (s, e) => await GuardarServicio_Accion();
            _view.EliminarServicio += async (s, e) => await EliminarServicio_Accion();
            _view.SeleccionarServicio += SeleccionarServicio_Accion;

            _view.GuardarTipo += async (s, e) => await GuardarTipo_Accion();
            _view.EliminarTipo += async (s, e) => await EliminarTipo_Accion();
            _view.SeleccionarTipo += SeleccionarTipo_Accion;

           // _ = CargarListado();
        }

       // private object CargarListado()
        //{
            
        //}

        private async Task GuardarServicio_Accion()
        {
            
        }

        private async Task EliminarServicio_Accion()
        {

        }

        private void SeleccionarServicio_Accion(object sender, EventArgs e)
        {

        }

        private async Task GuardarTipo_Accion()
        {

        }

        private async Task EliminarTipo_Accion()
        {

        }

        private void SeleccionarTipo_Accion(object sender, EventArgs e)
        {

        }
    }
}
