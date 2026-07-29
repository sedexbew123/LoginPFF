using Presentacion.View.Interfaces;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.View.Forms
{
    public partial class CambioMoneda : Form, ICambioMonedaView
    {
        #region

        public int IdMonedaSeleccionada
        {
            get
            {
                if (KcmbMoneda.SelectedValue == null) return -1;
                return int.TryParse(KcmbMoneda.SelectedValue.ToString(), out int id) ? id : -1;
            }
        }

        public string MonedaSeleccionada
        {
            get => KcmbMoneda.Text;
            set => KcmbMoneda.Text = value;
        }

        public string MontoTexto
        {
            get => txtValorMoneda.Text.Trim();
            set => txtValorMoneda.Text = value;
        }

        public decimal MontoValidado
        {
            get
            {
                string texto = MontoTexto.Trim();
                if (string.IsNullOrEmpty(texto)) return 0m;
                string normalizado = texto.Replace(".", "").Replace(",", ".");

                return decimal.TryParse(normalizado,
                           NumberStyles.Any,
                           CultureInfo.InvariantCulture,
                           out decimal resultado) ? resultado : 0m;
            }
        }

        #endregion

        public CambioMoneda()
        {
            InitializeComponent();
            SuscribirEventos();
        }

        public void CargarMonedas(DataTable dt)
        {
            KcmbMoneda.DataSource = dt;
            KcmbMoneda.DisplayMember = "Nombre";
            KcmbMoneda.ValueMember = "IdMoneda";
            KcmbMoneda.SelectedIndex = -1;
        }

        public void MostrarMensaje(string mensaje, bool esError)
        {
            MessageBox.Show(
                mensaje,
                esError ? "Error de validación" : "Información",
                MessageBoxButtons.OK,
                esError ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
        }

        public void CerrarVista()
        {
            this.Close();
        }

        private bool _formateando = false; 

        private void SuscribirEventos()
        {
            btnCancelar.Click += (s, e) => Cancelar?.Invoke(this, e);
            btnEditar.Click += (s, e) => GuardarTasa?.Invoke(this, e);

            txtValorMoneda.KeyPress += txtValorMoneda_KeyPress;
            txtValorMoneda.TextChanged += txtValorMoneda_TextChanged;
        }
        private void CambioMoneda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                btnCancelar.PerformClick();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Helpers.AnimateWindows.Start(this, 350,
                Helpers.AnimateWindows.AnimateWindowsFlags.AW_ACTIVATE |
                Helpers.AnimateWindows.AnimateWindowsFlags.AW_BLEND);

            ViewLoaded?.Invoke(this, EventArgs.Empty);
        }

        private void txtValorMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' && txtValorMoneda.Text.Contains(','))
            {
                e.Handled = true;
            }
        }

        private void txtValorMoneda_TextChanged(object sender, EventArgs e)
        {
            if (_formateando) return; 
            _formateando = true;

            try
            {
                TextBox txt = (TextBox)sender;
                string textoActual = txt.Text;

                string parteEntera;
                string parteDecimal = "";
                bool tieneDecimal = textoActual.Contains(',');

                if (tieneDecimal)
                {
                    int indiceComa = textoActual.IndexOf(',');
                    parteEntera = textoActual.Substring(0, indiceComa);
                    parteDecimal = textoActual.Substring(indiceComa); 
                }
                else
                {
                    parteEntera = textoActual;
                }
                string soloDigitos = parteEntera.Replace(".", "");

                if (!System.Text.RegularExpressions.Regex.IsMatch(soloDigitos, @"^\d*$"))
                {
                    _formateando = false;
                    return;
                }

                string enteroFormateado = "";
                if (!string.IsNullOrEmpty(soloDigitos))
                {
                    if (long.TryParse(soloDigitos, out long numero))
                        enteroFormateado = numero.ToString("N0", new CultureInfo("es-VE"));
                }

                string textoFinal = enteroFormateado + parteDecimal;

                if (txt.Text != textoFinal)
                {
                    int cursorPos = txt.SelectionStart + (textoFinal.Length - txt.Text.Length);
                    txt.Text = textoFinal;
                    txt.SelectionStart = Math.Max(0, Math.Min(cursorPos, txt.Text.Length));
                }
            }
            finally
            {
                _formateando = false;
            }
        }

        public event EventHandler ViewLoaded;
        public event EventHandler GuardarTasa;
        public event EventHandler Cancelar;
    }
}
