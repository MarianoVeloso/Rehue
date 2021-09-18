
using System.Windows.Forms;

namespace Rehue.CitaForms
{
    partial class RegistrarMesa
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
            this.lblCantidadComensales = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.numComensales = new System.Windows.Forms.NumericUpDown();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnCrear = new System.Windows.Forms.Button();
            this.lblMesas = new System.Windows.Forms.Label();
            this.dtMesas = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numComensales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMesas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCantidadComensales
            // 
            this.lblCantidadComensales.AutoSize = true;
            this.lblCantidadComensales.Location = new System.Drawing.Point(13, 13);
            this.lblCantidadComensales.Name = "lblCantidadComensales";
            this.lblCantidadComensales.Size = new System.Drawing.Size(109, 13);
            this.lblCantidadComensales.TabIndex = 0;
            this.lblCantidadComensales.Text = "Cantidad Comensales";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(12, 48);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // numComensales
            // 
            this.numComensales.Location = new System.Drawing.Point(165, 13);
            this.numComensales.Name = "numComensales";
            this.numComensales.Size = new System.Drawing.Size(120, 20);
            this.numComensales.TabIndex = 2;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(165, 41);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(369, 22);
            this.txtDescripcion.TabIndex = 3;
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(434, 70);
            this.btnCrear.Margin = new System.Windows.Forms.Padding(4);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(100, 28);
            this.btnCrear.TabIndex = 7;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // lblMesas
            // 
            this.lblMesas.AutoSize = true;
            this.lblMesas.Location = new System.Drawing.Point(15, 113);
            this.lblMesas.Name = "lblMesas";
            this.lblMesas.Size = new System.Drawing.Size(38, 13);
            this.lblMesas.TabIndex = 10;
            this.lblMesas.Text = "Mesas";
            // 
            // dtMesas
            // 
            this.dtMesas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtMesas.Location = new System.Drawing.Point(18, 133);
            this.dtMesas.Name = "dtMesas";
            this.dtMesas.ReadOnly = true;
            this.dtMesas.RowHeadersWidth = 51;
            this.dtMesas.RowTemplate.Height = 24;
            this.dtMesas.Size = new System.Drawing.Size(519, 239);
            this.dtMesas.TabIndex = 11;
            this.dtMesas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtMesas_CellClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(434, 379);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 28);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // RegistrarMesa
            // 
            this.ClientSize = new System.Drawing.Size(549, 420);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dtMesas);
            this.Controls.Add(this.lblMesas);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.numComensales);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblCantidadComensales);
            this.Name = "RegistrarMesa";
            this.Text = "RegistrarMesa";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegistrarMesa_FormClosed);
            this.Load += new System.EventHandler(this.RegistrarMesa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numComensales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMesas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblDescripcion;
        private NumericUpDown numComensales;
        private TextBox txtDescripcion;
        private Button btnCrear;
        private Label lblMesas;
        private DataGridView dtMesas;
        private Label lblCantidadComensales;
        private Button btnEliminar;
    }
}