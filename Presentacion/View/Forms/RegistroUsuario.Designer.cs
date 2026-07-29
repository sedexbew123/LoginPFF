namespace Presentacion.View.Forms
{
    partial class RegistroUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroUsuario));
            this.txtTrampa = new System.Windows.Forms.TextBox();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblRegistro = new System.Windows.Forms.Label();
            this.pnlContenedorDatos = new System.Windows.Forms.Panel();
            this.KbtnRegistrar = new System.Windows.Forms.Button();
            this.lblCedula = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.KtxtTelefono = new Krypton.Toolkit.KryptonTextBox();
            this.llbVolver = new System.Windows.Forms.LinkLabel();
            this.KtxtDireccion = new Krypton.Toolkit.KryptonTextBox();
            this.KtxtCorreo = new Krypton.Toolkit.KryptonTextBox();
            this.KtxtCedula = new Krypton.Toolkit.KryptonTextBox();
            this.KtxtApellido = new Krypton.Toolkit.KryptonTextBox();
            this.KtxtNombre = new Krypton.Toolkit.KryptonTextBox();
            this.pnlCarga = new System.Windows.Forms.Panel();
            this.picCarga = new System.Windows.Forms.PictureBox();
            this.pnlSuperior.SuspendLayout();
            this.pnlContenedorDatos.SuspendLayout();
            this.pnlCarga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCarga)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTrampa
            // 
            this.txtTrampa.Location = new System.Drawing.Point(-100, -100);
            this.txtTrampa.Name = "txtTrampa";
            this.txtTrampa.Size = new System.Drawing.Size(100, 20);
            this.txtTrampa.TabIndex = 0;
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlSuperior.Controls.Add(this.lblRegistro);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(5, 5);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(399, 50);
            this.pnlSuperior.TabIndex = 44;
            // 
            // lblRegistro
            // 
            this.lblRegistro.AutoSize = true;
            this.lblRegistro.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro.ForeColor = System.Drawing.Color.White;
            this.lblRegistro.Location = new System.Drawing.Point(98, 18);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(229, 19);
            this.lblRegistro.TabIndex = 1;
            this.lblRegistro.Text = "Información Personal";
            // 
            // pnlContenedorDatos
            // 
            this.pnlContenedorDatos.Controls.Add(this.KbtnRegistrar);
            this.pnlContenedorDatos.Controls.Add(this.lblCedula);
            this.pnlContenedorDatos.Controls.Add(this.lblNombre);
            this.pnlContenedorDatos.Controls.Add(this.lblApellido);
            this.pnlContenedorDatos.Controls.Add(this.lblTelefono);
            this.pnlContenedorDatos.Controls.Add(this.lblCorreo);
            this.pnlContenedorDatos.Controls.Add(this.lblDireccion);
            this.pnlContenedorDatos.Controls.Add(this.KtxtTelefono);
            this.pnlContenedorDatos.Controls.Add(this.llbVolver);
            this.pnlContenedorDatos.Controls.Add(this.KtxtDireccion);
            this.pnlContenedorDatos.Controls.Add(this.KtxtCorreo);
            this.pnlContenedorDatos.Controls.Add(this.KtxtCedula);
            this.pnlContenedorDatos.Controls.Add(this.KtxtApellido);
            this.pnlContenedorDatos.Controls.Add(this.KtxtNombre);
            this.pnlContenedorDatos.Location = new System.Drawing.Point(19, 62);
            this.pnlContenedorDatos.Name = "pnlContenedorDatos";
            this.pnlContenedorDatos.Size = new System.Drawing.Size(385, 266);
            this.pnlContenedorDatos.TabIndex = 45;
            // 
            // KbtnRegistrar
            // 
            this.KbtnRegistrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.KbtnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.KbtnRegistrar.FlatAppearance.BorderSize = 0;
            this.KbtnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KbtnRegistrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KbtnRegistrar.ForeColor = System.Drawing.Color.White;
            this.KbtnRegistrar.Location = new System.Drawing.Point(148, 215);
            this.KbtnRegistrar.Name = "KbtnRegistrar";
            this.KbtnRegistrar.Size = new System.Drawing.Size(90, 25);
            this.KbtnRegistrar.TabIndex = 65;
            this.KbtnRegistrar.Text = "Permitir";
            this.KbtnRegistrar.UseVisualStyleBackColor = false;
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.BackColor = System.Drawing.Color.Transparent;
            this.lblCedula.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCedula.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblCedula.Location = new System.Drawing.Point(28, 6);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(47, 15);
            this.lblCedula.TabIndex = 64;
            this.lblCedula.Text = "Cédula ";
            this.lblCedula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblNombre.Location = new System.Drawing.Point(213, 6);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(56, 15);
            this.lblNombre.TabIndex = 63;
            this.lblNombre.Text = "Nombre ";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblApellido.Location = new System.Drawing.Point(28, 58);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(55, 15);
            this.lblApellido.TabIndex = 62;
            this.lblApellido.Text = "Apellido ";
            this.lblApellido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.BackColor = System.Drawing.Color.Transparent;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblTelefono.Location = new System.Drawing.Point(213, 58);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(59, 15);
            this.lblTelefono.TabIndex = 61;
            this.lblTelefono.Text = "Teléfono ";
            this.lblTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblCorreo.Location = new System.Drawing.Point(28, 104);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(48, 15);
            this.lblCorreo.TabIndex = 60;
            this.lblCorreo.Text = "Correo ";
            this.lblCorreo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblDireccion.Location = new System.Drawing.Point(28, 150);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(63, 15);
            this.lblDireccion.TabIndex = 59;
            this.lblDireccion.Text = "Dirección ";
            this.lblDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KtxtTelefono
            // 
            this.KtxtTelefono.Location = new System.Drawing.Point(205, 78);
            this.KtxtTelefono.MaxLength = 12;
            this.KtxtTelefono.Name = "KtxtTelefono";
            this.KtxtTelefono.Size = new System.Drawing.Size(160, 23);
            this.KtxtTelefono.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtTelefono.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KtxtTelefono.TabIndex = 57;
            // 
            // llbVolver
            // 
            this.llbVolver.AutoSize = true;
            this.llbVolver.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbVolver.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.llbVolver.Location = new System.Drawing.Point(154, 247);
            this.llbVolver.Name = "llbVolver";
            this.llbVolver.Size = new System.Drawing.Size(81, 13);
            this.llbVolver.TabIndex = 56;
            this.llbVolver.TabStop = true;
            this.llbVolver.Text = "Volver al inicio";
            // 
            // KtxtDireccion
            // 
            this.KtxtDireccion.Location = new System.Drawing.Point(20, 172);
            this.KtxtDireccion.Name = "KtxtDireccion";
            this.KtxtDireccion.Size = new System.Drawing.Size(345, 23);
            this.KtxtDireccion.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtDireccion.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KtxtDireccion.TabIndex = 55;
            // 
            // KtxtCorreo
            // 
            this.KtxtCorreo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.KtxtCorreo.Location = new System.Drawing.Point(20, 124);
            this.KtxtCorreo.Name = "KtxtCorreo";
            this.KtxtCorreo.Size = new System.Drawing.Size(345, 23);
            this.KtxtCorreo.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtCorreo.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KtxtCorreo.TabIndex = 54;
            // 
            // KtxtCedula
            // 
            this.KtxtCedula.Location = new System.Drawing.Point(20, 26);
            this.KtxtCedula.MaxLength = 10;
            this.KtxtCedula.Name = "KtxtCedula";
            this.KtxtCedula.Size = new System.Drawing.Size(160, 23);
            this.KtxtCedula.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtCedula.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KtxtCedula.TabIndex = 53;
            // 
            // KtxtApellido
            // 
            this.KtxtApellido.Location = new System.Drawing.Point(20, 78);
            this.KtxtApellido.Name = "KtxtApellido";
            this.KtxtApellido.Size = new System.Drawing.Size(160, 23);
            this.KtxtApellido.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtApellido.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtApellido.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KtxtApellido.TabIndex = 52;
            // 
            // KtxtNombre
            // 
            this.KtxtNombre.Location = new System.Drawing.Point(205, 26);
            this.KtxtNombre.Name = "KtxtNombre";
            this.KtxtNombre.Size = new System.Drawing.Size(160, 23);
            this.KtxtNombre.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(61)))), ((int)(((byte)(105)))));
            this.KtxtNombre.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.KtxtNombre.TabIndex = 51;
            // 
            // pnlCarga
            // 
            this.pnlCarga.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlCarga.Controls.Add(this.picCarga);
            this.pnlCarga.Location = new System.Drawing.Point(10, 61);
            this.pnlCarga.Name = "pnlCarga";
            this.pnlCarga.Size = new System.Drawing.Size(388, 296);
            this.pnlCarga.TabIndex = 51;
            this.pnlCarga.Visible = false;
            // 
            // picCarga
            // 
            this.picCarga.Image = ((System.Drawing.Image)(resources.GetObject("picCarga.Image")));
            this.picCarga.Location = new System.Drawing.Point(140, 59);
            this.picCarga.Name = "picCarga";
            this.picCarga.Size = new System.Drawing.Size(106, 92);
            this.picCarga.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCarga.TabIndex = 0;
            this.picCarga.TabStop = false;
            // 
            // RegistroUsuario
            // 
            this.AcceptButton = this.KbtnRegistrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(409, 336);
            this.Controls.Add(this.pnlCarga);
            this.Controls.Add(this.pnlContenedorDatos);
            this.Controls.Add(this.pnlSuperior);
            this.Controls.Add(this.txtTrampa);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegistroUsuario";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlContenedorDatos.ResumeLayout(false);
            this.pnlContenedorDatos.PerformLayout();
            this.pnlCarga.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCarga)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTrampa;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblRegistro;
        private System.Windows.Forms.Panel pnlContenedorDatos;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblDireccion;
        private Krypton.Toolkit.KryptonTextBox KtxtTelefono;
        private System.Windows.Forms.LinkLabel llbVolver;
        private Krypton.Toolkit.KryptonTextBox KtxtDireccion;
        private Krypton.Toolkit.KryptonTextBox KtxtCorreo;
        private Krypton.Toolkit.KryptonTextBox KtxtCedula;
        private Krypton.Toolkit.KryptonTextBox KtxtApellido;
        private Krypton.Toolkit.KryptonTextBox KtxtNombre;
        private System.Windows.Forms.Panel pnlCarga;
        private System.Windows.Forms.PictureBox picCarga;
        private System.Windows.Forms.Button KbtnRegistrar;
    }
}