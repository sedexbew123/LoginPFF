using Presentacion.Helpers;
using Presentacion.View.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.View.Forms
{
    public partial class VisualizarEmpleados : Form, IVisualizarEmpleadoView
    {
        #region

        public string Cedula
        {
            set => lblMostrarCedula.Text = value;
        }
        public string Nombre
        {
            set => lblMostrarNombre.Text = value;
        }
        public string Apellido
        {
            set => lblMostrarApellido.Text = value;
        }
        public string Telefono
        {
            set => lblMostrarTelefono.Text = value;
        }
        public string Direccion
        {
            set => lblMostrarDireccion.Text = value;
        }
        public string Correo
        {
            set => lblMostrarCorreo.Text = value;
        }

        public byte[] FotoEmpleado
        {
            set
            {
                PicImagen.Image?.Dispose();

                // CASO 1: Si no hay foto o viene vacía (Opcional)
                if (value == null || value.Length == 0)
                {
                    PicImagen.Image = null;

                    // ACTIVAMOS EL BORDE para delimitar el cuadro vacío
                    PicImagen.BorderStyle = BorderStyle.FixedSingle;
                    return;
                }

                try
                {
                    using (var ms = new System.IO.MemoryStream(value))
                    {
                        // DESACTIVAMOS EL BORDE para que la foto no se corte ni se vea estirada
                        PicImagen.BorderStyle = BorderStyle.None;

                        PicImagen.SizeMode = PictureBoxSizeMode.Zoom;
                        PicImagen.Image = Image.FromStream(ms);
                    }
                }
                catch
                {
                    PicImagen.Image = null;
                    // Si hay error, regresamos al estado con borde
                    PicImagen.BorderStyle = BorderStyle.FixedSingle;
                }
            }
        }
        #endregion
        public VisualizarEmpleados()
        {
            InitializeComponent();
            Eventos();
        }

        private void Eventos()
        {

            this.Load += (s, e) => VistaCargando?.Invoke(this, EventArgs.Empty);
            btnCerrar.Click += (s, e) => Volver?.Invoke(this, EventArgs.Empty);
        }
        private void VisualizarEmpleados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                btnCerrar.PerformClick();
            }
        }

        public void MostrarCargando()
        {
            pnlContenidoDatos.Visible = false;

            if (pnlCarga != null)
            {
                pnlCarga.BringToFront();
                pnlCarga.Visible = true;

                pnlCarga.Update();
            }
        }
        public void OcultarCargando()
        {
            if (pnlCarga != null)
            {
                pnlCarga.Visible = false;
            }

            
            pnlContenidoDatos.Visible = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helpers.AnimateWindows.Start(this, 300, Helpers.AnimateWindows.AnimateWindowsFlags.AW_ACTIVATE | AnimateWindows.AnimateWindowsFlags.AW_BLEND);
        }

        public void CerrarVista()
        {
            this.Close();
        }

        public event EventHandler VistaCargando;
        public event EventHandler Volver;
    }
}
