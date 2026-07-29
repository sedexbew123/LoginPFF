namespace Presentacion.View.Forms
{
    partial class NuevoServicio
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
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblEditarCliente = new System.Windows.Forms.Label();
            this.KcmbServicio = new Krypton.Toolkit.KryptonComboBox();
            this.KtxtApellido = new Krypton.Toolkit.KryptonTextBox();
            this.KtxtNombre = new Krypton.Toolkit.KryptonTextBox();
            this.KtxtCedula = new Krypton.Toolkit.KryptonTextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblCedula = new System.Windows.Forms.Label();
            this.lblServicio = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFechaLimite = new System.Windows.Forms.Label();
            this.dtpFechaLimite = new System.Windows.Forms.DateTimePicker();
            this.KbtnCancelar = new System.Windows.Forms.Button();
            this.KbtnRegistrar = new System.Windows.Forms.Button();
            this.KTxtMonto = new Krypton.Toolkit.KryptonTextBox();
            this.KtxtTotalPagarB = new Krypton.Toolkit.KryptonTextBox();
            this.lblTotalBolivares = new System.Windows.Forms.Label();
            this.chkCredito = new System.Windows.Forms.CheckBox();
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KcmbServicio)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlSuperior.Controls.Add(this.lblEditarCliente);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(5, 5);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(630, 50);
            this.pnlSuperior.TabIndex = 23;
            // 
            // lblEditarCliente
            // 
            this.lblEditarCliente.AutoSize = true;
            this.lblEditarCliente.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditarCliente.ForeColor = System.Drawing.Color.White;
            this.lblEditarCliente.Location = new System.Drawing.Point(228, 17);
            this.lblEditarCliente.Name = "lblEditarCliente";
            this.lblEditarCliente.Size = new System.Drawing.Size(163, 19);
            this.lblEditarCliente.TabIndex = 2;
            this.lblEditarCliente.Text = "Nuevo Servicio";
            // 
            // KcmbServicio
            // 
            this.KcmbServicio.CornerRoundingRadius = -1F;
            this.KcmbServicio.DropButtonStyle = Krypton.Toolkit.ButtonStyle.NavigatorMini;
            this.KcmbServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KcmbServicio.DropDownWidth = 179;
            this.KcmbServicio.IntegralHeight = false;
            this.KcmbServicio.Location = new System.Drawing.Point(29, 192);
            this.KcmbServicio.Name = "KcmbServicio";
            this.KcmbServicio.Size = new System.Drawing.Size(179, 21);
            this.KcmbServicio.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KcmbServicio.StateCommon.ComboBox.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KcmbServicio.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.KcmbServicio.StateCommon.DropBack.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.KcmbServicio.StateCommon.Item.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.KcmbServicio.StateCommon.Item.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.KcmbServicio.TabIndex = 82;
            // 
            // KtxtApellido
            // 
            this.KtxtApellido.Location = new System.Drawing.Point(435, 106);
            this.KtxtApellido.Name = "KtxtApellido";
            this.KtxtApellido.Size = new System.Drawing.Size(179, 23);
            this.KtxtApellido.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtApellido.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtApellido.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KtxtApellido.TabIndex = 81;
            // 
            // KtxtNombre
            // 
            this.KtxtNombre.Location = new System.Drawing.Point(237, 106);
            this.KtxtNombre.Name = "KtxtNombre";
            this.KtxtNombre.Size = new System.Drawing.Size(179, 23);
            this.KtxtNombre.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtNombre.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KtxtNombre.TabIndex = 80;
            // 
            // KtxtCedula
            // 
            this.KtxtCedula.Location = new System.Drawing.Point(29, 106);
            this.KtxtCedula.Name = "KtxtCedula";
            this.KtxtCedula.ReadOnly = true;
            this.KtxtCedula.Size = new System.Drawing.Size(179, 23);
            this.KtxtCedula.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtCedula.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KtxtCedula.TabIndex = 79;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblApellido.Location = new System.Drawing.Point(431, 71);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(75, 21);
            this.lblApellido.TabIndex = 78;
            this.lblApellido.Text = "Apellido";
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCedula.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblCedula.Location = new System.Drawing.Point(25, 71);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(63, 21);
            this.lblCedula.TabIndex = 77;
            this.lblCedula.Text = "Cédula";
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblServicio.Location = new System.Drawing.Point(25, 159);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(72, 21);
            this.lblServicio.TabIndex = 76;
            this.lblServicio.Text = "Servicio";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblMonto.Location = new System.Drawing.Point(233, 159);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(71, 21);
            this.lblMonto.TabIndex = 75;
            this.lblMonto.Text = "Precio $";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblFecha.Location = new System.Drawing.Point(25, 239);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(148, 21);
            this.lblFecha.TabIndex = 74;
            this.lblFecha.Text = "Fecha del Servicio";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblNombre.Location = new System.Drawing.Point(233, 71);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(73, 21);
            this.lblNombre.TabIndex = 73;
            this.lblNombre.Text = "Nombre";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(29, 274);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(179, 20);
            this.dtpFecha.TabIndex = 92;
            // 
            // lblFechaLimite
            // 
            this.lblFechaLimite.AutoSize = true;
            this.lblFechaLimite.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaLimite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblFechaLimite.Location = new System.Drawing.Point(431, 239);
            this.lblFechaLimite.Name = "lblFechaLimite";
            this.lblFechaLimite.Size = new System.Drawing.Size(106, 21);
            this.lblFechaLimite.TabIndex = 93;
            this.lblFechaLimite.Text = "Fecha Límite";
            this.lblFechaLimite.Visible = false;
            // 
            // dtpFechaLimite
            // 
            this.dtpFechaLimite.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaLimite.Location = new System.Drawing.Point(435, 271);
            this.dtpFechaLimite.Name = "dtpFechaLimite";
            this.dtpFechaLimite.Size = new System.Drawing.Size(179, 20);
            this.dtpFechaLimite.TabIndex = 94;
            this.dtpFechaLimite.Visible = false;
            // 
            // KbtnCancelar
            // 
            this.KbtnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.KbtnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.KbtnCancelar.FlatAppearance.BorderSize = 0;
            this.KbtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KbtnCancelar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KbtnCancelar.ForeColor = System.Drawing.Color.White;
            this.KbtnCancelar.Location = new System.Drawing.Point(183, 326);
            this.KbtnCancelar.Name = "KbtnCancelar";
            this.KbtnCancelar.Size = new System.Drawing.Size(108, 25);
            this.KbtnCancelar.TabIndex = 95;
            this.KbtnCancelar.Text = "[ Esc ] Cancelar";
            this.KbtnCancelar.UseVisualStyleBackColor = false;
            // 
            // KbtnRegistrar
            // 
            this.KbtnRegistrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.KbtnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.KbtnRegistrar.FlatAppearance.BorderSize = 0;
            this.KbtnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KbtnRegistrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KbtnRegistrar.ForeColor = System.Drawing.Color.White;
            this.KbtnRegistrar.Location = new System.Drawing.Point(360, 326);
            this.KbtnRegistrar.Name = "KbtnRegistrar";
            this.KbtnRegistrar.Size = new System.Drawing.Size(108, 25);
            this.KbtnRegistrar.TabIndex = 96;
            this.KbtnRegistrar.Text = "[ Enter ] Registrar";
            this.KbtnRegistrar.UseVisualStyleBackColor = false;
            // 
            // KTxtMonto
            // 
            this.KTxtMonto.Location = new System.Drawing.Point(233, 190);
            this.KTxtMonto.Name = "KTxtMonto";
            this.KTxtMonto.Size = new System.Drawing.Size(179, 23);
            this.KTxtMonto.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KTxtMonto.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KTxtMonto.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KTxtMonto.TabIndex = 97;
            // 
            // KtxtTotalPagarB
            // 
            this.KtxtTotalPagarB.Location = new System.Drawing.Point(435, 190);
            this.KtxtTotalPagarB.Name = "KtxtTotalPagarB";
            this.KtxtTotalPagarB.ReadOnly = true;
            this.KtxtTotalPagarB.Size = new System.Drawing.Size(179, 23);
            this.KtxtTotalPagarB.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtTotalPagarB.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KtxtTotalPagarB.TabIndex = 99;
            // 
            // lblTotalBolivares
            // 
            this.lblTotalBolivares.AutoSize = true;
            this.lblTotalBolivares.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBolivares.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblTotalBolivares.Location = new System.Drawing.Point(431, 159);
            this.lblTotalBolivares.Name = "lblTotalBolivares";
            this.lblTotalBolivares.Size = new System.Drawing.Size(79, 21);
            this.lblTotalBolivares.TabIndex = 98;
            this.lblTotalBolivares.Text = "Precio Bs";
            // 
            // chkCredito
            // 
            this.chkCredito.AutoSize = true;
            this.chkCredito.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCredito.Location = new System.Drawing.Point(237, 239);
            this.chkCredito.Name = "chkCredito";
            this.chkCredito.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.chkCredito.Size = new System.Drawing.Size(141, 25);
            this.chkCredito.TabIndex = 100;
            this.chkCredito.Text = "¿Dar crédito?";
            this.chkCredito.UseVisualStyleBackColor = true;
            // 
            // NuevoServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(640, 364);
            this.Controls.Add(this.chkCredito);
            this.Controls.Add(this.KtxtTotalPagarB);
            this.Controls.Add(this.lblTotalBolivares);
            this.Controls.Add(this.KTxtMonto);
            this.Controls.Add(this.KbtnRegistrar);
            this.Controls.Add(this.KbtnCancelar);
            this.Controls.Add(this.dtpFechaLimite);
            this.Controls.Add(this.lblFechaLimite);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.KcmbServicio);
            this.Controls.Add(this.KtxtApellido);
            this.Controls.Add(this.KtxtNombre);
            this.Controls.Add(this.KtxtCedula);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblCedula);
            this.Controls.Add(this.lblServicio);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NuevoServicio";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NuevoServicio";
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KcmbServicio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblEditarCliente;
        private Krypton.Toolkit.KryptonComboBox KcmbServicio;
        private Krypton.Toolkit.KryptonTextBox KtxtApellido;
        private Krypton.Toolkit.KryptonTextBox KtxtNombre;
        private Krypton.Toolkit.KryptonTextBox KtxtCedula;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFechaLimite;
        private System.Windows.Forms.DateTimePicker dtpFechaLimite;
        private System.Windows.Forms.Button KbtnCancelar;
        private System.Windows.Forms.Button KbtnRegistrar;
        private Krypton.Toolkit.KryptonTextBox KTxtMonto;
        private Krypton.Toolkit.KryptonTextBox KtxtTotalPagarB;
        private System.Windows.Forms.Label lblTotalBolivares;
        private System.Windows.Forms.CheckBox chkCredito;
    }
}