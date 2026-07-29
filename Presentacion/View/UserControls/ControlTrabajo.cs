using Presentacion.View.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.View.UserControls
{
    public partial class ControlTrabajo : UserControl, IControlTrabajoView
    {
        #region
        public string MesSeleccionado => KcmMes.SelectedItem?.ToString() ?? "";
        
        public int AñoSeleccionado
        {
            get => (int)KnudAño.Value;
            set => KnudAño.Value = value;
        }
       
        public string TextoBusqueda => KtxtFiltro.Text;

        public string Nombre
        {
            get => dGVDatos.CurrentRow?.Cells["Nombre"].Value?.ToString() ?? string.Empty;
            set { }
        }
        public string Apellido
        {
            get => dGVDatos.CurrentRow?.Cells["Apellido"].Value?.ToString() ?? string.Empty;
            set { }
        }
        public int Cedula
        {
            get => int.TryParse(
                       dGVDatos.CurrentRow?.Cells["Cedula"].Value?.ToString(),
                       out int val) ? val : 0;
            set { }
        }
        public string Servicio
        {
            get => dGVDatos.CurrentRow?.Cells["Servicio"].Value?.ToString() ?? string.Empty;
            set { }
        }
        public decimal Monto
        {
            get => decimal.TryParse(
                       dGVDatos.CurrentRow?.Cells["Monto"].Value?.ToString(),
                       out decimal val) ? val : 0;
            set { }
        }
        public decimal TotalBolivares
        {
            get => decimal.TryParse(
                       dGVDatos.CurrentRow?.Cells["TotalBolivares"].Value?.ToString(),
                       out decimal val) ? val : 0;
            set { }
        }
        public DateTime Fecha
        {
            get => DateTime.TryParse(
                       dGVDatos.CurrentRow?.Cells["Fecha"].Value?.ToString(),
                       out DateTime val) ? val : DateTime.MinValue;
            set { }
        }
        public string Estado
        {
            get => dGVDatos.CurrentRow?.Cells["Estado"].Value?.ToString() ?? string.Empty;
            set { }
        }
        #endregion
        public ControlTrabajo()
        {
            InitializeComponent();
            Eventos();
            EnableDoubleBuffer(dGVDatos);
        }
        public object DataSource
        {
            set => dGVDatos.DataSource = value;
        }
        private void Eventos()
        {
            KcmMes.SelectedIndexChanged += (s, e) => FiltroFechaCambiado?.Invoke(this, EventArgs.Empty);
            KnudAño.ValueChanged += (s, e) => FiltroFechaCambiado?.Invoke(this, EventArgs.Empty);
            KtxtFiltro.TextChanged += delegate { FiltrarClientes?.Invoke(this, EventArgs.Empty); };
            btnActualizar.Click += delegate { AgregarServicio?.Invoke(this, EventArgs.Empty); };
            btnDelante.Click += delegate { PaginaSiguienteClick?.Invoke(this, EventArgs.Empty); };
            btnAtras.Click += delegate { PaginaAnteriorClick?.Invoke(this, EventArgs.Empty); };

            dGVDatos.CellPainting += DGVDatos_CellPainting;
        }

        private void DGVDatos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            bool esColumnaEstado = dGVDatos.Columns[e.ColumnIndex].Name == "ClmEstado" ||
                                   dGVDatos.Columns[e.ColumnIndex].Name == "Estado" ||
                                   dGVDatos.Columns[e.ColumnIndex].DataPropertyName == "Estado";

            if (esColumnaEstado && e.Value != null)
            {
                string estado = e.Value.ToString().Trim();

                Color colorFondo;
                Color colorTexto;
                bool estaSeleccionado = (e.State & DataGridViewElementStates.Selected) != 0;

                // Paleta Armónica (Soft Modern Palette) alineada al estándar de CrediTrack
                if (estado.Equals("Pagado", StringComparison.OrdinalIgnoreCase))
                {
                    colorFondo = estaSeleccionado ? Color.FromArgb(170, 235, 180) : Color.FromArgb(205, 245, 210);
                    colorTexto = Color.DarkGreen;
                }
                else if (estado.Equals("Parcial", StringComparison.OrdinalIgnoreCase))
                {
                    colorFondo = estaSeleccionado ? Color.FromArgb(255, 220, 140) : Color.FromArgb(255, 235, 170);
                    colorTexto = Color.FromArgb(133, 100, 4);
                }
                else if (estado.Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
                {
                    colorFondo = estaSeleccionado ? Color.FromArgb(255, 190, 190) : Color.FromArgb(255, 215, 215);
                    colorTexto = Color.DarkRed;
                }
                else if (estado.Equals("Vencido", StringComparison.OrdinalIgnoreCase))
                {
                    // Tono borgoña/vino para alertas de vencimiento
                    colorFondo = estaSeleccionado ? Color.FromArgb(240, 180, 185) : Color.FromArgb(248, 215, 218);
                    colorTexto = Color.FromArgb(114, 28, 36);
                }
                else // Estado por defecto
                {
                    colorFondo = estaSeleccionado ? Color.FromArgb(200, 200, 205) : Color.FromArgb(225, 225, 230);
                    colorTexto = Color.FromArgb(39, 39, 42);
                }

                // 1. Fondo nativo de la celda (preserva el resalte azul/gris de la fila)
                e.PaintBackground(e.CellBounds, true);

                // 2. Margenes y cálculo del área de la pastilla
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

                // 3. Dibujado de la cápsula y texto
                using (GraphicsPath path = ObtenerRutaRedondeada(rectBadge, radioCurvatura))
                using (SolidBrush brushFondo = new SolidBrush(colorFondo))
                using (SolidBrush brushTexto = new SolidBrush(colorTexto))
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    // Rellenar cápsula
                    e.Graphics.FillPath(brushFondo, path);

                    // Texto en negrita
                    using (Font fontBold = new Font(e.CellStyle.Font, FontStyle.Bold))
                    {
                        e.Graphics.DrawString(estado, fontBold, brushTexto, rectBadge, sf);
                    }
                }

                e.Handled = true; // Omitir dibujado básico por defecto
            }
        }

        // 🔹 Método auxiliar para crear las esquinas redondeadas estilo cápsula
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

        private static readonly string[] NombresMeses =
        {
            "Enero","Febrero","Marzo","Abril","Mayo","Junio",
            "Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre"
        };
        public void MostrarMensaje(string mensaje, bool isError = false)
        {
            MessageBox.Show(mensaje, "CrediTrack - Control de Trabajo",
                MessageBoxButtons.OK, isError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }
        private static void EnableDoubleBuffer(Control control) =>
            typeof(Control)
                .GetProperty("DoubleBuffered",
                    BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(control, true);

        public event EventHandler PaginaSiguienteClick;
        public event EventHandler PaginaAnteriorClick;
        public event EventHandler FiltrarClientes;
        public event EventHandler FiltroFechaCambiado;
        public event EventHandler AgregarServicio;
        public event EventHandler CargarServicios;
    }
}
