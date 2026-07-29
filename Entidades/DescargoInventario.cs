using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DescargoInventario
    {
        public int Id { get; set; }
        public string CodigoProducto { get; set; } = string.Empty;
        public string NombreProducto { get; set; } = string.Empty;
        public string NombreCategoria { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public int IdMotivo { get; set; } 
        public string Motivo { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
    }
}
