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
    public partial class Categoria : UserControl, ICategoriaView
    {
        #region

        public string CategoriaNombre
        {
            get => txtNombre.Text;
            set => txtNombre.Text = value;
        }
        public string CategoriaDescripcion
        {
            get => txtDescripcion.Text;
            set => txtDescripcion.Text = value;
        }
        public object CategoriasDataSource
        {
            set => dGVCategoria.DataSource = value;
        }

        private bool _categoriaEdicion;
        public bool CategoriaEdicion
        {
            get => _categoriaEdicion;
            set
            {
                _categoriaEdicion = value;
                btnCatGuardar.Text = value ? "Actualizar" : "Guardar";
            }
        }


        public string MotivoNombre
        {
            get => txtMotivo.Text;
            set => txtMotivo.Text = value;
        }

        public string MotivoDescripcion
        {
            get => txtDetalles.Text;
            set => txtDetalles.Text = value;
        }
        public object MotivosDataSource
        {
            set => dGVMotivos.DataSource = value;
        }

        private bool _motivoEdicion;
        public bool MotivoEdicion
        {
            get => _motivoEdicion;
            set
            {
                _motivoEdicion = value;
                btnMotGuardar.Text = value ? "Actualizar" : "Guardar";
            }
        }


        #endregion
        public Categoria()
        {
            InitializeComponent();
            Eventos();

            // Grilla Categorías
            dGVCategoria.AutoGenerateColumns = false;
            dGVCategoria.Columns.Clear();
            dGVCategoria.Columns.Add(new DataGridViewTextBoxColumn
            { HeaderText = "Nombre", DataPropertyName = "Nombre", Name = "Nombre", Width = 150 });
            dGVCategoria.Columns.Add(new DataGridViewTextBoxColumn
            { HeaderText = "Descripción", DataPropertyName = "Descripcion", Name = "Descripcion", Width = 200 });

            // Grilla Motivos — encabezado "Motivo" como pediste
            dGVMotivos.AutoGenerateColumns = false;
            dGVMotivos.Columns.Clear();
            dGVMotivos.Columns.Add(new DataGridViewTextBoxColumn
            { HeaderText = "Motivo", DataPropertyName = "Nombre", Name = "Nombre", Width = 150 });
            dGVMotivos.Columns.Add(new DataGridViewTextBoxColumn
            { HeaderText = "Detalles", DataPropertyName = "Descripcion", Name = "Descripcion", Width = 200 });
        }

        private void Eventos()
        {
            btnCatGuardar.Click += (s, e) => GuardarCategoria?.Invoke(this, EventArgs.Empty);
            btnCatLimpiar.Click += (s, e) => LimpiarCamposCategoria();
            btnCatEliminar.Click += (s, e) => EliminarCategoria?.Invoke(this, EventArgs.Empty);

            dGVCategoria.CellClick += DGVCategoria_CellClick;

            btnMotGuardar.Click += (s, e) => GuardarMotivo?.Invoke(this, EventArgs.Empty);
            btnMotLimpiar.Click += (s, e) => LimpiarCamposMotivo();
            btnMotEliminar.Click += (s, e) => EliminarMotivo?.Invoke(this, EventArgs.Empty);

            dGVMotivos.CellClick += DGVMotivo_CellClick;
        }

        private void DGVCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGVCategoria.Rows[e.RowIndex];
                CategoriaNombre = row.Cells["Nombre"].Value.ToString();
                CategoriaDescripcion = row.Cells["Descripcion"].Value.ToString();

                SeleccionarCategoria?.Invoke(this, EventArgs.Empty);
            }
        }

        private void DGVMotivo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGVMotivos.Rows[e.RowIndex];
                MotivoNombre = row.Cells["Nombre"].Value.ToString();
                MotivoDescripcion = row.Cells["Descripcion"].Value.ToString();

                SeleccionarMotivo?.Invoke(this, EventArgs.Empty);
            }
        }

        public void LimpiarCamposCategoria()
        {
            CategoriaNombre = "";
            CategoriaDescripcion = "";
            CategoriaEdicion = false; // ya deja btnCatGuardar.Text en "Guardar"
        }

        public void LimpiarCamposMotivo()
        {
            MotivoNombre = "";
            MotivoDescripcion = "";
            MotivoEdicion = false; // ya deja btnMotGuardar.Text en "Guardar"
        }

        public void MostrarMensaje(string mensaje, bool isError = false)
        {
            MessageBox.Show(mensaje, "CrediTrack - Configuración",
                MessageBoxButtons.OK, isError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }

        public bool ConfirmarAccion(string mensaje)
        {
            return MessageBox.Show(mensaje, "Confirmación Requerida",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public event EventHandler GuardarCategoria;
        public event EventHandler EliminarCategoria;
        public event EventHandler SeleccionarCategoria;

        public event EventHandler GuardarMotivo;
        public event EventHandler EliminarMotivo;
        public event EventHandler SeleccionarMotivo;

    }
}