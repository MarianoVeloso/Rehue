
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
            this.lblMesaDisponible = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.dtMesas = new System.Windows.Forms.DataGridView();
            this.btnCrear = new System.Windows.Forms.Button();
            this.numComensales = new System.Windows.Forms.NumericUpDown();
            this.lblComensales = new System.Windows.Forms.Label();
            this.dtPckrFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.grpCrearCita.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtMesas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numComensales)).BeginInit();
            this.SuspendLayout();
            // 
            // lstEmpresas
            // 
            this.lstEmpresas.FormattingEnabled = true;
            this.lstEmpresas.ItemHeight = 16;
            this.lstEmpresas.Location = new System.Drawing.Point(0, 39);
            this.lstEmpresas.Margin = new System.Windows.Forms.Padding(4);
            this.lstEmpresas.Name = "lstEmpresas";
            this.lstEmpresas.Size = new System.Drawing.Size(949, 180);
            this.lstEmpresas.TabIndex = 1;
            this.lstEmpresas.SelectedIndexChanged += new System.EventHandler(this.lstEmpresas_SelectedIndexChanged);
            // 
            // grpCrearCita
            // 
            this.grpCrearCita.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCrearCita.Controls.Add(this.lblMesaDisponible);
            this.grpCrearCita.Controls.Add(this.lblEmpresa);
            this.grpCrearCita.Controls.Add(this.dtMesas);
            this.grpCrearCita.Controls.Add(this.btnCrear);
            this.grpCrearCita.Controls.Add(this.numComensales);
            this.grpCrearCita.Controls.Add(this.lblComensales);
            this.grpCrearCita.Controls.Add(this.dtPckrFecha);
            this.grpCrearCita.Controls.Add(this.lblFecha);
            this.grpCrearCita.Controls.Add(this.lstEmpresas);
            this.grpCrearCita.Location = new System.Drawing.Point(16, 15);
            this.grpCrearCita.Margin = new System.Windows.Forms.Padding(4);
            this.grpCrearCita.Name = "grpCrearCita";
            this.grpCrearCita.Padding = new System.Windows.Forms.Padding(4);
            this.grpCrearCita.Size = new System.Drawing.Size(959, 626);
            this.grpCrearCita.TabIndex = 2;
            this.grpCrearCita.TabStop = false;
            this.grpCrearCita.Text = "Crear Cita";
            // 
            // lblMesaDisponible
            // 
            this.lblMesaDisponible.AutoSize = true;
            this.lblMesaDisponible.Location = new System.Drawing.Point(3, 238);
            this.lblMesaDisponible.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMesaDisponible.Name = "lblMesaDisponible";
            this.lblMesaDisponible.Size = new System.Drawing.Size(121, 16);
            this.lblMesaDisponible.TabIndex = 8;
            this.lblMesaDisponible.Text = "Mesas disponibles";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Location = new System.Drawing.Point(3, 20);
            this.lblEmpresa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(69, 16);
            this.lblEmpresa.TabIndex = 7;
            this.lblEmpresa.Text = "Empresas";
            // 
            // dtMesas
            // 
            this.dtMesas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtMesas.ColumnHeadersHeight = 29;
            this.dtMesas.Location = new System.Drawing.Point(0, 257);
            this.dtMesas.Margin = new System.Windows.Forms.Padding(4);
            this.dtMesas.Name = "dtMesas";
            this.dtMesas.RowHeadersWidth = 51;
            this.dtMesas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtMesas.Size = new System.Drawing.Size(951, 217);
            this.dtMesas.TabIndex = 0;
            this.dtMesas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtMesas_CellClick);
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(851, 591);
            this.btnCrear.Margin = new System.Windows.Forms.Padding(4);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(100, 28);
            this.btnCrear.TabIndex = 6;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // numComensales
            // 
            this.numComensales.Location = new System.Drawing.Point(113, 527);
            this.numComensales.Margin = new System.Windows.Forms.Padding(4);
            this.numComensales.Name = "numComensales";
            this.numComensales.Size = new System.Drawing.Size(267, 22);
            this.numComensales.TabIndex = 5;
            // 
            // lblComensales
            // 
            this.lblComensales.AutoSize = true;
            this.lblComensales.Location = new System.Drawing.Point(0, 529);
            this.lblComensales.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComensales.Name = "lblComensales";
            this.lblComensales.Size = new System.Drawing.Size(83, 16);
            this.lblComensales.TabIndex = 4;
            this.lblComensales.Text = "Comensales";
            // 
            // dtPckrFecha
            // 
            this.dtPckrFecha.Location = new System.Drawing.Point(115, 489);
            this.dtPckrFecha.Margin = new System.Windows.Forms.Padding(4);
            this.dtPckrFecha.Name = "dtPckrFecha";
            this.dtPckrFecha.Size = new System.Drawing.Size(265, 22);
            this.dtPckrFecha.TabIndex = 3;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(0, 489);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(107, 16);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha encuentro";
            // 
            // CitaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 645);
            this.Controls.Add(this.grpCrearCita);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CitaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CitaForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CitaForm_FormClosed);
            this.Load += new System.EventHandler(this.CitaForm_Load);
            this.grpCrearCita.ResumeLayout(false);
            this.grpCrearCita.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtMesas)).EndInit();
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
        private System.Windows.Forms.DataGridView dtMesas;
        private System.Windows.Forms.Label lblMesaDisponible;
        private System.Windows.Forms.Label lblEmpresa;
    }
}