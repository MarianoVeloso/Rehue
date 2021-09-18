using Rehue.BE;
using Rehue.BLL;
using Rehue.Interfaces;
using Rehue.Servicios;
using Rehue.Servicios.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rehue.CitaForms
{
    public partial class DenunciaForm : Form, IIdiomaObserver
    {
        private readonly DenunciaBLL _denunciaBLL = new DenunciaBLL();

        private ICita _cita { get; set; }

        public DenunciaForm(ICita cita)
        {
            _cita = cita;
            InitializeComponent();
            FormLoad();
        }

        private void FormLoad()
        {
            lblEmpresaValue.Text = _cita.Mesa.Empresa.ObtenerNombre();
            lblPersonaValue.Text = _cita.Persona.ObtenerNombre();
            lblCantidadComensalesValue.Text = _cita.CantidadComensales.ToString();
            lblFechaCreacionValue.Text = _cita.FechaCreacion.ToString();
            TraductorBLL.SuscribirForm(this);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            IDenuncia denuncia = new Denuncia()
            {
                Descripcion = txtBoxMotivoTexto.Text,
                FechaCreacion = DateTime.Now
            };
            try
            {
                _denunciaBLL.CrearDenuncia(denuncia, _cita.Id);
                MessageBox.Show(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["DenunciaCreadaConExito"].Texto);
                this.Close();
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

        private void DenunciaForm_Load(object sender, EventArgs e)
        {
            ActualizarIdioma(Session.Instancia.Usuario.Idioma);
            TraductorBLL.SuscribirForm(this);
        }

        private void DenunciaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TraductorBLL.DesuscribirForm(this);
        }

        public void ActualizarIdioma(IIdioma idioma)
        {
            var traducciones = TraductorBLL.ObtenerTraducciones(idioma);

            btnGuardar.Text = traducciones["btnConfirmar"].Texto;
            btnCancelar.Text = traducciones["btnCancelar"].Texto;
            lblEmpresa.Text = traducciones["lblEmpresa"].Texto;
            lblFechaCreacion.Text = traducciones["lblFechaCreacion"].Texto;
            lblMotivo.Text = traducciones["lblMotivo"].Texto;
            lblPersona.Text = traducciones["lblPersona"].Texto;
            lblCantidadComensales.Text = traducciones["lblCantidadComensales"].Texto;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
