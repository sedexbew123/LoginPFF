using Entidades;
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

namespace Presentacion.View.UserControls
{
    public partial class GestionEmpleados : UserControl, IGestionEmpleadosView
    {
        #region
        public string Cedula
        {
            get => dGVDatos.CurrentRow?.Cells["Cedula"].Value?.ToString() ?? string.Empty;
            set { }
        }
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

        public string TextoBusqueda => KtxtFiltro.Text;
        #endregion
        public GestionEmpleados()
        {
            InitializeComponent();
            Eventos();

            EnableDoubleBuffer(dGVDatos);
        }

        private void Eventos()
        {
            btnEditar.Click += delegate { EditarEmpleadosClick?.Invoke(this, EventArgs.Empty); };
            btnEliminar.Click += delegate { EliminarEmpleadosClick?.Invoke(this, EventArgs.Empty); };
            KtxtFiltro.TextChanged += delegate { FiltrarEmpleados?.Invoke(this, EventArgs.Empty); };
            btnDelante.Click += delegate { PaginaSiguienteClick?.Invoke(this, EventArgs.Empty); };
            btnAtras.Click += delegate { PaginaAnteriorClick?.Invoke(this, EventArgs.Empty); };
            btnAgregar.Click += delegate { AgregarEmpleadosClick?.Invoke(this, EventArgs.Empty); };
            btnVisualizar.Click += delegate { VisualizarEmpleadosClick?.Invoke(this, EventArgs.Empty); };
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F4)
            {
                btnAgregar.PerformClick(); 
                return true; 
            }
            if (keyData == Keys.F5)
            {
                btnVisualizar.PerformClick(); 
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

        public void LlenarListadoEmpleados(List<Usuarios> empleados)
        {
            dGVDatos.DataSource = null;
            dGVDatos.AutoGenerateColumns = true;
            dGVDatos.DataSource = empleados
                .Select(e => new
                {
                    e.Cedula,
                    e.Nombre,
                    e.Apellido
                })
                .ToList();

            // Si prefieres seguir mostrando todas las columnas vía
            // binding directo a Usuarios en vez de un objeto anónimo,
            // recuerda ocultar las columnas que no quieres ver
            // (Id, Correo, Telefono, etc.) igual que se hacía antes
            // con id_cliente.
        }

        public void ActualizarPaginacionEmpleados(int paginaActual, int totalPaginas)
        {
            lblPaginas.Text = paginaActual.ToString() + " - " + totalPaginas.ToString();

            btnAtras.Enabled = paginaActual > 1;
            btnDelante.Enabled = paginaActual < totalPaginas;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dGVDatos.AutoGenerateColumns = true;

            CargarEmpleados?.Invoke(this, EventArgs.Empty);
        }

        // CORRECCIÓN: los parámetros de MessageBoxIcon estaban invertidos
        // respecto al booleano esError (mostraba ícono de "Información"
        // cuando había error, y "Error" cuando no lo había).
        public void MostrarMensaje(string mensaje, bool esError)
        {
            MessageBox.Show(
                mensaje,
                esError ? "Error" : "Datos cargados",
                MessageBoxButtons.OK,
                esError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }

        private void EnableDoubleBuffer(Control control)
        {
            typeof(Control).GetProperty("DoubleBuffered",
                                        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(control, true);
        }

        public event EventHandler PaginaSiguienteClick;
        public event EventHandler PaginaAnteriorClick;
        public event EventHandler AgregarEmpleadosClick;
        public event EventHandler VisualizarEmpleadosClick;
        public event EventHandler EliminarEmpleadosClick;
        public event EventHandler EditarEmpleadosClick;
        public event EventHandler CargarEmpleados;
        public event EventHandler FiltrarEmpleados;
    }
}