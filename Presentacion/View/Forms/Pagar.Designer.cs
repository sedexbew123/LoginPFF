namespace Presentacion.View.Forms
{
    partial class Pagar
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
            this.lblRegistroPago = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTotalBolivares = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.lblPago = new System.Windows.Forms.Label();
            this.lblCedula = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.KtxtCedula = new Krypton.Toolkit.KryptonTextBox();
            this.KtxtNombre = new Krypton.Toolkit.KryptonTextBox();
            this.KtxtApellido = new Krypton.Toolkit.KryptonTextBox();
            this.KcmbPago = new Krypton.Toolkit.KryptonComboBox();
            this.KcmbMoneda = new Krypton.Toolkit.KryptonComboBox();
            this.KtxtTotalPagar = new Krypton.Toolkit.KryptonTextBox();
            this.KtxtTotalPagarB = new Krypton.Toolkit.KryptonTextBox();
            this.txtTrampa = new System.Windows.Forms.TextBox();
            this.KbtnRegistrar = new System.Windows.Forms.Button();
            this.KbtnCancelar = new System.Windows.Forms.Button();
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KcmbPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KcmbMoneda)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlSuperior.Controls.Add(this.lblRegistroPago);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(5, 5);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(630, 50);
            this.pnlSuperior.TabIndex = 46;
            // 
            // lblRegistroPago
            // 
            this.lblRegistroPago.AutoSize = true;
            this.lblRegistroPago.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistroPago.ForeColor = System.Drawing.Color.White;
            this.lblRegistroPago.Location = new System.Drawing.Point(237, 14);
            this.lblRegistroPago.Name = "lblRegistroPago";
            this.lblRegistroPago.Size = new System.Drawing.Size(185, 19);
            this.lblRegistroPago.TabIndex = 1;
            this.lblRegistroPago.Text = "Registro de Pago";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblNombre.Location = new System.Drawing.Point(36, 74);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(73, 21);
            this.lblNombre.TabIndex = 48;
            this.lblNombre.Text = "Nombre";
            // 
            // lblTotalBolivares
            // 
            this.lblTotalBolivares.AutoSize = true;
            this.lblTotalBolivares.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBolivares.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblTotalBolivares.Location = new System.Drawing.Point(36, 228);
            this.lblTotalBolivares.Name = "lblTotalBolivares";
            this.lblTotalBolivares.Size = new System.Drawing.Size(161, 21);
            this.lblTotalBolivares.TabIndex = 51;
            this.lblTotalBolivares.Text = "Conversion de Total";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblTotal.Location = new System.Drawing.Point(442, 152);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(109, 21);
            this.lblTotal.TabIndex = 52;
            this.lblTotal.Text = "Total a Pagar";
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoneda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblMoneda.Location = new System.Drawing.Point(238, 152);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(73, 21);
            this.lblMoneda.TabIndex = 53;
            this.lblMoneda.Text = "Moneda";
            // 
            // lblPago
            // 
            this.lblPago.AutoSize = true;
            this.lblPago.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblPago.Location = new System.Drawing.Point(36, 152);
            this.lblPago.Name = "lblPago";
            this.lblPago.Size = new System.Drawing.Size(49, 21);
            this.lblPago.TabIndex = 54;
            this.lblPago.Text = "Pago";
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCedula.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblCedula.Location = new System.Drawing.Point(442, 74);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(63, 21);
            this.lblCedula.TabIndex = 55;
            this.lblCedula.Text = "Cédula";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblApellido.Location = new System.Drawing.Point(236, 74);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(75, 21);
            this.lblApellido.TabIndex = 56;
            this.lblApellido.Text = "Apellido";
            // 
            // KtxtCedula
            // 
            this.KtxtCedula.Location = new System.Drawing.Point(441, 103);
            this.KtxtCedula.Name = "KtxtCedula";
            this.KtxtCedula.ReadOnly = true;
            this.KtxtCedula.Size = new System.Drawing.Size(154, 23);
            this.KtxtCedula.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtCedula.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KtxtCedula.TabIndex = 66;
            // 
            // KtxtNombre
            // 
            this.KtxtNombre.Location = new System.Drawing.Point(35, 103);
            this.KtxtNombre.Name = "KtxtNombre";
            this.KtxtNombre.ReadOnly = true;
            this.KtxtNombre.Size = new System.Drawing.Size(179, 23);
            this.KtxtNombre.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtNombre.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KtxtNombre.TabIndex = 67;
            // 
            // KtxtApellido
            // 
            this.KtxtApellido.Location = new System.Drawing.Point(237, 103);
            this.KtxtApellido.Name = "KtxtApellido";
            this.KtxtApellido.ReadOnly = true;
            this.KtxtApellido.Size = new System.Drawing.Size(179, 23);
            this.KtxtApellido.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtApellido.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtApellido.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KtxtApellido.TabIndex = 68;
            // 
            // KcmbPago
            // 
            this.KcmbPago.CornerRoundingRadius = -1F;
            this.KcmbPago.DropButtonStyle = Krypton.Toolkit.ButtonStyle.NavigatorMini;
            this.KcmbPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KcmbPago.DropDownWidth = 179;
            this.KcmbPago.IntegralHeight = false;
            this.KcmbPago.Items.AddRange(new object[] {
            "Completo",
            "Abono"});
            this.KcmbPago.Location = new System.Drawing.Point(35, 184);
            this.KcmbPago.Name = "KcmbPago";
            this.KcmbPago.Size = new System.Drawing.Size(179, 21);
            this.KcmbPago.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KcmbPago.StateCommon.ComboBox.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KcmbPago.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.KcmbPago.StateCommon.DropBack.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.KcmbPago.StateCommon.Item.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.KcmbPago.StateCommon.Item.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.KcmbPago.TabIndex = 69;
            // 
            // KcmbMoneda
            // 
            this.KcmbMoneda.CornerRoundingRadius = -1F;
            this.KcmbMoneda.DropButtonStyle = Krypton.Toolkit.ButtonStyle.NavigatorMini;
            this.KcmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KcmbMoneda.DropDownWidth = 154;
            this.KcmbMoneda.IntegralHeight = false;
            this.KcmbMoneda.Items.AddRange(new object[] {
            "Euro",
            "Dolar"});
            this.KcmbMoneda.Location = new System.Drawing.Point(237, 184);
            this.KcmbMoneda.Name = "KcmbMoneda";
            this.KcmbMoneda.Size = new System.Drawing.Size(179, 21);
            this.KcmbMoneda.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KcmbMoneda.StateCommon.ComboBox.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KcmbMoneda.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.KcmbMoneda.StateCommon.DropBack.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.KcmbMoneda.StateCommon.Item.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.KcmbMoneda.StateCommon.Item.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.KcmbMoneda.TabIndex = 70;
            // 
            // KtxtTotalPagar
            // 
            this.KtxtTotalPagar.Location = new System.Drawing.Point(441, 182);
            this.KtxtTotalPagar.Name = "KtxtTotalPagar";
            this.KtxtTotalPagar.Size = new System.Drawing.Size(154, 23);
            this.KtxtTotalPagar.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtTotalPagar.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KtxtTotalPagar.TabIndex = 72;
            // 
            // KtxtTotalPagarB
            // 
            this.KtxtTotalPagarB.Location = new System.Drawing.Point(35, 258);
            this.KtxtTotalPagarB.Name = "KtxtTotalPagarB";
            this.KtxtTotalPagarB.ReadOnly = true;
            this.KtxtTotalPagarB.Size = new System.Drawing.Size(179, 23);
            this.KtxtTotalPagarB.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtTotalPagarB.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KtxtTotalPagarB.TabIndex = 73;
            // 
            // txtTrampa
            // 
            this.txtTrampa.Location = new System.Drawing.Point(-100, -100);
            this.txtTrampa.Name = "txtTrampa";
            this.txtTrampa.Size = new System.Drawing.Size(100, 20);
            this.txtTrampa.TabIndex = 0;
            // 
            // KbtnRegistrar
            // 
            this.KbtnRegistrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.KbtnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.KbtnRegistrar.FlatAppearance.BorderSize = 0;
            this.KbtnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KbtnRegistrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KbtnRegistrar.ForeColor = System.Drawing.Color.White;
            this.KbtnRegistrar.Location = new System.Drawing.Point(373, 310);
            this.KbtnRegistrar.Name = "KbtnRegistrar";
            this.KbtnRegistrar.Size = new System.Drawing.Size(108, 25);
            this.KbtnRegistrar.TabIndex = 76;
            this.KbtnRegistrar.Text = "[ Enter ] Pagar";
            this.KbtnRegistrar.UseVisualStyleBackColor = false;
            // 
            // KbtnCancelar
            // 
            this.KbtnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.KbtnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.KbtnCancelar.FlatAppearance.BorderSize = 0;
            this.KbtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KbtnCancelar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KbtnCancelar.ForeColor = System.Drawing.Color.White;
            this.KbtnCancelar.Location = new System.Drawing.Point(188, 310);
            this.KbtnCancelar.Name = "KbtnCancelar";
            this.KbtnCancelar.Size = new System.Drawing.Size(108, 25);
            this.KbtnCancelar.TabIndex = 77;
            this.KbtnCancelar.Text = "[ Esc ] Cancelar";
            this.KbtnCancelar.UseVisualStyleBackColor = false;
            // 
            // Pagar
            // 
            this.AcceptButton = this.KbtnRegistrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(640, 364);
            this.Controls.Add(this.KbtnCancelar);
            this.Controls.Add(this.KbtnRegistrar);
            this.Controls.Add(this.txtTrampa);
            this.Controls.Add(this.KtxtTotalPagarB);
            this.Controls.Add(this.KtxtTotalPagar);
            this.Controls.Add(this.KcmbMoneda);
            this.Controls.Add(this.KcmbPago);
            this.Controls.Add(this.KtxtApellido);
            this.Controls.Add(this.KtxtNombre);
            this.Controls.Add(this.KtxtCedula);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblCedula);
            this.Controls.Add(this.lblPago);
            this.Controls.Add(this.lblMoneda);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTotalBolivares);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Pagar";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagar";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pagar_KeyDown);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KcmbPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KcmbMoneda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblRegistroPago;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTotalBolivares;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.Label lblPago;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.Label lblApellido;
        private Krypton.Toolkit.KryptonTextBox KtxtCedula;
        private Krypton.Toolkit.KryptonTextBox KtxtNombre;
        private Krypton.Toolkit.KryptonTextBox KtxtApellido;
        private Krypton.Toolkit.KryptonComboBox KcmbPago;
        private Krypton.Toolkit.KryptonComboBox KcmbMoneda;
        private Krypton.Toolkit.KryptonTextBox KtxtTotalPagar;
        private Krypton.Toolkit.KryptonTextBox KtxtTotalPagarB;
        private System.Windows.Forms.TextBox txtTrampa;
        private System.Windows.Forms.Button KbtnRegistrar;
        private System.Windows.Forms.Button KbtnCancelar;
    }
}