namespace Rehue.MenuForms
{
    partial class MenuDetalle
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
            this.grpRoles = new System.Windows.Forms.GroupBox();
            this.dtItemsEnMenu = new System.Windows.Forms.DataGridView();
            this.lblPermisosAsociadosARol = new System.Windows.Forms.Label();
            this.lblSeleccionMenu = new System.Windows.Forms.Label();
            this.lstMenu = new System.Windows.Forms.ListBox();
            this.grpRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtItemsEnMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // grpRoles
            // 
            this.grpRoles.Controls.Add(this.dtItemsEnMenu);
            this.grpRoles.Controls.Add(this.lblPermisosAsociadosARol);
            this.grpRoles.Controls.Add(this.lblSeleccionMenu);
            this.grpRoles.Controls.Add(this.lstMenu);
            this.grpRoles.Location = new System.Drawing.Point(12, 12);
            this.grpRoles.Name = "grpRoles";
            this.grpRoles.Size = new System.Drawing.Size(991, 603);
            this.grpRoles.TabIndex = 12;
            this.grpRoles.TabStop = false;
            this.grpRoles.Text = "Menu";
            // 
            // dtItemsEnMenu
            // 
            this.dtItemsEnMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtItemsEnMenu.Location = new System.Drawing.Point(15, 307);
            this.dtItemsEnMenu.Name = "dtItemsEnMenu";
            this.dtItemsEnMenu.Size = new System.Drawing.Size(963, 261);
            this.dtItemsEnMenu.TabIndex = 18;
            // 
            // lblPermisosAsociadosARol
            // 
            this.lblPermisosAsociadosARol.AutoSize = true;
            this.lblPermisosAsociadosARol.Location = new System.Drawing.Point(12, 291);
            this.lblPermisosAsociadosARol.Name = "lblPermisosAsociadosARol";
            this.lblPermisosAsociadosARol.Size = new System.Drawing.Size(87, 13);
            this.lblPermisosAsociadosARol.TabIndex = 14;
            this.lblPermisosAsociadosARol.Text = "Items en el menu";
            // 
            // lblSeleccionMenu
            // 
            this.lblSeleccionMenu.AutoSize = true;
            this.lblSeleccionMenu.Location = new System.Drawing.Point(12, 16);
            this.lblSeleccionMenu.Name = "lblSeleccionMenu";
            this.lblSeleccionMenu.Size = new System.Drawing.Size(34, 13);
            this.lblSeleccionMenu.TabIndex = 13;
            this.lblSeleccionMenu.Text = "Menu";
            // 
            // lstMenu
            // 
            this.lstMenu.FormattingEnabled = true;
            this.lstMenu.Location = new System.Drawing.Point(15, 32);
            this.lstMenu.Name = "lstMenu";
            this.lstMenu.Size = new System.Drawing.Size(120, 251);
            this.lstMenu.TabIndex = 10;
            this.lstMenu.SelectedIndexChanged += new System.EventHandler(this.lstMenu_SelectedIndexChanged);
            // 
            // MenuDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 619);
            this.Controls.Add(this.grpRoles);
            this.Name = "MenuDetalle";
            this.Text = "Menu Empresa";
            this.Load += new System.EventHandler(this.MenuDetalle_Load);
            this.grpRoles.ResumeLayout(false);
            this.grpRoles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtItemsEnMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpRoles;
        private System.Windows.Forms.DataGridView dtItemsEnMenu;
        private System.Windows.Forms.Label lblPermisosAsociadosARol;
        private System.Windows.Forms.Label lblSeleccionMenu;
        private System.Windows.Forms.ListBox lstMenu;
    }
}