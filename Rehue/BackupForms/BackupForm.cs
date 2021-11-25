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
                { "TamañoCN", typeof(decimal) }
            };

            GrillaHelper.CrearGrilla(columns,
                new List<string> { "Id", "Nombre", "Ubicacion", "FechaCreacion", "Tamaño" }, _servicio.ObtenerTodos(), dtBackups);
            lblRuta.Text = string.Empty;
            lblNombreRestoreValue.Text = string.Empty;
            lblUbicacionRestoreValue.Text = string.Empty;
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

        private void dtBackups_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int id = int.Parse(dtBackups[0, e.RowIndex].Value.ToString());

                IBackup backup = _servicio.ObtenerPorId(id);

                lblNombreRestoreValue.Text = backup.Nombre;
                lblUbicacionRestoreValue.Text = backup.Ubicacion;
                btnConfirmarRestore.Enabled = true;
            }
        }

        private void btnConfirmarRestore_Click(object sender, EventArgs e)
        {
            try
            {
                _servicio.RestaturarBackup(lblUbicacionRestoreValue.Text);
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
    }
}
