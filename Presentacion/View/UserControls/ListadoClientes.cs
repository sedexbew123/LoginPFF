using Entidades;
using Presentacion.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.View.UserControls
{
    public partial class ListadoClientes : UserControl, IListadoClientesView
    {
        #region

        public int Cedula
        {
            get => int.TryParse(
                       dGVDatos.CurrentRow?.Cells["Cedula"].Value?.ToString(),
                       out int val) ? val : 0;
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


        public string TextoBusqueda => KtxtFiltrarClientes.Text;

        #endregion
        public ListadoClientes()
        {
            InitializeComponent();
            Eventos();

            EnableDoubleBuffer(dGVDatos);
        }

        public Clientes ClienteSeleccionado
        {
            get
            {
                if (dGVDatos.CurrentRow != null)
                    return (Clientes)dGVDatos.CurrentRow.DataBoundItem;
                return null;
            }
        }

        private void Eventos()
        {
            btnEditar.Click += delegate { EditarClienteClick?.Invoke(this, EventArgs.Empty); };
            btnEliminar.Click += delegate { EliminarClienteClick?.Invoke(this, EventArgs.Empty); };
            btnVisualizar.Click += delegate { VisualizarClientesClick?.Invoke(this, EventArgs.Empty); };
            KtxtFiltrarClientes.TextChanged += delegate { FiltrarClientes?.Invoke(this, EventArgs.Empty); };
            btnDelante.Click += delegate { PaginaSiguienteClick?.Invoke(this, EventArgs.Empty); };
            btnAtras.Click += delegate { PaginaAnteriorClick?.Invoke(this, EventArgs.Empty); };

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
                btnEditar.PerformClick();
                return true;
            }

            if (keyData == Keys.F5)
            {
                btnVisualizar.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void LlenarListadoClientes(List<Clientes> clientes)
        {
            dGVDatos.DataSource = clientes;

            if (dGVDatos.Columns["id_cliente"] != null)
            {
                dGVDatos.Columns["id_cliente"].Visible = false;
                dGVDatos.Columns["NombreCompletoConCedula"].Visible = false;
            }
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

            if (dGVDatos.Columns.Count >= 3)
            {
                dGVDatos.Columns[0].DataPropertyName = "Cedula";
                dGVDatos.Columns[1].DataPropertyName = "Nombres";
                dGVDatos.Columns[2].DataPropertyName = "Apellidos";
            }
            CargarClientes?.Invoke(this, EventArgs.Empty);
        }

        public void MostrarMensaje(string mensaje, bool esError)
        {
            MessageBox.Show(mensaje, "Datos", MessageBoxButtons.OK,
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
        public event EventHandler EliminarClienteClick;
        public event EventHandler EditarClienteClick;
        public event EventHandler VisualizarClientesClick;
        public event EventHandler CargarClientes;
        public event EventHandler FiltrarClientes;
    }
}
