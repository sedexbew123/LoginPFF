namespace Presentacion.View.Forms
{
    partial class NuevoProducto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevoProducto));
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.txtTrampa = new System.Windows.Forms.TextBox();
            this.lblNuevoProducto = new System.Windows.Forms.Label();
            this.pnlContenedorDatos = new System.Windows.Forms.Panel();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.CmbCategoria = new Krypton.Toolkit.KryptonComboBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblInformacionStock = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.nudStockActual = new Krypton.Toolkit.KryptonNumericUpDown();
            this.nudPrecio = new Krypton.Toolkit.KryptonNumericUpDown();
            this.lblStockActual = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblInformacionBasica = new System.Windows.Forms.Label();
            this.pnlCarga = new System.Windows.Forms.Panel();
            this.picCarga = new System.Windows.Forms.PictureBox();
            this.pnlSuperior.SuspendLayout();
            this.pnlContenedorDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbCategoria)).BeginInit();
            this.pnlCarga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCarga)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlSuperior.Controls.Add(this.txtTrampa);
            this.pnlSuperior.Controls.Add(this.lblNuevoProducto);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(3, 3);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(486, 50);
            this.pnlSuperior.TabIndex = 23;
            // 
            // txtTrampa
            // 
            this.txtTrampa.Location = new System.Drawing.Point(-100, -100);
            this.txtTrampa.Name = "txtTrampa";
            this.txtTrampa.Size = new System.Drawing.Size(100, 20);
            this.txtTrampa.TabIndex = 0;
            // 
            // lblNuevoProducto
            // 
            this.lblNuevoProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNuevoProducto.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNuevoProducto.ForeColor = System.Drawing.Color.White;
            this.lblNuevoProducto.Location = new System.Drawing.Point(0, 0);
            this.lblNuevoProducto.Name = "lblNuevoProducto";
            this.lblNuevoProducto.Size = new System.Drawing.Size(486, 50);
            this.lblNuevoProducto.TabIndex = 1;
            this.lblNuevoProducto.Text = "Nuevo Producto";
            this.lblNuevoProducto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContenedorDatos
            // 
            this.pnlContenedorDatos.Controls.Add(this.btnRegistrar);
            this.pnlContenedorDatos.Controls.Add(this.txtNombreProducto);
            this.pnlContenedorDatos.Controls.Add(this.btnCancelar);
            this.pnlContenedorDatos.Controls.Add(this.CmbCategoria);
            this.pnlContenedorDatos.Controls.Add(this.lblCodigo);
            this.pnlContenedorDatos.Controls.Add(this.lblNombreProducto);
            this.pnlContenedorDatos.Controls.Add(this.txtCodigo);
            this.pnlContenedorDatos.Controls.Add(this.lblInformacionStock);
            this.pnlContenedorDatos.Controls.Add(this.lblCategoria);
            this.pnlContenedorDatos.Controls.Add(this.nudStockActual);
            this.pnlContenedorDatos.Controls.Add(this.nudPrecio);
            this.pnlContenedorDatos.Controls.Add(this.lblStockActual);
            this.pnlContenedorDatos.Controls.Add(this.lblPrecio);
            this.pnlContenedorDatos.Controls.Add(this.lblInformacionBasica);
            this.pnlContenedorDatos.Location = new System.Drawing.Point(6, 59);
            this.pnlContenedorDatos.Name = "pnlContenedorDatos";
            this.pnlContenedorDatos.Size = new System.Drawing.Size(480, 266);
            this.pnlContenedorDatos.TabIndex = 24;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(262, 227);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(104, 23);
            this.btnRegistrar.TabIndex = 86;
            this.btnRegistrar.Text = "[ Enter ] Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.BackColor = System.Drawing.Color.White;
            this.txtNombreProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreProducto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreProducto.Location = new System.Drawing.Point(343, 66);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(120, 22);
            this.txtNombreProducto.TabIndex = 85;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(125, 228);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 23);
            this.btnCancelar.TabIndex = 87;
            this.btnCancelar.Text = "[ Esc ] Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // CmbCategoria
            // 
            this.CmbCategoria.CornerRoundingRadius = -1F;
            this.CmbCategoria.DropButtonStyle = Krypton.Toolkit.ButtonStyle.NavigatorMini;
            this.CmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCategoria.DropDownWidth = 154;
            this.CmbCategoria.IntegralHeight = false;
            this.CmbCategoria.Location = new System.Drawing.Point(185, 66);
            this.CmbCategoria.Name = "CmbCategoria";
            this.CmbCategoria.Size = new System.Drawing.Size(113, 21);
            this.CmbCategoria.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.CmbCategoria.StateCommon.ComboBox.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.CmbCategoria.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.CmbCategoria.StateCommon.DropBack.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.CmbCategoria.StateCommon.Item.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.CmbCategoria.StateCommon.Item.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.CmbCategoria.StateCommon.Item.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.CmbCategoria.TabIndex = 88;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblCodigo.Location = new System.Drawing.Point(340, 43);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(117, 13);
            this.lblCodigo.TabIndex = 81;
            this.lblCodigo.Text = "Nombre del Producto";
            this.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.BackColor = System.Drawing.Color.Transparent;
            this.lblNombreProducto.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblNombreProducto.Location = new System.Drawing.Point(24, 43);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(45, 13);
            this.lblNombreProducto.TabIndex = 77;
            this.lblNombreProducto.Text = "Código";
            this.lblNombreProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(23, 66);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(113, 22);
            this.txtCodigo.TabIndex = 84;
            // 
            // lblInformacionStock
            // 
            this.lblInformacionStock.AutoSize = true;
            this.lblInformacionStock.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformacionStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblInformacionStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInformacionStock.Location = new System.Drawing.Point(9, 108);
            this.lblInformacionStock.Name = "lblInformacionStock";
            this.lblInformacionStock.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.lblInformacionStock.Size = new System.Drawing.Size(145, 27);
            this.lblInformacionStock.TabIndex = 82;
            this.lblInformacionStock.Text = "Información del Stock";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblCategoria.Location = new System.Drawing.Point(182, 43);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(57, 13);
            this.lblCategoria.TabIndex = 79;
            this.lblCategoria.Text = "Categoría";
            this.lblCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudStockActual
            // 
            this.nudStockActual.AllowDecimals = true;
            this.nudStockActual.DecimalPlaces = 2;
            this.nudStockActual.Location = new System.Drawing.Point(185, 174);
            this.nudStockActual.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudStockActual.Name = "nudStockActual";
            this.nudStockActual.Size = new System.Drawing.Size(113, 22);
            this.nudStockActual.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.nudStockActual.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.nudStockActual.TabIndex = 90;
            this.nudStockActual.UpDownButtonStyle = Krypton.Toolkit.ButtonStyle.NavigatorMini;
            // 
            // nudPrecio
            // 
            this.nudPrecio.AllowDecimals = true;
            this.nudPrecio.DecimalPlaces = 2;
            this.nudPrecio.Location = new System.Drawing.Point(23, 174);
            this.nudPrecio.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudPrecio.Name = "nudPrecio";
            this.nudPrecio.Size = new System.Drawing.Size(113, 22);
            this.nudPrecio.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.nudPrecio.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.nudPrecio.TabIndex = 89;
            this.nudPrecio.UpDownButtonStyle = Krypton.Toolkit.ButtonStyle.NavigatorMini;
            // 
            // lblStockActual
            // 
            this.lblStockActual.AutoSize = true;
            this.lblStockActual.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblStockActual.Location = new System.Drawing.Point(182, 152);
            this.lblStockActual.Name = "lblStockActual";
            this.lblStockActual.Size = new System.Drawing.Size(69, 13);
            this.lblStockActual.TabIndex = 80;
            this.lblStockActual.Text = "Stock Actual";
            this.lblStockActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.BackColor = System.Drawing.Color.Transparent;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblPrecio.Location = new System.Drawing.Point(24, 152);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(38, 13);
            this.lblPrecio.TabIndex = 78;
            this.lblPrecio.Text = "Precio";
            this.lblPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInformacionBasica
            // 
            this.lblInformacionBasica.AutoSize = true;
            this.lblInformacionBasica.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformacionBasica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblInformacionBasica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInformacionBasica.Location = new System.Drawing.Point(9, 4);
            this.lblInformacionBasica.Name = "lblInformacionBasica";
            this.lblInformacionBasica.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.lblInformacionBasica.Size = new System.Drawing.Size(127, 27);
            this.lblInformacionBasica.TabIndex = 83;
            this.lblInformacionBasica.Text = "Información básica";
            // 
            // pnlCarga
            // 
            this.pnlCarga.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlCarga.Controls.Add(this.picCarga);
            this.pnlCarga.Location = new System.Drawing.Point(3, 56);
            this.pnlCarga.Name = "pnlCarga";
            this.pnlCarga.Size = new System.Drawing.Size(483, 266);
            this.pnlCarga.TabIndex = 91;
            this.pnlCarga.Visible = false;
            // 
            // picCarga
            // 
            this.picCarga.Image = ((System.Drawing.Image)(resources.GetObject("picCarga.Image")));
            this.picCarga.Location = new System.Drawing.Point(176, 79);
            this.picCarga.Name = "picCarga";
            this.picCarga.Size = new System.Drawing.Size(106, 92);
            this.picCarga.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCarga.TabIndex = 0;
            this.picCarga.TabStop = false;
            // 
            // NuevoProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(492, 331);
            this.Controls.Add(this.pnlCarga);
            this.Controls.Add(this.pnlContenedorDatos);
            this.Controls.Add(this.pnlSuperior);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "NuevoProducto";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NuevoProducto_KeyDown);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlContenedorDatos.ResumeLayout(false);
            this.pnlContenedorDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbCategoria)).EndInit();
            this.pnlCarga.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCarga)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblNuevoProducto;
        private System.Windows.Forms.TextBox txtTrampa;
        private System.Windows.Forms.Panel pnlContenedorDatos;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.Button btnCancelar;
        private Krypton.Toolkit.KryptonComboBox CmbCategoria;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblInformacionStock;
        private System.Windows.Forms.Label lblCategoria;
        private Krypton.Toolkit.KryptonNumericUpDown nudStockActual;
        private Krypton.Toolkit.KryptonNumericUpDown nudPrecio;
        private System.Windows.Forms.Label lblStockActual;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblInformacionBasica;
        private System.Windows.Forms.Panel pnlCarga;
        private System.Windows.Forms.PictureBox picCarga;
    }
}