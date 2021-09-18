namespace Rehue.LogIn
{
    partial class RegistrarPersona
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
            this.grpOtrosDatos = new System.Windows.Forms.GroupBox();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.grpDatosBasicos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDocumento)).BeginInit();
            this.grpOtrosDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpOtrosDatos
            // 
            this.grpOtrosDatos.Controls.Add(this.txtUbicacion);
            this.grpOtrosDatos.Controls.Add(this.lblUbicacion);
            this.grpOtrosDatos.Controls.Add(this.txtApellido);
            this.grpOtrosDatos.Controls.Add(this.txtNombre);
            this.grpOtrosDatos.Controls.Add(this.lblApellido);
            this.grpOtrosDatos.Controls.Add(this.lblNombre);
            this.grpOtrosDatos.Location = new System.Drawing.Point(12, 178);
            this.grpOtrosDatos.Name = "grpOtrosDatos";
            this.grpOtrosDatos.Size = new System.Drawing.Size(317, 94);
            this.grpOtrosDatos.TabIndex = 7;
            this.grpOtrosDatos.TabStop = false;
            this.grpOtrosDatos.Text = "Otros Datos";
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Location = new System.Drawing.Point(109, 64);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(201, 20);
            this.txtUbicacion.TabIndex = 8;
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Location = new System.Drawing.Point(6, 67);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(55, 13);
            this.lblUbicacion.TabIndex = 10;
            this.lblUbicacion.Text = "Ubicacion";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(110, 38);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(201, 20);
            this.txtApellido.TabIndex = 6;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(110, 12);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(201, 20);
            this.txtNombre.TabIndex = 5;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(6, 41);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(44, 13);
            this.lblApellido.TabIndex = 1;
            this.lblApellido.Text = "Apellido";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(6, 15);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(260, 322);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrar.Location = new System.Drawing.Point(179, 322);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar.TabIndex = 9;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click_1);
            // 
            // RegistrarPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 352);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpOtrosDatos);
            this.Name = "RegistrarPersona";
            this.Text = "RegistrarPersona";
            this.Load += new System.EventHandler(this.RegistrarPersona_Load);
            this.Controls.SetChildIndex(this.grpDatosBasicos, 0);
            this.Controls.SetChildIndex(this.grpOtrosDatos, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnRegistrar, 0);
            this.grpDatosBasicos.ResumeLayout(false);
            this.grpDatosBasicos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDocumento)).EndInit();
            this.grpOtrosDatos.ResumeLayout(false);
            this.grpOtrosDatos.PerformLayout();
            this.ResumeLayout(false);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

        }

        #endregion

        private System.Windows.Forms.GroupBox grpOtrosDatos;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Label lblUbicacion;
    }
}