using Presentacion.Helpers;
using Presentacion.View.Interfaces;
using System;
using System.Windows.Forms;

namespace Presentacion.View.Forms
{
    public partial class AdministrarPermisos : Form, IAdministrarPermisosView
    {
        #region
        public object UsuariosPermisosDataSource
        {
            set => dGVDatos.DataSource = value;
        }
        #endregion
        public DataGridViewRowCollection FilasTabla => dGVDatos.Rows;

        public AdministrarPermisos()
        {
            InitializeComponent();
            ConfigurarColumnasTabla();
            AsociarEventos();
        }

        private void ConfigurarColumnasTabla()
        {
            dGVDatos.AutoGenerateColumns = false;
            dGVDatos.Columns.Clear();
            dGVDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ClmUsuarios",
                HeaderText = "Usuario / Empleado",
            });
            dGVDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ClmCorreo",
                HeaderText = "Correo Electrónico",
            });

            var checkColumn = new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "ClmAutorizacion",
                HeaderText = "¿Permitir Ingreso?",
                ReadOnly = true,
            };
            dGVDatos.Columns.Add(checkColumn);
        }

        public void ConfirmarEdicionPendiente()
        {
            if (dGVDatos.IsCurrentCellDirty)
            {
                dGVDatos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            dGVDatos.EndEdit();
        }

        private void AsociarEventos()
        {
            this.Load += (s, e) => VistaCargando?.Invoke(this, EventArgs.Empty);
            btnGuardar.Click += (s, e) => GuardarCambios?.Invoke(this, EventArgs.Empty);
            btnCerrar.Click += (s, e) => Cancelar?.Invoke(this, EventArgs.Empty);
            btnEliminar.Click += (s, e) => Eliminar?.Invoke(this, EventArgs.Empty);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Enter)
            {
                btnGuardar.PerformClick();
                return true;
            }

            if (keyData == Keys.Escape)
            {
                btnCerrar.PerformClick();
                return true;
            }

            if (keyData == Keys.Delete && !(this.ActiveControl is TextBox))
            {
                btnEliminar.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void MostrarMensaje(string mensaje, string titulo, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helpers.AnimateWindows.Start(this, 350, Helpers.AnimateWindows.AnimateWindowsFlags.AW_ACTIVATE | AnimateWindows.AnimateWindowsFlags.AW_BLEND);
        }

        public void CerrarVista(DialogResult resultado)
        {
            this.DialogResult = resultado;
            this.Close();
        }

        public event EventHandler VistaCargando;
        public event EventHandler GuardarCambios;
        public event EventHandler Cancelar;
        public event EventHandler Eliminar;
    }
}