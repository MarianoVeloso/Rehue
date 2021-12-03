
namespace Rehue.CitaForms
{
    partial class GestionarDenunciaForm
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
            this.lblDenuncias = new System.Windows.Forms.Label();
            this.dtGridCitasConDenuncia = new System.Windows.Forms.DataGridView();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnDenegar = new System.Windows.Forms.Button();
            this.dtGridDenunciasGestionadas = new System.Windows.Forms.DataGridView();
            this.lblDenunciasGestionadas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridCitasConDenuncia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridDenunciasGestionadas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDenuncias
            // 
            this.lblDenuncias.AutoSize = true;
            this.lblDenuncias.Location = new System.Drawing.Point(13, 13);
            this.lblDenuncias.Name = "lblDenuncias";
            this.lblDenuncias.Size = new System.Drawing.Size(58, 13);
            this.lblDenuncias.TabIndex = 0;
            this.lblDenuncias.Text = "Denuncias";
            // 
            // dtGridCitasConDenuncia
            // 
            this.dtGridCitasConDenuncia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtGridCitasConDenuncia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridCitasConDenuncia.Location = new System.Drawing.Point(16, 39);
            this.dtGridCitasConDenuncia.Name = "dtGridCitasConDenuncia";
            this.dtGridCitasConDenuncia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGridCitasConDenuncia.Size = new System.Drawing.Size(772, 254);
            this.dtGridCitasConDenuncia.TabIndex = 1;
            this.dtGridCitasConDenuncia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridCitasConDenuncia_CellClick);
            this.dtGridCitasConDenuncia.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtGridCitasConDenuncia_DataBindingComplete);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(632, 299);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 2;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnDenegar
            // 
            this.btnDenegar.Location = new System.Drawing.Point(713, 299);
            this.btnDenegar.Name = "btnDenegar";
            this.btnDenegar.Size = new System.Drawing.Size(75, 23);
            this.btnDenegar.TabIndex = 3;
            this.btnDenegar.Text = "Denegar";
            this.btnDenegar.UseVisualStyleBackColor = true;
            this.btnDenegar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dtGridDenunciasGestionadas
            // 
            this.dtGridDenunciasGestionadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtGridDenunciasGestionadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridDenunciasGestionadas.Location = new System.Drawing.Point(16, 334);
            this.dtGridDenunciasGestionadas.Name = "dtGridDenunciasGestionadas";
            this.dtGridDenunciasGestionadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGridDenunciasGestionadas.Size = new System.Drawing.Size(772, 254);
            this.dtGridDenunciasGestionadas.TabIndex = 5;
            // 
            // lblDenunciasGestionadas
            // 
            this.lblDenunciasGestionadas.AutoSize = true;
            this.lblDenunciasGestionadas.Location = new System.Drawing.Point(13, 311);
            this.lblDenunciasGestionadas.Name = "lblDenunciasGestionadas";
            this.lblDenunciasGestionadas.Size = new System.Drawing.Size(118, 13);
            this.lblDenunciasGestionadas.TabIndex = 4;
            this.lblDenunciasGestionadas.Text = "Denuncias gestionadas";
            // 
            // GestionarDenunciaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.dtGridDenunciasGestionadas);
            this.Controls.Add(this.lblDenunciasGestionadas);
            this.Controls.Add(this.btnDenegar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.dtGridCitasConDenuncia);
            this.Controls.Add(this.lblDenuncias);
            this.Name = "GestionarDenunciaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar Denuncias";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GestionarDenunciaForm_FormClosed);
            this.Load += new System.EventHandler(this.DenunciasForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridCitasConDenuncia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridDenunciasGestionadas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDenuncias;
        private System.Windows.Forms.DataGridView dtGridCitasConDenuncia;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnDenegar;
        private System.Windows.Forms.DataGridView dtGridDenunciasGestionadas;
        private System.Windows.Forms.Label lblDenunciasGestionadas;
    }
}