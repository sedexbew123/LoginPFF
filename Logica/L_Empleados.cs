using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class L_Empleados
    {
        private readonly D_Empleados DEmpleados = new D_Empleados();

        private string EncriptarConSHA256(string textoPlano)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(textoPlano);
            byte[] hash;
            using (var sha256 = SHA256.Create())
            {
                hash = sha256.ComputeHash(bytes);
            }
            return BitConverter.ToString(hash).Replace("-", "");
        }

        public async Task<Solicitud> ListarEmpleados(string filtro, int pagina, int registrosPorPagina)
        {
            try
            {
                var (datos, total) = await DEmpleados.ListarEmpleados(filtro, pagina, registrosPorPagina);
                int totalPaginas = (int)Math.Ceiling(total / (double)registrosPorPagina);
                if (totalPaginas == 0) totalPaginas = 1;

                return new Solicitud
                {
                    Estado = true,
                    Mensaje = "Listado obtenido correctamente.",
                    Datos = new ResultadoPaginado<Usuarios>
                    {
                        Datos = datos,
                        TotalPaginas = totalPaginas,
                        PaginaActual = pagina
                    }
                };
            }
            catch (Exception ex)
            {
                return new Solicitud 
                { 
                    Estado = false, 
                    Mensaje = ex.Message 
                };
            }
        }

        public async Task<Solicitud> ObtenerEmpleado(string cedula)
        {
            try
            {
                var empleado = await DEmpleados.ObtenerEmpleadoPorCedula(cedula);
                if (empleado == null)
                    return new Solicitud 
                    { 
                        Estado = false, 
                        Mensaje = "El empleado no existe." 
                    };

                return new Solicitud 
                { 
                    Estado = true, 
                    Mensaje = "Empleado encontrado.", 
                    Datos = empleado 
                };
            }
            catch (Exception ex)
            {
                return new Solicitud 
                { 
                    Estado = false, 
                    Mensaje = ex.Message 
                };
            }
        }

        public async Task<Solicitud> RegistrarEmpleado(Usuarios empleado, string contraseñaPlana)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(empleado.User) ||
                    string.IsNullOrWhiteSpace(contraseñaPlana) ||
                    string.IsNullOrWhiteSpace(empleado.Cedula) ||
                    string.IsNullOrWhiteSpace(empleado.Nombre) ||
                    string.IsNullOrWhiteSpace(empleado.Apellido) ||
                    string.IsNullOrWhiteSpace(empleado.Correo))
                {
                    return new Solicitud { Estado = false, Mensaje = "Todos los campos obligatorios deben completarse." };
                }

                if (contraseñaPlana.Length < 6)
                    return new Solicitud 
                    { 
                        Estado = false, 
                        Mensaje = "La contraseña debe tener al menos 6 caracteres." 
                    };

                if (await DEmpleados.ExisteUsuarioOCedula(empleado.User, empleado.Cedula))
                    return new Solicitud 
                    { 
                        Estado = false, 
                        Mensaje = "Ya existe un empleado con ese usuario o cédula." 
                    };

                string hash = EncriptarConSHA256(contraseñaPlana);
                int idGenerado = await DEmpleados.InsertarEmpleado(empleado, hash);

                return new Solicitud
                {
                    Estado = idGenerado > 0,
                    Mensaje = idGenerado > 0 ? "Empleado registrado exitosamente." : "No se pudo registrar el empleado.",
                    Datos = idGenerado
                };
            }
            catch (Exception ex)
            {
                return new Solicitud 
                { 
                    Estado = false, 
                    Mensaje = ex.Message 
                };
            }
        }

        public async Task<Solicitud> ActualizarEmpleado(Usuarios empleado)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(empleado.Nombre) ||
                    string.IsNullOrWhiteSpace(empleado.Apellido) ||
                    string.IsNullOrWhiteSpace(empleado.Cedula) ||
                    string.IsNullOrWhiteSpace(empleado.Correo))
                {
                    return new Solicitud 
                    { 
                        Estado = false, 
                        Mensaje = "Todos los campos obligatorios deben completarse." 
                    };
                }

                bool exito = await DEmpleados.ActualizarEmpleado(empleado);
                return new Solicitud
                {
                    Estado = exito,
                    Mensaje = exito ? "Empleado actualizado exitosamente." : "No se pudo actualizar el empleado."
                };
            }
            catch (Exception ex)
            {
                return new Solicitud 
                { 
                    Estado = false, 
                    Mensaje = ex.Message 
                };
            }
        }

        public async Task<Solicitud> EliminarEmpleado(string cedula)
        {
            try
            {
                bool exito = await DEmpleados.EliminarEmpleado(cedula);
                return new Solicitud
                {
                    Estado = exito,
                    Mensaje = exito ? "Empleado eliminado exitosamente."
                                    : "No se pudo eliminar el empleado (verifique que no sea el administrador)."
                };
            }
            catch (Exception ex)
            {
                return new Solicitud 
                { 
                    Estado = false, 
                    Mensaje = ex.Message 
                };
            }
        }

        public async Task<Solicitud> ListarEmpleadosParaPermisos()
        {
            try
            {
                var lista = await DEmpleados.ListarEmpleadosParaPermisos();
                return new Solicitud 
                { 
                    Estado = true, 
                    Mensaje = "Listado obtenido.", 
                    Datos = lista 
                };
            }
            catch (Exception ex)
            {
                return new Solicitud 
                { 
                    Estado = false, 
                    Mensaje = ex.Message 
                };
            }
        }

        public async Task<Solicitud> ActualizarPermisoIngreso(int idUsuario, bool permitir)
        {
            try
            {
                bool exito = await DEmpleados.ActualizarPermisoIngreso(idUsuario, permitir);
                return new Solicitud
                {
                    Estado = exito,
                    Mensaje = exito ? "Permiso actualizado." : "No se pudo actualizar el permiso."
                };
            }
            catch (Exception ex)
            {
                return new Solicitud 
                { 
                    Estado = false, 
                    Mensaje = ex.Message 
                };
            }
        }
    }
}
