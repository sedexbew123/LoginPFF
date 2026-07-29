using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ResultadoPaginado<T>
    {
        public List<T> Datos { get; set; }
        public int TotalPaginas { get; set; }
        public int PaginaActual { get; set; }
    }
}
