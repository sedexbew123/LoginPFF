using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class L_Inventario
    {
        private readonly D_Inventario _datos = new D_Inventario();

        public async Task<Solicitud> GuardarProducto(Productos producto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(producto.Codigo))
                    return Fallo("El campo Código es obligatorio.");

                if (string.IsNullOrWhiteSpace(producto.Nombre))
                    return Fallo("El campo Nombre es obligatorio.");

                if (producto.IdCategoria <= 0)
                    return Fallo("Debe seleccionar una Categoría válida.");

                if (producto.Precio < 0)
                    return Fallo("El precio no puede ser negativo.");

                if (producto.StockActual < 0)
                    return Fallo("El stock inicial no puede ser negativo.");

                var respuesta = new RespuestaBD();
                bool exito = await _datos.RegistrarProducto(producto, respuesta);

                return new Solicitud
                {
                    Estado = exito,
                    Mensaje = exito ? "Producto registrado con éxito." : respuesta.Mensaje,
                };
            }
            catch (Exception ex)
            {
                return Fallo("Error inesperado: " + ex.Message);
            }
        }

        public async Task<Solicitud> Editar(Productos producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Codigo))
                return Fallo("Código de producto no válido.");

            var respuesta = new RespuestaBD();

            bool exito = await _datos.ActualizarProducto(producto, respuesta);

            return new Solicitud
            {
                Estado = exito,
                Mensaje = exito ? "Producto actualizado correctamente." : respuesta.Mensaje
            };
        }

        public async Task<Solicitud> Eliminar(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return Fallo("Código de producto no válido.");

            var respuesta = new RespuestaBD();
            bool exito = await _datos.EliminarProducto(codigo, respuesta);

            if (!exito)
                return Fallo(respuesta.Mensaje);

            string mensaje = respuesta.Mensaje == "BAJA_LOGICA"
                ? "El producto tiene historial de crédito y fue marcado como Inactivo."
                : "Producto eliminado del sistema correctamente.";

            return new Solicitud 
            { 
                Estado = true, 
                Mensaje = mensaje 
            };
        }

        public async Task<DataTable> ObtenerCategoriasActivas()
            => await _datos.ObtenerCategoriasActivas();

        public async Task<Solicitud> RegistrarCargo(string codigoProducto, int cantidad)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(codigoProducto))
                    return Fallo("Debe seleccionar un producto.");

                if (cantidad <= 0)
                    return Fallo("La cantidad debe ser mayor a cero.");

                var producto = await _datos.ObtenerProductoPorCodigo(codigoProducto);

                if (producto == null)
                    return Fallo("El producto seleccionado no existe.");

                var cargo = new CargoInventario
                {
                    CodigoProducto = codigoProducto,
                    NombreProducto = producto.Nombre,
                    Cantidad = cantidad,
                    Fecha = DateTime.Now
                };

                var respuesta = new RespuestaBD();

                bool exito = await _datos.RegistrarCargo(cargo, respuesta);

                return new Solicitud
                {
                    Estado = exito,
                    Mensaje = exito ? "Cargo registrado con éxito." : respuesta.Mensaje
                };
            }
            catch (Exception ex)
            {
                return Fallo("Error inesperado: " + ex.Message);
            }
        }

        public async Task<Solicitud> RegistrarDescargo(string codigoProducto, int cantidad, int idMotivo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(codigoProducto))
                    return Fallo("Debe seleccionar un producto.");
                if (cantidad <= 0)
                    return Fallo("La cantidad debe ser mayor a cero.");
                if (idMotivo <= 0)
                    return Fallo("Debe seleccionar el motivo del descargo.");

                var producto = await _datos.ObtenerProductoPorCodigo(codigoProducto);
                if (producto == null)
                    return Fallo("El producto seleccionado no existe.");

                var descargo = new DescargoInventario
                {
                    CodigoProducto = codigoProducto,
                    NombreProducto = producto.Nombre,
                    Cantidad = cantidad,
                    IdMotivo = idMotivo,
                    Fecha = DateTime.Now
                };

                var respuesta = new RespuestaBD();
                bool exito = await _datos.RegistrarDescargo(descargo, respuesta);

                return new Solicitud
                {
                    Estado = exito,
                    Mensaje = exito ? "Descargo registrado con éxito." : respuesta.Mensaje
                };
            }
            catch (Exception ex)
            {
                return Fallo("Error inesperado: " + ex.Message);
            }
        }

        private Solicitud Fallo(string mensaje) => new Solicitud
        {
            Estado = false,
            Mensaje = mensaje
        };

        public async Task<Solicitud> GuardarCategoria(string nombre, string descripcion)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return Fallo("El nombre de la categoría es obligatorio.");

            var respuesta = new RespuestaBD();
            bool exito = await _datos.RegistrarCategoria(nombre.Trim(), descripcion?.Trim() ?? "", respuesta);
            return new Solicitud
            {
                Estado = exito,
                Mensaje = exito ? "Categoría registrada con éxito." : respuesta.Mensaje
            };
        }

        public async Task<DataTable> ListarCategoriasConfiguracion()
            => await _datos.ObtenerCategoriasListado();

        public async Task<Solicitud> EditarCategoria(string nombreActual, string nombreNuevo, string descripcion)
        {
            if (string.IsNullOrWhiteSpace(nombreNuevo))
                return Fallo("El nombre de la categoría es obligatorio.");

            var respuesta = new RespuestaBD();
            bool exito = await _datos.ActualizarCategoria(
                nombreActual, nombreNuevo.Trim(), descripcion?.Trim() ?? "", respuesta);
            return new Solicitud
            {
                Estado = exito,
                Mensaje = exito ? "Categoría actualizada con éxito." : respuesta.Mensaje
            };
        }

        public async Task<Solicitud> EliminarCategoria(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return Fallo("Debe seleccionar una categoría de la lista.");

            var respuesta = new RespuestaBD();
            bool exito = await _datos.EliminarCategoria(nombre, respuesta);
            return new Solicitud
            {
                Estado = exito,
                Mensaje = exito ? "Categoría eliminada con éxito." : respuesta.Mensaje
            };
        }

        public async Task<Solicitud> GuardarMotivo(string descripcion, string detalles)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                return Fallo("La descripción del motivo es obligatoria.");

            var respuesta = new RespuestaBD();
            bool exito = await _datos.RegistrarMotivo(
                descripcion.Trim(), detalles?.Trim() ?? "", respuesta);
            return new Solicitud
            {
                Estado = exito,
                Mensaje = exito ? "Motivo registrado con éxito." : respuesta.Mensaje
            };
        }

        public async Task<DataTable> ListarMotivosConfiguracion()
            => await _datos.ObtenerMotivosListado();

        public async Task<Solicitud> EditarMotivo(string descripcionActual, string descripcionNueva, string detalles)
        {
            if (string.IsNullOrWhiteSpace(descripcionNueva))
                return Fallo("La descripción del motivo es obligatoria.");

            var respuesta = new RespuestaBD();
            bool exito = await _datos.ActualizarMotivo(
                descripcionActual, descripcionNueva.Trim(), detalles?.Trim() ?? "", respuesta);
            return new Solicitud
            {
                Estado = exito,
                Mensaje = exito ? "Motivo actualizado con éxito." : respuesta.Mensaje
            };
        }

        public async Task<Solicitud> EliminarMotivo(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                return Fallo("Debe seleccionar un motivo de la lista.");

            var respuesta = new RespuestaBD();
            bool exito = await _datos.EliminarMotivo(descripcion, respuesta);
            return new Solicitud
            {
                Estado = exito,
                Mensaje = exito ? "Motivo eliminado con éxito." : respuesta.Mensaje
            };
        }

        public async Task<List<MotivosDescargo>> ListarMotivos()
            => await _datos.ObtenerMotivos();

        public async Task<List<OperacionInventario>> ListarHistorialOperaciones()
            => await _datos.ObtenerHistorialOperaciones();

        public async Task<List<Productos>> ListarProductosPorCategoria(int idCategoria)
            => await _datos.ObtenerProductosPorCategoria(idCategoria);

        public async Task<List<Productos>> ListarProductosActivos()
                       => await _datos.ObtenerProductosActivos();

        public async Task<DataTable> ObtenerCategoriasParaFiltro()
        {
            var dt = await _datos.ObtenerCategoriasActivas();

            if (dt.Columns.Contains("IdCategoria") && dt.Columns.Contains("NombreCategoria"))
            {
                DataRow filaTodas = dt.NewRow();
                filaTodas["IdCategoria"] = 0;
                filaTodas["NombreCategoria"] = "Todas las categorías";
                dt.Rows.InsertAt(filaTodas, 0);
            }

            return dt;
        }

        public async Task<DataTable> ListarTodosConPrecioBs()
        {
            var productos = await _datos.ObtenerProductos();
            var tasaUsd = await new L_Tasas().ObtenerTasaConIdAsync(2);
            return ArmarTabla(productos, tasaUsd.Tasa);
        }

        public async Task<DataTable> ListarConPrecioBs()
        {
            var productos = await _datos.ObtenerProductosSinInactivos();
            var tasaUsd = await new L_Tasas().ObtenerTasaConIdAsync(2);
            return ArmarTabla(productos, tasaUsd.Tasa);
        }

        private DataTable ArmarTabla(List<Productos> productos, decimal tasa)
        {
            var dt = new DataTable();
            dt.Columns.Add("Codigo");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("NombreCategoria");
            dt.Columns.Add("Precio", typeof(decimal));
            dt.Columns.Add("PrecioBs", typeof(string));
            dt.Columns.Add("StockActual", typeof(int));
            dt.Columns.Add("Estado");
            dt.Columns.Add("EstadoVisual");

            foreach (var p in productos)
            {
                string ev = p.Estado == "Inactivo" ? "Inactivo"
                          : p.StockActual <= 0 ? "Agotado"
                          : p.StockActual < 10 ? "Stock bajo"
                                                   : "Activo";

                dt.Rows.Add(p.Codigo, p.Nombre, p.NombreCategoria, p.Precio,
                    Math.Round(p.Precio * tasa, 2).ToString("N2"),
                    p.StockActual, p.Estado, ev);
            }
            return dt;
        }
    }
}