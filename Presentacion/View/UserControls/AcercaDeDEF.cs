using Logica;
using Presentacion.View.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.View.UserControls
{
    public partial class AcercaDeDEF : UserControl
    {
        public AcercaDeDEF()
        {
            InitializeComponent();

            EnableDoubleBuffer(tlpContenedor);
            EnableDoubleBuffer(tlpSecciones);
            EnableDoubleBuffer(tlpNombres);
            EnableDoubleBuffer(tlpLogo);
            EnableDoubleBuffer(tlpLetras);
            EnableDoubleBuffer(tlpHerramientas);
            EnableDoubleBuffer(tlpVersions);
        }

        private const float AnchoDiseno = 800f;

        private static float Clamp(float value, float min, float max)
            => Math.Max(min, Math.Min(max, value));

        private void EscalarFuentes()
        {
            float factorVentana = (float)this.Width / AnchoDiseno;
            float anchoActual = (float)this.Width;

            const float AnchoBaseUC = 697f;
            const float AnchoGrande = 1200f;

            Control[] controlesConcepto = { lblInformacion };

            foreach (Control ctrl in controlesConcepto)
            {
                if (ctrl == null) continue;

                float tope;

                if (anchoActual >= AnchoGrande)
                    tope = 13f;
                else if (anchoActual > AnchoBaseUC)
                    tope = 10f;
                else
                    tope = 8f;

                float nuevoTamano = Clamp(10f * factorVentana, 6f, tope);

                if (Math.Abs(ctrl.Font.Size - nuevoTamano) > 0.1)
                {
                    ctrl.Font = new Font(ctrl.Font.FontFamily, nuevoTamano, ctrl.Font.Style);
                }
            }

            Control[] controlesEquipo = {
                lblArquitecto, lblW, lblTecnicos, lblLideres, lblRamonM, lblMiembros, lblR, lblHerramientas
            };

            foreach (Control ctrl in controlesEquipo)
            {
                if (ctrl == null) continue;

                float tope;

                if (anchoActual >= AnchoGrande)
                    tope = 13f;
                else if (anchoActual > AnchoBaseUC)
                    tope = 12f;
                else
                    tope = 8f;

                float nuevoTamano = Clamp(10f * factorVentana, 6f, tope);

                if (Math.Abs(ctrl.Font.Size - nuevoTamano) > 0.1)
                {
                    ctrl.Font = new Font(ctrl.Font.FontFamily, nuevoTamano, ctrl.Font.Style);
                }
                if (ctrl == null) continue;
            }

            Control[] controlHerramientas = { lblHerramientas, lblCSharp, lblVisual, lblSQL, llblPoliticas };

            foreach (Control ctrl in controlHerramientas)
            {
                if (ctrl == null) continue;

                float nuevoTamano = Clamp(10f * factorVentana, 8f, 11f);

                if (Math.Abs(ctrl.Font.Size - nuevoTamano) > 0.1)
                {
                    ctrl.Font = new Font(ctrl.Font.FontFamily, nuevoTamano, ctrl.Font.Style);
                }
            }
        }
        private void EnableDoubleBuffer(Control control)
        {
            typeof(Control).GetProperty("DoubleBuffered",
                                        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(control, true);
        }

        private void AcercaDeDEF_Resize_1(object sender, EventArgs e)
        {
            EscalarFuentes();
        }

        private void llblPoliticas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var vista = new Politicas();

            vista.ShowDialog();
        }
    }
}