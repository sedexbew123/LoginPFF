namespace Presentacion.View.UserControls
{
    partial class RegistroProductos
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroProductos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblRegistroProductos = new System.Windows.Forms.Label();
            this.pnlSeparacion = new System.Windows.Forms.Panel();
            this.pnlInformacion = new System.Windows.Forms.Panel();
            this.lblInstruccion = new System.Windows.Forms.Label();
            this.lblCrearCredito = new System.Windows.Forms.Label();
            this.pnlSeparacion2 = new System.Windows.Forms.Panel();
            this.pnlIzquierda = new System.Windows.Forms.Panel();
            this.pnlDerecha = new System.Windows.Forms.Panel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.KtxtFiltro = new Krypton.Toolkit.KryptonTextBox();
            this.KcmbTipo = new Krypton.Toolkit.KryptonComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlPaginacion = new System.Windows.Forms.Panel();
            this.lblPaginas = new System.Windows.Forms.Label();
            this.btnDelante = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.dGVDatos = new System.Windows.Forms.DataGridView();
            this.ClmNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioBs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSuperior.SuspendLayout();
            this.pnlInformacion.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KcmbTipo)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnlPaginacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlSuperior.Controls.Add(this.lblRegistroProductos);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(5, 5);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(617, 50);
            this.pnlSuperior.TabIndex = 3;
            // 
            // lblRegistroProductos
            // 
            this.lblRegistroProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRegistroProductos.AutoSize = true;
            this.lblRegistroProductos.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistroProductos.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistroProductos.ForeColor = System.Drawing.Color.White;
            this.lblRegistroProductos.Location = new System.Drawing.Point(19, 23);
            this.lblRegistroProductos.Name = "lblRegistroProductos";
            this.lblRegistroProductos.Size = new System.Drawing.Size(201, 25);
            this.lblRegistroProductos.TabIndex = 1;
            this.lblRegistroProductos.Text = "Registro de Inventario";
            // 
            // pnlSeparacion
            // 
            this.pnlSeparacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparacion.Location = new System.Drawing.Point(5, 55);
            this.pnlSeparacion.Name = "pnlSeparacion";
            this.pnlSeparacion.Size = new System.Drawing.Size(617, 30);
            this.pnlSeparacion.TabIndex = 4;
            // 
            // pnlInformacion
            // 
            this.pnlInformacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlInformacion.Controls.Add(this.lblInstruccion);
            this.pnlInformacion.Controls.Add(this.lblCrearCredito);
            this.pnlInformacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInformacion.Location = new System.Drawing.Point(5, 85);
            this.pnlInformacion.Name = "pnlInformacion";
            this.pnlInformacion.Size = new System.Drawing.Size(617, 60);
            this.pnlInformacion.TabIndex = 21;
            // 
            // lblInstruccion
            // 
            this.lblInstruccion.AutoSize = true;
            this.lblInstruccion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruccion.ForeColor = System.Drawing.Color.White;
            this.lblInstruccion.Location = new System.Drawing.Point(56, 38);
            this.lblInstruccion.Name = "lblInstruccion";
            this.lblInstruccion.Size = new System.Drawing.Size(203, 13);
            this.lblInstruccion.TabIndex = 1;
            this.lblInstruccion.Text = "Añade nuevos productos al inventario";
            // 
            // lblCrearCredito
            // 
            this.lblCrearCredito.AutoSize = true;
            this.lblCrearCredito.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrearCredito.ForeColor = System.Drawing.Color.White;
            this.lblCrearCredito.Location = new System.Drawing.Point(53, 8);
            this.lblCrearCredito.Name = "lblCrearCredito";
            this.lblCrearCredito.Size = new System.Drawing.Size(152, 25);
            this.lblCrearCredito.TabIndex = 0;
            this.lblCrearCredito.Text = "Nuevo Producto";
            // 
            // pnlSeparacion2
            // 
            this.pnlSeparacion2.BackColor = System.Drawing.Color.White;
            this.pnlSeparacion2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparacion2.Location = new System.Drawing.Point(5, 145);
            this.pnlSeparacion2.Name = "pnlSeparacion2";
            this.pnlSeparacion2.Size = new System.Drawing.Size(617, 30);
            this.pnlSeparacion2.TabIndex = 22;
            // 
            // pnlIzquierda
            // 
            this.pnlIzquierda.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIzquierda.Location = new System.Drawing.Point(5, 175);
            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Size = new System.Drawing.Size(30, 285);
            this.pnlIzquierda.TabIndex = 24;
            // 
            // pnlDerecha
            // 
            this.pnlDerecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDerecha.Location = new System.Drawing.Point(592, 175);
            this.pnlDerecha.Name = "pnlDerecha";
            this.pnlDerecha.Size = new System.Drawing.Size(30, 285);
            this.pnlDerecha.TabIndex = 25;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(402, 28);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(149, 27);
            this.btnAgregar.TabIndex = 27;
            this.btnAgregar.Text = "[ F5 ] + Nuevo Producto";
            this.btnAgregar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(9, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(98, 25);
            this.btnEliminar.TabIndex = 33;
            this.btnEliminar.Text = "[ Supr] Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(161)))), ((int)(((byte)(107)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(125, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(98, 25);
            this.btnEditar.TabIndex = 34;
            this.btnEditar.Text = "[ F6 ] Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.btnEditar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(35, 428);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 32);
            this.panel1.TabIndex = 51;
            // 
            // KtxtFiltro
            // 
            this.KtxtFiltro.Location = new System.Drawing.Point(6, 31);
            this.KtxtFiltro.Name = "KtxtFiltro";
            this.KtxtFiltro.Size = new System.Drawing.Size(235, 23);
            this.KtxtFiltro.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtFiltro.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KtxtFiltro.TabIndex = 33;
            // 
            // KcmbTipo
            // 
            this.KcmbTipo.CornerRoundingRadius = -1F;
            this.KcmbTipo.DropButtonStyle = Krypton.Toolkit.ButtonStyle.NavigatorMini;
            this.KcmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KcmbTipo.DropDownWidth = 154;
            this.KcmbTipo.IntegralHeight = false;
            this.KcmbTipo.Items.AddRange(new object[] {
            "Todos",
            "Activo",
            "Stock bajo",
            "Agotado",
            "Inactivo"});
            this.KcmbTipo.Location = new System.Drawing.Point(247, 31);
            this.KcmbTipo.Name = "KcmbTipo";
            this.KcmbTipo.Size = new System.Drawing.Size(146, 21);
            this.KcmbTipo.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KcmbTipo.StateCommon.ComboBox.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KcmbTipo.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.KcmbTipo.StateCommon.DropBack.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.KcmbTipo.StateCommon.Item.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.KcmbTipo.StateCommon.Item.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.KcmbTipo.StateCommon.Item.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.KcmbTipo.TabIndex = 76;
            // 
            // lblTipo
            // 
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(249, 0);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(110, 28);
            this.lblTipo.TabIndex = 77;
            this.lblTipo.Text = "Filtrar";
            this.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProducto
            // 
            this.lblProducto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.Location = new System.Drawing.Point(9, 0);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(226, 28);
            this.lblProducto.TabIndex = 78;
            this.lblProducto.Text = "Buscar por Producto o Categoría";
            this.lblProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.panel2.Controls.Add(this.lblTipo);
            this.panel2.Controls.Add(this.lblProducto);
            this.panel2.Controls.Add(this.btnAgregar);
            this.panel2.Controls.Add(this.KcmbTipo);
            this.panel2.Controls.Add(this.KtxtFiltro);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(35, 175);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(557, 61);
            this.panel2.TabIndex = 53;
            // 
            // pnlPaginacion
            // 
            this.pnlPaginacion.Controls.Add(this.lblPaginas);
            this.pnlPaginacion.Controls.Add(this.btnDelante);
            this.pnlPaginacion.Controls.Add(this.btnAtras);
            this.pnlPaginacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPaginacion.Location = new System.Drawing.Point(35, 236);
            this.pnlPaginacion.Name = "pnlPaginacion";
            this.pnlPaginacion.Size = new System.Drawing.Size(557, 32);
            this.pnlPaginacion.TabIndex = 54;
            // 
            // lblPaginas
            // 
            this.lblPaginas.AutoSize = true;
            this.lblPaginas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaginas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblPaginas.Location = new System.Drawing.Point(12, 7);
            this.lblPaginas.Name = "lblPaginas";
            this.lblPaginas.Size = new System.Drawing.Size(35, 17);
            this.lblPaginas.TabIndex = 31;
            this.lblPaginas.Text = "1 - 1";
            // 
            // btnDelante
            // 
            this.btnDelante.BackColor = System.Drawing.Color.Transparent;
            this.btnDelante.FlatAppearance.BorderSize = 0;
            this.btnDelante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelante.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelante.ForeColor = System.Drawing.Color.White;
            this.btnDelante.Image = ((System.Drawing.Image)(resources.GetObject("btnDelante.Image")));
            this.btnDelante.Location = new System.Drawing.Point(82, 3);
            this.btnDelante.Name = "btnDelante";
            this.btnDelante.Size = new System.Drawing.Size(28, 25);
            this.btnDelante.TabIndex = 33;
            this.btnDelante.UseVisualStyleBackColor = false;
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.Transparent;
            this.btnAtras.FlatAppearance.BorderSize = 0;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtras.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.ForeColor = System.Drawing.Color.White;
            this.btnAtras.Image = ((System.Drawing.Image)(resources.GetObject("btnAtras.Image")));
            this.btnAtras.Location = new System.Drawing.Point(45, 3);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(30, 25);
            this.btnAtras.TabIndex = 32;
            this.btnAtras.UseVisualStyleBackColor = false;
            // 
            // dGVDatos
            // 
            this.dGVDatos.AllowUserToAddRows = false;
            this.dGVDatos.AllowUserToDeleteRows = false;
            this.dGVDatos.AllowUserToResizeColumns = false;
            this.dGVDatos.AllowUserToResizeRows = false;
            this.dGVDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVDatos.BackgroundColor = System.Drawing.Color.White;
            this.dGVDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGVDatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dGVDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmNombre,
            this.ClmCategoria,
            this.ClmPrecio,
            this.colPrecioBs,
            this.ClmStock,
            this.ClmEstado});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(190)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVDatos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGVDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVDatos.EnableHeadersVisualStyles = false;
            this.dGVDatos.GridColor = System.Drawing.Color.DarkGray;
            this.dGVDatos.Location = new System.Drawing.Point(35, 268);
            this.dGVDatos.MultiSelect = false;
            this.dGVDatos.Name = "dGVDatos";
            this.dGVDatos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dGVDatos.RowHeadersVisible = false;
            this.dGVDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVDatos.Size = new System.Drawing.Size(557, 160);
            this.dGVDatos.TabIndex = 55;
            // 
            // ClmNombre
            // 
            this.ClmNombre.HeaderText = "Nombre";
            this.ClmNombre.Name = "ClmNombre";
            this.ClmNombre.ReadOnly = true;
            // 
            // ClmCategoria
            // 
            this.ClmCategoria.HeaderText = "Categoría";
            this.ClmCategoria.Name = "ClmCategoria";
            this.ClmCategoria.ReadOnly = true;
            // 
            // ClmPrecio
            // 
            this.ClmPrecio.HeaderText = "Precio";
            this.ClmPrecio.Name = "ClmPrecio";
            this.ClmPrecio.ReadOnly = true;
            // 
            // colPrecioBs
            // 
            this.colPrecioBs.HeaderText = "PrecioBs";
            this.colPrecioBs.Name = "colPrecioBs";
            this.colPrecioBs.ReadOnly = true;
            // 
            // ClmStock
            // 
            this.ClmStock.HeaderText = "Stock Actual";
            this.ClmStock.Name = "ClmStock";
            this.ClmStock.ReadOnly = true;
            // 
            // ClmEstado
            // 
            this.ClmEstado.HeaderText = "Estado";
            this.ClmEstado.Name = "ClmEstado";
            this.ClmEstado.ReadOnly = true;
            // 
            // RegistroProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dGVDatos);
            this.Controls.Add(this.pnlPaginacion);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlDerecha);
            this.Controls.Add(this.pnlIzquierda);
            this.Controls.Add(this.pnlSeparacion2);
            this.Controls.Add(this.pnlInformacion);
            this.Controls.Add(this.pnlSeparacion);
            this.Controls.Add(this.pnlSuperior);
            this.Name = "RegistroProductos";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(627, 465);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlInformacion.ResumeLayout(false);
            this.pnlInformacion.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KcmbTipo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlPaginacion.ResumeLayout(false);
            this.pnlPaginacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblRegistroProductos;
        private System.Windows.Forms.Panel pnlSeparacion;
        private System.Windows.Forms.Panel pnlInformacion;
        private System.Windows.Forms.Label lblInstruccion;
        private System.Windows.Forms.Label lblCrearCredito;
        private System.Windows.Forms.Panel pnlSeparacion2;
        private System.Windows.Forms.Panel pnlIzquierda;
        private System.Windows.Forms.Panel pnlDerecha;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Panel panel1;
        private Krypton.Toolkit.KryptonTextBox KtxtFiltro;
        private Krypton.Toolkit.KryptonComboBox KcmbTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlPaginacion;
        private System.Windows.Forms.Label lblPaginas;
        private System.Windows.Forms.Button btnDelante;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.DataGridView dGVDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioBs;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmEstado;
    }
}
