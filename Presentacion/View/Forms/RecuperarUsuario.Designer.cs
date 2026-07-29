namespace Presentacion.View.Forms
{
    partial class RecuperarUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecuperarUsuario));
            this.llbVolver = new System.Windows.Forms.LinkLabel();
            this.lblOlvido = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblInformacion = new System.Windows.Forms.Label();
            this.KtxtCorreo = new Krypton.Toolkit.KryptonTextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.KbtnSiguiente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // llbVolver
            // 
            this.llbVolver.AutoSize = true;
            this.llbVolver.BackColor = System.Drawing.Color.Transparent;
            this.llbVolver.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.llbVolver.Location = new System.Drawing.Point(169, 461);
            this.llbVolver.Name = "llbVolver";
            this.llbVolver.Size = new System.Drawing.Size(75, 13);
            this.llbVolver.TabIndex = 18;
            this.llbVolver.TabStop = true;
            this.llbVolver.Text = "Volver al inicio";
            // 
            // lblOlvido
            // 
            this.lblOlvido.AutoSize = true;
            this.lblOlvido.BackColor = System.Drawing.Color.Transparent;
            this.lblOlvido.Font = new System.Drawing.Font("Lucida Console", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOlvido.Location = new System.Drawing.Point(64, 202);
            this.lblOlvido.Name = "lblOlvido";
            this.lblOlvido.Size = new System.Drawing.Size(276, 24);
            this.lblOlvido.TabIndex = 19;
            this.lblOlvido.Text = "¿Olvido su usuario?";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Image = global::Presentacion.Properties.Resources.icons8_x_161;
            this.btnCerrar.Location = new System.Drawing.Point(358, 7);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(24, 23);
            this.btnCerrar.TabIndex = 12;
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(123, 31);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(163, 140);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 2;
            this.picLogo.TabStop = false;
            // 
            // lblInformacion
            // 
            this.lblInformacion.AutoSize = true;
            this.lblInformacion.BackColor = System.Drawing.Color.Transparent;
            this.lblInformacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformacion.Location = new System.Drawing.Point(22, 251);
            this.lblInformacion.Name = "lblInformacion";
            this.lblInformacion.Size = new System.Drawing.Size(345, 21);
            this.lblInformacion.TabIndex = 29;
            this.lblInformacion.Text = "Le enviaremos un código a su correo electrónico";
            // 
            // KtxtCorreo
            // 
            this.KtxtCorreo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.KtxtCorreo.CueHint.CueHintText = "   email@gmail.com";
            this.KtxtCorreo.CueHint.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KtxtCorreo.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.KtxtCorreo.Location = new System.Drawing.Point(45, 287);
            this.KtxtCorreo.Name = "KtxtCorreo";
            this.KtxtCorreo.Size = new System.Drawing.Size(295, 23);
            this.KtxtCorreo.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtCorreo.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KtxtCorreo.TabIndex = 30;
            // 
            // lblEstado
            // 
            this.lblEstado.BackColor = System.Drawing.Color.Transparent;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(0, 418);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(410, 40);
            this.lblEstado.TabIndex = 47;
            this.lblEstado.Text = "Validando";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblEstado.Visible = false;
            // 
            // KbtnSiguiente
            // 
            this.KbtnSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(161)))), ((int)(((byte)(107)))));
            this.KbtnSiguiente.FlatAppearance.BorderSize = 0;
            this.KbtnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KbtnSiguiente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KbtnSiguiente.ForeColor = System.Drawing.Color.White;
            this.KbtnSiguiente.Location = new System.Drawing.Point(123, 388);
            this.KbtnSiguiente.Name = "KbtnSiguiente";
            this.KbtnSiguiente.Size = new System.Drawing.Size(163, 25);
            this.KbtnSiguiente.TabIndex = 60;
            this.KbtnSiguiente.Text = "Siguiente";
            this.KbtnSiguiente.UseVisualStyleBackColor = false;
            // 
            // RecuperarUsuario
            // 
            this.AcceptButton = this.KbtnSiguiente;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(391, 490);
            this.Controls.Add(this.KbtnSiguiente);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.KtxtCorreo);
            this.Controls.Add(this.lblInformacion);
            this.Controls.Add(this.lblOlvido);
            this.Controls.Add(this.llbVolver);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.picLogo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "RecuperarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RecuperarUsuario";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RecuperarUsuario_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.LinkLabel llbVolver;
        private System.Windows.Forms.Label lblOlvido;
        private System.Windows.Forms.Label lblInformacion;
        private Krypton.Toolkit.KryptonTextBox KtxtCorreo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button KbtnSiguiente;
    }
}