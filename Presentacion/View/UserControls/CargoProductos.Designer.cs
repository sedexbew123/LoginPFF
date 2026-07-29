namespace Presentacion.View.UserControls
{
    partial class CargoProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CargoProductos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblCargoProductos = new System.Windows.Forms.Label();
            this.pnlSeparacion = new System.Windows.Forms.Panel();
            this.pnlInformacion = new System.Windows.Forms.Panel();
            this.lblInstruccion = new System.Windows.Forms.Label();
            this.lblCrearCredito = new System.Windows.Forms.Label();
            this.pnlSeparacion2 = new System.Windows.Forms.Panel();
            this.pnlIzquierda = new System.Windows.Forms.Panel();
            this.pnlDerecha = new System.Windows.Forms.Panel();
            this.pnlRegistroCargo = new System.Windows.Forms.Panel();
            this.pnlInformacionDescargo = new System.Windows.Forms.Panel();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.numCantidad = new Krypton.Toolkit.KryptonNumericUpDown();
            this.cmbCategoria = new Krypton.Toolkit.KryptonComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblProductos = new System.Windows.Forms.Label();
            this.btnRegistrarCargo = new System.Windows.Forms.Button();
            this.lblHistorialCargos = new System.Windows.Forms.Label();
            this.pnlPaginacion = new System.Windows.Forms.Panel();
            this.lblPaginas = new System.Windows.Forms.Label();
            this.btnDelante = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.txtTrampa = new System.Windows.Forms.TextBox();
            this.dGVDatos = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSuperior.SuspendLayout();
            this.pnlInformacion.SuspendLayout();
            this.pnlRegistroCargo.SuspendLayout();
            this.pnlInformacionDescargo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCategoria)).BeginInit();
            this.pnlPaginacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlSuperior.Controls.Add(this.lblCargoProductos);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(5, 5);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(617, 50);
            this.pnlSuperior.TabIndex = 4;
            // 
            // lblCargoProductos
            // 
            this.lblCargoProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCargoProductos.AutoSize = true;
            this.lblCargoProductos.BackColor = System.Drawing.Color.Transparent;
            this.lblCargoProductos.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargoProductos.ForeColor = System.Drawing.Color.White;
            this.lblCargoProductos.Location = new System.Drawing.Point(19, 23);
            this.lblCargoProductos.Name = "lblCargoProductos";
            this.lblCargoProductos.Size = new System.Drawing.Size(182, 25);
            this.lblCargoProductos.TabIndex = 1;
            this.lblCargoProductos.Text = "Cargo de Inventario";
            // 
            // pnlSeparacion
            // 
            this.pnlSeparacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparacion.Location = new System.Drawing.Point(5, 55);
            this.pnlSeparacion.Name = "pnlSeparacion";
            this.pnlSeparacion.Size = new System.Drawing.Size(617, 30);
            this.pnlSeparacion.TabIndex = 5;
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
            this.pnlInformacion.TabIndex = 22;
            // 
            // lblInstruccion
            // 
            this.lblInstruccion.AutoSize = true;
            this.lblInstruccion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruccion.ForeColor = System.Drawing.Color.White;
            this.lblInstruccion.Location = new System.Drawing.Point(56, 38);
            this.lblInstruccion.Name = "lblInstruccion";
            this.lblInstruccion.Size = new System.Drawing.Size(232, 13);
            this.lblInstruccion.TabIndex = 1;
            this.lblInstruccion.Text = "Registra el cargo de productos al inventario";
            // 
            // lblCrearCredito
            // 
            this.lblCrearCredito.AutoSize = true;
            this.lblCrearCredito.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrearCredito.ForeColor = System.Drawing.Color.White;
            this.lblCrearCredito.Location = new System.Drawing.Point(53, 8);
            this.lblCrearCredito.Name = "lblCrearCredito";
            this.lblCrearCredito.Size = new System.Drawing.Size(195, 25);
            this.lblCrearCredito.TabIndex = 0;
            this.lblCrearCredito.Text = "Entrada de Productos";
            // 
            // pnlSeparacion2
            // 
            this.pnlSeparacion2.BackColor = System.Drawing.Color.White;
            this.pnlSeparacion2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparacion2.Location = new System.Drawing.Point(5, 145);
            this.pnlSeparacion2.Name = "pnlSeparacion2";
            this.pnlSeparacion2.Size = new System.Drawing.Size(617, 30);
            this.pnlSeparacion2.TabIndex = 23;
            // 
            // pnlIzquierda
            // 
            this.pnlIzquierda.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIzquierda.Location = new System.Drawing.Point(5, 175);
            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Size = new System.Drawing.Size(30, 285);
            this.pnlIzquierda.TabIndex = 25;
            // 
            // pnlDerecha
            // 
            this.pnlDerecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDerecha.Location = new System.Drawing.Point(592, 175);
            this.pnlDerecha.Name = "pnlDerecha";
            this.pnlDerecha.Size = new System.Drawing.Size(30, 285);
            this.pnlDerecha.TabIndex = 26;
            // 
            // pnlRegistroCargo
            // 
            this.pnlRegistroCargo.BackColor = System.Drawing.Color.White;
            this.pnlRegistroCargo.Controls.Add(this.pnlInformacionDescargo);
            this.pnlRegistroCargo.Controls.Add(this.lblProductos);
            this.pnlRegistroCargo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRegistroCargo.Location = new System.Drawing.Point(35, 175);
            this.pnlRegistroCargo.Name = "pnlRegistroCargo";
            this.pnlRegistroCargo.Padding = new System.Windows.Forms.Padding(5);
            this.pnlRegistroCargo.Size = new System.Drawing.Size(557, 98);
            this.pnlRegistroCargo.TabIndex = 27;
            // 
            // pnlInformacionDescargo
            // 
            this.pnlInformacionDescargo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlInformacionDescargo.Controls.Add(this.lblCategoria);
            this.pnlInformacionDescargo.Controls.Add(this.numCantidad);
            this.pnlInformacionDescargo.Controls.Add(this.cmbCategoria);
            this.pnlInformacionDescargo.Controls.Add(this.lblCantidad);
            this.pnlInformacionDescargo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInformacionDescargo.Location = new System.Drawing.Point(5, 35);
            this.pnlInformacionDescargo.Name = "pnlInformacionDescargo";
            this.pnlInformacionDescargo.Size = new System.Drawing.Size(547, 58);
            this.pnlInformacionDescargo.TabIndex = 53;
            // 
            // lblCategoria
            // 
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(6, 0);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(139, 28);
            this.lblCategoria.TabIndex = 35;
            this.lblCategoria.Text = "Categoría";
            this.lblCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numCantidad
            // 
            this.numCantidad.Location = new System.Drawing.Point(187, 34);
            this.numCantidad.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(121, 22);
            this.numCantidad.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.numCantidad.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.numCantidad.TabIndex = 46;
            this.numCantidad.UpDownButtonStyle = Krypton.Toolkit.ButtonStyle.NavigatorMini;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.CornerRoundingRadius = -1F;
            this.cmbCategoria.DropButtonStyle = Krypton.Toolkit.ButtonStyle.NavigatorMini;
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.DropDownWidth = 154;
            this.cmbCategoria.IntegralHeight = false;
            this.cmbCategoria.Location = new System.Drawing.Point(6, 34);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(160, 21);
            this.cmbCategoria.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.cmbCategoria.StateCommon.ComboBox.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbCategoria.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.cmbCategoria.StateCommon.DropBack.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cmbCategoria.StateCommon.Item.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cmbCategoria.StateCommon.Item.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cmbCategoria.StateCommon.Item.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cmbCategoria.TabIndex = 73;
            // 
            // lblCantidad
            // 
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(184, 0);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(124, 28);
            this.lblCantidad.TabIndex = 36;
            this.lblCantidad.Text = "Cantidad";
            this.lblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProductos
            // 
            this.lblProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProductos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductos.Location = new System.Drawing.Point(5, 5);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(547, 30);
            this.lblProductos.TabIndex = 28;
            this.lblProductos.Text = "Registrar Entrada de Inventario";
            // 
            // btnRegistrarCargo
            // 
            this.btnRegistrarCargo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrarCargo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnRegistrarCargo.FlatAppearance.BorderSize = 0;
            this.btnRegistrarCargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarCargo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarCargo.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarCargo.Location = new System.Drawing.Point(405, 3);
            this.btnRegistrarCargo.Name = "btnRegistrarCargo";
            this.btnRegistrarCargo.Size = new System.Drawing.Size(149, 23);
            this.btnRegistrarCargo.TabIndex = 28;
            this.btnRegistrarCargo.Text = "[ F5 ] + Registrar Cargo";
            this.btnRegistrarCargo.UseVisualStyleBackColor = false;
            // 
            // lblHistorialCargos
            // 
            this.lblHistorialCargos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHistorialCargos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistorialCargos.Location = new System.Drawing.Point(35, 273);
            this.lblHistorialCargos.Name = "lblHistorialCargos";
            this.lblHistorialCargos.Size = new System.Drawing.Size(557, 34);
            this.lblHistorialCargos.TabIndex = 33;
            this.lblHistorialCargos.Text = "  Historial de Cargos";
            // 
            // pnlPaginacion
            // 
            this.pnlPaginacion.Controls.Add(this.btnRegistrarCargo);
            this.pnlPaginacion.Controls.Add(this.lblPaginas);
            this.pnlPaginacion.Controls.Add(this.btnDelante);
            this.pnlPaginacion.Controls.Add(this.btnAtras);
            this.pnlPaginacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPaginacion.Location = new System.Drawing.Point(35, 307);
            this.pnlPaginacion.Name = "pnlPaginacion";
            this.pnlPaginacion.Size = new System.Drawing.Size(557, 32);
            this.pnlPaginacion.TabIndex = 50;
            // 
            // lblPaginas
            // 
            this.lblPaginas.AutoSize = true;
            this.lblPaginas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaginas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblPaginas.Location = new System.Drawing.Point(9, 7);
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
            this.btnDelante.Location = new System.Drawing.Point(78, 4);
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
            this.btnAtras.Location = new System.Drawing.Point(42, 4);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(30, 25);
            this.btnAtras.TabIndex = 32;
            this.btnAtras.UseVisualStyleBackColor = false;
            // 
            // txtTrampa
            // 
            this.txtTrampa.Location = new System.Drawing.Point(-100, -100);
            this.txtTrampa.Name = "txtTrampa";
            this.txtTrampa.Size = new System.Drawing.Size(100, 20);
            this.txtTrampa.TabIndex = 0;
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
            this.dGVDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Nombre,
            this.Stock});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(190)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVDatos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGVDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVDatos.EnableHeadersVisualStyles = false;
            this.dGVDatos.Location = new System.Drawing.Point(35, 339);
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
            this.dGVDatos.Size = new System.Drawing.Size(557, 121);
            this.dGVDatos.TabIndex = 51;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Stock Actual";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            // 
            // CargoProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dGVDatos);
            this.Controls.Add(this.txtTrampa);
            this.Controls.Add(this.pnlPaginacion);
            this.Controls.Add(this.lblHistorialCargos);
            this.Controls.Add(this.pnlRegistroCargo);
            this.Controls.Add(this.pnlDerecha);
            this.Controls.Add(this.pnlIzquierda);
            this.Controls.Add(this.pnlSeparacion2);
            this.Controls.Add(this.pnlInformacion);
            this.Controls.Add(this.pnlSeparacion);
            this.Controls.Add(this.pnlSuperior);
            this.Name = "CargoProductos";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(627, 465);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlInformacion.ResumeLayout(false);
            this.pnlInformacion.PerformLayout();
            this.pnlRegistroCargo.ResumeLayout(false);
            this.pnlInformacionDescargo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbCategoria)).EndInit();
            this.pnlPaginacion.ResumeLayout(false);
            this.pnlPaginacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblCargoProductos;
        private System.Windows.Forms.Panel pnlSeparacion;
        private System.Windows.Forms.Panel pnlInformacion;
        private System.Windows.Forms.Label lblInstruccion;
        private System.Windows.Forms.Label lblCrearCredito;
        private System.Windows.Forms.Panel pnlSeparacion2;
        private System.Windows.Forms.Panel pnlIzquierda;
        private System.Windows.Forms.Panel pnlDerecha;
        private System.Windows.Forms.Panel pnlRegistroCargo;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.Button btnRegistrarCargo;
        private System.Windows.Forms.Label lblHistorialCargos;
        private System.Windows.Forms.Panel pnlPaginacion;
        private System.Windows.Forms.Label lblPaginas;
        private System.Windows.Forms.Button btnDelante;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Panel pnlInformacionDescargo;
        private System.Windows.Forms.Label lblCategoria;
        private Krypton.Toolkit.KryptonNumericUpDown numCantidad;
        private Krypton.Toolkit.KryptonComboBox cmbCategoria;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtTrampa;
        private System.Windows.Forms.DataGridView dGVDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
    }
}
