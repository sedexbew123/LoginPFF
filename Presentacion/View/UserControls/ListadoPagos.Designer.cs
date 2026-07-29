namespace Presentacion.View.UserControls
{
    partial class ListadoPagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoPagos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblListadoPagos = new System.Windows.Forms.Label();
            this.pnlSeparacion = new System.Windows.Forms.Panel();
            this.pnlInformacion = new System.Windows.Forms.Panel();
            this.txtTrampa = new System.Windows.Forms.TextBox();
            this.lblInstruccion = new System.Windows.Forms.Label();
            this.lblDeudas = new System.Windows.Forms.Label();
            this.pnlSeparacion2 = new System.Windows.Forms.Panel();
            this.pnlIzquierda = new System.Windows.Forms.Panel();
            this.pnlDerecha = new System.Windows.Forms.Panel();
            this.lblGanacias1 = new System.Windows.Forms.Label();
            this.lblUSD = new System.Windows.Forms.Label();
            this.lblGanacias2 = new System.Windows.Forms.Label();
            this.lblGanacias3 = new System.Windows.Forms.Label();
            this.lblEUR = new System.Windows.Forms.Label();
            this.lblBs = new System.Windows.Forms.Label();
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.lblAño = new System.Windows.Forms.Label();
            this.lblMes = new System.Windows.Forms.Label();
            this.KnudAño = new Krypton.Toolkit.KryptonNumericUpDown();
            this.lblNombre = new System.Windows.Forms.Label();
            this.KtxtFiltro = new Krypton.Toolkit.KryptonTextBox();
            this.KcmMes = new Krypton.Toolkit.KryptonComboBox();
            this.pnlPaginacion = new System.Windows.Forms.Panel();
            this.lblPaginas = new System.Windows.Forms.Label();
            this.btnDelante = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dGVDatos = new System.Windows.Forms.DataGridView();
            this.ClmNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmPagoBS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSuperior.SuspendLayout();
            this.pnlInformacion.SuspendLayout();
            this.pnlFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KcmMes)).BeginInit();
            this.pnlPaginacion.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlSuperior.Controls.Add(this.lblListadoPagos);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(5, 5);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(617, 50);
            this.pnlSuperior.TabIndex = 3;
            // 
            // lblListadoPagos
            // 
            this.lblListadoPagos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblListadoPagos.AutoSize = true;
            this.lblListadoPagos.BackColor = System.Drawing.Color.Transparent;
            this.lblListadoPagos.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListadoPagos.ForeColor = System.Drawing.Color.White;
            this.lblListadoPagos.Location = new System.Drawing.Point(19, 23);
            this.lblListadoPagos.Name = "lblListadoPagos";
            this.lblListadoPagos.Size = new System.Drawing.Size(157, 25);
            this.lblListadoPagos.TabIndex = 1;
            this.lblListadoPagos.Text = "Listado De Pagos";
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
            this.pnlInformacion.Controls.Add(this.txtTrampa);
            this.pnlInformacion.Controls.Add(this.lblInstruccion);
            this.pnlInformacion.Controls.Add(this.lblDeudas);
            this.pnlInformacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInformacion.Location = new System.Drawing.Point(5, 85);
            this.pnlInformacion.Name = "pnlInformacion";
            this.pnlInformacion.Size = new System.Drawing.Size(617, 60);
            this.pnlInformacion.TabIndex = 21;
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
            this.lblInstruccion.Size = new System.Drawing.Size(270, 13);
            this.lblInstruccion.TabIndex = 1;
            this.lblInstruccion.Text = "Visualiza todas las deudas pagadas en su totalidad";
            // 
            // lblDeudas
            // 
            this.lblDeudas.AutoSize = true;
            this.lblDeudas.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeudas.ForeColor = System.Drawing.Color.White;
            this.lblDeudas.Location = new System.Drawing.Point(53, 8);
            this.lblDeudas.Name = "lblDeudas";
            this.lblDeudas.Size = new System.Drawing.Size(159, 25);
            this.lblDeudas.TabIndex = 0;
            this.lblDeudas.Text = "Créditos Pagados";
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
            // lblGanacias1
            // 
            this.lblGanacias1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGanacias1.AutoSize = true;
            this.lblGanacias1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGanacias1.Image = ((System.Drawing.Image)(resources.GetObject("lblGanacias1.Image")));
            this.lblGanacias1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGanacias1.Location = new System.Drawing.Point(6, 11);
            this.lblGanacias1.Name = "lblGanacias1";
            this.lblGanacias1.Size = new System.Drawing.Size(178, 15);
            this.lblGanacias1.TabIndex = 43;
            this.lblGanacias1.Text = "         Ganancias Mensuales USD";
            // 
            // lblUSD
            // 
            this.lblUSD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUSD.AutoSize = true;
            this.lblUSD.Location = new System.Drawing.Point(68, 43);
            this.lblUSD.Name = "lblUSD";
            this.lblUSD.Size = new System.Drawing.Size(35, 13);
            this.lblUSD.TabIndex = 44;
            this.lblUSD.Text = "label1";
            // 
            // lblGanacias2
            // 
            this.lblGanacias2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGanacias2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGanacias2.Image = ((System.Drawing.Image)(resources.GetObject("lblGanacias2.Image")));
            this.lblGanacias2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGanacias2.Location = new System.Drawing.Point(196, 6);
            this.lblGanacias2.Name = "lblGanacias2";
            this.lblGanacias2.Size = new System.Drawing.Size(178, 24);
            this.lblGanacias2.TabIndex = 45;
            this.lblGanacias2.Text = "     Ganancias Mensuales Bs";
            this.lblGanacias2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGanacias3
            // 
            this.lblGanacias3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGanacias3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGanacias3.Image = ((System.Drawing.Image)(resources.GetObject("lblGanacias3.Image")));
            this.lblGanacias3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGanacias3.Location = new System.Drawing.Point(375, 6);
            this.lblGanacias3.Name = "lblGanacias3";
            this.lblGanacias3.Size = new System.Drawing.Size(178, 29);
            this.lblGanacias3.TabIndex = 46;
            this.lblGanacias3.Text = "       Ganancias Mensuales EUR";
            this.lblGanacias3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEUR
            // 
            this.lblEUR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEUR.AutoSize = true;
            this.lblEUR.Location = new System.Drawing.Point(445, 43);
            this.lblEUR.Name = "lblEUR";
            this.lblEUR.Size = new System.Drawing.Size(35, 13);
            this.lblEUR.TabIndex = 47;
            this.lblEUR.Text = "label3";
            // 
            // lblBs
            // 
            this.lblBs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBs.AutoSize = true;
            this.lblBs.Location = new System.Drawing.Point(261, 43);
            this.lblBs.Name = "lblBs";
            this.lblBs.Size = new System.Drawing.Size(35, 13);
            this.lblBs.TabIndex = 48;
            this.lblBs.Text = "label2";
            // 
            // pnlFiltro
            // 
            this.pnlFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlFiltro.Controls.Add(this.lblAño);
            this.pnlFiltro.Controls.Add(this.lblMes);
            this.pnlFiltro.Controls.Add(this.KnudAño);
            this.pnlFiltro.Controls.Add(this.lblNombre);
            this.pnlFiltro.Controls.Add(this.KtxtFiltro);
            this.pnlFiltro.Controls.Add(this.KcmMes);
            this.pnlFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltro.Location = new System.Drawing.Point(35, 175);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(557, 71);
            this.pnlFiltro.TabIndex = 52;
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
            // pnlPaginacion
            // 
            this.pnlPaginacion.Controls.Add(this.lblPaginas);
            this.pnlPaginacion.Controls.Add(this.btnDelante);
            this.pnlPaginacion.Controls.Add(this.btnAtras);
            this.pnlPaginacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPaginacion.Location = new System.Drawing.Point(35, 246);
            this.pnlPaginacion.Name = "pnlPaginacion";
            this.pnlPaginacion.Size = new System.Drawing.Size(557, 32);
            this.pnlPaginacion.TabIndex = 53;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.lblGanacias1);
            this.panel1.Controls.Add(this.lblUSD);
            this.panel1.Controls.Add(this.lblGanacias2);
            this.panel1.Controls.Add(this.lblBs);
            this.panel1.Controls.Add(this.lblEUR);
            this.panel1.Controls.Add(this.lblGanacias3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(35, 386);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 74);
            this.panel1.TabIndex = 55;
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
            this.ClmNombre,
            this.ClmApellido,
            this.ClmPago,
            this.ClmPagoBS,
            this.ClmFecha});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVDatos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dGVDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVDatos.EnableHeadersVisualStyles = false;
            this.dGVDatos.GridColor = System.Drawing.Color.DarkGray;
            this.dGVDatos.Location = new System.Drawing.Point(35, 278);
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
            this.dGVDatos.Size = new System.Drawing.Size(557, 108);
            this.dGVDatos.TabIndex = 56;
            // 
            // ClmNombre
            // 
            this.ClmNombre.HeaderText = "Nombre";
            this.ClmNombre.Name = "ClmNombre";
            this.ClmNombre.ReadOnly = true;
            // 
            // ClmApellido
            // 
            this.ClmApellido.HeaderText = "Apellido";
            this.ClmApellido.Name = "ClmApellido";
            this.ClmApellido.ReadOnly = true;
            // 
            // ClmPago
            // 
            this.ClmPago.HeaderText = "Pago";
            this.ClmPago.Name = "ClmPago";
            this.ClmPago.ReadOnly = true;
            // 
            // ClmPagoBS
            // 
            this.ClmPagoBS.HeaderText = "Pago Bs";
            this.ClmPagoBS.Name = "ClmPagoBS";
            this.ClmPagoBS.ReadOnly = true;
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
            // ListadoPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dGVDatos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlPaginacion);
            this.Controls.Add(this.pnlFiltro);
            this.Controls.Add(this.pnlDerecha);
            this.Controls.Add(this.pnlIzquierda);
            this.Controls.Add(this.pnlSeparacion2);
            this.Controls.Add(this.pnlInformacion);
            this.Controls.Add(this.pnlSeparacion);
            this.Controls.Add(this.pnlSuperior);
            this.Name = "ListadoPagos";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(627, 465);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlInformacion.ResumeLayout(false);
            this.pnlInformacion.PerformLayout();
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KcmMes)).EndInit();
            this.pnlPaginacion.ResumeLayout(false);
            this.pnlPaginacion.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblListadoPagos;
        private System.Windows.Forms.Panel pnlSeparacion;
        private System.Windows.Forms.Panel pnlInformacion;
        private System.Windows.Forms.TextBox txtTrampa;
        private System.Windows.Forms.Label lblInstruccion;
        private System.Windows.Forms.Label lblDeudas;
        private System.Windows.Forms.Panel pnlSeparacion2;
        private System.Windows.Forms.Panel pnlIzquierda;
        private System.Windows.Forms.Panel pnlDerecha;
        private System.Windows.Forms.Label lblGanacias1;
        private System.Windows.Forms.Label lblUSD;
        private System.Windows.Forms.Label lblGanacias2;
        private System.Windows.Forms.Label lblGanacias3;
        private System.Windows.Forms.Label lblEUR;
        private System.Windows.Forms.Label lblBs;
        private System.Windows.Forms.Panel pnlFiltro;
        private System.Windows.Forms.Label lblAño;
        private System.Windows.Forms.Label lblMes;
        private Krypton.Toolkit.KryptonNumericUpDown KnudAño;
        private System.Windows.Forms.Label lblNombre;
        private Krypton.Toolkit.KryptonTextBox KtxtFiltro;
        private Krypton.Toolkit.KryptonComboBox KcmMes;
        private System.Windows.Forms.Panel pnlPaginacion;
        private System.Windows.Forms.Label lblPaginas;
        private System.Windows.Forms.Button btnDelante;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dGVDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmPagoBS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmFecha;
    }
}
