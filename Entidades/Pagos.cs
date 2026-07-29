using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pagos
    {
        public decimal MontoOriginal { get; set; }
        public int IdPago { get; set; }
        public int IdCredito { get; set; }
        public decimal Monto { get; set; }
        public decimal MontoBs { get; set; }
        public DateTime FechaPago { get; set; }
        public string Estado { get; set; }
        public string TipoPago { get; set; }
        public string Observacion { get; set; }
        public int IdUsuario { get; set; }
        public int IdMoneda { get; set; }
        public int? IdTasa { get; set; }
    }
}
