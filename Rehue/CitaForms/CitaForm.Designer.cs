
namespace Rehue.CitaForms
{
    partial class CitaForm
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
            this.lstEmpresas = new System.Windows.Forms.ListBox();
            this.grpCrearCita = new System.Windows.Forms.GroupBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtPckrFecha = new System.Windows.Forms.DateTimePicker();
            this.lblComensales = new System.Windows.Forms.Label();
            this.numComensales = new System.Windows.Forms.NumericUpDown();
            this.btnCrear = new System.Windows.Forms.Button();
            this.grpCrearCita.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numComensales)).BeginInit();
            this.SuspendLayout();
            // 
            // lstEmpresas
            // 
            this.lstEmpresas.FormattingEnabled = true;
            this.lstEmpresas.Location = new System.Drawing.Point(6, 19);
            this.lstEmpresas.Name = "lstEmpresas";
            this.lstEmpresas.Size = new System.Drawing.Size(311, 238);
            this.lstEmpresas.TabIndex = 1;
            // 
            // grpCrearCita
            // 
            this.grpCrearCita.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCrearCita.Controls.Add(this.btnCrear);
            this.grpCrearCita.Controls.Add(this.numComensales);
            this.grpCrearCita.Controls.Add(this.lblComensales);
            this.grpCrearCita.Controls.Add(this.dtPckrFecha);
            this.grpCrearCita.Controls.Add(this.lblFecha);
            this.grpCrearCita.Controls.Add(this.lstEmpresas);
            this.grpCrearCita.Location = new System.Drawing.Point(12, 12);
            this.grpCrearCita.Name = "grpCrearCita";
            this.grpCrearCita.Size = new System.Drawing.Size(332, 378);
            this.grpCrearCita.TabIndex = 2;
            this.grpCrearCita.TabStop = false;
            this.grpCrearCita.Text = "Crear Cita";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(6, 266);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha";
            // 
            // dtPckrFecha
            // 
            this.dtPckrFecha.Location = new System.Drawing.Point(76, 260);
            this.dtPckrFecha.Name = "dtPckrFecha";
            this.dtPckrFecha.Size = new System.Drawing.Size(200, 20);
            this.dtPckrFecha.TabIndex = 3;
            // 
            // lblComensales
            // 
            this.lblComensales.AutoSize = true;
            this.lblComensales.Location = new System.Drawing.Point(6, 299);
            this.lblComensales.Name = "lblComensales";
            this.lblComensales.Size = new System.Drawing.Size(64, 13);
            this.lblComensales.TabIndex = 4;
            this.lblComensales.Text = "Comensales";
            // 
            // numComensales
            // 
            this.numComensales.Location = new System.Drawing.Point(76, 297);
            this.numComensales.Name = "numComensales";
            this.numComensales.Size = new System.Drawing.Size(200, 20);
            this.numComensales.TabIndex = 5;
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(251, 346);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(75, 23);
            this.btnCrear.TabIndex = 6;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // CitaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 393);
            this.Controls.Add(this.grpCrearCita);
            this.Name = "CitaForm";
            this.Text = "CitaForm";
            this.Load += new System.EventHandler(this.CitaForm_Load);
            this.grpCrearCita.ResumeLayout(false);
            this.grpCrearCita.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numComensales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lstEmpresas;
        private System.Windows.Forms.GroupBox grpCrearCita;
        private System.Windows.Forms.DateTimePicker dtPckrFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.NumericUpDown numComensales;
        private System.Windows.Forms.Label lblComensales;
        private System.Windows.Forms.Button btnCrear;
    }
}