namespace Presentacion.View.Forms
{
    partial class CambiarContraseña
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambiarContraseña));
            this.lblContraseñaActual = new System.Windows.Forms.Label();
            this.lblCambiarContraseña = new System.Windows.Forms.Label();
            this.txtContraseñaActual = new System.Windows.Forms.TextBox();
            this.txtContraseñaNueva = new System.Windows.Forms.TextBox();
            this.txtConfirmarContraseña = new System.Windows.Forms.TextBox();
            this.lblNueva = new System.Windows.Forms.Label();
            this.lblConfirmarNueva = new System.Windows.Forms.Label();
            this.chkMostrar = new System.Windows.Forms.CheckBox();
            this.btnCambiar = new System.Windows.Forms.Button();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.txtTrampa = new System.Windows.Forms.TextBox();
            this.pnlSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblContraseñaActual
            // 
            this.lblContraseñaActual.AutoSize = true;
            this.lblContraseñaActual.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContraseñaActual.Location = new System.Drawing.Point(70, 91);
            this.lblContraseñaActual.Name = "lblContraseñaActual";
            this.lblContraseñaActual.Size = new System.Drawing.Size(102, 13);
            this.lblContraseñaActual.TabIndex = 0;
            this.lblContraseñaActual.Text = "Contraseña Actual";
            // 
            // lblCambiarContraseña
            // 
            this.lblCambiarContraseña.AutoSize = true;
            this.lblCambiarContraseña.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambiarContraseña.ForeColor = System.Drawing.Color.White;
            this.lblCambiarContraseña.Location = new System.Drawing.Point(61, 18);
            this.lblCambiarContraseña.Name = "lblCambiarContraseña";
            this.lblCambiarContraseña.Size = new System.Drawing.Size(207, 19);
            this.lblCambiarContraseña.TabIndex = 1;
            this.lblCambiarContraseña.Text = "Cambiar contraseña";
            // 
            // txtContraseñaActual
            // 
            this.txtContraseñaActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContraseñaActual.Location = new System.Drawing.Point(65, 111);
            this.txtContraseñaActual.Name = "txtContraseñaActual";
            this.txtContraseñaActual.Size = new System.Drawing.Size(189, 22);
            this.txtContraseñaActual.TabIndex = 2;
            this.txtContraseñaActual.UseSystemPasswordChar = true;
            // 
            // txtContraseñaNueva
            // 
            this.txtContraseñaNueva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContraseñaNueva.Location = new System.Drawing.Point(67, 185);
            this.txtContraseñaNueva.Name = "txtContraseñaNueva";
            this.txtContraseñaNueva.Size = new System.Drawing.Size(189, 22);
            this.txtContraseñaNueva.TabIndex = 3;
            this.txtContraseñaNueva.UseSystemPasswordChar = true;
            // 
            // txtConfirmarContraseña
            // 
            this.txtConfirmarContraseña.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmarContraseña.Location = new System.Drawing.Point(69, 264);
            this.txtConfirmarContraseña.Name = "txtConfirmarContraseña";
            this.txtConfirmarContraseña.Size = new System.Drawing.Size(189, 22);
            this.txtConfirmarContraseña.TabIndex = 4;
            this.txtConfirmarContraseña.UseSystemPasswordChar = true;
            // 
            // lblNueva
            // 
            this.lblNueva.AutoSize = true;
            this.lblNueva.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNueva.Location = new System.Drawing.Point(72, 168);
            this.lblNueva.Name = "lblNueva";
            this.lblNueva.Size = new System.Drawing.Size(103, 13);
            this.lblNueva.TabIndex = 5;
            this.lblNueva.Text = "Contraseña Nueva";
            // 
            // lblConfirmarNueva
            // 
            this.lblConfirmarNueva.AutoSize = true;
            this.lblConfirmarNueva.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmarNueva.Location = new System.Drawing.Point(74, 245);
            this.lblConfirmarNueva.Name = "lblConfirmarNueva";
            this.lblConfirmarNueva.Size = new System.Drawing.Size(158, 13);
            this.lblConfirmarNueva.TabIndex = 6;
            this.lblConfirmarNueva.Text = "Confirmar Contraseña Nueva";
            // 
            // chkMostrar
            // 
            this.chkMostrar.AutoSize = true;
            this.chkMostrar.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMostrar.Location = new System.Drawing.Point(79, 311);
            this.chkMostrar.Name = "chkMostrar";
            this.chkMostrar.Size = new System.Drawing.Size(150, 15);
            this.chkMostrar.TabIndex = 7;
            this.chkMostrar.Text = "Mostrar contraseña";
            this.chkMostrar.UseVisualStyleBackColor = true;
            // 
            // btnCambiar
            // 
            this.btnCambiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCambiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnCambiar.FlatAppearance.BorderSize = 0;
            this.btnCambiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiar.ForeColor = System.Drawing.Color.White;
            this.btnCambiar.Location = new System.Drawing.Point(112, 343);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(90, 23);
            this.btnCambiar.TabIndex = 17;
            this.btnCambiar.Text = "Cambiar";
            this.btnCambiar.UseVisualStyleBackColor = false;
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlSuperior.Controls.Add(this.btnCerrar);
            this.pnlSuperior.Controls.Add(this.lblCambiarContraseña);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(5, 5);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(319, 50);
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
            this.btnCerrar.Location = new System.Drawing.Point(288, 11);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(24, 23);
            this.btnCerrar.TabIndex = 20;
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // txtTrampa
            // 
            this.txtTrampa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTrampa.Location = new System.Drawing.Point(-100, -100);
            this.txtTrampa.Name = "txtTrampa";
            this.txtTrampa.Size = new System.Drawing.Size(189, 22);
            this.txtTrampa.TabIndex = 0;
            this.txtTrampa.UseSystemPasswordChar = true;
            // 
            // CambiarContraseña
            // 
            this.AcceptButton = this.btnCambiar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(329, 393);
            this.Controls.Add(this.txtTrampa);
            this.Controls.Add(this.pnlSuperior);
            this.Controls.Add(this.btnCambiar);
            this.Controls.Add(this.chkMostrar);
            this.Controls.Add(this.lblConfirmarNueva);
            this.Controls.Add(this.lblNueva);
            this.Controls.Add(this.txtConfirmarContraseña);
            this.Controls.Add(this.txtContraseñaNueva);
            this.Controls.Add(this.txtContraseñaActual);
            this.Controls.Add(this.lblContraseñaActual);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "CambiarContraseña";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CambiarContraseña";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CambiarContraseña_KeyDown);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblContraseñaActual;
        private System.Windows.Forms.Label lblCambiarContraseña;
        private System.Windows.Forms.TextBox txtContraseñaActual;
        private System.Windows.Forms.TextBox txtContraseñaNueva;
        private System.Windows.Forms.TextBox txtConfirmarContraseña;
        private System.Windows.Forms.Label lblNueva;
        private System.Windows.Forms.Label lblConfirmarNueva;
        private System.Windows.Forms.CheckBox chkMostrar;
        private System.Windows.Forms.Button btnCambiar;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TextBox txtTrampa;
    }
}