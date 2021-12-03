
namespace Rehue.IdiomaForms
{
    partial class IdiomaAltaForm
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
            this.lstIdiomas = new System.Windows.Forms.ListBox();
            this.grpTraducciones = new System.Windows.Forms.GroupBox();
            this.panelContent = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblNuevoIdioma = new System.Windows.Forms.Label();
            this.txtNuevoIdioma = new System.Windows.Forms.TextBox();
            this.btnNuevoIdioma = new System.Windows.Forms.Button();
            this.grpTraducciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstIdiomas
            // 
            this.lstIdiomas.FormattingEnabled = true;
            this.lstIdiomas.Location = new System.Drawing.Point(15, 96);
            this.lstIdiomas.Name = "lstIdiomas";
            this.lstIdiomas.Size = new System.Drawing.Size(120, 316);
            this.lstIdiomas.TabIndex = 0;
            this.lstIdiomas.SelectedIndexChanged += new System.EventHandler(this.lstIdiomas_SelectedIndexChanged);
            // 
            // grpTraducciones
            // 
            this.grpTraducciones.Controls.Add(this.panelContent);
            this.grpTraducciones.Location = new System.Drawing.Point(141, 12);
            this.grpTraducciones.Name = "grpTraducciones";
            this.grpTraducciones.Size = new System.Drawing.Size(460, 400);
            this.grpTraducciones.TabIndex = 1;
            this.grpTraducciones.TabStop = false;
            this.grpTraducciones.Text = "Traducciones";
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.Location = new System.Drawing.Point(6, 19);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(448, 375);
            this.panelContent.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(445, 418);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(526, 418);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblNuevoIdioma
            // 
            this.lblNuevoIdioma.AutoSize = true;
            this.lblNuevoIdioma.Location = new System.Drawing.Point(12, 12);
            this.lblNuevoIdioma.Name = "lblNuevoIdioma";
            this.lblNuevoIdioma.Size = new System.Drawing.Size(72, 13);
            this.lblNuevoIdioma.TabIndex = 4;
            this.lblNuevoIdioma.Text = "Nuevo idioma";
            // 
            // txtNuevoIdioma
            // 
            this.txtNuevoIdioma.Location = new System.Drawing.Point(15, 31);
            this.txtNuevoIdioma.Name = "txtNuevoIdioma";
            this.txtNuevoIdioma.Size = new System.Drawing.Size(120, 20);
            this.txtNuevoIdioma.TabIndex = 5;
            // 
            // btnNuevoIdioma
            // 
            this.btnNuevoIdioma.Location = new System.Drawing.Point(59, 58);
            this.btnNuevoIdioma.Name = "btnNuevoIdioma";
            this.btnNuevoIdioma.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoIdioma.TabIndex = 6;
            this.btnNuevoIdioma.Text = "Nuevo";
            this.btnNuevoIdioma.UseVisualStyleBackColor = true;
            this.btnNuevoIdioma.Click += new System.EventHandler(this.btnNuevoIdioma_Click);
            // 
            // IdiomaAltaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 465);
            this.Controls.Add(this.btnNuevoIdioma);
            this.Controls.Add(this.txtNuevoIdioma);
            this.Controls.Add(this.lblNuevoIdioma);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.grpTraducciones);
            this.Controls.Add(this.lstIdiomas);
            this.Name = "IdiomaAltaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Idioma";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IdiomaAltaForm_FormClosed);
            this.Load += new System.EventHandler(this.IdiomaAlta_Load);
            this.grpTraducciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstIdiomas;
        private System.Windows.Forms.GroupBox grpTraducciones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblNuevoIdioma;
        private System.Windows.Forms.TextBox txtNuevoIdioma;
        private System.Windows.Forms.Button btnNuevoIdioma;
    }
}