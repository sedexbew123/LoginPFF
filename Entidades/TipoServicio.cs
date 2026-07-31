using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoServicio
    {
        public int IdTipoServicio { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; } = true;
        public string Descripcion { get; set; }
    }
}
