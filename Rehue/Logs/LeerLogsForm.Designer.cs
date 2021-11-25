namespace Rehue.Logs
{
    partial class LeerLogsForm
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
            this.dtListadoErrores = new System.Windows.Forms.DataGridView();
            this.lblListadoErrores = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtListadoErrores)).BeginInit();
            this.SuspendLayout();
            // 
            // dtListadoErrores
            // 
            this.dtListadoErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtListadoErrores.Location = new System.Drawing.Point(13, 50);
            this.dtListadoErrores.Name = "dtListadoErrores";
            this.dtListadoErrores.RowHeadersWidth = 51;
            this.dtListadoErrores.RowTemplate.Height = 24;
            this.dtListadoErrores.Size = new System.Drawing.Size(775, 388);
            this.dtListadoErrores.TabIndex = 0;
            // 
            // lblListadoErrores
            // 
            this.lblListadoErrores.AutoSize = true;
            this.lblListadoErrores.Location = new System.Drawing.Point(10, 9);
            this.lblListadoErrores.Name = "lblListadoErrores";
            this.lblListadoErrores.Size = new System.Drawing.Size(116, 16);
            this.lblListadoErrores.TabIndex = 1;
            this.lblListadoErrores.Text = "Listado de errores";
            // 
            // LeerLogsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblListadoErrores);
            this.Controls.Add(this.dtListadoErrores);
            this.Name = "LeerLogsForm";
            this.Text = "Leer_Logs";
            ((System.ComponentModel.ISupportInitialize)(this.dtListadoErrores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtListadoErrores;
        private System.Windows.Forms.Label lblListadoErrores;
    }
}