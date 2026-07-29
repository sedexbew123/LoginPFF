using Entidades;
using Logica;
using Presentacion.View.Interfaces;
using System;
using System.Threading.Tasks;

namespace Presentacion.Presenter
{
    public class CategoriaPresenter
    {
        private readonly ICategoriaView _view;
        private readonly L_Inventario _logica;
        private string _categoriaSeleccionada;
        private string _motivoSeleccionado;

        public CategoriaPresenter(ICategoriaView view, L_Inventario logica)
        {
            _view = view;
            _logica = logica;

            _view.GuardarCategoria += async (s, e) => await GuardarCategoria_Accion();
            _view.EliminarCategoria += async (s, e) => await EliminarCategoria_Accion();
            _view.SeleccionarCategoria += SeleccionarCategoria_Accion;

            _view.GuardarMotivo += async (s, e) => await GuardarMotivo_Accion();
            _view.EliminarMotivo += async (s, e) => await EliminarMotivo_Accion();
            _view.SeleccionarMotivo += SeleccionarMotivo_Accion;

            _ = CargarListado();
        }

        private async Task CargarListado()
        {
            _view.CategoriasDataSource = await _logica.ListarCategoriasConfiguracion();
            _view.MotivosDataSource = await _logica.ListarMotivosConfiguracion();
        }

        private async Task GuardarCategoria_Accion()
        {
            string nombre = _view.CategoriaNombre?.Trim();
            string descripcion = _view.CategoriaDescripcion?.Trim();

            Solicitud resultado = _view.CategoriaEdicion
                ? await _logica.EditarCategoria(_categoriaSeleccionada, nombre, descripcion)
                : await _logica.GuardarCategoria(nombre, descripcion);

            _view.MostrarMensaje(resultado.Mensaje, !resultado.Estado);

            if (resultado.Estado)
            {
                _view.LimpiarCamposCategoria();
                _categoriaSeleccionada = null;
                await CargarListado();
            }
        }

        private async Task EliminarCategoria_Accion()
        {
            string nombre = string.IsNullOrWhiteSpace(_categoriaSeleccionada)
                ? _view.CategoriaNombre?.Trim()
                : _categoriaSeleccionada;

            if (string.IsNullOrWhiteSpace(nombre))
            {
                _view.MostrarMensaje("Seleccione una categoría de la lista para eliminar.", true);
                return;
            }

            if (!_view.ConfirmarAccion($"¿Desea eliminar la categoría \"{nombre}\"?"))
                return;

            var resultado = await _logica.EliminarCategoria(nombre);
            _view.MostrarMensaje(resultado.Mensaje, !resultado.Estado);

            if (resultado.Estado)
            {
                _view.LimpiarCamposCategoria();
                _categoriaSeleccionada = null;
                await CargarListado();
            }
        }

        private void SeleccionarCategoria_Accion(object sender, EventArgs e)
        {
            _categoriaSeleccionada = _view.CategoriaNombre?.Trim();
            _view.CategoriaEdicion = true;
        }

        private async Task GuardarMotivo_Accion()
        {
            string nombre = _view.MotivoNombre?.Trim();
            string detalles = _view.MotivoDescripcion?.Trim();

            Solicitud resultado = _view.MotivoEdicion
                ? await _logica.EditarMotivo(_motivoSeleccionado, nombre, detalles)
                : await _logica.GuardarMotivo(nombre, detalles);

            _view.MostrarMensaje(resultado.Mensaje, !resultado.Estado);

            if (resultado.Estado)
            {
                _view.LimpiarCamposMotivo();
                _motivoSeleccionado = null;
                await CargarListado();
            }
        }

        private async Task EliminarMotivo_Accion()
        {
            string nombre = string.IsNullOrWhiteSpace(_motivoSeleccionado)
                ? _view.MotivoNombre?.Trim()
                : _motivoSeleccionado;

            if (string.IsNullOrWhiteSpace(nombre))
            {
                _view.MostrarMensaje("Seleccione un motivo de la lista para eliminar.", true);
                return;
            }

            if (!_view.ConfirmarAccion($"¿Desea eliminar el motivo \"{nombre}\"?"))
                return;

            var resultado = await _logica.EliminarMotivo(nombre);
            _view.MostrarMensaje(resultado.Mensaje, !resultado.Estado);

            if (resultado.Estado)
            {
                _view.LimpiarCamposMotivo();
                _motivoSeleccionado = null;
                await CargarListado();
            }
        }

        private void SeleccionarMotivo_Accion(object sender, EventArgs e)
        {
            _motivoSeleccionado = _view.MotivoNombre?.Trim();
            _view.MotivoEdicion = true;
        }
    }
}