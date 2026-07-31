using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Servicio
    {
        public int IdServicio { get; set; }
        public string Nombre { get; set; }
        public int IdTipoServicio { get; set; }
        public string TipoNombre { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; } = true;
    }
}
