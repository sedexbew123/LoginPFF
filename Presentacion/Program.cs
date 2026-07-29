using Logica;
using Presentacion.Presenter;
using Presentacion.View.Forms;
using System.Runtime.InteropServices;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    internal static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [STAThread]
        static void Main()
        {

            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }


            try
            {
                bool reiniciar;
                do
                {
                    reiniciar = false;
                    Login loginView = new Login();
                    L_Usuarios logica = new L_Usuarios();
                    new LoginPresenter(loginView, logica);

                    if (loginView.ShowDialog() == DialogResult.OK)
                    {
                        MenuPrincipal menu = new MenuPrincipal();

                        new MenuPrincipalPresenter(menu);
                       

                        Application.Run(menu);

                        if (Entidades.SesionUsuario.UsuarioLogueado == null)
                        {
                            reiniciar = true;
                        }
                    }
                } while (reiniciar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error inesperado: " + ex.Message, "Error");
            }
        }
    }
}
