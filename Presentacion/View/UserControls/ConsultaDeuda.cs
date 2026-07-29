using Presentacion.View.Interfaces;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion.View.UserControls
{
    public partial class ConsultaDeuda : UserControl, IConsultaDeudaView
    {

        public int IdCredito
        {
            get
            {
                if (dGVDatos.CurrentRow == null) return 0;
                var rowView = dGVDatos.CurrentRow.DataBoundItem as System.Data.DataRowView;
                if (rowView == null) return 0;
                var val = rowView.Row["IdCredito"];
                return val != null && val != DBNull.Value ? Convert.ToInt32(val) : 0;
            }
        }

        #region

        public string Nombre
        {
            get => dGVDatos.CurrentRow?.Cells["Nombre"].Value?.ToString() ?? string.Empty;
        }

        public string Apellido
        {
            get => dGVDatos.CurrentRow?.Cells["Apellido"].Value?.ToString() ?? string.Empty;
        }

        public string Cedula
        {
            get
            {
                if (dGVDatos.SelectedRows.Count > 0)
                {
                    var fila = dGVDatos.SelectedRows[0];
                    if (fila.Cells["Cedula"] != null && fila.Cells["Cedula"].Value != null)
                    {
                        return fila.Cells["Cedula"].Value.ToString().Trim();
                    }
                }

                if (dGVDatos.CurrentRow != null)
                {
                    if (dGVDatos.CurrentRow.Cells["Cedula"] != null && dGVDatos.CurrentRow.Cells["Cedula"].Value != null)
                    {
                        return dGVDatos.CurrentRow.Cells["Cedula"].Value.ToString().Trim();
                    }
                }

                return string.Empty;
            }
        }
        public string Telefono
        {
            get
            {
                if (dGVDatos.CurrentRow != null && dGVDatos.Columns.Contains("Telefono"))
                {
                    return dGVDatos.CurrentRow.Cells["Telefono"].Value?.ToString().Trim() ?? string.Empty;
                }
                return string.Empty;
            }
        }

        public decimal Monto
        {
            get => decimal.TryParse(
                       dGVDatos.CurrentRow?.Cells["Monto"].Value?.ToString(),
                       out decimal val) ? val : 0;
        }

        public DateTime Fecha
        {
            get => DateTime.TryParse(
                dGVDatos.CurrentRow?.Cells["Fecha"].Value?.ToString(), out DateTime val) ? val : DateTime.MinValue;
        }

        public DateTime FechaLimite
        {
            get => DateTime.TryParse(
                dGVDatos.CurrentRow?.Cells["FechaLimite"].Value?.ToString(), out DateTime val) ? val : DateTime.MinValue;
        }

        public string TextoBusqueda => txtFiltrarClientes.Text.Trim();

        public string CriterioOrden => KcmbFiltro.SelectedItem?.ToString() ?? "Mayor deuda";

        public object DataSource { set => dGVDatos.DataSource = value; }

        public int TotalClientes { set => lblCantidadClientes.Text = $"Total Clientes: {value}"; }

        public decimal CreditoTotal { set => lblCantidadCredito.Text = $"Crédito Total: {value:N2} $"; }

        public int TotalProductos { set => lblCantidadProductos.Text = $"Productos Prestados: {value}"; }

        #endregion
        public ConsultaDeuda()
        {
            InitializeComponent();
            Eventos();

            EnableDoubleBuffer(tLPlbl);
            EnableDoubleBuffer(dGVDatos);
        }

        private void Eventos()
        {
            txtFiltrarClientes.TextChanged += delegate { BuscarDeuda?.Invoke(this, EventArgs.Empty); };
            KcmbFiltro.SelectedIndexChanged += delegate { BuscarDeuda?.Invoke(this, EventArgs.Empty); };


            btnBuscar.Click += delegate { VerDetalleCliente?.Invoke(this, EventArgs.Empty); };

            btnDelante.Click += delegate { PaginaSiguienteClick?.Invoke(this, EventArgs.Empty); };
            btnAtras.Click += delegate { PaginaAnteriorClick?.Invoke(this, EventArgs.Empty); };
            dGVDatos.CellClick += DGVDatos_CellClick;
            dGVDatos.CellPainting += DGVDatos_CellPainting;
        }
        private void DGVDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validar que no sea el encabezado de la columna (-1) y que sea la columna del botón
            if (e.RowIndex >= 0 && dGVDatos.Columns[e.ColumnIndex].Name == "BtnWhatsApp")
            {
                EnviarWhatsAppClick?.Invoke(this, EventArgs.Empty);
            }
        }

        private void DGVDatos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Validar que sea la columna de WhatsApp y no el encabezado
            if (e.RowIndex >= 0 && dGVDatos.Columns[e.ColumnIndex].Name == "BtnWhatsApp")
            {
                // 1. Pintar únicamente el fondo de la celda base (limpia cualquier residuo)
                e.PaintBackground(e.CellBounds, true);

                // 2. Definir dimensiones del botón dentro de la celda
                int paddingX = 8;
                int paddingY = 4;

                Rectangle rectBoton = new Rectangle(
                    e.CellBounds.X + paddingX,
                    e.CellBounds.Y + paddingY,
                    e.CellBounds.Width - (paddingX * 2),
                    e.CellBounds.Height - (paddingY * 2)
                );

                // Evitar rectángulos inválidos si la celda es muy pequeña
                if (rectBoton.Width <= 0 || rectBoton.Height <= 0) return;

                // 3. Colores oficiales de WhatsApp
                Color colorFondoBoton = Color.FromArgb(37, 211, 102);
                Color colorTexto = Color.White; // Texto blanco resalta mucho mejor sobre el verde

                // Efecto visual cuando la fila está seleccionada
                if ((e.State & DataGridViewElementStates.Selected) != 0)
                {
                    colorFondoBoton = Color.FromArgb(18, 140, 126);
                }

                // 4. Radio proporcional a la altura para lograr el efecto cápsula/pastilla perfecto
                int radioCurvatura = rectBoton.Height / 2;

                using (GraphicsPath path = ObtenerRutaRedondeada(rectBoton, radioCurvatura))
                using (SolidBrush brushFondo = new SolidBrush(colorFondoBoton))
                using (SolidBrush brushTexto = new SolidBrush(colorTexto))
                {
                    // Calidad de renderizado alta para curvas suaves
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    // Dibujar el cuerpo redondeado del botón
                    e.Graphics.FillPath(brushFondo, path);

                    // 5. Dibujar Ícono + Texto centrados
                    Image imgWhatsApp = Properties.Resources.ic_whatsapp;

                    int imgWidth = 16;
                    int imgHeight = 16;
                    int espaciado = 6;
                    string texto = "Notificar";

                    Size tamañoTexto = TextRenderer.MeasureText(texto, e.CellStyle.Font);

                    int anchoTotalContenido = imgWidth + espaciado + tamañoTexto.Width;
                    int inicioX = rectBoton.Left + (rectBoton.Width - anchoTotalContenido) / 2;
                    int imgY = rectBoton.Top + (rectBoton.Height - imgHeight) / 2;

                    if (imgWhatsApp != null)
                    {
                        e.Graphics.DrawImage(imgWhatsApp, new Rectangle(inicioX, imgY, imgWidth, imgHeight));
                    }

                    Rectangle rectTexto = new Rectangle(
                        inicioX + imgWidth + espaciado,
                        rectBoton.Top,
                        tamañoTexto.Width,
                        rectBoton.Height
                    );

                    TextRenderer.DrawText(
                        e.Graphics,
                        texto,
                        e.CellStyle.Font,
                        rectTexto,
                        colorTexto,
                        TextFormatFlags.VerticalCenter | TextFormatFlags.Left
                    );
                }

                e.Handled = true; // Notificar a WinForms que omitimos el pintado estándar
            }
        }

        // 🔹 Método auxiliar para bordes redondeados
        private GraphicsPath ObtenerRutaRedondeada(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F6)
            {
                btnBuscar.PerformClick(); 
                return true; 
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void ActualizarPaginacionClientes(int paginaActual, int totalPaginas)
        {
            lblPaginas.Text = paginaActual.ToString() + " - " + totalPaginas.ToString();

            btnAtras.Enabled = paginaActual > 1;
            btnDelante.Enabled = paginaActual < totalPaginas;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dGVDatos.AutoGenerateColumns = false;

            if (dGVDatos.Columns.Count >= 5)
            {
                dGVDatos.Columns[0].Name = "Nombre";
                dGVDatos.Columns[0].DataPropertyName = "Nombre";

                dGVDatos.Columns[1].Name = "Apellido";
                dGVDatos.Columns[1].DataPropertyName = "Apellido";

                dGVDatos.Columns[2].Name = "Cedula";
                dGVDatos.Columns[2].DataPropertyName = "Cedula";

                dGVDatos.Columns[3].Name = "Monto";
                dGVDatos.Columns[3].DataPropertyName = "Monto";
                dGVDatos.Columns[3].DefaultCellStyle.Format = "N2";

                dGVDatos.Columns[4].Name = "Fecha";
                dGVDatos.Columns[4].DataPropertyName = "Fecha";
                dGVDatos.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";

                dGVDatos.Columns[5].Name = "FechaLimite";
                dGVDatos.Columns[5].DataPropertyName = "FechaLimite";
                dGVDatos.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (!dGVDatos.Columns.Contains("Telefono"))
            {
                dGVDatos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Telefono",
                    DataPropertyName = "Telefono", // Debe coincidir con el nombre de la columna en tu DataTable
                    Visible = false // Ponlo en true si quieres que el usuario lo vea
                });
            }

            // Agregar la columna del botón de WhatsApp
            if (!dGVDatos.Columns.Contains("BtnWhatsApp"))
            {
                var colBtn = new DataGridViewTextBoxColumn
                {
                    Name = "BtnWhatsApp",
                    HeaderText = "WhatsApp",
                    ReadOnly = true
                };

                dGVDatos.Columns.Add(colBtn);
            }

            if (!dGVDatos.Columns.Contains("IdCredito"))
            {
                dGVDatos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "IdCredito",
                    DataPropertyName = "IdCredito",
                    Visible = false
                });
            }

            if (KcmbFiltro.Items.Count == 0)
            {
                KcmbFiltro.Items.AddRange(new object[]
                {
                    "Mayor deuda",
                    "Menor deuda",
                    "Mayor antigüedad",
                    "Menor antigüedad"
                });
                KcmbFiltro.SelectedIndex = 0;
            }

            CargarDeudas?.Invoke(this, EventArgs.Empty);
        }

        private static readonly string[] NombresMeses =
{
    "Enero","Febrero","Marzo","Abril","Mayo","Junio",
    "Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre"
};

        public void MostrarMensaje(string m, bool e)
        {
            MessageBox.Show(m, "Sistema", MessageBoxButtons.OK, e ?
                MessageBoxIcon.Error : MessageBoxIcon.Information);
        }

        private void EnableDoubleBuffer(Control control)
        {
            typeof(Control).GetProperty("DoubleBuffered",
                                        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(control, true);
        }

        public event EventHandler PaginaSiguienteClick;
        public event EventHandler PaginaAnteriorClick;
        public event EventHandler BuscarDeuda;
        public event EventHandler VerDetalleCliente;
        public event EventHandler EnviarWhatsAppClick;
        public event EventHandler CargarDeudas;
    }
}
