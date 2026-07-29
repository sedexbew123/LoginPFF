using Presentacion.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices; 
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.View.Forms
{
    public partial class Politicas : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        private const int WM_SETREDRAW = 0x0B;

        public Politicas()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SendMessage(rtbPoliticas.Handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);

            AplicarNegritasRapidas();

            SendMessage(rtbPoliticas.Handle, WM_SETREDRAW, new IntPtr(1), IntPtr.Zero);
            rtbPoliticas.Refresh();

            Helpers.AnimateWindows.Start(this, 350, Helpers.AnimateWindows.AnimateWindowsFlags.AW_ACTIVATE | AnimateWindows.AnimateWindowsFlags.AW_BLEND);

            this.Invalidate(true);
        }

        private void AplicarNegritasRapidas()
        {
            string[] titulos = {
                "Seguridad y Control de Acceso (Usuarios y Empleados)",
                "Gestión de Clientes, Privacidad y Marco Legal",
                "Normas Operativas de Crédito, Pagos y Fiscalidad",
                "Control de Inventario y Prevención de Ilícitos Económicos",
                "Integridad del Sistema y Custodia Digital (Responsabilidad General)"
            };

            string textoTotal = rtbPoliticas.Text;
            Font fuenteTitulo = new Font(rtbPoliticas.Font.FontFamily, 12f, FontStyle.Bold);

            foreach (string titulo in titulos)
            {
                int index = textoTotal.IndexOf(titulo);
                while (index != -1)
                {
                    rtbPoliticas.Select(index, titulo.Length);
                    rtbPoliticas.SelectionFont = fuenteTitulo;

                    index = textoTotal.IndexOf(titulo, index + titulo.Length);
                }
            }

            rtbPoliticas.SelectionStart = 0;
            rtbPoliticas.SelectionLength = 0;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}