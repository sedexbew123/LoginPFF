using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ServicioRealizado
    {
        public int IdServicioRealizado { get; set; }
        public int IdCliente { get; set; }
        public int IdServicio { get; set; }
        public decimal MontoDolares { get; set; }
        public decimal MontoBolivares { get; set; }
        public DateTime FechaServicio { get; set; }
        public bool DarCredito { get; set; }
        public int? IdCredito { get; set; }
    }
}
