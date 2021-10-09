﻿
namespace Rehue.CitaForms
{
    partial class ConsultarCitaForm
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
            this.lblCitasPendientes = new System.Windows.Forms.Label();
            this.dtGridPendienteConfirmacion = new System.Windows.Forms.DataGridView();
            this.dtGridCanceladas = new System.Windows.Forms.DataGridView();
            this.lblCitasCanceladas = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnDenunciar = new System.Windows.Forms.Button();
            this.dtGridViewCitasPendienteResolucion = new System.Windows.Forms.DataGridView();
            this.lblCitasPendientesDeResolucion = new System.Windows.Forms.Label();
            this.dtGridCitasConfirmadas = new System.Windows.Forms.DataGridView();
            this.lblCitasConfirmadas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridPendienteConfirmacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridCanceladas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridViewCitasPendienteResolucion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridCitasConfirmadas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCitasPendientes
            // 
            this.lblCitasPendientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCitasPendientes.AutoSize = true;
            this.lblCitasPendientes.Location = new System.Drawing.Point(16, 15);
            this.lblCitasPendientes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCitasPendientes.Name = "lblCitasPendientes";
            this.lblCitasPendientes.Size = new System.Drawing.Size(217, 17);
            this.lblCitasPendientes.TabIndex = 0;
            this.lblCitasPendientes.Text = "Citas pendientes de confirmación";
            // 
            // dtGridPendienteConfirmacion
            // 
            this.dtGridPendienteConfirmacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridPendienteConfirmacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtGridPendienteConfirmacion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtGridPendienteConfirmacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridPendienteConfirmacion.Location = new System.Drawing.Point(20, 34);
            this.dtGridPendienteConfirmacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtGridPendienteConfirmacion.MultiSelect = false;
            this.dtGridPendienteConfirmacion.Name = "dtGridPendienteConfirmacion";
            this.dtGridPendienteConfirmacion.ReadOnly = true;
            this.dtGridPendienteConfirmacion.RowHeadersWidth = 51;
            this.dtGridPendienteConfirmacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGridPendienteConfirmacion.Size = new System.Drawing.Size(1035, 215);
            this.dtGridPendienteConfirmacion.TabIndex = 1;
            this.dtGridPendienteConfirmacion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridPendienteConfirmacion_CellClick);
            this.dtGridPendienteConfirmacion.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtGridPendienteConfirmacion_DataBindingComplete);
            // 
            // dtGridCanceladas
            // 
            this.dtGridCanceladas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridCanceladas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtGridCanceladas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtGridCanceladas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridCanceladas.Location = new System.Drawing.Point(20, 747);
            this.dtGridCanceladas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtGridCanceladas.MultiSelect = false;
            this.dtGridCanceladas.Name = "dtGridCanceladas";
            this.dtGridCanceladas.RowHeadersWidth = 51;
            this.dtGridCanceladas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGridCanceladas.Size = new System.Drawing.Size(1035, 144);
            this.dtGridCanceladas.TabIndex = 3;
            // 
            // lblCitasCanceladas
            // 
            this.lblCitasCanceladas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCitasCanceladas.AutoSize = true;
            this.lblCitasCanceladas.Location = new System.Drawing.Point(16, 727);
            this.lblCitasCanceladas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCitasCanceladas.Name = "lblCitasCanceladas";
            this.lblCitasCanceladas.Size = new System.Drawing.Size(115, 17);
            this.lblCitasCanceladas.TabIndex = 2;
            this.lblCitasCanceladas.Text = "Citas canceladas";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.Location = new System.Drawing.Point(847, 257);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(100, 28);
            this.btnConfirmar.TabIndex = 4;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(955, 257);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 28);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnDenunciar
            // 
            this.btnDenunciar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDenunciar.Location = new System.Drawing.Point(955, 516);
            this.btnDenunciar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDenunciar.Name = "btnDenunciar";
            this.btnDenunciar.Size = new System.Drawing.Size(100, 28);
            this.btnDenunciar.TabIndex = 6;
            this.btnDenunciar.Text = "Denunciar";
            this.btnDenunciar.UseVisualStyleBackColor = true;
            this.btnDenunciar.Click += new System.EventHandler(this.btnDenunciar_Click);
            // 
            // dtGridViewCitasPendienteResolucion
            // 
            this.dtGridViewCitasPendienteResolucion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridViewCitasPendienteResolucion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtGridViewCitasPendienteResolucion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtGridViewCitasPendienteResolucion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridViewCitasPendienteResolucion.Location = new System.Drawing.Point(20, 569);
            this.dtGridViewCitasPendienteResolucion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtGridViewCitasPendienteResolucion.MultiSelect = false;
            this.dtGridViewCitasPendienteResolucion.Name = "dtGridViewCitasPendienteResolucion";
            this.dtGridViewCitasPendienteResolucion.RowHeadersWidth = 51;
            this.dtGridViewCitasPendienteResolucion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGridViewCitasPendienteResolucion.Size = new System.Drawing.Size(1035, 144);
            this.dtGridViewCitasPendienteResolucion.TabIndex = 7;
            // 
            // lblCitasPendientesDeResolucion
            // 
            this.lblCitasPendientesDeResolucion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCitasPendientesDeResolucion.AutoSize = true;
            this.lblCitasPendientesDeResolucion.Location = new System.Drawing.Point(16, 549);
            this.lblCitasPendientesDeResolucion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCitasPendientesDeResolucion.Name = "lblCitasPendientesDeResolucion";
            this.lblCitasPendientesDeResolucion.Size = new System.Drawing.Size(202, 17);
            this.lblCitasPendientesDeResolucion.TabIndex = 8;
            this.lblCitasPendientesDeResolucion.Text = "Citas pendientes de resolución";
            // 
            // dtGridCitasConfirmadas
            // 
            this.dtGridCitasConfirmadas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridCitasConfirmadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtGridCitasConfirmadas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtGridCitasConfirmadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridCitasConfirmadas.Location = new System.Drawing.Point(20, 293);
            this.dtGridCitasConfirmadas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtGridCitasConfirmadas.MultiSelect = false;
            this.dtGridCitasConfirmadas.Name = "dtGridCitasConfirmadas";
            this.dtGridCitasConfirmadas.ReadOnly = true;
            this.dtGridCitasConfirmadas.RowHeadersWidth = 51;
            this.dtGridCitasConfirmadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGridCitasConfirmadas.Size = new System.Drawing.Size(1035, 215);
            this.dtGridCitasConfirmadas.TabIndex = 10;
            this.dtGridCitasConfirmadas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridCitasConfirmadas_CellClick);
            this.dtGridCitasConfirmadas.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtGridCitasConfirmadas_DataBindingComplete);
            // 
            // lblCitasConfirmadas
            // 
            this.lblCitasConfirmadas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCitasConfirmadas.AutoSize = true;
            this.lblCitasConfirmadas.Location = new System.Drawing.Point(16, 273);
            this.lblCitasConfirmadas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCitasConfirmadas.Name = "lblCitasConfirmadas";
            this.lblCitasConfirmadas.Size = new System.Drawing.Size(120, 17);
            this.lblCitasConfirmadas.TabIndex = 9;
            this.lblCitasConfirmadas.Text = "Citas confirmadas";
            // 
            // ConsultarCitaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 946);
            this.Controls.Add(this.dtGridCitasConfirmadas);
            this.Controls.Add(this.lblCitasConfirmadas);
            this.Controls.Add(this.lblCitasPendientesDeResolucion);
            this.Controls.Add(this.dtGridViewCitasPendienteResolucion);
            this.Controls.Add(this.btnDenunciar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.dtGridCanceladas);
            this.Controls.Add(this.lblCitasCanceladas);
            this.Controls.Add(this.dtGridPendienteConfirmacion);
            this.Controls.Add(this.lblCitasPendientes);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ConsultarCitaForm";
            this.Text = "ConsultarCitaForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConsultarCitaForm_FormClosed);
            this.Load += new System.EventHandler(this.ConsultarCitaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridPendienteConfirmacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridCanceladas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridViewCitasPendienteResolucion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridCitasConfirmadas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCitasPendientes;
        private System.Windows.Forms.DataGridView dtGridPendienteConfirmacion;
        private System.Windows.Forms.DataGridView dtGridCanceladas;
        private System.Windows.Forms.Label lblCitasCanceladas;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnDenunciar;
        private System.Windows.Forms.DataGridView dtGridViewCitasPendienteResolucion;
        private System.Windows.Forms.Label lblCitasPendientesDeResolucion;
        private System.Windows.Forms.DataGridView dtGridCitasConfirmadas;
        private System.Windows.Forms.Label lblCitasConfirmadas;
    }
}