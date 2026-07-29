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
    public partial class CapturaFotoClientes : Form, ICapturaFotoClientesView
    {
        private PictureBox picPreview;
        private ComboBox cmbCamaras;
        private Button btnCapturar;
        private Button btnReintentar;
        private Button btnAceptar;
        private Button btnCancelar;
        #region
        public byte[] FotoCapturada { get; set; }
        public int CamaraSeleccionada => cmbCamaras.SelectedIndex;

        public bool EnModoPreview
        {
            get => btnCapturar.Visible;
            set
            {
                btnCapturar.Visible = value;
                cmbCamaras.Enabled = value;
                btnReintentar.Visible = !value;
                btnAceptar.Visible = !value;
            }
        }
        #endregion
        public CapturaFotoClientes()
        {
            InitializeComponentManual();
            this.Load += (s, e) => VistaCargando?.Invoke(this, EventArgs.Empty);
            this.FormClosing += (s, e) => VistaCerrando?.Invoke(this, EventArgs.Empty);
        }

        private void InitializeComponentManual()
        {
            this.Text = "Tomar foto del Cliente";
            this.Size = new Size(420, 480);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            picPreview = new PictureBox
            {
                Location = new Point(10, 10),
                Size = new Size(384, 288),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.Black
            };

            cmbCamaras = new ComboBox
            {
                Location = new Point(10, 308),
                Size = new Size(384, 24),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbCamaras.SelectedIndexChanged += (s, e) =>
                CamaraCambiada?.Invoke(this, cmbCamaras.SelectedIndex);

            btnCapturar = new Button
            {
                Text = "Capturar",
                Location = new Point(10, 345),
                Size = new Size(180, 35)
            };
            btnCapturar.Click += (s, e) => CapturarClick?.Invoke(this, EventArgs.Empty);

            btnReintentar = new Button
            {
                Text = "Reintentar",
                Location = new Point(10, 345),
                Size = new Size(180, 35),
                Visible = false
            };
            btnReintentar.Click += (s, e) => ReintentarClick?.Invoke(this, EventArgs.Empty);

            btnAceptar = new Button
            {
                Text = "Aceptar",
                Location = new Point(214, 345),
                Size = new Size(180, 35),
                Visible = false
            };
            btnAceptar.Click += (s, e) => AceptarClick?.Invoke(this, EventArgs.Empty);

            btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(10, 390),
                Size = new Size(384, 30)
            };
            btnCancelar.Click += (s, e) => CancelarClick?.Invoke(this, EventArgs.Empty);

            this.Controls.Add(picPreview);
            this.Controls.Add(cmbCamaras);
            this.Controls.Add(btnCapturar);
            this.Controls.Add(btnReintentar);
            this.Controls.Add(btnAceptar);
            this.Controls.Add(btnCancelar);
        }

        public void MostrarListaCamaras(string[] nombresCamaras)
        {
            cmbCamaras.Items.Clear();
            cmbCamaras.Items.AddRange(nombresCamaras);
            if (nombresCamaras.Length > 0)
                cmbCamaras.SelectedIndex = 0;
        }

        public void MostrarFramePreview(Bitmap frame)
        {
            if (this.IsDisposed || !this.IsHandleCreated)
            {
                frame?.Dispose();
                return;
            }

            try
            {
                var anterior = picPreview.Image;
                picPreview.Image = frame;
                anterior?.Dispose();
            }
            catch (ArgumentException)
            {
                frame?.Dispose();
            }
        }

        public void MostrarFotoCapturada(Bitmap foto)
        {
            if (this.IsDisposed) return;

            try
            {
                var anterior = picPreview.Image;
                picPreview.Image = (Bitmap)foto.Clone();
                anterior?.Dispose();
            }
            catch (ArgumentException)
            {

            }
        }

        public void MostrarMensaje(string mensaje, string titulo, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);
        }

        public void CerrarVista(bool exito)
        {
            this.DialogResult = exito ? DialogResult.OK : DialogResult.Cancel;
            this.Close();
        }

        public event EventHandler VistaCargando;
        public event EventHandler<int> CamaraCambiada;
        public event EventHandler CapturarClick;
        public event EventHandler ReintentarClick;
        public event EventHandler AceptarClick;
        public event EventHandler CancelarClick;
        public event EventHandler VistaCerrando;
    }
}
