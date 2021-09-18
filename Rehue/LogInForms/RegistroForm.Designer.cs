namespace Rehue.LogIn
{
    public partial class RegistroForm
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
            this.grpDatosBasicos = new System.Windows.Forms.GroupBox();
            this.numDocumento = new System.Windows.Forms.NumericUpDown();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.dtFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.grpDatosBasicos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDocumento)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDatosBasicos
            // 
            this.grpDatosBasicos.Controls.Add(this.numDocumento);
            this.grpDatosBasicos.Controls.Add(this.lblDocumento);
            this.grpDatosBasicos.Controls.Add(this.dtFechaNacimiento);
            this.grpDatosBasicos.Controls.Add(this.lblFechaNacimiento);
            this.grpDatosBasicos.Controls.Add(this.txtTelefono);
            this.grpDatosBasicos.Controls.Add(this.lblTelefono);
            this.grpDatosBasicos.Controls.Add(this.txtPassword);
            this.grpDatosBasicos.Controls.Add(this.lblContraseña);
            this.grpDatosBasicos.Controls.Add(this.lblEmail);
            this.grpDatosBasicos.Controls.Add(this.txtEmail);
            this.grpDatosBasicos.Location = new System.Drawing.Point(16, 15);
            this.grpDatosBasicos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpDatosBasicos.Name = "grpDatosBasicos";
            this.grpDatosBasicos.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpDatosBasicos.Size = new System.Drawing.Size(423, 197);
            this.grpDatosBasicos.TabIndex = 1;
            this.grpDatosBasicos.TabStop = false;
            this.grpDatosBasicos.Text = "Datos básicos";
            // 
            // numDocumento
            // 
            this.numDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numDocumento.Location = new System.Drawing.Point(147, 154);
            this.numDocumento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numDocumento.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numDocumento.Name = "numDocumento";
            this.numDocumento.Size = new System.Drawing.Size(268, 22);
            this.numDocumento.TabIndex = 5;
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(8, 162);
            this.lblDocumento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(80, 17);
            this.lblDocumento.TabIndex = 8;
            this.lblDocumento.Text = "Documento";
            // 
            // dtFechaNacimiento
            // 
            this.dtFechaNacimiento.Location = new System.Drawing.Point(147, 119);
            this.dtFechaNacimiento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtFechaNacimiento.Name = "dtFechaNacimiento";
            this.dtFechaNacimiento.Size = new System.Drawing.Size(265, 22);
            this.dtFechaNacimiento.TabIndex = 4;
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(8, 127);
            this.lblFechaNacimiento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(121, 17);
            this.lblFechaNacimiento.TabIndex = 7;
            this.lblFechaNacimiento.Text = "Fecha Nacimiento";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.Location = new System.Drawing.Point(147, 87);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(267, 22);
            this.txtTelefono.TabIndex = 3;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(8, 90);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(64, 17);
            this.lblTelefono.TabIndex = 5;
            this.lblTelefono.Text = "Telefono";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Location = new System.Drawing.Point(147, 55);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(267, 22);
            this.txtPassword.TabIndex = 2;
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(8, 58);
            this.lblContraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(81, 17);
            this.lblContraseña.TabIndex = 3;
            this.lblContraseña.Text = "Contraseña";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(8, 26);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 17);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(147, 23);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(267, 22);
            this.txtEmail.TabIndex = 1;
            // 
            // RegistroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 226);
            this.Controls.Add(this.grpDatosBasicos);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RegistroForm";
            this.Text = "RegistrarForm";
            this.grpDatosBasicos.ResumeLayout(false);
            this.grpDatosBasicos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDocumento)).EndInit();
            this.ResumeLayout(false);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

        }

        #endregion

        public System.Windows.Forms.GroupBox grpDatosBasicos;
        public System.Windows.Forms.TextBox txtPassword;
        public System.Windows.Forms.Label lblContraseña;
        public System.Windows.Forms.Label lblEmail;
        public System.Windows.Forms.TextBox txtEmail;
        public System.Windows.Forms.TextBox txtTelefono;
        public System.Windows.Forms.Label lblTelefono;
        public System.Windows.Forms.Label lblFechaNacimiento;
        public System.Windows.Forms.DateTimePicker dtFechaNacimiento;
        public System.Windows.Forms.Label lblDocumento;
        public System.Windows.Forms.NumericUpDown numDocumento;
    }
}