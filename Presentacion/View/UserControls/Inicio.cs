using System;
using System.Windows.Forms;

namespace Presentacion.View.UserControls
{

    public partial class Inicio : UserControl
    {
        private readonly System.Windows.Forms.Timer timer;

        public Inicio()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += (_, __) => ActualizarReloj();

            ActualizarReloj();
            timer.Start();

            AsociarEventos();
        }

        private void AsociarEventos()
        {
            this.Resize += (s, e) => AjusteUC();
        }

        private void AjusteUC()
        {
            int alto = this.ClientSize.Height;

            pnlSeparacion.Height = (int)(alto * 0.05);
            tlpLogo.Height = (int)(alto * 0.60);
            tlpReloj.Height = (int)(alto * 0.20);
        }

        private void ActualizarReloj()
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFecha.Text = $"{DateTime.Now:dddd, d} de {DateTime.Now:MMMM} del {DateTime.Now:yyyy}";
        }
    }
}
