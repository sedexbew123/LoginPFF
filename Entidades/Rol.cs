using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Rol
    {
        public int IdRol { get; set; }
        public string NombreRol { get; set; }

        public const int ADMINISTRADOR = 1;
        public const int EMPLEADO = 2;
    }
}
