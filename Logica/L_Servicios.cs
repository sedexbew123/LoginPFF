using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class L_Servicios
    {
        private readonly D_Servicios DServicios = new D_Servicios();
        private readonly L_Clientes LClientes = new L_Clientes();
        private readonly L_Creditos LCreditos = new L_Creditos();
        private readonly L_Tasas LTasas = new L_Tasas();

        private const int IdMonedaDolar = 2;

        #region Tipos de Servicio

        public async Task<List<TipoServicioListado>> ObtenerTipos() => await DServicios.ObtenerTiposAsync();

        public async Task<List<TipoServicio>> ObtenerTiposActivos() => await DServicios.ObtenerTiposActivosAsync();

        public async Task<TipoServicio> ObtenerTipoPorId(int idTipoServicio) => await DServicios.ObtenerTipoPorIdAsync(idTipoServicio);

        public async Task<Solicitud> GuardarTipo(TipoServicio tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo.Nombre))
                return new Solicitud { Estado = false, Mensaje = "El nombre del tipo es obligatorio." };

            tipo.Nombre = tipo.Nombre.Trim();

            if (await DServicios.ExisteTipoPorNombreAsync(tipo.Nombre, tipo.IdTipoServicio))
                return new Solicitud { Estado = false, Mensaje = "Ya existe un tipo de servicio con ese nombre." };

            bool exito = tipo.IdTipoServicio == 0
                ? await DServicios.InsertarTipoAsync(tipo)
                : await DServicios.ActualizarTipoAsync(tipo);

            return new Solicitud
            {
                Estado = exito,
                Mensaje = exito ? "Tipo guardado correctamente." : "No se pudo guardar el tipo."
            };
        }

        /// <summary>Solicitud.Estado = false cuando solo se desactivó (tenía servicios asociados).</summary>
        public async Task<Solicitud> EliminarTipo(int idTipoServicio)
        {
            bool tieneServicios = await DServicios.TipoTieneServiciosAsync(idTipoServicio);
            if (tieneServicios)
            {
                await DServicios.DesactivarTipoAsync(idTipoServicio);
                return new Solicitud { Estado = false, Mensaje = "El tipo tiene servicios asociados; se desactivó en lugar de eliminarse." };
            }

            bool eliminado = await DServicios.EliminarTipoAsync(idTipoServicio);
            return new Solicitud
            {
                Estado = eliminado,
                Mensaje = eliminado ? "Tipo eliminado correctamente." : "No se pudo eliminar el tipo."
            };
        }

        #endregion

        #region Servicios

        public async Task<List<ServicioListado>> ObtenerServicios() => await DServicios.ObtenerServiciosAsync();

        public async Task<List<Servicio>> ObtenerServiciosActivos() => await DServicios.ObtenerServiciosActivosAsync();

        public async Task<Servicio> ObtenerServicioPorId(int idServicio) => await DServicios.ObtenerServicioPorIdAsync(idServicio);

        public async Task<Servicio> ObtenerServicioPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return null;
            var activos = await DServicios.ObtenerServiciosActivosAsync();
            return activos.FirstOrDefault(s => s.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Solicitud> GuardarServicio(Servicio servicio)
        {
            if (string.IsNullOrWhiteSpace(servicio.Nombre))
                return new Solicitud { Estado = false, Mensaje = "El nombre del servicio es obligatorio." };
            if (servicio.IdTipoServicio <= 0)
                return new Solicitud { Estado = false, Mensaje = "Debe seleccionar un tipo de servicio." };
            if (servicio.Precio <= 0)
                return new Solicitud { Estado = false, Mensaje = "El precio debe ser mayor a cero." };

            servicio.Nombre = servicio.Nombre.Trim();

            bool exito = servicio.IdServicio == 0
                ? await DServicios.InsertarServicioAsync(servicio)
                : await DServicios.ActualizarServicioAsync(servicio);

            return new Solicitud
            {
                Estado = exito,
                Mensaje = exito ? "Servicio guardado correctamente." : "No se pudo guardar el servicio."
            };
        }

        /// <summary>Solicitud.Estado = false cuando solo se ocultó (tenía historial de operaciones).</summary>
        public async Task<Solicitud> EliminarServicio(int idServicio)
        {
            bool tieneHistorial = await DServicios.ServicioTieneHistorialAsync(idServicio);
            if (tieneHistorial)
            {
                await DServicios.DesactivarServicioAsync(idServicio);
                return new Solicitud { Estado = false, Mensaje = "El servicio tiene historial de operaciones; se desactivó en lugar de eliminarse." };
            }

            bool eliminado = await DServicios.EliminarServicioAsync(idServicio);
            return new Solicitud
            {
                Estado = eliminado,
                Mensaje = eliminado ? "Servicio eliminado correctamente." : "No se pudo eliminar el servicio."
            };
        }

        #endregion

        #region Clientes / Tasa (usando tus módulos reales)

        public async Task<Clientes> BuscarClientePorCedula(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula)) return null;
            return await LClientes.ObtenerCliente(cedula.Trim());
        }

        public async Task<decimal> ConvertirDolaresABolivares(decimal montoDolares)
        {
            var tasa = await LTasas.ObtenerTasaConIdAsync(IdMonedaDolar);
            return Math.Round(montoDolares * tasa.Tasa, 2);
        }

        #endregion

        #region Servicios Realizados

        public async Task<Solicitud> RegistrarServicioRealizado(string cedula, string nombre, string apellido,
            string nombreServicio, decimal montoDolares, decimal montoBolivares,
            DateTime fechaServicio, bool darCredito, DateTime? fechaLimite, int idUsuario)
        {
            if (string.IsNullOrWhiteSpace(cedula))
                return new Solicitud { Estado = false, Mensaje = "La cédula del cliente es obligatoria." };
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
                return new Solicitud { Estado = false, Mensaje = "Debe indicar el nombre y apellido del cliente." };

            var servicio = await ObtenerServicioPorNombre(nombreServicio);
            if (servicio == null)
                return new Solicitud { Estado = false, Mensaje = "El servicio seleccionado no es válido." };

            if (montoDolares <= 0)
                return new Solicitud { Estado = false, Mensaje = "El monto del servicio debe ser mayor a cero." };

            DateTime? fechaLimiteFinal = darCredito ? (fechaLimite ?? fechaServicio) : (DateTime?)null;

            if (darCredito && fechaLimiteFinal.Value.Date < fechaServicio.Date)
                return new Solicitud { Estado = false, Mensaje = "La fecha límite no puede ser anterior a la fecha del servicio." };

            // 1) Cliente: buscarlo o crearlo (usando tu módulo real de Clientes)
            cedula = cedula.Trim();
            var cliente = await LClientes.ObtenerCliente(cedula);
            if (cliente == null)
            {
                var nuevoCliente = new Clientes
                {
                    Cedula = cedula,
                    Nombres = nombre,
                    Apellidos = apellido,
                    Telefono = "",
                    Correo = "",
                    Direccion = ""
                };

                var resultadoCliente = await LClientes.GuardarCliente(nuevoCliente);
                if (!resultadoCliente.Estado)
                    return new Solicitud { Estado = false, Mensaje = "No se pudo registrar el cliente: " + resultadoCliente.Mensaje };

                cliente = await LClientes.ObtenerCliente(cedula);
                if (cliente == null)
                    return new Solicitud { Estado = false, Mensaje = "No se pudo recuperar el cliente recién creado." };
            }

            // 2) Crédito (si aplica), usando tu módulo real de Créditos
            int? idCredito = null;
            if (darCredito)
            {
                var (exito, mensaje, idCreditoCreado) = await LCreditos.AsignarCreditoServicio(
                    cedula, montoDolares, idUsuario, fechaLimiteFinal.Value);

                if (!exito)
                    return new Solicitud { Estado = false, Mensaje = mensaje };

                idCredito = idCreditoCreado;
            }

            // 3) Registrar el servicio realizado
            var servicioRealizado = new ServicioRealizado
            {
                IdCliente = cliente.id_cliente,
                IdServicio = servicio.IdServicio,
                MontoDolares = montoDolares,
                MontoBolivares = montoBolivares,
                FechaServicio = fechaServicio,
                DarCredito = darCredito,
                IdCredito = idCredito
            };

            bool guardado = await DServicios.RegistrarServicioRealizadoAsync(servicioRealizado);

            return new Solicitud
            {
                Estado = guardado,
                Mensaje = guardado ? "Servicio registrado correctamente." : "No se pudo registrar el servicio realizado."
            };
        }

        public async Task<(List<ServicioRealizadoListado> lista, int totalPaginas)> ObtenerServiciosRealizados(
            string textoBusqueda, string mes, int año, int pagina, int tamañoPagina)
        {
            var (lista, totalRegistros) = await DServicios.ObtenerServiciosRealizadosAsync(textoBusqueda, mes, año, pagina, tamañoPagina);

            int totalPaginas = (int)Math.Ceiling(totalRegistros / (double)tamañoPagina);
            if (totalPaginas == 0) totalPaginas = 1;

            return (lista, totalPaginas);
        }

        public async Task<List<ServicioRealizadoListado>> ObtenerServiciosRealizadosPorRango(DateTime desde, DateTime hasta)
    => await DServicios.ObtenerServiciosRealizadosPorRangoAsync(desde, hasta);

        #endregion
    }
}
