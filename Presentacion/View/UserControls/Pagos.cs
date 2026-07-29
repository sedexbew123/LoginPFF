using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace Presentacion.View.UserControls
{
    public partial class Pagos : UserControl, Interfaces.IPagosView
    {
        #region IPagosView – Propiedades de filtro

        public string MesSeleccionado => KcmMes.SelectedItem?.ToString() ?? "";

        public int AñoSeleccionado
        {
            get => (int)KnudAño.Value;
            set => KnudAño.Value = value;
        }

        public string TextoBusqueda => KtxtFiltro.Text;

        #endregion

        #region IPagosView – Fila seleccionada (columnas visibles)

        public string Nombre
        {
            get => GetDataTableValue<string>("Nombre");
            set { }
        }

        public string Apellido
        {
            get => GetDataTableValue<string>("Apellido");
            set { }
        }

        public int Cedula
        {
            get => GetDataTableValue<int>("Cedula");
            set { }
        }

        public decimal Monto
        {
            get => GetDataTableValue<decimal>("SaldoPendiente");
            set { }
        }

        public DateTime FechaPago
        {
            get => GetDataTableValue<DateTime>("FechaPago");
            set { }
        }

        public string Estado
        {
            get => GetDataTableValue<string>("Estado");
            set { }
        }

        #endregion

        #region IPagosView – Columnas ocultas del DataTable

        public int IdCredito
        {
            get => dGVDatos.CurrentRow == null ? 0 : GetDataTableValue<int>("IdCredito");
        }

        public int IdCliente
        {
            get => dGVDatos.CurrentRow == null ? 0 : GetDataTableValue<int>("IdCliente");
        }

        public decimal SaldoPendiente
        {
            get => dGVDatos.CurrentRow == null ? 0m : GetDataTableValue<decimal>("SaldoPendiente");
        }
        public string Telefono
        {
            get
            {
                if (dGVDatos.CurrentRow == null) return string.Empty;

                // Intentar leer de la celda de la columna "Telefono"
                if (dGVDatos.Columns.Contains("Telefono"))
                {
                    var val = dGVDatos.CurrentRow.Cells["Telefono"].Value?.ToString().Trim();
                    if (!string.IsNullOrEmpty(val)) return val;
                }

                // Fallback al DataRowView
                return GetDataTableValue<string>("Telefono") ?? string.Empty;
            }
        }

        #endregion

        public object DataSource
        {
            set => dGVDatos.DataSource = value;
        }

        public Pagos()
        {
            InitializeComponent();
            SuscribirEventos();
            EnableDoubleBuffer(dGVDatos);
        }

        private void SuscribirEventos()
        {
            KcmMes.SelectedIndexChanged += (s, e) => FiltroFechaCambiado?.Invoke(this, EventArgs.Empty);
            KnudAño.ValueChanged += (s, e) => FiltroFechaCambiado?.Invoke(this, EventArgs.Empty);
            KtxtFiltro.TextChanged += delegate { FiltrarDeudas?.Invoke(this, EventArgs.Empty); };
            btnActualizar.Click += delegate { ActualizarPago?.Invoke(this, EventArgs.Empty); };
            btnEliminar.Click += delegate { EliminarPago?.Invoke(this, EventArgs.Empty); };
            btnDelante.Click += delegate { PaginaSiguienteClick?.Invoke(this, EventArgs.Empty); };
            btnAtras.Click += delegate { PaginaAnteriorClick?.Invoke(this, EventArgs.Empty); };
            btnWhatsApp.Click += delegate { EnviarComprobanteWhatsAppClick?.Invoke(this, EventArgs.Empty); };

            dGVDatos.CellPainting += DGVDatos_CellPainting;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete && !(this.ActiveControl is TextBox))
            {
                btnEliminar.PerformClick(); 
                return true; 
            }

            if (keyData == Keys.F6)
            {
                btnActualizar.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void DGVDatos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dGVDatos.Columns[e.ColumnIndex].Name == "ClmEstado" && e.Value != null)
            {
                string estado = e.Value.ToString().Trim();

                Color colorFondo;
                Color colorTexto;
                bool estaSeleccionado = (e.State & DataGridViewElementStates.Selected) != 0;

                // Paleta Armónica (Soft Modern Palette) alineada a Productos
                if (estado.Equals("Pagado", StringComparison.OrdinalIgnoreCase) || estado.Equals("Solvente", StringComparison.OrdinalIgnoreCase))
                {
                    colorFondo = estaSeleccionado ? Color.FromArgb(170, 235, 180) : Color.FromArgb(205, 245, 210);
                    colorTexto = Color.DarkGreen;
                }
                else if (estado.Equals("Parcial", StringComparison.OrdinalIgnoreCase))
                {
                    colorFondo = estaSeleccionado ? Color.FromArgb(255, 220, 140) : Color.FromArgb(255, 235, 170);
                    colorTexto = Color.FromArgb(133, 100, 4);
                }
                else if (estado.Equals("Debe", StringComparison.OrdinalIgnoreCase) || estado.Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
                {
                    colorFondo = estaSeleccionado ? Color.FromArgb(255, 190, 190) : Color.FromArgb(255, 215, 215);
                    colorTexto = Color.DarkRed;
                }
                else if (estado.Equals("Vencido", StringComparison.OrdinalIgnoreCase) || estado.Equals("Vencida", StringComparison.OrdinalIgnoreCase))
                {
                    // Tono rojo borgoña/vino para alertar estado crítico
                    colorFondo = estaSeleccionado ? Color.FromArgb(240, 180, 185) : Color.FromArgb(248, 215, 218);
                    colorTexto = Color.FromArgb(114, 28, 36);
                }
                else // Estado desconocido o inactivo por defecto
                {
                    colorFondo = estaSeleccionado ? Color.FromArgb(200, 200, 205) : Color.FromArgb(225, 225, 230);
                    colorTexto = Color.FromArgb(39, 39, 42);
                }

                // 1. Limpiar el fondo base respetando la selección nativa del DataGridView
                e.PaintBackground(e.CellBounds, true);

                // 2. Definir margenes y geometría de la cápsula
                int paddingX = 8;
                int paddingY = 4;

                Rectangle rectBadge = new Rectangle(
                    e.CellBounds.X + paddingX,
                    e.CellBounds.Y + paddingY,
                    e.CellBounds.Width - (paddingX * 2),
                    e.CellBounds.Height - (paddingY * 2)
                );

                if (rectBadge.Width <= 0 || rectBadge.Height <= 0) return;

                int radioCurvatura = rectBadge.Height / 2;

                // 3. Dibujar la cápsula suave y el texto centrado
                using (GraphicsPath path = ObtenerRutaRedondeada(rectBadge, radioCurvatura))
                using (SolidBrush brushFondo = new SolidBrush(colorFondo))
                using (SolidBrush brushTexto = new SolidBrush(colorTexto))
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    // Rellenar la pastilla redondeada
                    e.Graphics.FillPath(brushFondo, path);

                    // Texto resaltado en negrita con la tipografía oficial del grid
                    using (Font fontBold = new Font(e.CellStyle.Font, FontStyle.Bold))
                    {
                        e.Graphics.DrawString(estado, fontBold, brushTexto, rectBadge, sf);
                    }
                }

                e.Handled = true; // Omite el pintado predeterminado de WinForms
            }
        }

        // 🔹 Método auxiliar para crear las esquinas redondeadas
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

        public void ActualizarPaginacionClientes(int paginaActual, int totalPaginas)
        {
            lblPaginas.Text = $"{paginaActual} - {totalPaginas}";
            btnAtras.Enabled = paginaActual > 1;
            btnDelante.Enabled = paginaActual < totalPaginas;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dGVDatos.AutoGenerateColumns = false;

            MapearColumna("Nombre", "Nombre");
            MapearColumna("Apellido", "Apellido");
            MapearColumna("Cédula", "Cedula");
            MapearColumna("Monto", "Monto");
            MapearColumna("Fecha", "FechaPago");
            MapearColumna("Estado", "Estado");
            MapearColumna("Total Bs", "MontoBs");

            if (!dGVDatos.Columns.Contains("Telefono"))
            {
                dGVDatos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Telefono",
                    DataPropertyName = "Telefono",
                    Visible = false
                });
            }

            if (KcmMes.Items.Count == 0)
                KcmMes.Items.AddRange(NombresMeses);

            KcmMes.SelectedIndex = DateTime.Now.Month - 1;
            KnudAño.Value = DateTime.Now.Year;

            CargarDeudas?.Invoke(this, EventArgs.Empty);
        }

        private static readonly string[] NombresMeses =
        {
            "Enero","Febrero","Marzo","Abril","Mayo","Junio",
            "Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre"
        };


        private void MapearColumna(string headerText, string dataPropertyName)
        {
            foreach (DataGridViewColumn col in dGVDatos.Columns)
            {
                if (col.HeaderText == headerText)
                {
                    col.DataPropertyName = dataPropertyName;
                    return;
                }
            }

            System.Diagnostics.Debug.WriteLine(
                $"[Pagos UC] No se encontró ninguna columna con encabezado '{headerText}'. " +
                "Revisa el DataGridView en el diseñador (Edit Columns).");
        }

        private T GetDataTableValue<T>(string columnName)
        {
            try
            {
                if (dGVDatos.CurrentRow == null) return default;

                int idx = dGVDatos.CurrentRow.Index;
                DataTable dt = null;

                if (dGVDatos.DataSource is DataTable table) dt = table;
                else if (dGVDatos.DataSource is DataView view) dt = view.Table;

                if (dt != null
                    && idx >= 0 && idx < dt.Rows.Count
                    && dt.Columns.Contains(columnName))
                {
                    object raw = dt.Rows[idx][columnName];
                    if (raw != DBNull.Value)
                        return (T)Convert.ChangeType(raw, typeof(T));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    $"[Pagos UC] GetDataTableValue({columnName}): {ex.Message}");
            }
            return default;
        }
        public void MostrarMensaje(string mensaje, bool esError)
        {
            MessageBox.Show(mensaje, "Sistema CrediTrack", MessageBoxButtons.OK,
                esError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }
        private static void EnableDoubleBuffer(Control control) =>
            typeof(Control)
                .GetProperty("DoubleBuffered",
                    BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(control, true);

        public event EventHandler PaginaSiguienteClick;
        public event EventHandler PaginaAnteriorClick;
        public event EventHandler FiltrarDeudas;
        public event EventHandler FiltroFechaCambiado;
        public event EventHandler EnviarComprobanteWhatsAppClick;
        public event EventHandler ActualizarPago;
        public event EventHandler EliminarPago;
        public event EventHandler CargarDeudas;
    }
}