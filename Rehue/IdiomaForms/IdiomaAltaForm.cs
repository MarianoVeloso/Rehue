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

namespace Rehue.IdiomaForms
{
    public partial class IdiomaAltaForm : Form, IIdiomaObserver
    {
        private readonly IdiomaBLL _idiomaBLL = new IdiomaBLL();
        public IdiomaAltaForm()
        {
            InitializeComponent();
        }

        private void IdiomaAlta_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        {
            TraductorBLL.SuscribirForm(this);
            ActualizarIdioma(Session.Instancia.Usuario.Idioma);
            var idiomas = _idiomaBLL.ObtenerTodos();

            lstIdiomas.DataSource = null;
            lstIdiomas.DataSource = idiomas;
        }

        private void lstIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            IIdioma idioma = (IIdioma)lstIdiomas.SelectedItem;
            if (idioma != null)
            {
                var traducciones = _idiomaBLL.ObtenerTraducciones(idioma.Id);
                var etiquetas = _idiomaBLL.ObtenerEtiquetas();

                int x = 15;
                int y = 15;
                panelContent.Controls.Clear();
                foreach (var etiqueta in etiquetas)
                {
                    var traduccion = traducciones.Where(_ => _.Value.Etiqueta.Id == etiqueta.Id).FirstOrDefault();

                    if (traduccion.Value != null)
                    {
                        var control = new IdiomaUC
                        {
                            Traduccion = traduccion.Value,
                            Etiqueta = traduccion.Value.Etiqueta,
                            Location = new Point(x, y)
                        };
                        panelContent.Controls.Add(control);
                    }
                    else
                    {
                        var control = new IdiomaUC
                        {
                            Traduccion = new Traduccion(),
                            Etiqueta = etiqueta,
                            Location = new Point(x, y)
                        };
                        panelContent.Controls.Add(control);
                    }
                    y += 60;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            IIdioma idioma = (IIdioma)lstIdiomas.SelectedItem;
            try
            {
                _idiomaBLL.GuardarTraduccion(ConstruirTraducciones(idioma), idioma);
            }
            catch (ErrorLogInException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private IDictionary<IEtiqueta, ITraduccion> ConstruirTraducciones(IIdioma idioma)
        {

            IDictionary<IEtiqueta, ITraduccion> traducciones = new Dictionary<IEtiqueta, ITraduccion>();

            foreach (var control in panelContent.Controls)
            {
                IdiomaUC uc = (IdiomaUC)control;

                if (string.IsNullOrEmpty(uc.Traduccion.Texto))
                    throw new Exception(TraductorBLL.ObtenerTraducciones(idioma)["ErrorTraduccion"].Texto);

                var etiqueta = uc.Etiqueta;

                traducciones.Add(etiqueta, uc.Traduccion);
            }
            return traducciones;
        }

        private void btnNuevoIdioma_Click(object sender, EventArgs e)
        {
            IIdioma idioma = new Idioma()
            {
                Nombre = txtNuevoIdioma.Text
            };
            try
            {
                _idiomaBLL.Guardar(idioma);
                LoadForm();
            }
            catch (ErrorLogInException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ActualizarIdioma(IIdioma idioma)
        {
            var traducciones = TraductorBLL.ObtenerTraducciones(idioma);

            lblNuevoIdioma.Text = traducciones["lblNuevoIdioma"].Texto;
            btnCancelar.Text = traducciones["btnCancelar"].Texto;
            btnGuardar.Text = traducciones["btnGuardar"].Texto;
            grpTraducciones.Text = traducciones["grpTraducciones"].Texto;
        }

        private void IdiomaAltaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TraductorBLL.DesuscribirForm(this);
        }
    }
}
