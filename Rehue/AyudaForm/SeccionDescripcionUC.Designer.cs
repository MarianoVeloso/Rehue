namespace Rehue.AyudaForm
{
    partial class SeccionDescripcionUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSeccion = new System.Windows.Forms.Label();
            this.txtTextoInformativo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblSeccion
            // 
            this.lblSeccion.AutoSize = true;
            this.lblSeccion.Location = new System.Drawing.Point(3, 11);
            this.lblSeccion.Name = "lblSeccion";
            this.lblSeccion.Size = new System.Drawing.Size(56, 16);
            this.lblSeccion.TabIndex = 0;
            this.lblSeccion.Text = "Seccion";
            // 
            // txtTextoInformativo
            // 
            this.txtTextoInformativo.Location = new System.Drawing.Point(117, 11);
            this.txtTextoInformativo.Multiline = true;
            this.txtTextoInformativo.Name = "txtTextoInformativo";
            this.txtTextoInformativo.ReadOnly = true;
            this.txtTextoInformativo.Size = new System.Drawing.Size(408, 67);
            this.txtTextoInformativo.TabIndex = 1;
            // 
            // SeccionDescripcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtTextoInformativo);
            this.Controls.Add(this.lblSeccion);
            this.Name = "SeccionDescripcion";
            this.Size = new System.Drawing.Size(528, 81);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSeccion;
        private System.Windows.Forms.TextBox txtTextoInformativo;
    }
}
