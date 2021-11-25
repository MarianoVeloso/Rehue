
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNombreRestoreValue = new System.Windows.Forms.Label();
            this.lblNombreRestore = new System.Windows.Forms.Label();
            this.btnConfirmarRestore = new System.Windows.Forms.Button();
            this.lblUbicacionRestoreValue = new System.Windows.Forms.Label();
            this.lblUbicacionRestore = new System.Windows.Forms.Label();
            this.grpCrear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtBackups)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.lblCarpetaSeleccionada.Location = new System.Drawing.Point(12, 18);
            this.lblCarpetaSeleccionada.Name = "lblCarpetaSeleccionada";
            this.lblCarpetaSeleccionada.Size = new System.Drawing.Size(145, 16);
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
            this.lblNombre.Location = new System.Drawing.Point(15, 64);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(56, 16);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(15, 83);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 22);
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
            this.lblRuta.Location = new System.Drawing.Point(15, 34);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(68, 16);
            this.lblRuta.TabIndex = 2;
            this.lblRuta.Text = "Ubicacion";
            // 
            // dtBackups
            // 
            this.dtBackups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtBackups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtBackups.Location = new System.Drawing.Point(12, 154);
            this.dtBackups.Name = "dtBackups";
            this.dtBackups.ReadOnly = true;
            this.dtBackups.RowHeadersWidth = 51;
            this.dtBackups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtBackups.Size = new System.Drawing.Size(857, 258);
            this.dtBackups.TabIndex = 3;
            this.dtBackups.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtBackups_CellClick);
            // 
            // lblCreados
            // 
            this.lblCreados.AutoSize = true;
            this.lblCreados.Location = new System.Drawing.Point(12, 138);
            this.lblCreados.Name = "lblCreados";
            this.lblCreados.Size = new System.Drawing.Size(113, 16);
            this.lblCreados.TabIndex = 4;
            this.lblCreados.Text = "Backups creados";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNombreRestoreValue);
            this.groupBox1.Controls.Add(this.lblNombreRestore);
            this.groupBox1.Controls.Add(this.btnConfirmarRestore);
            this.groupBox1.Controls.Add(this.lblUbicacionRestoreValue);
            this.groupBox1.Controls.Add(this.lblUbicacionRestore);
            this.groupBox1.Location = new System.Drawing.Point(448, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 122);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Restaurar backup";
            // 
            // lblNombreRestoreValue
            // 
            this.lblNombreRestoreValue.AutoSize = true;
            this.lblNombreRestoreValue.Location = new System.Drawing.Point(15, 71);
            this.lblNombreRestoreValue.Name = "lblNombreRestoreValue";
            this.lblNombreRestoreValue.Size = new System.Drawing.Size(59, 16);
            this.lblNombreRestoreValue.TabIndex = 6;
            this.lblNombreRestoreValue.Text = "Nombre:";
            // 
            // lblNombreRestore
            // 
            this.lblNombreRestore.AutoSize = true;
            this.lblNombreRestore.Location = new System.Drawing.Point(12, 55);
            this.lblNombreRestore.Name = "lblNombreRestore";
            this.lblNombreRestore.Size = new System.Drawing.Size(59, 16);
            this.lblNombreRestore.TabIndex = 5;
            this.lblNombreRestore.Text = "Nombre:";
            // 
            // btnConfirmarRestore
            // 
            this.btnConfirmarRestore.Enabled = false;
            this.btnConfirmarRestore.Location = new System.Drawing.Point(294, 93);
            this.btnConfirmarRestore.Name = "btnConfirmarRestore";
            this.btnConfirmarRestore.Size = new System.Drawing.Size(118, 23);
            this.btnConfirmarRestore.TabIndex = 3;
            this.btnConfirmarRestore.Text = "Confirmar";
            this.btnConfirmarRestore.UseVisualStyleBackColor = true;
            this.btnConfirmarRestore.Click += new System.EventHandler(this.btnConfirmarRestore_Click);
            // 
            // lblUbicacionRestoreValue
            // 
            this.lblUbicacionRestoreValue.AutoSize = true;
            this.lblUbicacionRestoreValue.Location = new System.Drawing.Point(15, 34);
            this.lblUbicacionRestoreValue.Name = "lblUbicacionRestoreValue";
            this.lblUbicacionRestoreValue.Size = new System.Drawing.Size(68, 16);
            this.lblUbicacionRestoreValue.TabIndex = 2;
            this.lblUbicacionRestoreValue.Text = "Ubicacion";
            // 
            // lblUbicacionRestore
            // 
            this.lblUbicacionRestore.AutoSize = true;
            this.lblUbicacionRestore.Location = new System.Drawing.Point(12, 16);
            this.lblUbicacionRestore.Name = "lblUbicacionRestore";
            this.lblUbicacionRestore.Size = new System.Drawing.Size(71, 16);
            this.lblUbicacionRestore.TabIndex = 1;
            this.lblUbicacionRestore.Text = "Ubicacion:";
            // 
            // BackupForm
            // 
            this.ClientSize = new System.Drawing.Size(878, 424);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCreados);
            this.Controls.Add(this.dtBackups);
            this.Controls.Add(this.grpCrear);
            this.Name = "BackupForm";
            this.grpCrear.ResumeLayout(false);
            this.grpCrear.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtBackups)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNombreRestore;
        private System.Windows.Forms.Button btnConfirmarRestore;
        private System.Windows.Forms.Label lblUbicacionRestoreValue;
        private System.Windows.Forms.Label lblUbicacionRestore;
        private System.Windows.Forms.Label lblNombreRestoreValue;
    }
}
