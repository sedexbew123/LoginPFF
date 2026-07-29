using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MotivosDescargo
    {
        public int IdMotivo { get; set; }
        public string Descripcion { get; set; }
        public string Detalles { get; set; }
        public bool Estado { get; set; }
    }
}
