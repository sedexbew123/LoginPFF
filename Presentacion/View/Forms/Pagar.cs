using Presentacion.Helpers;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace Presentacion.View.Forms
{
    public partial class Pagar : Form, Interfaces.IPagarView
    {
        #region 

        public string Nombre 
        { 
            set => KtxtNombre.Text = value; 
        }
        public string Apellido 
        { 
            set => KtxtApellido.Text = value; 
        }
        public string Cedula 
        { 
            set => KtxtCedula.Text = value; 
        }

        public int IdCredito 
        { 
            get; set; 
        }
        public decimal SaldoPendiente 
        { 
            get; set; 
        }

        public string TipoPago
        {
            get => KcmbPago.SelectedItem?.ToString() ?? "";
        }

        public int IdMoneda
        {
            get
            {
                int idx = KcmbMoneda.SelectedIndex;
                return idx == 0 ? 1 :
                       idx == 1 ? 2 :
                       idx == 2 ? 3 : 0;
            }
        }

        public string MontoExtranjeroTexto
        {
            get => KtxtTotalPagar.Text.Trim();
            set => KtxtTotalPagar.Text = value;
        }

        public decimal MontoExtranjeroValidado
        {
            get
            {
                string raw = MontoExtranjeroTexto
                    .Replace(".", "")
                    .Replace(",", ".");
                decimal.TryParse(raw,
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out decimal res);
                return res;
            }
        }

        public string MontoBsTexto
        {
            get => KtxtTotalPagarB.Text.Trim();
            set => KtxtTotalPagarB.Text = value;
        }


        #endregion

        public Pagar()
        {
            InitializeComponent();
            InicializarCombos();
            Eventos();
        }

        private void InicializarCombos()
        {
            KcmbPago.Items.Clear();
            KcmbPago.Items.Add("Abono");
            KcmbPago.Items.Add("Completo");

            KcmbMoneda.Items.Clear();
            KcmbMoneda.Items.Add("Bolívares");
            KcmbMoneda.Items.Add("Dólar");
            KcmbMoneda.Items.Add("Euro");
        }

        private void Eventos()
        {
            KbtnCancelar.Click += delegate { Cancelar?.Invoke(this, EventArgs.Empty); };
            KbtnRegistrar.Click += delegate { RegistrarPago?.Invoke(this, EventArgs.Empty); };
            KcmbPago.SelectedIndexChanged += delegate { TipoPagoCambiado?.Invoke(this, EventArgs.Empty); };
            KcmbMoneda.SelectedIndexChanged += delegate { MonedaCambiada?.Invoke(this, EventArgs.Empty); };
            KtxtTotalPagar.TextChanged += MontoCambiado_Handler;
        }

        private bool _formateando = false;

        private void MontoCambiado_Handler(object sender, EventArgs e)
        {
            if (_formateando) return;
            AplicarFormatoMiles();
            MontoExtranjeroCambiado?.Invoke(this, EventArgs.Empty);
        }

        private void AplicarFormatoMiles()
        {
            _formateando = true;
            try
            {
                string texto = KtxtTotalPagar.Text;
                if (string.IsNullOrEmpty(texto)) return;

                int posComma = texto.IndexOf(',');
                string parteDecimal = posComma >= 0 ? texto.Substring(posComma) : "";
                string parteEntera = posComma >= 0 ? texto.Substring(0, posComma) : texto;

                parteEntera = parteEntera.Replace(".", "");
                var sb = new System.Text.StringBuilder();
                foreach (char c in parteEntera)
                    if (char.IsDigit(c)) sb.Append(c);
                parteEntera = sb.ToString();

                if (string.IsNullOrEmpty(parteEntera)) return;

                if (long.TryParse(parteEntera, out long numero))
                {
                    var fmt = new System.Globalization.NumberFormatInfo
                    {
                        NumberGroupSeparator = ".",
                        NumberDecimalSeparator = ","
                    };
                    string resultado = numero.ToString("N0", fmt) + parteDecimal;

                    if (KtxtTotalPagar.Text != resultado)
                    {
                        int cursor = KtxtTotalPagar.SelectionStart;
                        int dif = resultado.Length - KtxtTotalPagar.Text.Length;
                        KtxtTotalPagar.Text = resultado;
                        KtxtTotalPagar.SelectionStart = Math.Max(0, Math.Min(cursor + dif, resultado.Length));
                    }
                }
            }
            finally
            {
                _formateando = false;
            }
        }
        private void Pagar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                KbtnCancelar.PerformClick();
            }
        }
        public void ConfigurarMontoSoloLectura(bool soloLectura)
        {
            KtxtTotalPagar.ReadOnly = soloLectura;
            KtxtTotalPagar.StateCommon.Back.Color1 = soloLectura
                ? System.Drawing.Color.FromArgb(240, 240, 240)
                : System.Drawing.Color.White;
        }

        public void MostrarMensaje(string mensaje) =>
            MessageBox.Show(mensaje, "Pagos",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        public void CerrarVista(bool exitoso)
        {
            this.DialogResult = exitoso ? DialogResult.OK : DialogResult.Cancel;
            this.Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AnimateWindows.Start(this, 350,
                AnimateWindows.AnimateWindowsFlags.AW_ACTIVATE |
                AnimateWindows.AnimateWindowsFlags.AW_BLEND);
            this.Invalidate(true);
        }

        public event EventHandler TipoPagoCambiado;
        public event EventHandler MonedaCambiada;
        public event EventHandler MontoExtranjeroCambiado;
        public event EventHandler RegistrarPago;
        public event EventHandler Cancelar;
    }
}