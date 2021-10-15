
namespace Rehue.BackupForms
{
    partial class BackupForm
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
            this.btnSeleccionarCarpeta = new System.Windows.Forms.Button();
            this.lblCarpetaSeleccionada = new System.Windows.Forms.Label();
            this.grpCrear = new System.Windows.Forms.GroupBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lblRuta = new System.Windows.Forms.Label();
            this.dtBackups = new System.Windows.Forms.DataGridView();
            this.lblCreados = new System.Windows.Forms.Label();
            this.grpCrear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtBackups)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSeleccionarCarpeta
            // 
            this.btnSeleccionarCarpeta.Location = new System.Drawing.Point(292, 64);
            this.btnSeleccionarCarpeta.Name = "btnSeleccionarCarpeta";
            this.btnSeleccionarCarpeta.Size = new System.Drawing.Size(118, 23);
            this.btnSeleccionarCarpeta.TabIndex = 0;
            this.btnSeleccionarCarpeta.Text = "Seleccionar carpeta";
            this.btnSeleccionarCarpeta.UseVisualStyleBackColor = true;
            this.btnSeleccionarCarpeta.Click += new System.EventHandler(this.btnSeleccionarCarpeta_Click);
            // 
            // lblCarpetaSeleccionada
            // 
            this.lblCarpetaSeleccionada.AutoSize = true;
            this.lblCarpetaSeleccionada.Location = new System.Drawing.Point(12, 16);
            this.lblCarpetaSeleccionada.Name = "lblCarpetaSeleccionada";
            this.lblCarpetaSeleccionada.Size = new System.Drawing.Size(115, 13);
            this.lblCarpetaSeleccionada.TabIndex = 1;
            this.lblCarpetaSeleccionada.Text = "Carpeta Seleccionada:";
            // 
            // grpCrear
            // 
            this.grpCrear.Controls.Add(this.lblNombre);
            this.grpCrear.Controls.Add(this.txtNombre);
            this.grpCrear.Controls.Add(this.btnConfirmar);
            this.grpCrear.Controls.Add(this.lblRuta);
            this.grpCrear.Controls.Add(this.btnSeleccionarCarpeta);
            this.grpCrear.Controls.Add(this.lblCarpetaSeleccionada);
            this.grpCrear.Location = new System.Drawing.Point(13, 13);
            this.grpCrear.Name = "grpCrear";
            this.grpCrear.Size = new System.Drawing.Size(416, 122);
            this.grpCrear.TabIndex = 2;
            this.grpCrear.TabStop = false;
            this.grpCrear.Text = "Crear nuevo backup";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(15, 45);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(15, 64);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 4;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Enabled = false;
            this.btnConfirmar.Location = new System.Drawing.Point(292, 93);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(118, 23);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Location = new System.Drawing.Point(6, 29);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(0, 13);
            this.lblRuta.TabIndex = 2;
            // 
            // dtBackups
            // 
            this.dtBackups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtBackups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtBackups.Location = new System.Drawing.Point(12, 154);
            this.dtBackups.Name = "dtBackups";
            this.dtBackups.Size = new System.Drawing.Size(706, 258);
            this.dtBackups.TabIndex = 3;
            // 
            // lblCreados
            // 
            this.lblCreados.AutoSize = true;
            this.lblCreados.Location = new System.Drawing.Point(12, 138);
            this.lblCreados.Name = "lblCreados";
            this.lblCreados.Size = new System.Drawing.Size(90, 13);
            this.lblCreados.TabIndex = 4;
            this.lblCreados.Text = "Backups creados";
            // 
            // BackupForm
            // 
            this.ClientSize = new System.Drawing.Size(730, 424);
            this.Controls.Add(this.lblCreados);
            this.Controls.Add(this.dtBackups);
            this.Controls.Add(this.grpCrear);
            this.Name = "BackupForm";
            this.grpCrear.ResumeLayout(false);
            this.grpCrear.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtBackups)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSeleccionarCarpeta;
        private System.Windows.Forms.Label lblCarpetaSeleccionada;
        private System.Windows.Forms.GroupBox grpCrear;
        private System.Windows.Forms.Label lblRuta;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridView dtBackups;
        private System.Windows.Forms.Label lblCreados;
    }
}
