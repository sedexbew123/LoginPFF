using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ServicioRealizadoListado
    {
        public int IdServicioRealizado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [DisplayName("Cédula")]
        public string Cedula { get; set; }

        public string Servicio { get; set; }
        public decimal Monto { get; set; }

        [DisplayName("Total Bs")]
        public decimal TotalBs { get; set; }

        public DateTime Fecha { get; set; }

        public string Estado { get; set; }
    }
}
