using Logica;
using Presentacion.View.Interfaces;
using System;
using System.Windows.Forms;

namespace Presentacion.View.Forms
{
    public partial class DatosConsultaDeuda : Form, IDatosConsultaDeudaView
    {
        #region Propiedades

        public string LabelCedula
        {
            set
            {
                if (lblCedulaMostrar.InvokeRequired)
                    lblCedulaMostrar.Invoke(new Action(() => lblCedulaMostrar.Text = value));
                else
                    lblCedulaMostrar.Text = value;
            }
        }

        public string LabelNombre
        {
            set
            {
                if (lblNombreMostrar.InvokeRequired)
                    lblNombreMostrar.Invoke(new Action(() => lblNombreMostrar.Text = value));
                else
                    lblNombreMostrar.Text = value;
            }
        }

        public string LabelApellido
        {
            set
            {
                if (lblApellidoMostrar.InvokeRequired)
                    lblApellidoMostrar.Invoke(new Action(() => lblApellidoMostrar.Text = value));
                else
                    lblApellidoMostrar.Text = value;
            }
        }

        public string LabelCreditoTotal
        {
            set
            {
                if (lblCreditoMostrar.InvokeRequired)
                    lblCreditoMostrar.Invoke(new Action(() => lblCreditoMostrar.Text = value));
                else
                    lblCreditoMostrar.Text = value;
            }
        }

        public string MesesSinPagar
        {
            set
            {
                if (lblMostrarMeses.InvokeRequired)
                    lblMostrarMeses.Invoke(new Action(() => lblMostrarMeses.Text = value));
                else
                    lblMostrarMeses.Text = value;
            }
        }

        public string FechaLimite
        {
            set
            {
                if (lblFechaLimite.InvokeRequired)
                    lblFechaLimite.Invoke(new Action(() => lblFechaLimite.Text = value));
                else
                    lblFechaLimite.Text = value;
            }
        }
        public object DataSource
        {
            set
            {
                if (dGVDatos.InvokeRequired)
                {
                    dGVDatos.Invoke(new Action(() => DataSource = value));
                    return;
                }
                dGVDatos.DataSource = value;
                dGVDatos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        #endregion

        public DatosConsultaDeuda(string cedula, int idCredito)
        {
            InitializeComponent();
            Eventos();
            this.ActiveControl = lblDatosDeuda;

            if (pnlContenedorDatos != null) pnlContenedorDatos.Visible = false;
            if (pnlCarga != null)
            {
                pnlCarga.Visible = true;
                pnlCarga.BringToFront();
            }

            _presenter = new Presenter.DatosConsultaDeudaPresenter(this, cedula, idCredito, new L_Creditos());
        }

        private Presenter.DatosConsultaDeudaPresenter _presenter;

        private void Eventos()
        {
            btnCerrar.Click += delegate { Cerrar?.Invoke(this, EventArgs.Empty); };
        }
        private void DatosConsultaDeuda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                btnCerrar.PerformClick();
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            dGVDatos.AutoGenerateColumns = false;
            if (dGVDatos.Columns.Count >= 5)
            {
                dGVDatos.Columns[0].DataPropertyName = "Cantidad";
                dGVDatos.Columns[1].DataPropertyName = "Producto";
                dGVDatos.Columns[2].DataPropertyName = "Categoria";
                dGVDatos.Columns[3].DataPropertyName = "Monto";
                dGVDatos.Columns[4].DataPropertyName = "Fecha";
                dGVDatos.Columns[3].DefaultCellStyle.Format = "N2";
                dGVDatos.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            CargarDeudas?.Invoke(this, EventArgs.Empty);

            Helpers.AnimateWindows.Start(this, 350,
                Helpers.AnimateWindows.AnimateWindowsFlags.AW_ACTIVATE |
                Helpers.AnimateWindows.AnimateWindowsFlags.AW_BLEND);
        }

        public void MostrarCargando()
        {
            if (pnlContenedorDatos != null) pnlContenedorDatos.Visible = false;
            if (pnlCarga != null)
            {
                pnlCarga.BringToFront();
                pnlCarga.Visible = true;
                pnlCarga.Update(); 
            }
        }

        public void OcultarCargando()
        {
            if (pnlCarga != null) pnlCarga.Visible = false;
            if (pnlContenedorDatos != null) pnlContenedorDatos.Visible = true;
        }

        public void CerrarVista()
        {
            this.Close();
        }

        public event EventHandler Cerrar;
        public event EventHandler CargarDeudas;
    }
}

