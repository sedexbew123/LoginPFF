using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class L_Clientes
    {
        private readonly D_Clientes DClientes = new D_Clientes();

        public async Task<Solicitud> GuardarCliente(Clientes cliente)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cliente.Cedula))
                    return new Solicitud
                    {
                        Estado = false,
                        Mensaje = "El campo Cédula es obligatorio."
                    };

                if (string.IsNullOrWhiteSpace(cliente.Nombres))
                    return new Solicitud
                    {
                        Estado = false,
                        Mensaje = "El campo Nombre es obligatorio."
                    };

                if (string.IsNullOrWhiteSpace(cliente.Apellidos))
                    return new Solicitud
                    {
                        Estado = false,
                        Mensaje = "El campo Apellido es obligatorio."
                    };

                var respuesta = new RespuestaBD();

                bool exito = await DClientes.RegistrarCliente(cliente, respuesta);

                if (exito)
                {
                    return new Solicitud
                    {
                        Estado = true,
                        Mensaje = "Cliente registrado con éxito."
                    };
                }
                else
                {
                    return new Solicitud
                    {
                        Estado = false,
                        Mensaje = respuesta.Mensaje
                    };
                }
            }
            catch (Exception ex)
            {
                return new Solicitud
                {
                    Estado = false,
                    Mensaje = "Error inesperado: " + ex.Message
                };
            }
        }

        public async Task<(List<Clientes> clientes, int TotalPaginas)> Listar(int pagina, int CantidadPagina, string filtro = " ")
        {
            try
            {
                int offset = (pagina - 1) * CantidadPagina;
                var clientes = await DClientes.ObtenerClientes(offset, CantidadPagina, filtro);
                int totalClientes = await DClientes.ObtenerTotalClientes(filtro);
                int totalPaginas = (int)Math.Ceiling((double)totalClientes / CantidadPagina);

                if (totalPaginas == 0) totalPaginas = 1;
                return (clientes, totalPaginas);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar clientes: " + ex.Message);
            }
        }

        public async Task<Solicitud> Editar(Clientes cliente)
        {
            var respuesta = new RespuestaBD();

            bool exito = await DClientes.ActualizarCliente(cliente, respuesta);

            return new Solicitud
            {
                Estado = exito,
                Mensaje = exito ? "Datos actualizados correctamente." : respuesta.Mensaje.ToString()
            };
        }

        public async Task<Solicitud> Eliminar(string cedula)
        {
            if (string.IsNullOrEmpty(cedula))
                return new Solicitud
                {
                    Estado = false,
                    Mensaje = "Cédula no válida."
                };

            var respuesta = new RespuestaBD();

            bool exito = await DClientes.EliminarCliente(cedula, respuesta);

            return new Solicitud
            {
                Estado = exito,
                Mensaje = exito ? "Cliente eliminado del sistema." : respuesta.Mensaje
            };
        }

        public async Task<Clientes> ObtenerCliente(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula))
                return null;

            return await DClientes.ObtenerClientePorCedula(cedula);
        }
    }
}