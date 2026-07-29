namespace Presentacion.View.Forms
{
    partial class AgregarDeuda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarDeuda));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblAgregarDeuda = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.pnlContenedorDatos = new System.Windows.Forms.Panel();
            this.KbtnSeleccionar = new System.Windows.Forms.Button();
            this.KnudCantidad = new Krypton.Toolkit.KryptonNumericUpDown();
            this.KcmbCategoria = new Krypton.Toolkit.KryptonComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.dGVDatos = new System.Windows.Forms.DataGridView();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtFiltrar = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.KbtnCancelar = new System.Windows.Forms.Button();
            this.pnlCarga = new System.Windows.Forms.Panel();
            this.picCarga = new System.Windows.Forms.PictureBox();
            this.pnlSuperior.SuspendLayout();
            this.pnlContenedorDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KcmbCategoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDatos)).BeginInit();
            this.pnlCarga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCarga)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAgregarDeuda
            // 
            this.lblAgregarDeuda.AutoSize = true;
            this.lblAgregarDeuda.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgregarDeuda.ForeColor = System.Drawing.Color.White;
            this.lblAgregarDeuda.Location = new System.Drawing.Point(125, 16);
            this.lblAgregarDeuda.Name = "lblAgregarDeuda";
            this.lblAgregarDeuda.Size = new System.Drawing.Size(152, 19);
            this.lblAgregarDeuda.TabIndex = 2;
            this.lblAgregarDeuda.Text = "Agregar Deuda";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(77)))), ((int)(((byte)(117)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(77)))), ((int)(((byte)(117)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(371, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(24, 23);
            this.btnCerrar.TabIndex = 8;
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlSuperior.Controls.Add(this.btnCerrar);
            this.pnlSuperior.Controls.Add(this.lblAgregarDeuda);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(5, 5);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(403, 50);
            this.pnlSuperior.TabIndex = 21;
            // 
            // pnlContenedorDatos
            // 
            this.pnlContenedorDatos.Controls.Add(this.KbtnSeleccionar);
            this.pnlContenedorDatos.Controls.Add(this.KnudCantidad);
            this.pnlContenedorDatos.Controls.Add(this.KcmbCategoria);
            this.pnlContenedorDatos.Controls.Add(this.lblCantidad);
            this.pnlContenedorDatos.Controls.Add(this.dGVDatos);
            this.pnlContenedorDatos.Controls.Add(this.lblCategoria);
            this.pnlContenedorDatos.Controls.Add(this.txtFiltrar);
            this.pnlContenedorDatos.Controls.Add(this.lblNombre);
            this.pnlContenedorDatos.Controls.Add(this.KbtnCancelar);
            this.pnlContenedorDatos.Location = new System.Drawing.Point(9, 56);
            this.pnlContenedorDatos.Name = "pnlContenedorDatos";
            this.pnlContenedorDatos.Size = new System.Drawing.Size(401, 300);
            this.pnlContenedorDatos.TabIndex = 77;
            // 
            // KbtnSeleccionar
            // 
            this.KbtnSeleccionar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.KbtnSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.KbtnSeleccionar.FlatAppearance.BorderSize = 0;
            this.KbtnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KbtnSeleccionar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KbtnSeleccionar.ForeColor = System.Drawing.Color.White;
            this.KbtnSeleccionar.Location = new System.Drawing.Point(215, 270);
            this.KbtnSeleccionar.Name = "KbtnSeleccionar";
            this.KbtnSeleccionar.Size = new System.Drawing.Size(150, 23);
            this.KbtnSeleccionar.TabIndex = 5;
            this.KbtnSeleccionar.Text = "[ Enter ] Agregar";
            this.KbtnSeleccionar.UseVisualStyleBackColor = false;
            // 
            // KnudCantidad
            // 
            this.KnudCantidad.Location = new System.Drawing.Point(78, 75);
            this.KnudCantidad.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.KnudCantidad.Name = "KnudCantidad";
            this.KnudCantidad.Size = new System.Drawing.Size(121, 22);
            this.KnudCantidad.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.KnudCantidad.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KnudCantidad.TabIndex = 4;
            this.KnudCantidad.UpDownButtonStyle = Krypton.Toolkit.ButtonStyle.NavigatorMini;
            // 
            // KcmbCategoria
            // 
            this.KcmbCategoria.CornerRoundingRadius = -1F;
            this.KcmbCategoria.DropButtonStyle = Krypton.Toolkit.ButtonStyle.NavigatorMini;
            this.KcmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KcmbCategoria.DropDownWidth = 179;
            this.KcmbCategoria.IntegralHeight = false;
            this.KcmbCategoria.Items.AddRange(new object[] {
            "Completo",
            "Abono"});
            this.KcmbCategoria.Location = new System.Drawing.Point(78, 40);
            this.KcmbCategoria.Name = "KcmbCategoria";
            this.KcmbCategoria.Size = new System.Drawing.Size(194, 21);
            this.KcmbCategoria.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KcmbCategoria.StateCommon.ComboBox.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KcmbCategoria.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.KcmbCategoria.StateCommon.DropBack.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.KcmbCategoria.StateCommon.Item.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.KcmbCategoria.StateCommon.Item.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.KcmbCategoria.TabIndex = 3;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(15, 77);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(54, 13);
            this.lblCantidad.TabIndex = 78;
            this.lblCantidad.Text = "Cantidad";
            // 
            // dGVDatos
            // 
            this.dGVDatos.AllowUserToAddRows = false;
            this.dGVDatos.AllowUserToDeleteRows = false;
            this.dGVDatos.AllowUserToOrderColumns = true;
            this.dGVDatos.AllowUserToResizeColumns = false;
            this.dGVDatos.AllowUserToResizeRows = false;
            this.dGVDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(190)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVDatos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGVDatos.EnableHeadersVisualStyles = false;
            this.dGVDatos.GridColor = System.Drawing.Color.DarkGray;
            this.dGVDatos.Location = new System.Drawing.Point(7, 106);
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
            this.dGVDatos.Size = new System.Drawing.Size(386, 158);
            this.dGVDatos.TabIndex = 70;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(15, 44);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(57, 13);
            this.lblCategoria.TabIndex = 76;
            this.lblCategoria.Text = "Categoría";
            // 
            // txtFiltrar
            // 
            this.txtFiltrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltrar.Location = new System.Drawing.Point(78, 8);
            this.txtFiltrar.Name = "txtFiltrar";
            this.txtFiltrar.Size = new System.Drawing.Size(194, 20);
            this.txtFiltrar.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(15, 13);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(50, 13);
            this.lblNombre.TabIndex = 74;
            this.lblNombre.Text = "Nombre";
            // 
            // KbtnCancelar
            // 
            this.KbtnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.KbtnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.KbtnCancelar.FlatAppearance.BorderSize = 0;
            this.KbtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KbtnCancelar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KbtnCancelar.ForeColor = System.Drawing.Color.White;
            this.KbtnCancelar.Location = new System.Drawing.Point(35, 270);
            this.KbtnCancelar.Name = "KbtnCancelar";
            this.KbtnCancelar.Size = new System.Drawing.Size(150, 23);
            this.KbtnCancelar.TabIndex = 6;
            this.KbtnCancelar.Text = "[ Esc ] Cancelar";
            this.KbtnCancelar.UseVisualStyleBackColor = false;
            // 
            // pnlCarga
            // 
            this.pnlCarga.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlCarga.Controls.Add(this.picCarga);
            this.pnlCarga.Location = new System.Drawing.Point(0, 56);
            this.pnlCarga.Name = "pnlCarga";
            this.pnlCarga.Size = new System.Drawing.Size(410, 342);
            this.pnlCarga.TabIndex = 78;
            this.pnlCarga.Visible = false;
            // 
            // picCarga
            // 
            this.picCarga.Image = ((System.Drawing.Image)(resources.GetObject("picCarga.Image")));
            this.picCarga.Location = new System.Drawing.Point(146, 103);
            this.picCarga.Name = "picCarga";
            this.picCarga.Size = new System.Drawing.Size(106, 92);
            this.picCarga.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCarga.TabIndex = 0;
            this.picCarga.TabStop = false;
            // 
            // AgregarDeuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(413, 358);
            this.Controls.Add(this.pnlCarga);
            this.Controls.Add(this.pnlContenedorDatos);
            this.Controls.Add(this.pnlSuperior);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "AgregarDeuda";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgregarDeuda";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AgregarDeuda_KeyDown);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlContenedorDatos.ResumeLayout(false);
            this.pnlContenedorDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KcmbCategoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDatos)).EndInit();
            this.pnlCarga.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCarga)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAgregarDeuda;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Panel pnlContenedorDatos;
        private System.Windows.Forms.Button KbtnSeleccionar;
        private Krypton.Toolkit.KryptonNumericUpDown KnudCantidad;
        private Krypton.Toolkit.KryptonComboBox KcmbCategoria;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.DataGridView dGVDatos;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox txtFiltrar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button KbtnCancelar;
        private System.Windows.Forms.Panel pnlCarga;
        private System.Windows.Forms.PictureBox picCarga;
    }
}