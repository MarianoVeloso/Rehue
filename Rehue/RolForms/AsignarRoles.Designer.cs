
namespace Rehue.RolForm
{
    partial class AsignarRoles
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
            this.lstUsuarios = new System.Windows.Forms.ListBox();
            this.lblUsuarios = new System.Windows.Forms.Label();
            this.lstRoles = new System.Windows.Forms.ListBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.btnAsignarRol = new System.Windows.Forms.Button();
            this.lstRolesDeUsuario = new System.Windows.Forms.ListBox();
            this.btnEliminarRol = new System.Windows.Forms.Button();
            this.lblRolesDeUsuario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstUsuarios
            // 
            this.lstUsuarios.FormattingEnabled = true;
            this.lstUsuarios.Location = new System.Drawing.Point(12, 38);
            this.lstUsuarios.Name = "lstUsuarios";
            this.lstUsuarios.Size = new System.Drawing.Size(155, 160);
            this.lstUsuarios.TabIndex = 0;
            this.lstUsuarios.SelectedIndexChanged += new System.EventHandler(this.lstUsuarios_SelectedIndexChanged);
            // 
            // lblUsuarios
            // 
            this.lblUsuarios.AutoSize = true;
            this.lblUsuarios.Location = new System.Drawing.Point(9, 22);
            this.lblUsuarios.Name = "lblUsuarios";
            this.lblUsuarios.Size = new System.Drawing.Size(48, 13);
            this.lblUsuarios.TabIndex = 1;
            this.lblUsuarios.Text = "Usuarios";
            // 
            // lstRoles
            // 
            this.lstRoles.FormattingEnabled = true;
            this.lstRoles.Location = new System.Drawing.Point(173, 38);
            this.lstRoles.Name = "lstRoles";
            this.lstRoles.Size = new System.Drawing.Size(164, 160);
            this.lstRoles.TabIndex = 2;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(170, 22);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(23, 13);
            this.lblRol.TabIndex = 5;
            this.lblRol.Text = "Rol";
            // 
            // btnAsignarRol
            // 
            this.btnAsignarRol.Location = new System.Drawing.Point(262, 205);
            this.btnAsignarRol.Name = "btnAsignarRol";
            this.btnAsignarRol.Size = new System.Drawing.Size(75, 23);
            this.btnAsignarRol.TabIndex = 6;
            this.btnAsignarRol.Text = "Asignar rol";
            this.btnAsignarRol.UseVisualStyleBackColor = true;
            this.btnAsignarRol.Click += new System.EventHandler(this.btnAsignarRol_Click);
            // 
            // lstRolesDeUsuario
            // 
            this.lstRolesDeUsuario.FormattingEnabled = true;
            this.lstRolesDeUsuario.Location = new System.Drawing.Point(12, 234);
            this.lstRolesDeUsuario.Name = "lstRolesDeUsuario";
            this.lstRolesDeUsuario.Size = new System.Drawing.Size(325, 173);
            this.lstRolesDeUsuario.TabIndex = 7;
            // 
            // btnEliminarRol
            // 
            this.btnEliminarRol.Location = new System.Drawing.Point(262, 413);
            this.btnEliminarRol.Name = "btnEliminarRol";
            this.btnEliminarRol.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarRol.TabIndex = 8;
            this.btnEliminarRol.Text = "Eliminar rol";
            this.btnEliminarRol.UseVisualStyleBackColor = true;
            this.btnEliminarRol.Click += new System.EventHandler(this.btnEliminarRol_Click);
            // 
            // lblRolesDeUsuario
            // 
            this.lblRolesDeUsuario.AutoSize = true;
            this.lblRolesDeUsuario.Location = new System.Drawing.Point(12, 215);
            this.lblRolesDeUsuario.Name = "lblRolesDeUsuario";
            this.lblRolesDeUsuario.Size = new System.Drawing.Size(88, 13);
            this.lblRolesDeUsuario.TabIndex = 9;
            this.lblRolesDeUsuario.Text = "Roles de Usuario";
            // 
            // AsignarRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 451);
            this.Controls.Add(this.lblRolesDeUsuario);
            this.Controls.Add(this.btnEliminarRol);
            this.Controls.Add(this.lstRolesDeUsuario);
            this.Controls.Add(this.btnAsignarRol);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.lstRoles);
            this.Controls.Add(this.lblUsuarios);
            this.Controls.Add(this.lstUsuarios);
            this.Name = "AsignarRoles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignar Roles";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AsignarRoles_FormClosed);
            this.Load += new System.EventHandler(this.AsignarRoles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstUsuarios;
        private System.Windows.Forms.Label lblUsuarios;
        private System.Windows.Forms.ListBox lstRoles;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Button btnAsignarRol;
        private System.Windows.Forms.ListBox lstRolesDeUsuario;
        private System.Windows.Forms.Button btnEliminarRol;
        private System.Windows.Forms.Label lblRolesDeUsuario;
    }
}