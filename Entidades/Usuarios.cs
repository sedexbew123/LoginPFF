using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Contraseña { get; set; }   

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public byte[] Foto { get; set; }
        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public bool PermitirIngreso { get; set; } = true;
        public bool EsAdministrador => IdRol == Rol.ADMINISTRADOR;
        public bool EsEmpleado => IdRol == Rol.EMPLEADO;
    }
}
