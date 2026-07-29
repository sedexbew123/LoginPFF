namespace Presentacion.View.UserControls
{
    partial class AsignarCredito
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblAsignar = new System.Windows.Forms.Label();
            this.pnlSeparacion = new System.Windows.Forms.Panel();
            this.pnlInformacion = new System.Windows.Forms.Panel();
            this.txtTrampa = new System.Windows.Forms.TextBox();
            this.lblInstruccion = new System.Windows.Forms.Label();
            this.lblCrearCredito = new System.Windows.Forms.Label();
            this.pnlSeparacion2 = new System.Windows.Forms.Panel();
            this.pnlDerecha = new System.Windows.Forms.Panel();
            this.pnlIzquierda = new System.Windows.Forms.Panel();
            this.tLPInformacionBasica = new System.Windows.Forms.TableLayoutPanel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.dtpFechaLimite = new System.Windows.Forms.DateTimePicker();
            this.pnlSeparacion3 = new System.Windows.Forms.Panel();
            this.tLPDatos = new System.Windows.Forms.TableLayoutPanel();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.nUDMontoTotal = new System.Windows.Forms.NumericUpDown();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.tLPBoton = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSeparacion4 = new System.Windows.Forms.Panel();
            this.dGVDatos = new System.Windows.Forms.DataGridView();
            this.ClmCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSuperior.SuspendLayout();
            this.pnlInformacion.SuspendLayout();
            this.tLPInformacionBasica.SuspendLayout();
            this.tLPDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMontoTotal)).BeginInit();
            this.tLPBoton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlSuperior.Controls.Add(this.lblAsignar);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(5, 5);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(617, 50);
            this.pnlSuperior.TabIndex = 2;
            // 
            // lblAsignar
            // 
            this.lblAsignar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAsignar.AutoSize = true;
            this.lblAsignar.BackColor = System.Drawing.Color.Transparent;
            this.lblAsignar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsignar.ForeColor = System.Drawing.Color.White;
            this.lblAsignar.Location = new System.Drawing.Point(19, 23);
            this.lblAsignar.Name = "lblAsignar";
            this.lblAsignar.Size = new System.Drawing.Size(142, 25);
            this.lblAsignar.TabIndex = 1;
            this.lblAsignar.Text = "Asignar crédito";
            // 
            // pnlSeparacion
            // 
            this.pnlSeparacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparacion.Location = new System.Drawing.Point(5, 55);
            this.pnlSeparacion.Name = "pnlSeparacion";
            this.pnlSeparacion.Size = new System.Drawing.Size(617, 30);
            this.pnlSeparacion.TabIndex = 3;
            // 
            // pnlInformacion
            // 
            this.pnlInformacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlInformacion.Controls.Add(this.txtTrampa);
            this.pnlInformacion.Controls.Add(this.lblInstruccion);
            this.pnlInformacion.Controls.Add(this.lblCrearCredito);
            this.pnlInformacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInformacion.Location = new System.Drawing.Point(5, 85);
            this.pnlInformacion.Name = "pnlInformacion";
            this.pnlInformacion.Size = new System.Drawing.Size(617, 60);
            this.pnlInformacion.TabIndex = 20;
            // 
            // txtTrampa
            // 
            this.txtTrampa.Location = new System.Drawing.Point(-100, -100);
            this.txtTrampa.Name = "txtTrampa";
            this.txtTrampa.Size = new System.Drawing.Size(100, 20);
            this.txtTrampa.TabIndex = 0;
            // 
            // lblInstruccion
            // 
            this.lblInstruccion.AutoSize = true;
            this.lblInstruccion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruccion.ForeColor = System.Drawing.Color.White;
            this.lblInstruccion.Location = new System.Drawing.Point(56, 38);
            this.lblInstruccion.Name = "lblInstruccion";
            this.lblInstruccion.Size = new System.Drawing.Size(146, 13);
            this.lblInstruccion.TabIndex = 1;
            this.lblInstruccion.Text = "Registra las deudas nuevas";
            // 
            // lblCrearCredito
            // 
            this.lblCrearCredito.AutoSize = true;
            this.lblCrearCredito.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrearCredito.ForeColor = System.Drawing.Color.White;
            this.lblCrearCredito.Location = new System.Drawing.Point(53, 8);
            this.lblCrearCredito.Name = "lblCrearCredito";
            this.lblCrearCredito.Size = new System.Drawing.Size(126, 25);
            this.lblCrearCredito.TabIndex = 0;
            this.lblCrearCredito.Text = "Crear Crédito";
            // 
            // pnlSeparacion2
            // 
            this.pnlSeparacion2.BackColor = System.Drawing.Color.White;
            this.pnlSeparacion2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparacion2.Location = new System.Drawing.Point(5, 145);
            this.pnlSeparacion2.Name = "pnlSeparacion2";
            this.pnlSeparacion2.Size = new System.Drawing.Size(617, 30);
            this.pnlSeparacion2.TabIndex = 21;
            // 
            // pnlDerecha
            // 
            this.pnlDerecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDerecha.Location = new System.Drawing.Point(592, 175);
            this.pnlDerecha.Name = "pnlDerecha";
            this.pnlDerecha.Size = new System.Drawing.Size(30, 285);
            this.pnlDerecha.TabIndex = 22;
            // 
            // pnlIzquierda
            // 
            this.pnlIzquierda.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIzquierda.Location = new System.Drawing.Point(5, 175);
            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Size = new System.Drawing.Size(30, 285);
            this.pnlIzquierda.TabIndex = 23;
            // 
            // tLPInformacionBasica
            // 
            this.tLPInformacionBasica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.tLPInformacionBasica.ColumnCount = 9;
            this.tLPInformacionBasica.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.523809F));
            this.tLPInformacionBasica.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.2381F));
            this.tLPInformacionBasica.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.761905F));
            this.tLPInformacionBasica.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.14286F));
            this.tLPInformacionBasica.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.761905F));
            this.tLPInformacionBasica.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.14286F));
            this.tLPInformacionBasica.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.761905F));
            this.tLPInformacionBasica.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.14286F));
            this.tLPInformacionBasica.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.523809F));
            this.tLPInformacionBasica.Controls.Add(this.lblFecha, 7, 0);
            this.tLPInformacionBasica.Controls.Add(this.txtApellido, 5, 1);
            this.tLPInformacionBasica.Controls.Add(this.txtCedula, 1, 1);
            this.tLPInformacionBasica.Controls.Add(this.txtNombre, 3, 1);
            this.tLPInformacionBasica.Controls.Add(this.lblCedula, 1, 0);
            this.tLPInformacionBasica.Controls.Add(this.lblNombre, 3, 0);
            this.tLPInformacionBasica.Controls.Add(this.lblApellido, 5, 0);
            this.tLPInformacionBasica.Controls.Add(this.dtpFechaLimite, 7, 1);
            this.tLPInformacionBasica.Dock = System.Windows.Forms.DockStyle.Top;
            this.tLPInformacionBasica.Location = new System.Drawing.Point(35, 175);
            this.tLPInformacionBasica.Name = "tLPInformacionBasica";
            this.tLPInformacionBasica.RowCount = 2;
            this.tLPInformacionBasica.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPInformacionBasica.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPInformacionBasica.Size = new System.Drawing.Size(557, 70);
            this.tLPInformacionBasica.TabIndex = 29;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblFecha.Location = new System.Drawing.Point(408, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(89, 35);
            this.lblFecha.TabIndex = 19;
            this.lblFecha.Text = "Fecha Limite";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.Color.White;
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(287, 38);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.ReadOnly = true;
            this.txtApellido.Size = new System.Drawing.Size(89, 22);
            this.txtApellido.TabIndex = 11;
            // 
            // txtCedula
            // 
            this.txtCedula.BackColor = System.Drawing.Color.White;
            this.txtCedula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCedula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCedula.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedula.Location = new System.Drawing.Point(56, 38);
            this.txtCedula.MaxLength = 8;
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(78, 22);
            this.txtCedula.TabIndex = 6;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(166, 38);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(89, 22);
            this.txtNombre.TabIndex = 10;
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCedula.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblCedula.Location = new System.Drawing.Point(56, 0);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(78, 35);
            this.lblCedula.TabIndex = 12;
            this.lblCedula.Text = "Cédula";
            this.lblCedula.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblNombre.Location = new System.Drawing.Point(166, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(89, 35);
            this.lblNombre.TabIndex = 13;
            this.lblNombre.Text = "Nombre";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblApellido.Location = new System.Drawing.Point(287, 0);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(89, 35);
            this.lblApellido.TabIndex = 14;
            this.lblApellido.Text = "Apellido";
            this.lblApellido.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dtpFechaLimite
            // 
            this.dtpFechaLimite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFechaLimite.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaLimite.Location = new System.Drawing.Point(408, 38);
            this.dtpFechaLimite.Name = "dtpFechaLimite";
            this.dtpFechaLimite.Size = new System.Drawing.Size(89, 20);
            this.dtpFechaLimite.TabIndex = 20;
            // 
            // pnlSeparacion3
            // 
            this.pnlSeparacion3.BackColor = System.Drawing.Color.White;
            this.pnlSeparacion3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparacion3.Location = new System.Drawing.Point(35, 245);
            this.pnlSeparacion3.Name = "pnlSeparacion3";
            this.pnlSeparacion3.Size = new System.Drawing.Size(557, 10);
            this.pnlSeparacion3.TabIndex = 30;
            // 
            // tLPDatos
            // 
            this.tLPDatos.ColumnCount = 3;
            this.tLPDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tLPDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tLPDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tLPDatos.Controls.Add(this.btnAsignar, 1, 2);
            this.tLPDatos.Controls.Add(this.lblMontoTotal, 1, 0);
            this.tLPDatos.Controls.Add(this.nUDMontoTotal, 1, 1);
            this.tLPDatos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tLPDatos.Location = new System.Drawing.Point(35, 372);
            this.tLPDatos.Name = "tLPDatos";
            this.tLPDatos.RowCount = 3;
            this.tLPDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tLPDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tLPDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tLPDatos.Size = new System.Drawing.Size(557, 88);
            this.tLPDatos.TabIndex = 38;
            // 
            // btnAsignar
            // 
            this.btnAsignar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnAsignar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAsignar.FlatAppearance.BorderSize = 0;
            this.btnAsignar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(151)))), ((int)(((byte)(241)))));
            this.btnAsignar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(151)))), ((int)(((byte)(241)))));
            this.btnAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignar.ForeColor = System.Drawing.Color.White;
            this.btnAsignar.Location = new System.Drawing.Point(203, 61);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(149, 24);
            this.btnAsignar.TabIndex = 24;
            this.btnAsignar.Text = "[ F6 ] Asignar Crédito";
            this.btnAsignar.UseVisualStyleBackColor = false;
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblMontoTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMontoTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTotal.ForeColor = System.Drawing.Color.White;
            this.lblMontoTotal.Location = new System.Drawing.Point(203, 0);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(149, 29);
            this.lblMontoTotal.TabIndex = 14;
            this.lblMontoTotal.Text = "Monto Total";
            this.lblMontoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nUDMontoTotal
            // 
            this.nUDMontoTotal.DecimalPlaces = 2;
            this.nUDMontoTotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.nUDMontoTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nUDMontoTotal.Location = new System.Drawing.Point(203, 32);
            this.nUDMontoTotal.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDMontoTotal.Name = "nUDMontoTotal";
            this.nUDMontoTotal.Size = new System.Drawing.Size(149, 23);
            this.nUDMontoTotal.TabIndex = 25;
            this.nUDMontoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnAgregar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(151)))), ((int)(((byte)(241)))));
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(151)))), ((int)(((byte)(241)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(203, 3);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(149, 24);
            this.btnAgregar.TabIndex = 18;
            this.btnAgregar.Text = "[ F5 ] Agregar Crédito";
            this.btnAgregar.UseVisualStyleBackColor = false;
            // 
            // tLPBoton
            // 
            this.tLPBoton.ColumnCount = 3;
            this.tLPBoton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tLPBoton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tLPBoton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tLPBoton.Controls.Add(this.btnAgregar, 1, 0);
            this.tLPBoton.Dock = System.Windows.Forms.DockStyle.Top;
            this.tLPBoton.Location = new System.Drawing.Point(35, 255);
            this.tLPBoton.Name = "tLPBoton";
            this.tLPBoton.RowCount = 1;
            this.tLPBoton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPBoton.Size = new System.Drawing.Size(557, 30);
            this.tLPBoton.TabIndex = 2;
            // 
            // pnlSeparacion4
            // 
            this.pnlSeparacion4.BackColor = System.Drawing.Color.White;
            this.pnlSeparacion4.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparacion4.Location = new System.Drawing.Point(35, 285);
            this.pnlSeparacion4.Name = "pnlSeparacion4";
            this.pnlSeparacion4.Size = new System.Drawing.Size(557, 10);
            this.pnlSeparacion4.TabIndex = 40;
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
            this.ClmCantidad,
            this.ClmProducto,
            this.ClmCategoria,
            this.ClmPrecio});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVDatos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGVDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVDatos.EnableHeadersVisualStyles = false;
            this.dGVDatos.GridColor = System.Drawing.Color.DarkGray;
            this.dGVDatos.Location = new System.Drawing.Point(35, 295);
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
            this.dGVDatos.Size = new System.Drawing.Size(557, 77);
            this.dGVDatos.TabIndex = 41;
            // 
            // ClmCantidad
            // 
            this.ClmCantidad.HeaderText = "Cantidad";
            this.ClmCantidad.Name = "ClmCantidad";
            this.ClmCantidad.ReadOnly = true;
            // 
            // ClmProducto
            // 
            this.ClmProducto.HeaderText = "Producto";
            this.ClmProducto.Name = "ClmProducto";
            this.ClmProducto.ReadOnly = true;
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
            // AsignarCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dGVDatos);
            this.Controls.Add(this.pnlSeparacion4);
            this.Controls.Add(this.tLPBoton);
            this.Controls.Add(this.tLPDatos);
            this.Controls.Add(this.pnlSeparacion3);
            this.Controls.Add(this.tLPInformacionBasica);
            this.Controls.Add(this.pnlIzquierda);
            this.Controls.Add(this.pnlDerecha);
            this.Controls.Add(this.pnlSeparacion2);
            this.Controls.Add(this.pnlInformacion);
            this.Controls.Add(this.pnlSeparacion);
            this.Controls.Add(this.pnlSuperior);
            this.DoubleBuffered = true;
            this.Name = "AsignarCredito";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(627, 465);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlInformacion.ResumeLayout(false);
            this.pnlInformacion.PerformLayout();
            this.tLPInformacionBasica.ResumeLayout(false);
            this.tLPInformacionBasica.PerformLayout();
            this.tLPDatos.ResumeLayout(false);
            this.tLPDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMontoTotal)).EndInit();
            this.tLPBoton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblAsignar;
        private System.Windows.Forms.Panel pnlSeparacion;
        private System.Windows.Forms.Panel pnlInformacion;
        private System.Windows.Forms.Label lblInstruccion;
        private System.Windows.Forms.Label lblCrearCredito;
        private System.Windows.Forms.Panel pnlSeparacion2;
        private System.Windows.Forms.Panel pnlDerecha;
        private System.Windows.Forms.Panel pnlIzquierda;
        private System.Windows.Forms.TableLayoutPanel tLPInformacionBasica;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Panel pnlSeparacion3;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TableLayoutPanel tLPDatos;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.NumericUpDown nUDMontoTotal;
        private System.Windows.Forms.TextBox txtTrampa;
        private System.Windows.Forms.TableLayoutPanel tLPBoton;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Panel pnlSeparacion4;
        private System.Windows.Forms.DataGridView dGVDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmPrecio;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFechaLimite;
    }
}
