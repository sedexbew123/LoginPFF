namespace Presentacion.View.Forms
{
    partial class DatosConsultaDeuda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatosConsultaDeuda));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblDatosDeuda = new System.Windows.Forms.Label();
            this.pnlContenedorDatos = new System.Windows.Forms.Panel();
            this.dGVDatos = new System.Windows.Forms.DataGridView();
            this.ClmCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmProductos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblHistorial = new System.Windows.Forms.Label();
            this.pnlTiempo = new System.Windows.Forms.Panel();
            this.lblFechaLimite = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblMeses = new System.Windows.Forms.Label();
            this.lblMostrarMeses = new System.Windows.Forms.Label();
            this.pnlInformacion = new System.Windows.Forms.Panel();
            this.lblCedula = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblNombreMostrar = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblApellidoMostrar = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblCreditoMostrar = new System.Windows.Forms.Label();
            this.lblCedulaMostrar = new System.Windows.Forms.Label();
            this.pnlCarga = new System.Windows.Forms.Panel();
            this.picCarga = new System.Windows.Forms.PictureBox();
            this.pnlSuperior.SuspendLayout();
            this.pnlContenedorDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDatos)).BeginInit();
            this.pnlTiempo.SuspendLayout();
            this.pnlInformacion.SuspendLayout();
            this.pnlCarga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCarga)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlSuperior.Controls.Add(this.btnCerrar);
            this.pnlSuperior.Controls.Add(this.lblDatosDeuda);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(5, 5);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(403, 50);
            this.pnlSuperior.TabIndex = 22;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(77)))), ((int)(((byte)(117)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(77)))), ((int)(((byte)(117)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(372, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(24, 23);
            this.btnCerrar.TabIndex = 21;
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // lblDatosDeuda
            // 
            this.lblDatosDeuda.AutoSize = true;
            this.lblDatosDeuda.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosDeuda.ForeColor = System.Drawing.Color.White;
            this.lblDatosDeuda.Location = new System.Drawing.Point(100, 16);
            this.lblDatosDeuda.Name = "lblDatosDeuda";
            this.lblDatosDeuda.Size = new System.Drawing.Size(196, 19);
            this.lblDatosDeuda.TabIndex = 2;
            this.lblDatosDeuda.Text = "Datos de la Deuda";
            // 
            // pnlContenedorDatos
            // 
            this.pnlContenedorDatos.Controls.Add(this.dGVDatos);
            this.pnlContenedorDatos.Controls.Add(this.lblHistorial);
            this.pnlContenedorDatos.Controls.Add(this.pnlTiempo);
            this.pnlContenedorDatos.Controls.Add(this.pnlInformacion);
            this.pnlContenedorDatos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlContenedorDatos.Location = new System.Drawing.Point(5, 55);
            this.pnlContenedorDatos.Name = "pnlContenedorDatos";
            this.pnlContenedorDatos.Size = new System.Drawing.Size(403, 298);
            this.pnlContenedorDatos.TabIndex = 37;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dGVDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmCantidad,
            this.ClmProductos,
            this.ClmCategoria,
            this.ClmMonto,
            this.ClmFecha});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(190)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVDatos.DefaultCellStyle = dataGridViewCellStyle7;
            this.dGVDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVDatos.EnableHeadersVisualStyles = false;
            this.dGVDatos.Location = new System.Drawing.Point(0, 142);
            this.dGVDatos.Name = "dGVDatos";
            this.dGVDatos.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dGVDatos.RowHeadersVisible = false;
            this.dGVDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVDatos.Size = new System.Drawing.Size(403, 125);
            this.dGVDatos.TabIndex = 48;
            // 
            // ClmCantidad
            // 
            this.ClmCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ClmCantidad.HeaderText = "Cantidad";
            this.ClmCantidad.Name = "ClmCantidad";
            this.ClmCantidad.ReadOnly = true;
            this.ClmCantidad.Width = 87;
            // 
            // ClmProductos
            // 
            this.ClmProductos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClmProductos.HeaderText = "Producto";
            this.ClmProductos.Name = "ClmProductos";
            this.ClmProductos.ReadOnly = true;
            // 
            // ClmCategoria
            // 
            this.ClmCategoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ClmCategoria.HeaderText = "Categoría";
            this.ClmCategoria.Name = "ClmCategoria";
            this.ClmCategoria.ReadOnly = true;
            this.ClmCategoria.Width = 91;
            // 
            // ClmMonto
            // 
            this.ClmMonto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ClmMonto.HeaderText = "Monto";
            this.ClmMonto.Name = "ClmMonto";
            this.ClmMonto.ReadOnly = true;
            this.ClmMonto.Width = 73;
            // 
            // ClmFecha
            // 
            this.ClmFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ClmFecha.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.ClmFecha.DefaultCellStyle = dataGridViewCellStyle6;
            this.ClmFecha.HeaderText = "Fecha";
            this.ClmFecha.Name = "ClmFecha";
            this.ClmFecha.ReadOnly = true;
            this.ClmFecha.Width = 67;
            // 
            // lblHistorial
            // 
            this.lblHistorial.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHistorial.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistorial.Location = new System.Drawing.Point(0, 127);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(403, 15);
            this.lblHistorial.TabIndex = 46;
            this.lblHistorial.Text = "Detalles del Crédito";
            // 
            // pnlTiempo
            // 
            this.pnlTiempo.Controls.Add(this.pnlCarga);
            this.pnlTiempo.Controls.Add(this.lblFechaLimite);
            this.pnlTiempo.Controls.Add(this.lblFecha);
            this.pnlTiempo.Controls.Add(this.lblMeses);
            this.pnlTiempo.Controls.Add(this.lblMostrarMeses);
            this.pnlTiempo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTiempo.Location = new System.Drawing.Point(0, 267);
            this.pnlTiempo.Name = "pnlTiempo";
            this.pnlTiempo.Size = new System.Drawing.Size(403, 31);
            this.pnlTiempo.TabIndex = 46;
            // 
            // lblFechaLimite
            // 
            this.lblFechaLimite.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaLimite.Location = new System.Drawing.Point(317, 9);
            this.lblFechaLimite.Name = "lblFechaLimite";
            this.lblFechaLimite.Size = new System.Drawing.Size(73, 13);
            this.lblFechaLimite.TabIndex = 50;
            this.lblFechaLimite.Text = "Limite";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(243, 9);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(75, 13);
            this.lblFecha.TabIndex = 49;
            this.lblFecha.Text = "Fecha Límite:";
            // 
            // lblMeses
            // 
            this.lblMeses.AutoSize = true;
            this.lblMeses.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeses.Location = new System.Drawing.Point(7, 9);
            this.lblMeses.Name = "lblMeses";
            this.lblMeses.Size = new System.Drawing.Size(100, 13);
            this.lblMeses.TabIndex = 48;
            this.lblMeses.Text = "Tiempo sin Pagar:";
            // 
            // lblMostrarMeses
            // 
            this.lblMostrarMeses.AutoSize = true;
            this.lblMostrarMeses.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMostrarMeses.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMostrarMeses.Location = new System.Drawing.Point(112, 9);
            this.lblMostrarMeses.Name = "lblMostrarMeses";
            this.lblMostrarMeses.Size = new System.Drawing.Size(35, 13);
            this.lblMostrarMeses.TabIndex = 37;
            this.lblMostrarMeses.Text = "Label";
            // 
            // pnlInformacion
            // 
            this.pnlInformacion.Controls.Add(this.lblCedula);
            this.pnlInformacion.Controls.Add(this.lblNombre);
            this.pnlInformacion.Controls.Add(this.lblNombreMostrar);
            this.pnlInformacion.Controls.Add(this.lblApellido);
            this.pnlInformacion.Controls.Add(this.lblApellidoMostrar);
            this.pnlInformacion.Controls.Add(this.lblMonto);
            this.pnlInformacion.Controls.Add(this.lblCreditoMostrar);
            this.pnlInformacion.Controls.Add(this.lblCedulaMostrar);
            this.pnlInformacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInformacion.Location = new System.Drawing.Point(0, 0);
            this.pnlInformacion.Name = "pnlInformacion";
            this.pnlInformacion.Size = new System.Drawing.Size(403, 127);
            this.pnlInformacion.TabIndex = 44;
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCedula.Location = new System.Drawing.Point(210, 25);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(47, 15);
            this.lblCedula.TabIndex = 35;
            this.lblCedula.Text = "Cédula:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(12, 26);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(53, 13);
            this.lblNombre.TabIndex = 23;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblNombreMostrar
            // 
            this.lblNombreMostrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreMostrar.Location = new System.Drawing.Point(71, 16);
            this.lblNombreMostrar.Name = "lblNombreMostrar";
            this.lblNombreMostrar.Size = new System.Drawing.Size(133, 23);
            this.lblNombreMostrar.TabIndex = 29;
            this.lblNombreMostrar.Text = "label2";
            this.lblNombreMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.Location = new System.Drawing.Point(12, 57);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(54, 13);
            this.lblApellido.TabIndex = 28;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblApellidoMostrar
            // 
            this.lblApellidoMostrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellidoMostrar.Location = new System.Drawing.Point(72, 53);
            this.lblApellidoMostrar.Name = "lblApellidoMostrar";
            this.lblApellidoMostrar.Size = new System.Drawing.Size(133, 17);
            this.lblApellidoMostrar.TabIndex = 33;
            this.lblApellidoMostrar.Text = "label2";
            this.lblApellidoMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonto.Location = new System.Drawing.Point(12, 92);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(76, 13);
            this.lblMonto.TabIndex = 26;
            this.lblMonto.Text = "Crédito Total:";
            // 
            // lblCreditoMostrar
            // 
            this.lblCreditoMostrar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditoMostrar.Location = new System.Drawing.Point(212, 72);
            this.lblCreditoMostrar.Name = "lblCreditoMostrar";
            this.lblCreditoMostrar.Size = new System.Drawing.Size(191, 17);
            this.lblCreditoMostrar.TabIndex = 31;
            this.lblCreditoMostrar.Text = "label2";
            this.lblCreditoMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCedulaMostrar
            // 
            this.lblCedulaMostrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCedulaMostrar.Location = new System.Drawing.Point(262, 19);
            this.lblCedulaMostrar.Name = "lblCedulaMostrar";
            this.lblCedulaMostrar.Size = new System.Drawing.Size(149, 17);
            this.lblCedulaMostrar.TabIndex = 32;
            this.lblCedulaMostrar.Text = "label2";
            this.lblCedulaMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCarga
            // 
            this.pnlCarga.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlCarga.Controls.Add(this.picCarga);
            this.pnlCarga.Location = new System.Drawing.Point(226, 9);
            this.pnlCarga.Name = "pnlCarga";
            this.pnlCarga.Size = new System.Drawing.Size(410, 342);
            this.pnlCarga.TabIndex = 79;
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
            // DatosConsultaDeuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(413, 358);
            this.Controls.Add(this.pnlContenedorDatos);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "DatosConsultaDeuda";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DatosConsultaDeuda";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DatosConsultaDeuda_KeyDown);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlContenedorDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVDatos)).EndInit();
            this.pnlTiempo.ResumeLayout(false);
            this.pnlTiempo.PerformLayout();
            this.pnlInformacion.ResumeLayout(false);
            this.pnlInformacion.PerformLayout();
            this.pnlCarga.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCarga)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblDatosDeuda;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlContenedorDatos;
        private System.Windows.Forms.DataGridView dGVDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmFecha;
        private System.Windows.Forms.Label lblHistorial;
        private System.Windows.Forms.Panel pnlTiempo;
        private System.Windows.Forms.Label lblMeses;
        private System.Windows.Forms.Label lblMostrarMeses;
        private System.Windows.Forms.Panel pnlInformacion;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblNombreMostrar;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblApellidoMostrar;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblCreditoMostrar;
        private System.Windows.Forms.Label lblCedulaMostrar;
        private System.Windows.Forms.Panel pnlCarga;
        private System.Windows.Forms.PictureBox picCarga;
        private System.Windows.Forms.Label lblFechaLimite;
        private System.Windows.Forms.Label lblFecha;
    }
}