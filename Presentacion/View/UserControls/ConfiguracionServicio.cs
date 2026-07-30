using Presentacion.View.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.View.UserControls
{
    public partial class ConfiguracionServicio : UserControl, IConfiguracionServiciosView
    {
        #region Propiedades Servicios

        public string ServicioNombre
        {
            get => txtServicio.Text;
            set => txtServicio.Text = value;
        }

        public string ServicioTipo
        {
            get => KcmbTipo.Text;
            set => KcmbTipo.Text = value;
        }

        public decimal ServicioPrecio
        {
            get => nudPrecio.Value;
            set => nudPrecio.Value = value;
        }

        public string ServicioDescripcion
        {
            get => txtDescripcionServ.Text;
            set => txtDescripcionServ.Text = value;
        }

        public object ServiciosDataSource
        {
            set => dGVServicios.DataSource = value;
        }

        public object TiposComboBoxDataSource
        {
            set => KcmbTipo.DataSource = value;
        }

        private bool _servicioEdicion;
        public bool ServicioEdicion
        {
            get => _servicioEdicion;
            set
            {
                _servicioEdicion = value;
                btnServGuardar.Text = value ? "Actualizar" : "Guardar";
            }
        }

        #endregion

        #region Propiedades Tipos

        public string TipoNombre
        {
            get => txtTipo.Text;
            set => txtTipo.Text = value;
        }

        public bool TipoEstado
        {
            get => chkActivo.Checked;
            set => chkActivo.Checked = value;
        }

        public string TipoDescripcion
        {
            get => txtDescripcionTipo.Text;
            set => txtDescripcionTipo.Text = value;
        }

        public object TiposDataSource
        {
            set => dGVTipos.DataSource = value;
        }

        private bool _tipoEdicion;
        public bool TipoEdicion
        {
            get => _tipoEdicion;
            set
            {
                _tipoEdicion = value;
                btnTipoGuardar.Text = value ? "Actualizar" : "Guardar";
            }
        }

        #endregion
        public ConfiguracionServicio()
        {
            InitializeComponent();
            Eventos();

            this.DoubleBuffered = true;
            EnableDoubleBuffer(this);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; 
                return cp;
            }
        }
        private void Eventos()
        {
            btnServGuardar.Click += (s, e) => GuardarServicio?.Invoke(this, EventArgs.Empty);
            btnServLimpiar.Click += (s, e) => LimpiarCamposServicio();
            btnServEliminar.Click += (s, e) => EliminarServicio?.Invoke(this, EventArgs.Empty);
            dGVServicios.CellClick += DGVServicios_CellClick;

            btnTipoGuardar.Click += (s, e) => GuardarTipo?.Invoke(this, EventArgs.Empty);
            btnTipoLimpiar.Click += (s, e) => LimpiarCamposTipo();
            btnTipoEliminar.Click += (s, e) => EliminarTipo?.Invoke(this, EventArgs.Empty);
            dGVTipos.CellClick += DGVTipos_CellClick;
            dGVTipos.CellPainting += DGVTipos_CellPainting;
        }
        private void DGVServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGVServicios.Rows[e.RowIndex];
                ServicioNombre = row.Cells["Nombre"].Value?.ToString();
                ServicioTipo = row.Cells["TipoNombre"].Value?.ToString();
                ServicioPrecio = Convert.ToDecimal(row.Cells["Precio"].Value);
                ServicioDescripcion = row.Cells["Descripcion"].Value?.ToString();

                SeleccionarServicio?.Invoke(this, EventArgs.Empty);
            }
        }

        private void DGVTipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGVTipos.Rows[e.RowIndex];
                TipoNombre = row.Cells["Nombre"].Value?.ToString();
                TipoEstado = Convert.ToBoolean(row.Cells["Estado"].Value);
                TipoDescripcion = row.Cells["Descripcion"].Value?.ToString();

                SeleccionarTipo?.Invoke(this, EventArgs.Empty);
            }
        }

        private void DGVTipos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // Mapear por nombre de columna o propiedad de datos "Estado"
            bool esColumnaEstado = dGVTipos.Columns[e.ColumnIndex].Name == "Estado" ||
                                   dGVTipos.Columns[e.ColumnIndex].DataPropertyName == "Estado";

            if (esColumnaEstado && e.Value != null)
            {
                bool esActivo = false;

                if (e.Value is bool boolVal)
                {
                    esActivo = boolVal;
                }
                else
                {
                    string estadoTexto = e.Value.ToString().Trim();
                    esActivo = estadoTexto.Equals("Activo", StringComparison.OrdinalIgnoreCase) ||
                               estadoTexto.Equals("True", StringComparison.OrdinalIgnoreCase);
                }

                string textoEstado = esActivo ? "Activo" : "Inactivo";
                bool estaSeleccionado = (e.State & DataGridViewElementStates.Selected) != 0;

                Color colorFondo;
                Color colorTexto;

                if (esActivo)
                {
                    colorFondo = estaSeleccionado ? Color.FromArgb(170, 235, 180) : Color.FromArgb(205, 245, 210);
                    colorTexto = Color.DarkGreen;
                }
                else
                {
                    colorFondo = estaSeleccionado ? Color.FromArgb(200, 200, 205) : Color.FromArgb(225, 225, 230);
                    colorTexto = Color.FromArgb(39, 39, 42);
                }

                // 1. Limpiar el fondo base respetando la selección nativa del DataGridView
                e.PaintBackground(e.CellBounds, true);

                // 2. Calcular dimensiones de la cápsula
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

                // 👇 Guardamos el SmoothingMode original ANTES de tocarlo
                SmoothingMode smoothingOriginal = e.Graphics.SmoothingMode;

                // 3. Dibujar la cápsula suave y el texto centrado
                using (GraphicsPath path = ObtenerRutaRedondeada(rectBadge, radioCurvatura))
                using (SolidBrush brushFondo = new SolidBrush(colorFondo))
                using (SolidBrush brushTexto = new SolidBrush(colorTexto))
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    // Rellenar la pastilla
                    e.Graphics.FillPath(brushFondo, path);

                    // Dibujar el texto en negrita
                    using (Font fontBold = new Font(e.CellStyle.Font, FontStyle.Bold))
                    {
                        e.Graphics.DrawString(textoEstado, fontBold, brushTexto, rectBadge, sf);
                    }
                }

                // 👇 Restauramos el SmoothingMode original DESPUÉS de usarlo
                e.Graphics.SmoothingMode = smoothingOriginal;

                e.Handled = true; // Omitir el dibujado nativo
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
        public void LimpiarCamposServicio()
        {
            ServicioNombre = "";
            ServicioTipo = "";
            ServicioPrecio = 0;
            ServicioDescripcion = "";
            ServicioEdicion = false;
        }

        public void LimpiarCamposTipo()
        {
            TipoNombre = "";
            TipoEstado = true;
            TipoDescripcion = "";
            TipoEdicion = false;
        }

        public void MostrarMensaje(string mensaje, bool isError = false)
        {
            MessageBox.Show(mensaje, "CrediTrack - Servicios",
                MessageBoxButtons.OK, isError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }

        public bool ConfirmarAccion(string mensaje)
        {
            return MessageBox.Show(mensaje, "Confirmación Requerida",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void EnableDoubleBuffer(Control control)
        {
            typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(control, true, null);

            foreach (Control child in control.Controls)
            {
                EnableDoubleBuffer(child);
            }
        }

        public event EventHandler GuardarServicio;
        public event EventHandler EliminarServicio;
        public event EventHandler SeleccionarServicio;

        public event EventHandler GuardarTipo;
        public event EventHandler EliminarTipo;
        public event EventHandler SeleccionarTipo;
    }
}
