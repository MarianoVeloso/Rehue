
namespace Rehue.RolForm
{
    partial class RolAltaForm
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
            this.txtNuevoRol = new System.Windows.Forms.TextBox();
            this.lblNuevoRol = new System.Windows.Forms.Label();
            this.btnNuevoRol = new System.Windows.Forms.Button();
            this.lstPermisos = new System.Windows.Forms.ListBox();
            this.grpRoles = new System.Windows.Forms.GroupBox();
            this.lblPermisosAsociadosARol = new System.Windows.Forms.Label();
            this.lblSeleccionRolHijo = new System.Windows.Forms.Label();
            this.btnEliminarHijo = new System.Windows.Forms.Button();
            this.lstRoles = new System.Windows.Forms.ListBox();
            this.btnAsignarHijo = new System.Windows.Forms.Button();
            this.lstPermisosDisponibles = new System.Windows.Forms.ListBox();
            this.lblPermisos = new System.Windows.Forms.Label();
            this.grpRoles.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNuevoRol
            // 
            this.txtNuevoRol.Location = new System.Drawing.Point(9, 32);
            this.txtNuevoRol.Name = "txtNuevoRol";
            this.txtNuevoRol.Size = new System.Drawing.Size(120, 20);
            this.txtNuevoRol.TabIndex = 6;
            // 
            // lblNuevoRol
            // 
            this.lblNuevoRol.AutoSize = true;
            this.lblNuevoRol.Location = new System.Drawing.Point(6, 16);
            this.lblNuevoRol.Name = "lblNuevoRol";
            this.lblNuevoRol.Size = new System.Drawing.Size(58, 13);
            this.lblNuevoRol.TabIndex = 7;
            this.lblNuevoRol.Text = "Nuevo Rol";
            // 
            // btnNuevoRol
            // 
            this.btnNuevoRol.Location = new System.Drawing.Point(54, 58);
            this.btnNuevoRol.Name = "btnNuevoRol";
            this.btnNuevoRol.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoRol.TabIndex = 8;
            this.btnNuevoRol.Text = "Nuevo";
            this.btnNuevoRol.UseVisualStyleBackColor = true;
            this.btnNuevoRol.Click += new System.EventHandler(this.btnNuevoRol_Click);
            // 
            // lstPermisos
            // 
            this.lstPermisos.FormattingEnabled = true;
            this.lstPermisos.Location = new System.Drawing.Point(336, 32);
            this.lstPermisos.Name = "lstPermisos";
            this.lstPermisos.Size = new System.Drawing.Size(267, 342);
            this.lstPermisos.TabIndex = 9;
            // 
            // grpRoles
            // 
            this.grpRoles.Controls.Add(this.lblPermisos);
            this.grpRoles.Controls.Add(this.lstPermisosDisponibles);
            this.grpRoles.Controls.Add(this.btnAsignarHijo);
            this.grpRoles.Controls.Add(this.lblPermisosAsociadosARol);
            this.grpRoles.Controls.Add(this.lblSeleccionRolHijo);
            this.grpRoles.Controls.Add(this.btnEliminarHijo);
            this.grpRoles.Controls.Add(this.lstRoles);
            this.grpRoles.Controls.Add(this.lstPermisos);
            this.grpRoles.Controls.Add(this.btnNuevoRol);
            this.grpRoles.Controls.Add(this.lblNuevoRol);
            this.grpRoles.Controls.Add(this.txtNuevoRol);
            this.grpRoles.Location = new System.Drawing.Point(12, 12);
            this.grpRoles.Name = "grpRoles";
            this.grpRoles.Size = new System.Drawing.Size(616, 414);
            this.grpRoles.TabIndex = 10;
            this.grpRoles.TabStop = false;
            this.grpRoles.Text = "Rol";
            // 
            // lblPermisosAsociadosARol
            // 
            this.lblPermisosAsociadosARol.AutoSize = true;
            this.lblPermisosAsociadosARol.Location = new System.Drawing.Point(333, 16);
            this.lblPermisosAsociadosARol.Name = "lblPermisosAsociadosARol";
            this.lblPermisosAsociadosARol.Size = new System.Drawing.Size(123, 13);
            this.lblPermisosAsociadosARol.TabIndex = 14;
            this.lblPermisosAsociadosARol.Text = "Permisos asociados a rol";
            // 
            // lblSeleccionRolHijo
            // 
            this.lblSeleccionRolHijo.AutoSize = true;
            this.lblSeleccionRolHijo.Location = new System.Drawing.Point(6, 107);
            this.lblSeleccionRolHijo.Name = "lblSeleccionRolHijo";
            this.lblSeleccionRolHijo.Size = new System.Drawing.Size(34, 13);
            this.lblSeleccionRolHijo.TabIndex = 13;
            this.lblSeleccionRolHijo.Text = "Roles";
            // 
            // btnEliminarHijo
            // 
            this.btnEliminarHijo.Location = new System.Drawing.Point(127, 233);
            this.btnEliminarHijo.Name = "btnEliminarHijo";
            this.btnEliminarHijo.Size = new System.Drawing.Size(77, 23);
            this.btnEliminarHijo.TabIndex = 11;
            this.btnEliminarHijo.Text = "Eliminar Hijo";
            this.btnEliminarHijo.UseVisualStyleBackColor = true;
            this.btnEliminarHijo.Click += new System.EventHandler(this.btnEliminarHijo_Click);
            // 
            // lstRoles
            // 
            this.lstRoles.FormattingEnabled = true;
            this.lstRoles.Location = new System.Drawing.Point(0, 123);
            this.lstRoles.Name = "lstRoles";
            this.lstRoles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstRoles.Size = new System.Drawing.Size(120, 251);
            this.lstRoles.TabIndex = 10;
            this.lstRoles.SelectedIndexChanged += new System.EventHandler(this.lstRoles_SelectedIndexChanged);
            // 
            // btnAsignarHijo
            // 
            this.btnAsignarHijo.Location = new System.Drawing.Point(126, 204);
            this.btnAsignarHijo.Name = "btnAsignarHijo";
            this.btnAsignarHijo.Size = new System.Drawing.Size(78, 23);
            this.btnAsignarHijo.TabIndex = 15;
            this.btnAsignarHijo.Text = "Asignar hijo";
            this.btnAsignarHijo.UseVisualStyleBackColor = true;
            this.btnAsignarHijo.Click += new System.EventHandler(this.btnAsignarHijo_Click);
            // 
            // lstPermisosDisponibles
            // 
            this.lstPermisosDisponibles.FormattingEnabled = true;
            this.lstPermisosDisponibles.Location = new System.Drawing.Point(210, 123);
            this.lstPermisosDisponibles.Name = "lstPermisosDisponibles";
            this.lstPermisosDisponibles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstPermisosDisponibles.Size = new System.Drawing.Size(120, 251);
            this.lstPermisosDisponibles.TabIndex = 16;
            // 
            // lblPermisos
            // 
            this.lblPermisos.AutoSize = true;
            this.lblPermisos.Location = new System.Drawing.Point(207, 107);
            this.lblPermisos.Name = "lblPermisos";
            this.lblPermisos.Size = new System.Drawing.Size(49, 13);
            this.lblPermisos.TabIndex = 17;
            this.lblPermisos.Text = "Permisos";
            // 
            // RolAltaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 442);
            this.Controls.Add(this.grpRoles);
            this.Name = "RolAltaForm";
            this.Text = "RolAltaForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RolAltaForm_FormClosed);
            this.Load += new System.EventHandler(this.RolAltaForm_Load);
            this.grpRoles.ResumeLayout(false);
            this.grpRoles.PerformLayout();
            this.ResumeLayout(false);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

        }

        #endregion
        private System.Windows.Forms.TextBox txtNuevoRol;
        private System.Windows.Forms.Label lblNuevoRol;
        private System.Windows.Forms.Button btnNuevoRol;
        private System.Windows.Forms.ListBox lstPermisos;
        private System.Windows.Forms.GroupBox grpRoles;
        private System.Windows.Forms.Button btnEliminarHijo;
        private System.Windows.Forms.ListBox lstRoles;
        private System.Windows.Forms.Label lblSeleccionRolHijo;
        private System.Windows.Forms.Label lblPermisosAsociadosARol;
        private System.Windows.Forms.Button btnAsignarHijo;
        private System.Windows.Forms.ListBox lstPermisosDisponibles;
        private System.Windows.Forms.Label lblPermisos;
    }
}