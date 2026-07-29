namespace Presentacion.View.Forms
{
    partial class EditarClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarClientes));
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblEditarCliente = new System.Windows.Forms.Label();
            this.pnlContenidoDatos = new System.Windows.Forms.Panel();
            this.lblFotoGuardada = new System.Windows.Forms.Label();
            this.btnTomarFoto = new System.Windows.Forms.Button();
            this.btnAgregarImagen = new System.Windows.Forms.Button();
            this.lblCedula = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.pnlCarga = new System.Windows.Forms.Panel();
            this.picCarga = new System.Windows.Forms.PictureBox();
            this.picFotoEmpleado = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlSuperior.SuspendLayout();
            this.pnlContenidoDatos.SuspendLayout();
            this.pnlCarga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCarga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFotoEmpleado)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlSuperior.Controls.Add(this.btnCerrar);
            this.pnlSuperior.Controls.Add(this.lblEditarCliente);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(5, 5);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(561, 50);
            this.pnlSuperior.TabIndex = 22;
            // 
            // lblEditarCliente
            // 
            this.lblEditarCliente.AutoSize = true;
            this.lblEditarCliente.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditarCliente.ForeColor = System.Drawing.Color.White;
            this.lblEditarCliente.Location = new System.Drawing.Point(210, 17);
            this.lblEditarCliente.Name = "lblEditarCliente";
            this.lblEditarCliente.Size = new System.Drawing.Size(163, 19);
            this.lblEditarCliente.TabIndex = 2;
            this.lblEditarCliente.Text = "Editar Cliente";
            // 
            // pnlContenidoDatos
            // 
            this.pnlContenidoDatos.Controls.Add(this.picFotoEmpleado);
            this.pnlContenidoDatos.Controls.Add(this.lblFotoGuardada);
            this.pnlContenidoDatos.Controls.Add(this.btnTomarFoto);
            this.pnlContenidoDatos.Controls.Add(this.btnAgregarImagen);
            this.pnlContenidoDatos.Controls.Add(this.lblCedula);
            this.pnlContenidoDatos.Controls.Add(this.txtNombre);
            this.pnlContenidoDatos.Controls.Add(this.txtTelefono);
            this.pnlContenidoDatos.Controls.Add(this.txtCorreo);
            this.pnlContenidoDatos.Controls.Add(this.txtApellido);
            this.pnlContenidoDatos.Controls.Add(this.txtDireccion);
            this.pnlContenidoDatos.Controls.Add(this.lblNombre);
            this.pnlContenidoDatos.Controls.Add(this.lblApellido);
            this.pnlContenidoDatos.Controls.Add(this.lblTelefono);
            this.pnlContenidoDatos.Controls.Add(this.lblCorreo);
            this.pnlContenidoDatos.Controls.Add(this.lblDireccion);
            this.pnlContenidoDatos.Controls.Add(this.btnEditar);
            this.pnlContenidoDatos.Controls.Add(this.btnCancelar);
            this.pnlContenidoDatos.Controls.Add(this.txtCedula);
            this.pnlContenidoDatos.Location = new System.Drawing.Point(15, 69);
            this.pnlContenidoDatos.Name = "pnlContenidoDatos";
            this.pnlContenidoDatos.Size = new System.Drawing.Size(541, 321);
            this.pnlContenidoDatos.TabIndex = 23;
            // 
            // lblFotoGuardada
            // 
            this.lblFotoGuardada.AutoSize = true;
            this.lblFotoGuardada.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFotoGuardada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblFotoGuardada.Location = new System.Drawing.Point(57, 246);
            this.lblFotoGuardada.Name = "lblFotoGuardada";
            this.lblFotoGuardada.Size = new System.Drawing.Size(83, 13);
            this.lblFotoGuardada.TabIndex = 69;
            this.lblFotoGuardada.Text = "Foto guardada";
            this.lblFotoGuardada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFotoGuardada.Visible = false;
            // 
            // btnTomarFoto
            // 
            this.btnTomarFoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTomarFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnTomarFoto.FlatAppearance.BorderSize = 0;
            this.btnTomarFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTomarFoto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTomarFoto.ForeColor = System.Drawing.Color.White;
            this.btnTomarFoto.Location = new System.Drawing.Point(46, 208);
            this.btnTomarFoto.Name = "btnTomarFoto";
            this.btnTomarFoto.Size = new System.Drawing.Size(98, 25);
            this.btnTomarFoto.TabIndex = 67;
            this.btnTomarFoto.Text = "Tomar Foto";
            this.btnTomarFoto.UseVisualStyleBackColor = false;
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregarImagen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(154)))), ((int)(((byte)(160)))));
            this.btnAgregarImagen.FlatAppearance.BorderSize = 0;
            this.btnAgregarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarImagen.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarImagen.ForeColor = System.Drawing.Color.White;
            this.btnAgregarImagen.Location = new System.Drawing.Point(46, 176);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(98, 25);
            this.btnAgregarImagen.TabIndex = 66;
            this.btnAgregarImagen.Text = "Subir Foto";
            this.btnAgregarImagen.UseVisualStyleBackColor = false;
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.BackColor = System.Drawing.Color.Transparent;
            this.lblCedula.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCedula.Location = new System.Drawing.Point(178, 12);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(43, 13);
            this.lblCedula.TabIndex = 65;
            this.lblCedula.Text = "Cédula";
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(376, 32);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(146, 22);
            this.txtNombre.TabIndex = 64;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(376, 102);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(146, 22);
            this.txtTelefono.TabIndex = 63;
            // 
            // txtCorreo
            // 
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCorreo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.Location = new System.Drawing.Point(181, 236);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(341, 22);
            this.txtCorreo.TabIndex = 62;
            // 
            // txtApellido
            // 
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(181, 102);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(146, 22);
            this.txtApellido.TabIndex = 61;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(181, 168);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(341, 22);
            this.txtDireccion.TabIndex = 60;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(373, 12);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(48, 13);
            this.lblNombre.TabIndex = 59;
            this.lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.Location = new System.Drawing.Point(178, 78);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(50, 13);
            this.lblApellido.TabIndex = 58;
            this.lblApellido.Text = "Apellido";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(377, 78);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(51, 13);
            this.lblTelefono.TabIndex = 57;
            this.lblTelefono.Text = "Teléfono";
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.Location = new System.Drawing.Point(178, 208);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(42, 13);
            this.lblCorreo.TabIndex = 56;
            this.lblCorreo.Text = "Correo";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.Location = new System.Drawing.Point(178, 145);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(55, 13);
            this.lblDireccion.TabIndex = 55;
            this.lblDireccion.Text = "Dirección";
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(161)))), ((int)(((byte)(107)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(376, 284);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(109, 25);
            this.btnEditar.TabIndex = 54;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(229, 284);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 53;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // txtCedula
            // 
            this.txtCedula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCedula.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedula.Location = new System.Drawing.Point(181, 33);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(146, 22);
            this.txtCedula.TabIndex = 52;
            // 
            // pnlCarga
            // 
            this.pnlCarga.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlCarga.Controls.Add(this.picCarga);
            this.pnlCarga.Location = new System.Drawing.Point(3, 59);
            this.pnlCarga.Name = "pnlCarga";
            this.pnlCarga.Size = new System.Drawing.Size(569, 385);
            this.pnlCarga.TabIndex = 53;
            this.pnlCarga.Visible = false;
            // 
            // picCarga
            // 
            this.picCarga.Image = ((System.Drawing.Image)(resources.GetObject("picCarga.Image")));
            this.picCarga.Location = new System.Drawing.Point(216, 95);
            this.picCarga.Name = "picCarga";
            this.picCarga.Size = new System.Drawing.Size(106, 92);
            this.picCarga.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCarga.TabIndex = 0;
            this.picCarga.TabStop = false;
            // 
            // picFotoEmpleado
            // 
            this.picFotoEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.picFotoEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFotoEmpleado.Location = new System.Drawing.Point(23, 49);
            this.picFotoEmpleado.Name = "picFotoEmpleado";
            this.picFotoEmpleado.Size = new System.Drawing.Size(136, 121);
            this.picFotoEmpleado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFotoEmpleado.TabIndex = 68;
            this.picFotoEmpleado.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(77)))), ((int)(((byte)(117)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(77)))), ((int)(((byte)(117)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(527, 13);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(24, 23);
            this.btnCerrar.TabIndex = 20;
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // EditarClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(571, 404);
            this.Controls.Add(this.pnlCarga);
            this.Controls.Add(this.pnlContenidoDatos);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "EditarClientes";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditarClientes";
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlContenidoDatos.ResumeLayout(false);
            this.pnlContenidoDatos.PerformLayout();
            this.pnlCarga.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCarga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFotoEmpleado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblEditarCliente;
        private System.Windows.Forms.Panel pnlContenidoDatos;
        private System.Windows.Forms.Label lblFotoGuardada;
        private System.Windows.Forms.Button btnTomarFoto;
        private System.Windows.Forms.Button btnAgregarImagen;
        private System.Windows.Forms.PictureBox picFotoEmpleado;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Panel pnlCarga;
        private System.Windows.Forms.PictureBox picCarga;
    }
}