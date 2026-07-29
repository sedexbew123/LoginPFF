using Presentacion.Helpers;
using Presentacion.View.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.View.Forms
{
    public partial class NuevoServicio : Form, INuevoServicioView
    {
        #region
        public int Cedula
        {
            get => int.TryParse(KtxtCedula.Text, out int cedula) ? cedula : 0;
            set => KtxtCedula.Text = value.ToString();
        }
        public string Nombre
        {
            set => KtxtNombre.Text = value;
        }
        public string Apellido
        {
            set => KtxtApellido.Text = value;
        }
        public string ServicioSeleccionado => KcmbServicio.SelectedItem?.ToString() ?? "";
        public object ServiciosDataSource
        {
            set
            {
                KcmbServicio.DataSource = value;
                KcmbServicio.DisplayMember = "Nombre"; 
                KcmbServicio.ValueMember = "Nombre";   
            }
        }
        public decimal MontoDolares
        {
            get => decimal.TryParse(KTxtMonto.Text, out decimal monto) ? monto : 0;
            set => KTxtMonto.Text = value.ToString("F2");
        }
        public decimal MontoBolivares
        {
            get => decimal.TryParse(KtxtTotalPagarB.Text, out decimal monto) ? monto : 0;
            set => KtxtTotalPagarB.Text = value.ToString("F2");
        }
        public bool DarCredito
        {
            get => chkCredito.Checked;
            set => chkCredito.Checked = value;
        }
        public DateTime FechaServicio => dtpFecha.Value;
        public DateTime? FechaLimite => DarCredito ? dtpFechaLimite.Value : (DateTime?)null;
        public bool FechaLimiteVisible
        {
            set
            {
                lblFechaLimite.Visible = value;
                dtpFechaLimite.Visible = value;
            }
        }
        #endregion
        public NuevoServicio()
        {
            InitializeComponent();
            Eventos();

            FechaLimiteVisible = false;
        }

        private void Eventos()
        {
            KbtnCancelar.Click += delegate { Cancelar?.Invoke(this, EventArgs.Empty); };
            KbtnRegistrar.Click += delegate { RegistrarServicioRealizado?.Invoke(this, EventArgs.Empty); };
            KtxtCedula.TextChanged += delegate { CedulaBusqueda?.Invoke(this, EventArgs.Empty); };
            chkCredito.CheckedChanged += (s, e) => CreditoCambiado?.Invoke(this, EventArgs.Empty);
            KcmbServicio.SelectedIndexChanged += (s, e) => ServicioCambiado?.Invoke(this, EventArgs.Empty);
            KtxtCedula.KeyPress += SoloNumeros_KeyPress;
            KtxtCedula.TextChanged += QuitarLetrasCedula_TextChanged;
        }
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void QuitarLetrasCedula_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                int cursorPosition = textBox.SelectionStart;
                string textoFiltrado = "";

                foreach (char c in textBox.Text)
                {
                    if (char.IsDigit(c))
                    {
                        textoFiltrado += c;
                    }
                }

                if (textBox.Text != textoFiltrado)
                {
                    textBox.Text = textoFiltrado;
                    textBox.SelectionStart = Math.Max(0, cursorPosition - 1);
                }
            }
        }
        public void MostrarMensaje(string mensaje, bool isError = false)
        {
            MessageBox.Show(mensaje, "CrediTrack - Servicio",
                MessageBoxButtons.OK, isError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }

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

        public event EventHandler RegistrarServicioRealizado;
        public event EventHandler CreditoCambiado;
        public event EventHandler CedulaBusqueda;
        public event EventHandler ServicioCambiado;
        public event EventHandler Cancelar;
    }
}
