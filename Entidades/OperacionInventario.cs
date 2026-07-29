using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class OperacionInventario
    {
        public DateTime Fecha { get; set; }
        public string Producto { get; set; }
        public string Categoria { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public string Motivo { get; set; }
    }
}
