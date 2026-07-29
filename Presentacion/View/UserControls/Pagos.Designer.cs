namespace Presentacion.View.UserControls
{
    partial class Pagos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pagos));
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblPagos = new System.Windows.Forms.Label();
            this.pnlSeparacion = new System.Windows.Forms.Panel();
            this.pnlInformacion = new System.Windows.Forms.Panel();
            this.lblInstruccion = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pnlSeparacion2 = new System.Windows.Forms.Panel();
            this.pnlIzquierda = new System.Windows.Forms.Panel();
            this.pnlDerecha = new System.Windows.Forms.Panel();
            this.KnudAño = new Krypton.Toolkit.KryptonNumericUpDown();
            this.KtxtFiltro = new Krypton.Toolkit.KryptonTextBox();
            this.KcmMes = new Krypton.Toolkit.KryptonComboBox();
            this.lblAño = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblMes = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.txtTrampa = new System.Windows.Forms.TextBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlPaginacion = new System.Windows.Forms.Panel();
            this.lblPaginas = new System.Windows.Forms.Label();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.dGVDatos = new System.Windows.Forms.DataGridView();
            this.ClmNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmCedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmMontoBs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnWhatsApp = new System.Windows.Forms.Button();
            this.btnDelante = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.pnlSuperior.SuspendLayout();
            this.pnlInformacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KcmMes)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlPaginacion.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlSuperior.Controls.Add(this.lblPagos);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(5, 5);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(617, 50);
            this.pnlSuperior.TabIndex = 8;
            // 
            // lblPagos
            // 
            this.lblPagos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPagos.AutoSize = true;
            this.lblPagos.BackColor = System.Drawing.Color.Transparent;
            this.lblPagos.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagos.ForeColor = System.Drawing.Color.White;
            this.lblPagos.Location = new System.Drawing.Point(19, 23);
            this.lblPagos.Name = "lblPagos";
            this.lblPagos.Size = new System.Drawing.Size(62, 25);
            this.lblPagos.TabIndex = 1;
            this.lblPagos.Text = "Pagos";
            // 
            // pnlSeparacion
            // 
            this.pnlSeparacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparacion.Location = new System.Drawing.Point(5, 55);
            this.pnlSeparacion.Name = "pnlSeparacion";
            this.pnlSeparacion.Size = new System.Drawing.Size(617, 24);
            this.pnlSeparacion.TabIndex = 9;
            // 
            // pnlInformacion
            // 
            this.pnlInformacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlInformacion.Controls.Add(this.lblInstruccion);
            this.pnlInformacion.Controls.Add(this.lblEstado);
            this.pnlInformacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInformacion.Location = new System.Drawing.Point(5, 79);
            this.pnlInformacion.Name = "pnlInformacion";
            this.pnlInformacion.Size = new System.Drawing.Size(617, 60);
            this.pnlInformacion.TabIndex = 10;
            // 
            // lblInstruccion
            // 
            this.lblInstruccion.AutoSize = true;
            this.lblInstruccion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruccion.ForeColor = System.Drawing.Color.White;
            this.lblInstruccion.Location = new System.Drawing.Point(56, 38);
            this.lblInstruccion.Name = "lblInstruccion";
            this.lblInstruccion.Size = new System.Drawing.Size(309, 13);
            this.lblInstruccion.TabIndex = 1;
            this.lblInstruccion.Text = "Agregue si un cliente ha pagado su deuda o desea abonar";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.White;
            this.lblEstado.Location = new System.Drawing.Point(53, 8);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(208, 25);
            this.lblEstado.TabIndex = 0;
            this.lblEstado.Text = "Agregue pago o abono";
            // 
            // pnlSeparacion2
            // 
            this.pnlSeparacion2.BackColor = System.Drawing.Color.White;
            this.pnlSeparacion2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparacion2.Location = new System.Drawing.Point(5, 139);
            this.pnlSeparacion2.Name = "pnlSeparacion2";
            this.pnlSeparacion2.Size = new System.Drawing.Size(617, 25);
            this.pnlSeparacion2.TabIndex = 11;
            // 
            // pnlIzquierda
            // 
            this.pnlIzquierda.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIzquierda.Location = new System.Drawing.Point(5, 164);
            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Size = new System.Drawing.Size(30, 296);
            this.pnlIzquierda.TabIndex = 25;
            // 
            // pnlDerecha
            // 
            this.pnlDerecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDerecha.Location = new System.Drawing.Point(592, 164);
            this.pnlDerecha.Name = "pnlDerecha";
            this.pnlDerecha.Size = new System.Drawing.Size(30, 296);
            this.pnlDerecha.TabIndex = 26;
            // 
            // KnudAño
            // 
            this.KnudAño.Location = new System.Drawing.Point(391, 42);
            this.KnudAño.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.KnudAño.Minimum = new decimal(new int[] {
            2026,
            0,
            0,
            0});
            this.KnudAño.Name = "KnudAño";
            this.KnudAño.Size = new System.Drawing.Size(123, 22);
            this.KnudAño.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.KnudAño.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KnudAño.TabIndex = 45;
            this.KnudAño.UpDownButtonStyle = Krypton.Toolkit.ButtonStyle.NavigatorMini;
            this.KnudAño.Value = new decimal(new int[] {
            2026,
            0,
            0,
            0});
            // 
            // KtxtFiltro
            // 
            this.KtxtFiltro.Location = new System.Drawing.Point(6, 42);
            this.KtxtFiltro.Name = "KtxtFiltro";
            this.KtxtFiltro.Size = new System.Drawing.Size(225, 23);
            this.KtxtFiltro.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtFiltro.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KtxtFiltro.TabIndex = 68;
            // 
            // KcmMes
            // 
            this.KcmMes.CornerRoundingRadius = -1F;
            this.KcmMes.DropButtonStyle = Krypton.Toolkit.ButtonStyle.NavigatorMini;
            this.KcmMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KcmMes.DropDownWidth = 179;
            this.KcmMes.IntegralHeight = false;
            this.KcmMes.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.KcmMes.Location = new System.Drawing.Point(241, 42);
            this.KcmMes.Name = "KcmMes";
            this.KcmMes.Size = new System.Drawing.Size(142, 21);
            this.KcmMes.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KcmMes.StateCommon.ComboBox.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KcmMes.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.KcmMes.StateCommon.DropBack.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.KcmMes.StateCommon.Item.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.KcmMes.StateCommon.Item.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.KcmMes.TabIndex = 70;
            // 
            // lblAño
            // 
            this.lblAño.AutoSize = true;
            this.lblAño.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAño.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblAño.Location = new System.Drawing.Point(411, 17);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(28, 13);
            this.lblAño.TabIndex = 19;
            this.lblAño.Text = "Año";
            this.lblAño.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblNombre.Location = new System.Drawing.Point(6, 17);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(112, 13);
            this.lblNombre.TabIndex = 12;
            this.lblNombre.Text = "Nombre y/o apellido";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblMes.Location = new System.Drawing.Point(259, 17);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(28, 13);
            this.lblMes.TabIndex = 14;
            this.lblMes.Text = "Mes";
            this.lblMes.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(7, 8);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(96, 25);
            this.btnEliminar.TabIndex = 43;
            this.btnEliminar.Text = "[ Supr ] Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // txtTrampa
            // 
            this.txtTrampa.BackColor = System.Drawing.Color.White;
            this.txtTrampa.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrampa.Location = new System.Drawing.Point(-100, -100);
            this.txtTrampa.Name = "txtTrampa";
            this.txtTrampa.Size = new System.Drawing.Size(25, 22);
            this.txtTrampa.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(121, 8);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(128, 25);
            this.btnActualizar.TabIndex = 44;
            this.btnActualizar.Text = "[ F6 ] Actualizar pago";
            this.btnActualizar.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.lblAño);
            this.panel1.Controls.Add(this.lblMes);
            this.panel1.Controls.Add(this.KnudAño);
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.KtxtFiltro);
            this.panel1.Controls.Add(this.KcmMes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(35, 164);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 71);
            this.panel1.TabIndex = 51;
            // 
            // pnlPaginacion
            // 
            this.pnlPaginacion.Controls.Add(this.lblPaginas);
            this.pnlPaginacion.Controls.Add(this.btnDelante);
            this.pnlPaginacion.Controls.Add(this.btnAtras);
            this.pnlPaginacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPaginacion.Location = new System.Drawing.Point(35, 235);
            this.pnlPaginacion.Name = "pnlPaginacion";
            this.pnlPaginacion.Size = new System.Drawing.Size(557, 32);
            this.pnlPaginacion.TabIndex = 52;
            // 
            // lblPaginas
            // 
            this.lblPaginas.AutoSize = true;
            this.lblPaginas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaginas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblPaginas.Location = new System.Drawing.Point(15, 11);
            this.lblPaginas.Name = "lblPaginas";
            this.lblPaginas.Size = new System.Drawing.Size(35, 17);
            this.lblPaginas.TabIndex = 31;
            this.lblPaginas.Text = "1 - 1";
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnWhatsApp);
            this.pnlBotones.Controls.Add(this.btnEliminar);
            this.pnlBotones.Controls.Add(this.btnActualizar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(35, 419);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(557, 41);
            this.pnlBotones.TabIndex = 53;
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
            this.ClmApellido,
            this.ClmCedula,
            this.ClmMonto,
            this.ClmMontoBs,
            this.ClmFecha,
            this.ClmEstado});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(190)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVDatos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dGVDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVDatos.EnableHeadersVisualStyles = false;
            this.dGVDatos.GridColor = System.Drawing.Color.DarkGray;
            this.dGVDatos.Location = new System.Drawing.Point(35, 267);
            this.dGVDatos.MultiSelect = false;
            this.dGVDatos.Name = "dGVDatos";
            this.dGVDatos.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dGVDatos.RowHeadersVisible = false;
            this.dGVDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVDatos.Size = new System.Drawing.Size(557, 152);
            this.dGVDatos.TabIndex = 54;
            // 
            // ClmNombre
            // 
            this.ClmNombre.DataPropertyName = "Nombre";
            this.ClmNombre.HeaderText = "Nombre";
            this.ClmNombre.Name = "ClmNombre";
            this.ClmNombre.ReadOnly = true;
            // 
            // ClmApellido
            // 
            this.ClmApellido.DataPropertyName = "Apellido";
            this.ClmApellido.HeaderText = "Apellido";
            this.ClmApellido.Name = "ClmApellido";
            this.ClmApellido.ReadOnly = true;
            // 
            // ClmCedula
            // 
            this.ClmCedula.HeaderText = "Cédula";
            this.ClmCedula.Name = "ClmCedula";
            this.ClmCedula.ReadOnly = true;
            // 
            // ClmMonto
            // 
            this.ClmMonto.HeaderText = "Monto";
            this.ClmMonto.Name = "ClmMonto";
            this.ClmMonto.ReadOnly = true;
            // 
            // ClmMontoBs
            // 
            this.ClmMontoBs.HeaderText = "Total Bs";
            this.ClmMontoBs.Name = "ClmMontoBs";
            this.ClmMontoBs.ReadOnly = true;
            // 
            // ClmFecha
            // 
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.ClmFecha.DefaultCellStyle = dataGridViewCellStyle2;
            this.ClmFecha.HeaderText = "Fecha";
            this.ClmFecha.Name = "ClmFecha";
            this.ClmFecha.ReadOnly = true;
            // 
            // ClmEstado
            // 
            this.ClmEstado.HeaderText = "Estado";
            this.ClmEstado.Name = "ClmEstado";
            this.ClmEstado.ReadOnly = true;
            // 
            // btnWhatsApp
            // 
            this.btnWhatsApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(161)))), ((int)(((byte)(107)))));
            this.btnWhatsApp.FlatAppearance.BorderSize = 0;
            this.btnWhatsApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWhatsApp.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWhatsApp.ForeColor = System.Drawing.Color.White;
            this.btnWhatsApp.Image = ((System.Drawing.Image)(resources.GetObject("btnWhatsApp.Image")));
            this.btnWhatsApp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWhatsApp.Location = new System.Drawing.Point(263, 8);
            this.btnWhatsApp.Name = "btnWhatsApp";
            this.btnWhatsApp.Size = new System.Drawing.Size(121, 25);
            this.btnWhatsApp.TabIndex = 46;
            this.btnWhatsApp.Text = "Enviar WhatsApp";
            this.btnWhatsApp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWhatsApp.UseVisualStyleBackColor = false;
            // 
            // btnDelante
            // 
            this.btnDelante.BackColor = System.Drawing.Color.Transparent;
            this.btnDelante.FlatAppearance.BorderSize = 0;
            this.btnDelante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelante.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelante.ForeColor = System.Drawing.Color.White;
            this.btnDelante.Image = ((System.Drawing.Image)(resources.GetObject("btnDelante.Image")));
            this.btnDelante.Location = new System.Drawing.Point(84, 5);
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
            this.btnAtras.Location = new System.Drawing.Point(48, 5);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(30, 25);
            this.btnAtras.TabIndex = 32;
            this.btnAtras.UseVisualStyleBackColor = false;
            // 
            // Pagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dGVDatos);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlPaginacion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtTrampa);
            this.Controls.Add(this.pnlDerecha);
            this.Controls.Add(this.pnlIzquierda);
            this.Controls.Add(this.pnlSeparacion2);
            this.Controls.Add(this.pnlInformacion);
            this.Controls.Add(this.pnlSeparacion);
            this.Controls.Add(this.pnlSuperior);
            this.DoubleBuffered = true;
            this.Name = "Pagos";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(627, 465);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlInformacion.ResumeLayout(false);
            this.pnlInformacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KcmMes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlPaginacion.ResumeLayout(false);
            this.pnlPaginacion.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblPagos;
        private System.Windows.Forms.Panel pnlSeparacion;
        private System.Windows.Forms.Panel pnlInformacion;
        private System.Windows.Forms.Label lblInstruccion;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Panel pnlSeparacion2;
        private System.Windows.Forms.Panel pnlIzquierda;
        private System.Windows.Forms.Panel pnlDerecha;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.Label lblAño;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox txtTrampa;
        private System.Windows.Forms.Button btnActualizar;
        private Krypton.Toolkit.KryptonComboBox KcmMes;
        private Krypton.Toolkit.KryptonTextBox KtxtFiltro;
        private Krypton.Toolkit.KryptonNumericUpDown KnudAño;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlPaginacion;
        private System.Windows.Forms.Label lblPaginas;
        private System.Windows.Forms.Button btnDelante;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.DataGridView dGVDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmMontoBs;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmEstado;
        private System.Windows.Forms.Button btnWhatsApp;
    }
}
