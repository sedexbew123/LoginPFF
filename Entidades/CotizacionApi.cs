using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CotizacionApi
    {

        public string Fuente { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;

        public decimal? Compra { get; set; }

        public decimal? Venta { get; set; } 

        public string Moneda { get; set; } = string.Empty;  

        public decimal Promedio { get; set; }

        public string FechaActualizacion { get; set; }
    }
}
