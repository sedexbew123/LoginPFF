using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class L_Creditos
    {
        private readonly D_Creditos DCreditos = new D_Creditos();

        public async Task<Clientes> BuscarPorCedula(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula)) return null;
            return await DCreditos.BuscarPorCedula(cedula.Trim());
        }

        public async Task<List<string>> ObtenerCategorias()
            => await DCreditos.ObtenerCategorias();

        public async Task<DataTable> ObtenerProductosFiltrados(string nombre, string categoria)
            => await DCreditos.ObtenerProductos(nombre, categoria);

        public async Task<(bool exito, string mensaje)> AsignarCredito(string cedula, List<ItemCredito> items, int idUsuario)
        {
            if (string.IsNullOrWhiteSpace(cedula))
                return (false, "La cédula es obligatoria.");
            if (items == null || items.Count == 0)
                return (false, "No hay productos en el crédito.");
            if (items.Any(i => i.Cantidad <= 0))
                return (false, "La cantidad de cada producto debe ser mayor a cero.");
            decimal total = items.Sum(i => i.Subtotal);
            return await DCreditos.AsignarCredito(cedula.Trim(), items, total, idUsuario);
        }

        public async Task<DataTable> ObtenerResumenDeudas(string filtro, string criterio)
        {
            string ordenSQL;

            string criterioLimpio = (criterio ?? "").Trim().ToLower();

            switch (criterioLimpio)
            {
                case "mayor deuda":
                    ordenSQL = "Monto DESC";
                    break;

                case "menor deuda":
                    ordenSQL = "Monto ASC";
                    break;

                case "mayor antigüedad":
                case "mayor antiguedad":
                    ordenSQL = "Fecha ASC"; 
                    break;

                case "menor antigüedad":
                case "menor antiguedad":
                    ordenSQL = "Fecha DESC";
                    break;

                default:
                    ordenSQL = "Monto DESC";
                    break;
            }

            return await DCreditos.ObtenerResumenDeudas(filtro, ordenSQL);
        }

        public async Task<(Clientes cliente, DataTable detalle, decimal total, int meses)>
    ObtenerDetalleDeuda(string cedula, int idCredito)
        {
            return await DCreditos.ObtenerDetalleDeuda(cedula, idCredito);
        }

        public async Task<(int totalClientes, decimal creditoTotal, int totalProductos)> ObtenerEstadisticasDeudas()
            => await DCreditos.ObtenerEstadisticasDeudas();
    }
}