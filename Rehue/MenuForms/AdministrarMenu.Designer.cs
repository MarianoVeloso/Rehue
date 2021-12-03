namespace Rehue.MenuForms
{
    partial class AdministrarMenu
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMenuNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreItem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAsignarItem = new System.Windows.Forms.Button();
            this.lblNuevoMenu = new System.Windows.Forms.Label();
            this.dtItemsEnMenu = new System.Windows.Forms.DataGridView();
            this.lblPermisos = new System.Windows.Forms.Label();
            this.lstItemsDisponibles = new System.Windows.Forms.ListBox();
            this.lblPermisosAsociadosARol = new System.Windows.Forms.Label();
            this.lblSeleccionMenu = new System.Windows.Forms.Label();
            this.lstMenu = new System.Windows.Forms.ListBox();
            this.grpRoles.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtItemsEnMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // grpRoles
            // 
            this.grpRoles.Controls.Add(this.groupBox2);
            this.grpRoles.Controls.Add(this.groupBox1);
            this.grpRoles.Controls.Add(this.dtItemsEnMenu);
            this.grpRoles.Controls.Add(this.lblPermisos);
            this.grpRoles.Controls.Add(this.lstItemsDisponibles);
            this.grpRoles.Controls.Add(this.lblPermisosAsociadosARol);
            this.grpRoles.Controls.Add(this.lblSeleccionMenu);
            this.grpRoles.Controls.Add(this.lstMenu);
            this.grpRoles.Location = new System.Drawing.Point(12, 12);
            this.grpRoles.Name = "grpRoles";
            this.grpRoles.Size = new System.Drawing.Size(991, 603);
            this.grpRoles.TabIndex = 11;
            this.grpRoles.TabStop = false;
            this.grpRoles.Text = "Menu";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMenuNombre);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(155, 95);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nuevo Menu/Item";
            // 
            // txtMenuNombre
            // 
            this.txtMenuNombre.Location = new System.Drawing.Point(6, 36);
            this.txtMenuNombre.Name = "txtMenuNombre";
            this.txtMenuNombre.Size = new System.Drawing.Size(143, 20);
            this.txtMenuNombre.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nombre";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(74, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Nuevo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCosto);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNombreItem);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAsignarItem);
            this.groupBox1.Controls.Add(this.lblNuevoMenu);
            this.groupBox1.Location = new System.Drawing.Point(419, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 180);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar Item a menu";
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(9, 121);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(171, 20);
            this.txtCosto.TabIndex = 22;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(9, 75);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(171, 20);
            this.txtDescripcion.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Costo";
            // 
            // txtNombreItem
            // 
            this.txtNombreItem.Location = new System.Drawing.Point(9, 36);
            this.txtNombreItem.Name = "txtNombreItem";
            this.txtNombreItem.ReadOnly = true;
            this.txtNombreItem.Size = new System.Drawing.Size(171, 20);
            this.txtNombreItem.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Descripcion";
            // 
            // btnAsignarItem
            // 
            this.btnAsignarItem.Location = new System.Drawing.Point(102, 147);
            this.btnAsignarItem.Name = "btnAsignarItem";
            this.btnAsignarItem.Size = new System.Drawing.Size(78, 23);
            this.btnAsignarItem.TabIndex = 15;
            this.btnAsignarItem.Text = "Agregar Item";
            this.btnAsignarItem.UseVisualStyleBackColor = true;
            this.btnAsignarItem.Click += new System.EventHandler(this.btnAsignarItem_Click);
            // 
            // lblNuevoMenu
            // 
            this.lblNuevoMenu.AutoSize = true;
            this.lblNuevoMenu.Location = new System.Drawing.Point(3, 20);
            this.lblNuevoMenu.Name = "lblNuevoMenu";
            this.lblNuevoMenu.Size = new System.Drawing.Size(44, 13);
            this.lblNuevoMenu.TabIndex = 7;
            this.lblNuevoMenu.Text = "Nombre";
            // 
            // dtItemsEnMenu
            // 
            this.dtItemsEnMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtItemsEnMenu.Location = new System.Drawing.Point(15, 307);
            this.dtItemsEnMenu.Name = "dtItemsEnMenu";
            this.dtItemsEnMenu.Size = new System.Drawing.Size(963, 261);
            this.dtItemsEnMenu.TabIndex = 18;
            // 
            // lblPermisos
            // 
            this.lblPermisos.AutoSize = true;
            this.lblPermisos.Location = new System.Drawing.Point(293, 12);
            this.lblPermisos.Name = "lblPermisos";
            this.lblPermisos.Size = new System.Drawing.Size(32, 13);
            this.lblPermisos.TabIndex = 17;
            this.lblPermisos.Text = "Items";
            // 
            // lstItemsDisponibles
            // 
            this.lstItemsDisponibles.FormattingEnabled = true;
            this.lstItemsDisponibles.Location = new System.Drawing.Point(293, 28);
            this.lstItemsDisponibles.Name = "lstItemsDisponibles";
            this.lstItemsDisponibles.Size = new System.Drawing.Size(120, 251);
            this.lstItemsDisponibles.TabIndex = 16;
            this.lstItemsDisponibles.SelectedIndexChanged += new System.EventHandler(this.lstItemsDisponibles_SelectedIndexChanged);
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
            this.lblSeleccionMenu.Location = new System.Drawing.Point(164, 12);
            this.lblSeleccionMenu.Name = "lblSeleccionMenu";
            this.lblSeleccionMenu.Size = new System.Drawing.Size(59, 13);
            this.lblSeleccionMenu.TabIndex = 13;
            this.lblSeleccionMenu.Text = "Menu/Item";
            // 
            // lstMenu
            // 
            this.lstMenu.FormattingEnabled = true;
            this.lstMenu.Location = new System.Drawing.Point(167, 28);
            this.lstMenu.Name = "lstMenu";
            this.lstMenu.Size = new System.Drawing.Size(120, 251);
            this.lstMenu.TabIndex = 10;
            this.lstMenu.SelectedIndexChanged += new System.EventHandler(this.lstMenu_SelectedIndexChanged);
            // 
            // AdministrarMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 627);
            this.Controls.Add(this.grpRoles);
            this.Name = "AdministrarMenu";
            this.Text = "Crear Menu";
            this.grpRoles.ResumeLayout(false);
            this.grpRoles.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtItemsEnMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpRoles;
        private System.Windows.Forms.Label lblPermisos;
        private System.Windows.Forms.ListBox lstItemsDisponibles;
        private System.Windows.Forms.Button btnAsignarItem;
        private System.Windows.Forms.Label lblPermisosAsociadosARol;
        private System.Windows.Forms.Label lblSeleccionMenu;
        private System.Windows.Forms.ListBox lstMenu;
        private System.Windows.Forms.DataGridView dtItemsEnMenu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMenuNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtNombreItem;
        private System.Windows.Forms.Label lblNuevoMenu;
    }
}