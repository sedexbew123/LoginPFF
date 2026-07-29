namespace Presentacion.View.UserControls
{
    partial class InformacionUsuario
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformacionUsuario));
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.txtTrampa = new System.Windows.Forms.TextBox();
            this.lblInformacionUsuario = new System.Windows.Forms.Label();
            this.pnlSeparacion = new System.Windows.Forms.Panel();
            this.pnlInformacion = new System.Windows.Forms.Panel();
            this.lblInstruccion = new System.Windows.Forms.Label();
            this.lblPerfil = new System.Windows.Forms.Label();
            this.pnlSeparacion2 = new System.Windows.Forms.Panel();
            this.pnlIzquierda = new System.Windows.Forms.Panel();
            this.pnlDerecha = new System.Windows.Forms.Panel();
            this.pnlInformacionBasica = new System.Windows.Forms.Panel();
            this.tLPInformacionPersonal = new System.Windows.Forms.TableLayoutPanel();
            this.KtxtApellido = new Krypton.Toolkit.KryptonTextBox();
            this.KtxtNombre = new Krypton.Toolkit.KryptonTextBox();
            this.KtxtCedula = new Krypton.Toolkit.KryptonTextBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblInformacionBasica = new System.Windows.Forms.Label();
            this.pnlSeparacion3 = new System.Windows.Forms.Panel();
            this.tLPInformacionPersonal2 = new System.Windows.Forms.TableLayoutPanel();
            this.KtxtDireccion = new Krypton.Toolkit.KryptonTextBox();
            this.KtxtCorreo = new Krypton.Toolkit.KryptonTextBox();
            this.KtxtTelefono = new Krypton.Toolkit.KryptonTextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.pnlSeparacion4 = new System.Windows.Forms.Panel();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.llbCorreo = new System.Windows.Forms.LinkLabel();
            this.lblSoporte = new System.Windows.Forms.Label();
            this.btnPermisos = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnSoporte = new System.Windows.Forms.Button();
            this.cmsSoporte = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemReportarFalla = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSolicitarLicencia = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlSuperior.SuspendLayout();
            this.pnlInformacion.SuspendLayout();
            this.pnlInformacionBasica.SuspendLayout();
            this.tLPInformacionPersonal.SuspendLayout();
            this.tLPInformacionPersonal2.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.cmsSoporte.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlSuperior.Controls.Add(this.txtTrampa);
            this.pnlSuperior.Controls.Add(this.lblInformacionUsuario);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(5, 5);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(600, 50);
            this.pnlSuperior.TabIndex = 2;
            // 
            // txtTrampa
            // 
            this.txtTrampa.Location = new System.Drawing.Point(-100, -100);
            this.txtTrampa.Name = "txtTrampa";
            this.txtTrampa.Size = new System.Drawing.Size(100, 20);
            this.txtTrampa.TabIndex = 0;
            // 
            // lblInformacionUsuario
            // 
            this.lblInformacionUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInformacionUsuario.AutoSize = true;
            this.lblInformacionUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblInformacionUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformacionUsuario.ForeColor = System.Drawing.Color.White;
            this.lblInformacionUsuario.Location = new System.Drawing.Point(19, 23);
            this.lblInformacionUsuario.Name = "lblInformacionUsuario";
            this.lblInformacionUsuario.Size = new System.Drawing.Size(276, 25);
            this.lblInformacionUsuario.TabIndex = 1;
            this.lblInformacionUsuario.Text = "Información del Administrador";
            // 
            // pnlSeparacion
            // 
            this.pnlSeparacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparacion.Location = new System.Drawing.Point(5, 55);
            this.pnlSeparacion.Name = "pnlSeparacion";
            this.pnlSeparacion.Size = new System.Drawing.Size(600, 30);
            this.pnlSeparacion.TabIndex = 3;
            // 
            // pnlInformacion
            // 
            this.pnlInformacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlInformacion.Controls.Add(this.lblInstruccion);
            this.pnlInformacion.Controls.Add(this.lblPerfil);
            this.pnlInformacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInformacion.Location = new System.Drawing.Point(5, 85);
            this.pnlInformacion.Name = "pnlInformacion";
            this.pnlInformacion.Size = new System.Drawing.Size(600, 60);
            this.pnlInformacion.TabIndex = 4;
            // 
            // lblInstruccion
            // 
            this.lblInstruccion.AutoSize = true;
            this.lblInstruccion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruccion.ForeColor = System.Drawing.Color.White;
            this.lblInstruccion.Location = new System.Drawing.Point(56, 38);
            this.lblInstruccion.Name = "lblInstruccion";
            this.lblInstruccion.Size = new System.Drawing.Size(210, 13);
            this.lblInstruccion.TabIndex = 1;
            this.lblInstruccion.Text = "Los datos personales del Administrador";
            // 
            // lblPerfil
            // 
            this.lblPerfil.AutoSize = true;
            this.lblPerfil.BackColor = System.Drawing.Color.Transparent;
            this.lblPerfil.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerfil.ForeColor = System.Drawing.Color.White;
            this.lblPerfil.Location = new System.Drawing.Point(53, 8);
            this.lblPerfil.Name = "lblPerfil";
            this.lblPerfil.Size = new System.Drawing.Size(56, 25);
            this.lblPerfil.TabIndex = 0;
            this.lblPerfil.Text = "Perfil";
            // 
            // pnlSeparacion2
            // 
            this.pnlSeparacion2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparacion2.Location = new System.Drawing.Point(5, 145);
            this.pnlSeparacion2.Name = "pnlSeparacion2";
            this.pnlSeparacion2.Size = new System.Drawing.Size(600, 30);
            this.pnlSeparacion2.TabIndex = 5;
            // 
            // pnlIzquierda
            // 
            this.pnlIzquierda.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIzquierda.Location = new System.Drawing.Point(5, 175);
            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Size = new System.Drawing.Size(30, 340);
            this.pnlIzquierda.TabIndex = 6;
            // 
            // pnlDerecha
            // 
            this.pnlDerecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDerecha.Location = new System.Drawing.Point(575, 175);
            this.pnlDerecha.Name = "pnlDerecha";
            this.pnlDerecha.Size = new System.Drawing.Size(30, 340);
            this.pnlDerecha.TabIndex = 7;
            // 
            // pnlInformacionBasica
            // 
            this.pnlInformacionBasica.AutoSize = true;
            this.pnlInformacionBasica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlInformacionBasica.Controls.Add(this.tLPInformacionPersonal);
            this.pnlInformacionBasica.Controls.Add(this.lblInformacionBasica);
            this.pnlInformacionBasica.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInformacionBasica.Location = new System.Drawing.Point(35, 175);
            this.pnlInformacionBasica.Name = "pnlInformacionBasica";
            this.pnlInformacionBasica.Padding = new System.Windows.Forms.Padding(3);
            this.pnlInformacionBasica.Size = new System.Drawing.Size(540, 103);
            this.pnlInformacionBasica.TabIndex = 8;
            // 
            // tLPInformacionPersonal
            // 
            this.tLPInformacionPersonal.BackColor = System.Drawing.Color.Transparent;
            this.tLPInformacionPersonal.ColumnCount = 7;
            this.tLPInformacionPersonal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tLPInformacionPersonal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tLPInformacionPersonal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tLPInformacionPersonal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21F));
            this.tLPInformacionPersonal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tLPInformacionPersonal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21F));
            this.tLPInformacionPersonal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tLPInformacionPersonal.Controls.Add(this.KtxtApellido, 5, 1);
            this.tLPInformacionPersonal.Controls.Add(this.KtxtNombre, 3, 1);
            this.tLPInformacionPersonal.Controls.Add(this.KtxtCedula, 1, 1);
            this.tLPInformacionPersonal.Controls.Add(this.lblCedula, 1, 0);
            this.tLPInformacionPersonal.Controls.Add(this.lblApellido, 5, 0);
            this.tLPInformacionPersonal.Controls.Add(this.lblNombre, 3, 0);
            this.tLPInformacionPersonal.Dock = System.Windows.Forms.DockStyle.Top;
            this.tLPInformacionPersonal.Location = new System.Drawing.Point(3, 30);
            this.tLPInformacionPersonal.Name = "tLPInformacionPersonal";
            this.tLPInformacionPersonal.RowCount = 2;
            this.tLPInformacionPersonal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPInformacionPersonal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPInformacionPersonal.Size = new System.Drawing.Size(534, 70);
            this.tLPInformacionPersonal.TabIndex = 8;
            // 
            // KtxtApellido
            // 
            this.KtxtApellido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KtxtApellido.Location = new System.Drawing.Point(343, 38);
            this.KtxtApellido.Name = "KtxtApellido";
            this.KtxtApellido.ReadOnly = true;
            this.KtxtApellido.Size = new System.Drawing.Size(106, 23);
            this.KtxtApellido.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtApellido.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtApellido.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KtxtApellido.TabIndex = 31;
            // 
            // KtxtNombre
            // 
            this.KtxtNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KtxtNombre.Location = new System.Drawing.Point(205, 38);
            this.KtxtNombre.Name = "KtxtNombre";
            this.KtxtNombre.ReadOnly = true;
            this.KtxtNombre.Size = new System.Drawing.Size(106, 23);
            this.KtxtNombre.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtNombre.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KtxtNombre.TabIndex = 29;
            // 
            // KtxtCedula
            // 
            this.KtxtCedula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KtxtCedula.Location = new System.Drawing.Point(83, 38);
            this.KtxtCedula.Name = "KtxtCedula";
            this.KtxtCedula.ReadOnly = true;
            this.KtxtCedula.Size = new System.Drawing.Size(90, 23);
            this.KtxtCedula.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtCedula.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KtxtCedula.TabIndex = 22;
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.BackColor = System.Drawing.Color.Transparent;
            this.lblCedula.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCedula.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCedula.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblCedula.Location = new System.Drawing.Point(83, 22);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(90, 13);
            this.lblCedula.TabIndex = 0;
            this.lblCedula.Text = "Cédula ";
            this.lblCedula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblApellido.Location = new System.Drawing.Point(343, 22);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(106, 13);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido ";
            this.lblApellido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblNombre.Location = new System.Drawing.Point(205, 22);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(106, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre ";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInformacionBasica
            // 
            this.lblInformacionBasica.AutoSize = true;
            this.lblInformacionBasica.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInformacionBasica.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformacionBasica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblInformacionBasica.Image = ((System.Drawing.Image)(resources.GetObject("lblInformacionBasica.Image")));
            this.lblInformacionBasica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInformacionBasica.Location = new System.Drawing.Point(3, 3);
            this.lblInformacionBasica.Name = "lblInformacionBasica";
            this.lblInformacionBasica.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.lblInformacionBasica.Size = new System.Drawing.Size(145, 27);
            this.lblInformacionBasica.TabIndex = 2;
            this.lblInformacionBasica.Text = "       Datos Personales";
            // 
            // pnlSeparacion3
            // 
            this.pnlSeparacion3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparacion3.Location = new System.Drawing.Point(35, 278);
            this.pnlSeparacion3.Name = "pnlSeparacion3";
            this.pnlSeparacion3.Size = new System.Drawing.Size(540, 30);
            this.pnlSeparacion3.TabIndex = 9;
            // 
            // tLPInformacionPersonal2
            // 
            this.tLPInformacionPersonal2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.tLPInformacionPersonal2.ColumnCount = 7;
            this.tLPInformacionPersonal2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.00128F));
            this.tLPInformacionPersonal2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.99973F));
            this.tLPInformacionPersonal2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.999925F));
            this.tLPInformacionPersonal2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.99969F));
            this.tLPInformacionPersonal2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.999925F));
            this.tLPInformacionPersonal2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.99969F));
            this.tLPInformacionPersonal2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.99978F));
            this.tLPInformacionPersonal2.Controls.Add(this.KtxtDireccion, 5, 1);
            this.tLPInformacionPersonal2.Controls.Add(this.KtxtCorreo, 3, 1);
            this.tLPInformacionPersonal2.Controls.Add(this.KtxtTelefono, 1, 1);
            this.tLPInformacionPersonal2.Controls.Add(this.lblTelefono, 1, 0);
            this.tLPInformacionPersonal2.Controls.Add(this.lblDireccion, 5, 0);
            this.tLPInformacionPersonal2.Controls.Add(this.lblCorreo, 3, 0);
            this.tLPInformacionPersonal2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tLPInformacionPersonal2.Location = new System.Drawing.Point(35, 308);
            this.tLPInformacionPersonal2.Name = "tLPInformacionPersonal2";
            this.tLPInformacionPersonal2.RowCount = 2;
            this.tLPInformacionPersonal2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPInformacionPersonal2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPInformacionPersonal2.Size = new System.Drawing.Size(540, 70);
            this.tLPInformacionPersonal2.TabIndex = 10;
            // 
            // KtxtDireccion
            // 
            this.KtxtDireccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KtxtDireccion.Location = new System.Drawing.Point(346, 38);
            this.KtxtDireccion.Name = "KtxtDireccion";
            this.KtxtDireccion.ReadOnly = true;
            this.KtxtDireccion.Size = new System.Drawing.Size(107, 23);
            this.KtxtDireccion.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtDireccion.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KtxtDireccion.TabIndex = 52;
            // 
            // KtxtCorreo
            // 
            this.KtxtCorreo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.KtxtCorreo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KtxtCorreo.Location = new System.Drawing.Point(207, 38);
            this.KtxtCorreo.Name = "KtxtCorreo";
            this.KtxtCorreo.ReadOnly = true;
            this.KtxtCorreo.Size = new System.Drawing.Size(107, 23);
            this.KtxtCorreo.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtCorreo.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KtxtCorreo.TabIndex = 50;
            // 
            // KtxtTelefono
            // 
            this.KtxtTelefono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KtxtTelefono.Location = new System.Drawing.Point(84, 38);
            this.KtxtTelefono.Name = "KtxtTelefono";
            this.KtxtTelefono.ReadOnly = true;
            this.KtxtTelefono.Size = new System.Drawing.Size(91, 23);
            this.KtxtTelefono.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtTelefono.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KtxtTelefono.TabIndex = 48;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.BackColor = System.Drawing.Color.Transparent;
            this.lblTelefono.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblTelefono.Location = new System.Drawing.Point(84, 22);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(91, 13);
            this.lblTelefono.TabIndex = 0;
            this.lblTelefono.Text = "Teléfono ";
            this.lblTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblDireccion.Location = new System.Drawing.Point(346, 22);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(107, 13);
            this.lblDireccion.TabIndex = 2;
            this.lblDireccion.Text = "Dirección ";
            this.lblDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCorreo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblCorreo.Location = new System.Drawing.Point(207, 22);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(107, 13);
            this.lblCorreo.TabIndex = 1;
            this.lblCorreo.Text = "Correo ";
            this.lblCorreo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSeparacion4
            // 
            this.pnlSeparacion4.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparacion4.Location = new System.Drawing.Point(35, 378);
            this.pnlSeparacion4.Name = "pnlSeparacion4";
            this.pnlSeparacion4.Size = new System.Drawing.Size(540, 30);
            this.pnlSeparacion4.TabIndex = 13;
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnSoporte);
            this.pnlBotones.Controls.Add(this.llbCorreo);
            this.pnlBotones.Controls.Add(this.lblSoporte);
            this.pnlBotones.Controls.Add(this.btnPermisos);
            this.pnlBotones.Controls.Add(this.btnEditar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotones.Location = new System.Drawing.Point(35, 408);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(540, 104);
            this.pnlBotones.TabIndex = 16;
            // 
            // llbCorreo
            // 
            this.llbCorreo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.llbCorreo.AutoSize = true;
            this.llbCorreo.BackColor = System.Drawing.Color.Transparent;
            this.llbCorreo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbCorreo.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.llbCorreo.Location = new System.Drawing.Point(351, 28);
            this.llbCorreo.Name = "llbCorreo";
            this.llbCorreo.Size = new System.Drawing.Size(174, 17);
            this.llbCorreo.TabIndex = 25;
            this.llbCorreo.TabStop = true;
            this.llbCorreo.Text = "creditrack.oficial@gmail.com";
            // 
            // lblSoporte
            // 
            this.lblSoporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSoporte.AutoSize = true;
            this.lblSoporte.BackColor = System.Drawing.Color.Transparent;
            this.lblSoporte.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoporte.Location = new System.Drawing.Point(351, 4);
            this.lblSoporte.Name = "lblSoporte";
            this.lblSoporte.Size = new System.Drawing.Size(174, 17);
            this.lblSoporte.TabIndex = 24;
            this.lblSoporte.Text = "Reporte sus incidencias aqui";
            // 
            // btnPermisos
            // 
            this.btnPermisos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPermisos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(161)))), ((int)(((byte)(107)))));
            this.btnPermisos.FlatAppearance.BorderSize = 0;
            this.btnPermisos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPermisos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPermisos.ForeColor = System.Drawing.Color.White;
            this.btnPermisos.Location = new System.Drawing.Point(17, 60);
            this.btnPermisos.Name = "btnPermisos";
            this.btnPermisos.Size = new System.Drawing.Size(109, 25);
            this.btnPermisos.TabIndex = 21;
            this.btnPermisos.Text = "Aceptar Permisos";
            this.btnPermisos.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(155, 60);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(90, 25);
            this.btnEditar.TabIndex = 20;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnSoporte
            // 
            this.btnSoporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSoporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(161)))), ((int)(((byte)(107)))));
            this.btnSoporte.FlatAppearance.BorderSize = 0;
            this.btnSoporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoporte.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSoporte.ForeColor = System.Drawing.Color.White;
            this.btnSoporte.Image = ((System.Drawing.Image)(resources.GetObject("btnSoporte.Image")));
            this.btnSoporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSoporte.Location = new System.Drawing.Point(354, 62);
            this.btnSoporte.Name = "btnSoporte";
            this.btnSoporte.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnSoporte.Size = new System.Drawing.Size(171, 25);
            this.btnSoporte.TabIndex = 47;
            this.btnSoporte.Text = "Enviar WhatsApp";
            this.btnSoporte.UseVisualStyleBackColor = false;
            // 
            // cmsSoporte
            // 
            this.cmsSoporte.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemReportarFalla,
            this.itemSolicitarLicencia});
            this.cmsSoporte.Name = "cmsSoporte";
            this.cmsSoporte.Size = new System.Drawing.Size(264, 48);
            // 
            // itemReportarFalla
            // 
            this.itemReportarFalla.Name = "itemReportarFalla";
            this.itemReportarFalla.Size = new System.Drawing.Size(263, 22);
            this.itemReportarFalla.Text = "🛠️ Reportar una falla técnica";
            // 
            // itemSolicitarLicencia
            // 
            this.itemSolicitarLicencia.Name = "itemSolicitarLicencia";
            this.itemSolicitarLicencia.Size = new System.Drawing.Size(263, 22);
            this.itemSolicitarLicencia.Text = "💳 Solicitar datos de pago / Licencia";
            // 
            // InformacionUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlSeparacion4);
            this.Controls.Add(this.tLPInformacionPersonal2);
            this.Controls.Add(this.pnlSeparacion3);
            this.Controls.Add(this.pnlInformacionBasica);
            this.Controls.Add(this.pnlDerecha);
            this.Controls.Add(this.pnlIzquierda);
            this.Controls.Add(this.pnlSeparacion2);
            this.Controls.Add(this.pnlInformacion);
            this.Controls.Add(this.pnlSeparacion);
            this.Controls.Add(this.pnlSuperior);
            this.Name = "InformacionUsuario";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(610, 520);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlInformacion.ResumeLayout(false);
            this.pnlInformacion.PerformLayout();
            this.pnlInformacionBasica.ResumeLayout(false);
            this.pnlInformacionBasica.PerformLayout();
            this.tLPInformacionPersonal.ResumeLayout(false);
            this.tLPInformacionPersonal.PerformLayout();
            this.tLPInformacionPersonal2.ResumeLayout(false);
            this.tLPInformacionPersonal2.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.pnlBotones.PerformLayout();
            this.cmsSoporte.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblInformacionUsuario;
        private System.Windows.Forms.Panel pnlSeparacion;
        private System.Windows.Forms.Panel pnlInformacion;
        private System.Windows.Forms.Label lblInstruccion;
        private System.Windows.Forms.Label lblPerfil;
        private System.Windows.Forms.Panel pnlSeparacion2;
        private System.Windows.Forms.Panel pnlIzquierda;
        private System.Windows.Forms.Panel pnlDerecha;
        private System.Windows.Forms.Panel pnlInformacionBasica;
        private System.Windows.Forms.TableLayoutPanel tLPInformacionPersonal;
        private System.Windows.Forms.Label lblInformacionBasica;
        private System.Windows.Forms.Panel pnlSeparacion3;
        private System.Windows.Forms.TableLayoutPanel tLPInformacionPersonal2;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Panel pnlSeparacion4;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Label lblNombre;
        private Krypton.Toolkit.KryptonTextBox KtxtNombre;
        private Krypton.Toolkit.KryptonTextBox KtxtApellido;
        private Krypton.Toolkit.KryptonTextBox KtxtTelefono;
        private Krypton.Toolkit.KryptonTextBox KtxtCorreo;
        private Krypton.Toolkit.KryptonTextBox KtxtDireccion;
        private Krypton.Toolkit.KryptonTextBox KtxtCedula;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.TextBox txtTrampa;
        private System.Windows.Forms.Button btnPermisos;
        private System.Windows.Forms.LinkLabel llbCorreo;
        private System.Windows.Forms.Label lblSoporte;
        private System.Windows.Forms.Button btnSoporte;
        private System.Windows.Forms.ContextMenuStrip cmsSoporte;
        private System.Windows.Forms.ToolStripMenuItem itemReportarFalla;
        private System.Windows.Forms.ToolStripMenuItem itemSolicitarLicencia;
    }
}
