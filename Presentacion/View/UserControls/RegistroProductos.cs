using Entidades;
using Presentacion.View.Interfaces;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion.View.UserControls
{
    public partial class RegistroProductos : UserControl, IRegistroProductoView
    {
        #region

        public string TipoOperacion => KcmbTipo.SelectedItem?.ToString() ?? "";
        public string TextoBusqueda => KtxtFiltro.Text;
        public string Nombre
        {
            get => dGVDatos.CurrentRow?.Cells["Nombre"].Value?.ToString() ?? string.Empty;
            set {  }
        }

        public string Categoria
        {
            get => dGVDatos.CurrentRow?.Cells["Categoria"].Value?.ToString() ?? string.Empty;
            set { }
        }

        public int Precio
        {
            get => int.TryParse(
                       dGVDatos.CurrentRow?.Cells["Precio"].Value?.ToString(),
                       out int val) ? val : 0;
            set { }
        }

        public int Stock
        {
            get => int.TryParse(
                       dGVDatos.CurrentRow?.Cells["Stock"].Value?.ToString(),
                       out int val) ? val : 0;
            set { }
        }
        public string Estado
        {
            get => dGVDatos.CurrentRow?.Cells["Estado"].Value?.ToString() ?? string.Empty;
            set { }
        }
        #endregion
        public RegistroProductos()
        {
            InitializeComponent();
            Eventos();
            dGVDatos.AutoGenerateColumns = false;

            EnableDoubleBuffer(dGVDatos);
            KcmbTipo.SelectedIndex = 0;
        }

        public Productos ProductoSeleccionado
        {
            get
            {
                if (dGVDatos.CurrentRow == null) return null;

                var fila = dGVDatos.CurrentRow.DataBoundItem as DataRowView;
                if (fila == null) return null;

                return new Productos
                {
                    Codigo = fila["Codigo"]?.ToString() ?? "",
                    Nombre = fila["Nombre"]?.ToString() ?? "",
                    NombreCategoria = fila["NombreCategoria"]?.ToString() ?? "",
                    Precio = Convert.ToDecimal(fila["Precio"]),
                    StockActual = Convert.ToInt32(fila["StockActual"]),
                    Estado = fila["Estado"]?.ToString() ?? ""
                };
            }
        }
        public decimal PrecioPrecio
        {
            get => decimal.TryParse(
                       dGVDatos.CurrentRow?.Cells["Precio"].Value?.ToString(),
                       out decimal val) ? val : 0;
            set { }
        }

        public object DataSource
        {
            set
            {
                dGVDatos.SuspendLayout();
                try
                {
                    dGVDatos.DataSource = value;
                }
                finally
                {
                    dGVDatos.ResumeLayout();
                }
            }
        }

        public void ActualizarPaginacionClientes(int paginaActual, int totalPaginas)
        {
            lblPaginas.Text = paginaActual.ToString() + " - " + totalPaginas.ToString();

            btnAtras.Enabled = paginaActual > 1;
            btnDelante.Enabled = paginaActual < totalPaginas;
        }

        private void Eventos()
        {
            KcmbTipo.SelectedIndexChanged += (s, e) => FiltroFechaCambiado?.Invoke(this, EventArgs.Empty);
            KtxtFiltro.TextChanged += delegate { FiltrarProductos?.Invoke(this, EventArgs.Empty); };

            btnEditar.Click += delegate { EditarProductoClick?.Invoke(this, EventArgs.Empty); };
            btnEliminar.Click += delegate { EliminarProductoClick?.Invoke(this, EventArgs.Empty); };
            btnDelante.Click += delegate { PaginaSiguienteClick?.Invoke(this, EventArgs.Empty); };
            btnAtras.Click += delegate { PaginaAnteriorClick?.Invoke(this, EventArgs.Empty); };
            btnAgregar.Click += delegate { AgregarProductoClick?.Invoke(this, EventArgs.Empty); };

            dGVDatos.CellPainting += DGVDatos_CellPainting;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                btnAgregar.PerformClick(); 
                return true; 
            }

            if (keyData == Keys.F6)
            {
                btnEditar.PerformClick();
                return true;
            }

            if (keyData == Keys.Delete && !(this.ActiveControl is TextBox))
            {
                btnEliminar.PerformClick();
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

                // Asignación de paleta soft/moderna acorde al diseño general
                if (estado.Equals("Activo", StringComparison.OrdinalIgnoreCase))
                {
                    colorFondo = estaSeleccionado ? Color.FromArgb(170, 235, 180) : Color.FromArgb(205, 245, 210);
                    colorTexto = Color.DarkGreen;
                }
                else if (estado.Equals("Stock bajo", StringComparison.OrdinalIgnoreCase))
                {
                    colorFondo = estaSeleccionado ? Color.FromArgb(255, 220, 140) : Color.FromArgb(255, 235, 170);
                    colorTexto = Color.FromArgb(133, 100, 4);
                }
                else if (estado.Equals("Agotado", StringComparison.OrdinalIgnoreCase))
                {
                    colorFondo = estaSeleccionado ? Color.FromArgb(255, 190, 190) : Color.FromArgb(255, 215, 215);
                    colorTexto = Color.DarkRed;
                }
                else // Inactivo
                {
                    colorFondo = estaSeleccionado ? Color.FromArgb(200, 200, 205) : Color.FromArgb(225, 225, 230);
                    colorTexto = Color.FromArgb(39, 39, 42);
                }

                // 1. Pintar el fondo nativo de la celda (mantiene la selección azul/gris de la fila)
                e.PaintBackground(e.CellBounds, true);

                // 2. Calcular dimensiones de la pastilla
                int paddingX = 8;
                int paddingY = 4;

                Rectangle rectBadge = new Rectangle(
                    e.CellBounds.X + paddingX,
                    e.CellBounds.Y + paddingY,
                    e.CellBounds.Width - (paddingX * 2),
                    e.CellBounds.Height - (paddingY * 2)
                );

                // Evitar errores de dibujo si la celda es muy diminuta
                if (rectBadge.Width <= 0 || rectBadge.Height <= 0) return;

                // 3. Radio para la curvatura estilo cápsula
                int radioCurvatura = rectBadge.Height / 2;

                // 4. Dibujar la cápsula y el texto
                using (GraphicsPath path = ObtenerRutaRedondeada(rectBadge, radioCurvatura))
                using (SolidBrush brushFondo = new SolidBrush(colorFondo))
                using (SolidBrush brushTexto = new SolidBrush(colorTexto))
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    // Rellenar la cápsula
                    e.Graphics.FillPath(brushFondo, path);

                    // Texto en negrita para máxima nitidez
                    using (Font fontBold = new Font(e.CellStyle.Font, FontStyle.Bold))
                    {
                        e.Graphics.DrawString(estado, fontBold, brushTexto, rectBadge, sf);
                    }
                }

                e.Handled = true; // Indicar a WinForms que omitimos el dibujado por defecto
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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dGVDatos.AutoGenerateColumns = false;
            if (dGVDatos.Columns.Count >= 6)
            {
                dGVDatos.Columns[0].DataPropertyName = "Nombre";
                dGVDatos.Columns[1].DataPropertyName = "NombreCategoria";
                dGVDatos.Columns[2].DataPropertyName = "Precio";
                dGVDatos.Columns[3].DataPropertyName = "PrecioBs";
                dGVDatos.Columns[4].DataPropertyName = "StockActual";
                dGVDatos.Columns[5].DataPropertyName = "EstadoVisual";
            }
            CargarProductos?.Invoke(this, EventArgs.Empty);
        }


        public void MostrarMensaje(string mensaje, bool esError)
        {
            MessageBox.Show(mensaje, "Datos cargados?", MessageBoxButtons.OK,
                esError ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }

        private void EnableDoubleBuffer(Control control)
        {
            typeof(Control).GetProperty("DoubleBuffered",
                                        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(control, true);
        }

        public event EventHandler PaginaSiguienteClick;
        public event EventHandler PaginaAnteriorClick;
        public event EventHandler FiltroFechaCambiado;
        public event EventHandler EliminarProductoClick;
        public event EventHandler EditarProductoClick;
        public event EventHandler AgregarProductoClick;
        public event EventHandler CargarProductos;
        public event EventHandler FiltrarProductos;
    }
}