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
            this.dtListadoErrores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtListadoErrores.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtListadoErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtListadoErrores.Location = new System.Drawing.Point(10, 41);
            this.dtListadoErrores.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtListadoErrores.Name = "dtListadoErrores";
            this.dtListadoErrores.ReadOnly = true;
            this.dtListadoErrores.RowHeadersWidth = 51;
            this.dtListadoErrores.RowTemplate.Height = 24;
            this.dtListadoErrores.Size = new System.Drawing.Size(581, 315);
            this.dtListadoErrores.TabIndex = 0;
            // 
            // lblListadoErrores
            // 
            this.lblListadoErrores.AutoSize = true;
            this.lblListadoErrores.Location = new System.Drawing.Point(8, 7);
            this.lblListadoErrores.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblListadoErrores.Name = "lblListadoErrores";
            this.lblListadoErrores.Size = new System.Drawing.Size(91, 13);
            this.lblListadoErrores.TabIndex = 1;
            this.lblListadoErrores.Text = "Listado de errores";
            // 
            // LeerLogsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.lblListadoErrores);
            this.Controls.Add(this.dtListadoErrores);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "LeerLogsForm";
            this.Text = "Leer Logs";
            ((System.ComponentModel.ISupportInitialize)(this.dtListadoErrores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtListadoErrores;
        private System.Windows.Forms.Label lblListadoErrores;
    }
}