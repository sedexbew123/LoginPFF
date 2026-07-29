using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public class D_ConexionBD
    {
        public readonly string _cadenaConexion = "Data Source =localhost; Initial Catalog =Users;Integrated Security =True; TrustServerCertificate =True";
        public async Task<SqlConnection> ConectarAsync()
        {
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            await conexion.OpenAsync();
            return conexion;
        }

        
        /*private string CadenaConexion { get; } =
        $"Data Source={Get("CREDIT_HOST")};" +
        $"Initial Catalog={Get("CREDIT_NAME")};" +
        $"User Id={Get("CREDIT_USER")};" +
        $"Password={Get("CREDIT_PASS")};" +
        "TrustServerCertificate=True;";

        private static string Get(string name) =>
            Environment.GetEnvironmentVariable(name)
            ?? throw new Exception($"No se encontró el: {name}. Por favor contacta al Administrador.");
        public async Task<SqlConnection> ConectarAsync()
        {
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            await conexion.OpenAsync();
            return conexion;
        }*/
        
    }
}
