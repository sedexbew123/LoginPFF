namespace Presentacion.View.Forms
{
    partial class CambioMoneda
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
            this.lblCambioMoneda = new System.Windows.Forms.Label();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.lblValorBs = new System.Windows.Forms.Label();
            this.txtValorMoneda = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.KcmbMoneda = new Krypton.Toolkit.KryptonComboBox();
            this.txtTrampa = new System.Windows.Forms.TextBox();
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KcmbMoneda)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlSuperior.Controls.Add(this.lblCambioMoneda);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(5, 5);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(391, 50);
            this.pnlSuperior.TabIndex = 45;
            // 
            // lblCambioMoneda
            // 
            this.lblCambioMoneda.AutoSize = true;
            this.lblCambioMoneda.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambioMoneda.ForeColor = System.Drawing.Color.White;
            this.lblCambioMoneda.Location = new System.Drawing.Point(40, 18);
            this.lblCambioMoneda.Name = "lblCambioMoneda";
            this.lblCambioMoneda.Size = new System.Drawing.Size(317, 19);
            this.lblCambioMoneda.TabIndex = 1;
            this.lblCambioMoneda.Text = "Asigne el valor de su moneda";
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoneda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblMoneda.Location = new System.Drawing.Point(59, 87);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(73, 21);
            this.lblMoneda.TabIndex = 46;
            this.lblMoneda.Text = "Moneda";
            // 
            // lblValorBs
            // 
            this.lblValorBs.AutoSize = true;
            this.lblValorBs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorBs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblValorBs.Location = new System.Drawing.Point(59, 136);
            this.lblValorBs.Name = "lblValorBs";
            this.lblValorBs.Size = new System.Drawing.Size(71, 21);
            this.lblValorBs.TabIndex = 47;
            this.lblValorBs.Text = "Valor Bs";
            // 
            // txtValorMoneda
            // 
            this.txtValorMoneda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorMoneda.Location = new System.Drawing.Point(134, 132);
            this.txtValorMoneda.Name = "txtValorMoneda";
            this.txtValorMoneda.Size = new System.Drawing.Size(187, 20);
            this.txtValorMoneda.TabIndex = 49;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(77, 193);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 25);
            this.btnCancelar.TabIndex = 50;
            this.btnCancelar.Text = "[ Esc ] Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(221, 193);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(90, 25);
            this.btnEditar.TabIndex = 51;
            this.btnEditar.Text = "[ Enter ] Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            // 
            // KcmbMoneda
            // 
            this.KcmbMoneda.CornerRoundingRadius = -1F;
            this.KcmbMoneda.DropButtonStyle = Krypton.Toolkit.ButtonStyle.NavigatorMini;
            this.KcmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KcmbMoneda.DropDownWidth = 154;
            this.KcmbMoneda.IntegralHeight = false;
            this.KcmbMoneda.Location = new System.Drawing.Point(134, 82);
            this.KcmbMoneda.Name = "KcmbMoneda";
            this.KcmbMoneda.Size = new System.Drawing.Size(187, 21);
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
            // txtTrampa
            // 
            this.txtTrampa.Location = new System.Drawing.Point(-100, -100);
            this.txtTrampa.Name = "txtTrampa";
            this.txtTrampa.Size = new System.Drawing.Size(100, 20);
            this.txtTrampa.TabIndex = 0;
            // 
            // CambioMoneda
            // 
            this.AcceptButton = this.btnEditar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(401, 264);
            this.Controls.Add(this.txtTrampa);
            this.Controls.Add(this.KcmbMoneda);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtValorMoneda);
            this.Controls.Add(this.lblValorBs);
            this.Controls.Add(this.lblMoneda);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "CambioMoneda";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CambioMoneda";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CambioMoneda_KeyDown);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KcmbMoneda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblCambioMoneda;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.Label lblValorBs;
        private System.Windows.Forms.TextBox txtValorMoneda;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditar;
        private Krypton.Toolkit.KryptonComboBox KcmbMoneda;
        private System.Windows.Forms.TextBox txtTrampa;
    }
}