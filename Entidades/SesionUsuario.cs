using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class SesionUsuario
    {
        public static Usuarios UsuarioLogueado { get; set; }

        public static bool HaySesionActiva => UsuarioLogueado != null;

        public static bool EsAdministrador =>
            UsuarioLogueado != null && UsuarioLogueado.EsAdministrador;

        public static bool EsEmpleado =>
            UsuarioLogueado != null && UsuarioLogueado.EsEmpleado;

        public static void CerrarSesion()
        {
            UsuarioLogueado = null;
        }
    }
}