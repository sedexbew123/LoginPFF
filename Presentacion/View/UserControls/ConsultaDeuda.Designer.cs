namespace Presentacion.View.UserControls
{
    partial class ConsultaDeuda
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultaDeuda));
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblConsultaDeuda = new System.Windows.Forms.Label();
            this.pnlSeparacion = new System.Windows.Forms.Panel();
            this.pnlInformacion = new System.Windows.Forms.Panel();
            this.txtTrampa = new System.Windows.Forms.TextBox();
            this.lblInstruccion = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pnlSeparacion2 = new System.Windows.Forms.Panel();
            this.lblTotalProductos = new System.Windows.Forms.Label();
            this.lblCreditoTotal = new System.Windows.Forms.Label();
            this.lbTotallClientes = new System.Windows.Forms.Label();
            this.pnlIzquierda = new System.Windows.Forms.Panel();
            this.pnlDerecha = new System.Windows.Forms.Panel();
            this.lblCantidadProductos = new System.Windows.Forms.Label();
            this.lblCantidadCredito = new System.Windows.Forms.Label();
            this.lblCantidadClientes = new System.Windows.Forms.Label();
            this.lblFiltrar = new System.Windows.Forms.Label();
            this.pnlTextbox = new System.Windows.Forms.Panel();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.KcmbFiltro = new Krypton.Toolkit.KryptonComboBox();
            this.txtFiltrarClientes = new System.Windows.Forms.TextBox();
            this.pnlPaginacion = new System.Windows.Forms.Panel();
            this.lblPaginas = new System.Windows.Forms.Label();
            this.tLPlbl = new System.Windows.Forms.TableLayoutPanel();
            this.dGVDatos = new System.Windows.Forms.DataGridView();
            this.ClmNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmCedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmFechaLimite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnDelante = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.pnlSuperior.SuspendLayout();
            this.pnlInformacion.SuspendLayout();
            this.pnlTextbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KcmbFiltro)).BeginInit();
            this.pnlPaginacion.SuspendLayout();
            this.tLPlbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlSuperior.Controls.Add(this.lblConsultaDeuda);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(5, 5);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(600, 50);
            this.pnlSuperior.TabIndex = 2;
            // 
            // lblConsultaDeuda
            // 
            this.lblConsultaDeuda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblConsultaDeuda.AutoSize = true;
            this.lblConsultaDeuda.BackColor = System.Drawing.Color.Transparent;
            this.lblConsultaDeuda.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultaDeuda.ForeColor = System.Drawing.Color.White;
            this.lblConsultaDeuda.Location = new System.Drawing.Point(19, 23);
            this.lblConsultaDeuda.Name = "lblConsultaDeuda";
            this.lblConsultaDeuda.Size = new System.Drawing.Size(156, 25);
            this.lblConsultaDeuda.TabIndex = 1;
            this.lblConsultaDeuda.Text = "Estado de Deuda";
            // 
            // pnlSeparacion
            // 
            this.pnlSeparacion.BackColor = System.Drawing.Color.White;
            this.pnlSeparacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparacion.Location = new System.Drawing.Point(5, 55);
            this.pnlSeparacion.Name = "pnlSeparacion";
            this.pnlSeparacion.Size = new System.Drawing.Size(600, 24);
            this.pnlSeparacion.TabIndex = 3;
            // 
            // pnlInformacion
            // 
            this.pnlInformacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlInformacion.Controls.Add(this.txtTrampa);
            this.pnlInformacion.Controls.Add(this.lblInstruccion);
            this.pnlInformacion.Controls.Add(this.lblEstado);
            this.pnlInformacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInformacion.Location = new System.Drawing.Point(5, 79);
            this.pnlInformacion.Name = "pnlInformacion";
            this.pnlInformacion.Size = new System.Drawing.Size(600, 60);
            this.pnlInformacion.TabIndex = 4;
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
            this.lblInstruccion.Size = new System.Drawing.Size(148, 13);
            this.lblInstruccion.TabIndex = 1;
            this.lblInstruccion.Text = "Consulta las deudas activas";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.White;
            this.lblEstado.Location = new System.Drawing.Point(53, 8);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(69, 25);
            this.lblEstado.TabIndex = 0;
            this.lblEstado.Text = "Estado";
            // 
            // pnlSeparacion2
            // 
            this.pnlSeparacion2.BackColor = System.Drawing.Color.White;
            this.pnlSeparacion2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparacion2.Location = new System.Drawing.Point(5, 139);
            this.pnlSeparacion2.Name = "pnlSeparacion2";
            this.pnlSeparacion2.Size = new System.Drawing.Size(600, 25);
            this.pnlSeparacion2.TabIndex = 5;
            // 
            // lblTotalProductos
            // 
            this.lblTotalProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalProductos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(92)))), ((int)(((byte)(175)))));
            this.lblTotalProductos.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblTotalProductos.Location = new System.Drawing.Point(363, 33);
            this.lblTotalProductos.Name = "lblTotalProductos";
            this.lblTotalProductos.Size = new System.Drawing.Size(174, 26);
            this.lblTotalProductos.TabIndex = 0;
            this.lblTotalProductos.Text = "Total de Productos";
            this.lblTotalProductos.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCreditoTotal
            // 
            this.lblCreditoTotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCreditoTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditoTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(192)))), ((int)(((byte)(138)))));
            this.lblCreditoTotal.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblCreditoTotal.Location = new System.Drawing.Point(183, 33);
            this.lblCreditoTotal.Name = "lblCreditoTotal";
            this.lblCreditoTotal.Size = new System.Drawing.Size(174, 25);
            this.lblCreditoTotal.TabIndex = 1;
            this.lblCreditoTotal.Text = "Crédito Total";
            this.lblCreditoTotal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbTotallClientes
            // 
            this.lbTotallClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTotallClientes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotallClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(152)))), ((int)(((byte)(242)))));
            this.lbTotallClientes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbTotallClientes.Location = new System.Drawing.Point(3, 33);
            this.lbTotallClientes.Name = "lbTotallClientes";
            this.lbTotallClientes.Size = new System.Drawing.Size(174, 26);
            this.lbTotallClientes.TabIndex = 0;
            this.lbTotallClientes.Text = "Total de Clientes";
            this.lbTotallClientes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlIzquierda
            // 
            this.pnlIzquierda.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIzquierda.Location = new System.Drawing.Point(5, 164);
            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Size = new System.Drawing.Size(30, 305);
            this.pnlIzquierda.TabIndex = 24;
            // 
            // pnlDerecha
            // 
            this.pnlDerecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDerecha.Location = new System.Drawing.Point(575, 164);
            this.pnlDerecha.Name = "pnlDerecha";
            this.pnlDerecha.Size = new System.Drawing.Size(30, 305);
            this.pnlDerecha.TabIndex = 25;
            // 
            // lblCantidadProductos
            // 
            this.lblCantidadProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCantidadProductos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadProductos.Location = new System.Drawing.Point(363, 59);
            this.lblCantidadProductos.Name = "lblCantidadProductos";
            this.lblCantidadProductos.Size = new System.Drawing.Size(174, 26);
            this.lblCantidadProductos.TabIndex = 1;
            this.lblCantidadProductos.Text = "Productos Prestados";
            this.lblCantidadProductos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCantidadCredito
            // 
            this.lblCantidadCredito.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCantidadCredito.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadCredito.Location = new System.Drawing.Point(183, 59);
            this.lblCantidadCredito.Name = "lblCantidadCredito";
            this.lblCantidadCredito.Size = new System.Drawing.Size(174, 26);
            this.lblCantidadCredito.TabIndex = 2;
            this.lblCantidadCredito.Text = "Crédito Total";
            this.lblCantidadCredito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCantidadClientes
            // 
            this.lblCantidadClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCantidadClientes.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadClientes.Location = new System.Drawing.Point(3, 59);
            this.lblCantidadClientes.Name = "lblCantidadClientes";
            this.lblCantidadClientes.Size = new System.Drawing.Size(174, 26);
            this.lblCantidadClientes.TabIndex = 1;
            this.lblCantidadClientes.Text = "Total Clientes";
            this.lblCantidadClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFiltrar
            // 
            this.lblFiltrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltrar.Location = new System.Drawing.Point(10, 5);
            this.lblFiltrar.Name = "lblFiltrar";
            this.lblFiltrar.Size = new System.Drawing.Size(214, 26);
            this.lblFiltrar.TabIndex = 26;
            this.lblFiltrar.Text = "Buscar por nombre o descripción";
            this.lblFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTextbox
            // 
            this.pnlTextbox.Controls.Add(this.lblFiltro);
            this.pnlTextbox.Controls.Add(this.KcmbFiltro);
            this.pnlTextbox.Controls.Add(this.txtFiltrarClientes);
            this.pnlTextbox.Controls.Add(this.lblFiltrar);
            this.pnlTextbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTextbox.Location = new System.Drawing.Point(35, 164);
            this.pnlTextbox.Name = "pnlTextbox";
            this.pnlTextbox.Padding = new System.Windows.Forms.Padding(8);
            this.pnlTextbox.Size = new System.Drawing.Size(540, 76);
            this.pnlTextbox.TabIndex = 27;
            // 
            // lblFiltro
            // 
            this.lblFiltro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.Location = new System.Drawing.Point(377, 8);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(67, 26);
            this.lblFiltro.TabIndex = 74;
            this.lblFiltro.Text = "Filtrar ";
            this.lblFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KcmbFiltro
            // 
            this.KcmbFiltro.CornerRoundingRadius = -1F;
            this.KcmbFiltro.DropButtonStyle = Krypton.Toolkit.ButtonStyle.NavigatorMini;
            this.KcmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KcmbFiltro.DropDownWidth = 154;
            this.KcmbFiltro.IntegralHeight = false;
            this.KcmbFiltro.Items.AddRange(new object[] {
            "Mayor Deuda",
            "Menor Deuda",
            "Mayor Antiguedad",
            "Menor Antiguedad"});
            this.KcmbFiltro.Location = new System.Drawing.Point(380, 34);
            this.KcmbFiltro.Name = "KcmbFiltro";
            this.KcmbFiltro.Size = new System.Drawing.Size(152, 21);
            this.KcmbFiltro.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KcmbFiltro.StateCommon.ComboBox.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KcmbFiltro.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.KcmbFiltro.StateCommon.DropBack.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.KcmbFiltro.StateCommon.Item.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.KcmbFiltro.StateCommon.Item.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.KcmbFiltro.StateCommon.Item.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.KcmbFiltro.TabIndex = 73;
            // 
            // txtFiltrarClientes
            // 
            this.txtFiltrarClientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltrarClientes.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltrarClientes.Location = new System.Drawing.Point(8, 34);
            this.txtFiltrarClientes.Name = "txtFiltrarClientes";
            this.txtFiltrarClientes.Size = new System.Drawing.Size(360, 22);
            this.txtFiltrarClientes.TabIndex = 72;
            // 
            // pnlPaginacion
            // 
            this.pnlPaginacion.Controls.Add(this.lblPaginas);
            this.pnlPaginacion.Controls.Add(this.btnDelante);
            this.pnlPaginacion.Controls.Add(this.btnAtras);
            this.pnlPaginacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPaginacion.Location = new System.Drawing.Point(35, 240);
            this.pnlPaginacion.Name = "pnlPaginacion";
            this.pnlPaginacion.Size = new System.Drawing.Size(540, 32);
            this.pnlPaginacion.TabIndex = 50;
            // 
            // lblPaginas
            // 
            this.lblPaginas.AutoSize = true;
            this.lblPaginas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaginas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblPaginas.Location = new System.Drawing.Point(13, 11);
            this.lblPaginas.Name = "lblPaginas";
            this.lblPaginas.Size = new System.Drawing.Size(35, 17);
            this.lblPaginas.TabIndex = 31;
            this.lblPaginas.Text = "1 - 1";
            // 
            // tLPlbl
            // 
            this.tLPlbl.ColumnCount = 3;
            this.tLPlbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tLPlbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tLPlbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tLPlbl.Controls.Add(this.lblCantidadProductos, 2, 3);
            this.tLPlbl.Controls.Add(this.btnBuscar, 1, 0);
            this.tLPlbl.Controls.Add(this.lblTotalProductos, 2, 2);
            this.tLPlbl.Controls.Add(this.lbTotallClientes, 0, 2);
            this.tLPlbl.Controls.Add(this.lblCantidadCredito, 1, 3);
            this.tLPlbl.Controls.Add(this.lblCreditoTotal, 1, 2);
            this.tLPlbl.Controls.Add(this.lblCantidadClientes, 0, 3);
            this.tLPlbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tLPlbl.Location = new System.Drawing.Point(35, 381);
            this.tLPlbl.Name = "tLPlbl";
            this.tLPlbl.RowCount = 4;
            this.tLPlbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.66693F));
            this.tLPlbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.9992F));
            this.tLPlbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.66693F));
            this.tLPlbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.66693F));
            this.tLPlbl.Size = new System.Drawing.Size(540, 88);
            this.tLPlbl.TabIndex = 30;
            // 
            // dGVDatos
            // 
            this.dGVDatos.AllowUserToAddRows = false;
            this.dGVDatos.AllowUserToDeleteRows = false;
            this.dGVDatos.AllowUserToResizeColumns = false;
            this.dGVDatos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVDatos.BackgroundColor = System.Drawing.Color.White;
            this.dGVDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGVDatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dGVDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmNombre,
            this.ClmApellido,
            this.ClmCedula,
            this.ClmMonto,
            this.ClmFecha,
            this.ClmFechaLimite});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(190)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVDatos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dGVDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVDatos.EnableHeadersVisualStyles = false;
            this.dGVDatos.Location = new System.Drawing.Point(35, 272);
            this.dGVDatos.MultiSelect = false;
            this.dGVDatos.Name = "dGVDatos";
            this.dGVDatos.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dGVDatos.RowHeadersVisible = false;
            this.dGVDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVDatos.Size = new System.Drawing.Size(540, 109);
            this.dGVDatos.TabIndex = 51;
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
            // ClmCedula
            // 
            this.ClmCedula.HeaderText = "Cedula";
            this.ClmCedula.Name = "ClmCedula";
            this.ClmCedula.ReadOnly = true;
            // 
            // ClmMonto
            // 
            this.ClmMonto.HeaderText = "Monto";
            this.ClmMonto.Name = "ClmMonto";
            this.ClmMonto.ReadOnly = true;
            // 
            // ClmFecha
            // 
            this.ClmFecha.HeaderText = "Fecha";
            this.ClmFecha.Name = "ClmFecha";
            this.ClmFecha.ReadOnly = true;
            // 
            // ClmFechaLimite
            // 
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.ClmFechaLimite.DefaultCellStyle = dataGridViewCellStyle3;
            this.ClmFechaLimite.HeaderText = "Fecha Límite";
            this.ClmFechaLimite.Name = "ClmFechaLimite";
            this.ClmFechaLimite.ReadOnly = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(183, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(174, 20);
            this.btnBuscar.TabIndex = 30;
            this.btnBuscar.Text = "[ F6 ] Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // btnDelante
            // 
            this.btnDelante.BackColor = System.Drawing.Color.Transparent;
            this.btnDelante.FlatAppearance.BorderSize = 0;
            this.btnDelante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelante.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelante.ForeColor = System.Drawing.Color.White;
            this.btnDelante.Image = ((System.Drawing.Image)(resources.GetObject("btnDelante.Image")));
            this.btnDelante.Location = new System.Drawing.Point(82, 4);
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
            this.btnAtras.Location = new System.Drawing.Point(48, 4);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(30, 25);
            this.btnAtras.TabIndex = 32;
            this.btnAtras.UseVisualStyleBackColor = false;
            // 
            // ConsultaDeuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dGVDatos);
            this.Controls.Add(this.pnlPaginacion);
            this.Controls.Add(this.tLPlbl);
            this.Controls.Add(this.pnlTextbox);
            this.Controls.Add(this.pnlDerecha);
            this.Controls.Add(this.pnlIzquierda);
            this.Controls.Add(this.pnlSeparacion2);
            this.Controls.Add(this.pnlInformacion);
            this.Controls.Add(this.pnlSeparacion);
            this.Controls.Add(this.pnlSuperior);
            this.DoubleBuffered = true;
            this.Name = "ConsultaDeuda";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(610, 474);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlInformacion.ResumeLayout(false);
            this.pnlInformacion.PerformLayout();
            this.pnlTextbox.ResumeLayout(false);
            this.pnlTextbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KcmbFiltro)).EndInit();
            this.pnlPaginacion.ResumeLayout(false);
            this.pnlPaginacion.PerformLayout();
            this.tLPlbl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblConsultaDeuda;
        private System.Windows.Forms.Panel pnlSeparacion;
        private System.Windows.Forms.Panel pnlInformacion;
        private System.Windows.Forms.Label lblInstruccion;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Panel pnlSeparacion2;
        private System.Windows.Forms.Label lblTotalProductos;
        private System.Windows.Forms.Label lblCreditoTotal;
        private System.Windows.Forms.Label lbTotallClientes;
        private System.Windows.Forms.Panel pnlIzquierda;
        private System.Windows.Forms.Panel pnlDerecha;
        private System.Windows.Forms.Label lblFiltrar;
        private System.Windows.Forms.Label lblCantidadCredito;
        private System.Windows.Forms.Label lblCantidadProductos;
        private System.Windows.Forms.Label lblCantidadClientes;
        private System.Windows.Forms.Panel pnlTextbox;
        private System.Windows.Forms.Panel pnlPaginacion;
        private System.Windows.Forms.Label lblPaginas;
        private System.Windows.Forms.Button btnDelante;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.TextBox txtTrampa;
        private System.Windows.Forms.TableLayoutPanel tLPlbl;
        private System.Windows.Forms.DataGridView dGVDatos;
        private Krypton.Toolkit.KryptonComboBox KcmbFiltro;
        private System.Windows.Forms.TextBox txtFiltrarClientes;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmFechaLimite;
        private System.Windows.Forms.Button btnBuscar;
    }
}
