using Rehue.BLL;
using Rehue.Interfaces;
using Rehue.BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Rehue.Servicios.Helpers;
using Rehue.Servicios;

namespace Rehue.BackupForms
{
    public partial class BackupForm : Form, IIdiomaObserver
    {
        private readonly BackupBLL _servicio = new BackupBLL();

        private string _ruta = string.Empty;
        public BackupForm()
        {
            InitializeComponent();
            LoadForm();
        }

        public void ActualizarIdioma(IIdioma idioma)
        {
            var traducciones = TraductorBLL.ObtenerTraducciones(idioma);

            txtNombre.Text = traducciones["txtNombre"].Texto;
            lblRuta.Text = traducciones["lblRuta"].Texto;
        }

        private void LoadForm()
        {
            Dictionary<string, Type> columns = new Dictionary<string, Type> {
                { "NumeroCN", typeof(int) },
                { "NombreCN", typeof(string) },
                { "UbicacionCN", typeof(string) },
                { "FechaCreacionCN", typeof(DateTime) },
            };

            GrillaHelper.CrearColumnasGridCita(columns,
                new List<string> { "Id", "Nombre", "Ubicacion", "FechaCreacion" }, _servicio.ObtenerTodos(), dtBackups);
        }

        private void btnSeleccionarCarpeta_Click(object sender, EventArgs e)
        {
            using (var carpeta = new FolderBrowserDialog())
            {
                DialogResult result = carpeta.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(carpeta.SelectedPath))
                {
                    lblRuta.Text = carpeta.SelectedPath;
                    _ruta = carpeta.SelectedPath;
                    btnConfirmar.Enabled = true;
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarInput();

                IBackup backup = new Backup()
                {
                    Nombre = txtNombre.Text,
                    Ubicacion = lblRuta.Text
                };

                _servicio.Crear(backup);

                MessageBox.Show(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["BackupCreado"].Texto);
                LoadForm();
            }
            catch (OperacionDBException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ValidarInput()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
                throw new Exception(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["BackupNombreIncompleto"].Texto);
        }
    }
}
