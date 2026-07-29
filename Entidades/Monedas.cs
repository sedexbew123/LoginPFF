using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moneda
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Simbolo { get; set; }

        public override string ToString() => Nombre; 
    }

}
