using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rehue.BE;
using Rehue.BLL;
using Rehue.CitaForms;
using Rehue.IdiomaForms;
using Rehue.Interfaces;
using Rehue.LogIn;
using Rehue.RolForm;
using Rehue.Servicios;

namespace Rehue
{
    public partial class RehueForm : Form, IIdiomaObserver
    {
        private readonly IdiomaBLL _idiomaBLL = new IdiomaBLL();
        public RehueForm()
        {
            InitializeComponent();
        }
        private void RehueForm_Load(object sender, EventArgs e)
        {
            LoadForm();
            LogInForm();
        }

        private void LoadForm()
        {
            var idioma = _idiomaBLL.ObtenerTodos();
            cmbIdioma.DataSource = null;
            cmbIdioma.DataSource = idioma;

            TraductorBLL.SuscribirForm(this);
        }
        private void LogInForm()
        {
            LogInForm form = new LogInForm()
            {
                Idioma = (IIdioma)cmbIdioma.SelectedItem
            };
            form.ShowDialog();

            HabilitarFormulario();
        }
        private void HabilitarFormulario()
        {
            if (!Session.Instancia.IsLogged())
            {
                this.Close();
            }
            else if (Session.Instancia.Usuario.GetType().Equals(typeof(Empresa)))
            {
                MostrarEmpresa();
            }
            else if (Session.Instancia.Usuario.GetType().Equals(typeof(Persona)))
            {
                MostrarPersona();
            }
            else if (Session.Instancia.Usuario.GetType().Equals(typeof(Administrador)))
            {
                MostrarAdministrador();
            }
        }

        private void MostrarEmpresa()
        {
            idiomaToolStripMenuItem.Visible = false;
            rolToolStripMenuItem.Visible = false;
            citaToolStripMenuItem.Visible = true;
            citaToolStripMenuItem.Visible = true;
            crearToolStripMenuItem.Visible = false; 
            cmbIdioma.Text = Session.Instancia.Usuario.Idioma.Nombre;
        }

        private void MostrarPersona()
        {
            idiomaToolStripMenuItem.Visible = false;
            rolToolStripMenuItem.Visible = false;
            citaToolStripMenuItem.Visible = true;
            cmbIdioma.Text = Session.Instancia.Usuario.Idioma.Nombre;
        }

        private void MostrarAdministrador()
        {
            idiomaToolStripMenuItem.Visible = true;
            rolToolStripMenuItem.Visible = true;
            citaToolStripMenuItem.Visible = false;
            cmbIdioma.Text = Session.Instancia.Usuario.Idioma.Nombre;
        }

        private void administrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IdiomaAltaForm form = new IdiomaAltaForm
            {
                MdiParent = this
            };
            form.Show();
        }

        private void administrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RolAltaForm form = new RolAltaForm()
            {
                MdiParent = this
            };
            form.Show();
        }

        private void asignarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsignarRoles form = new AsignarRoles()
            {
                MdiParent = this
            };
            form.Show();
        }

        public void ActualizarIdioma(IIdioma idioma)
        {
            var traducciones = TraductorBLL.ObtenerTraducciones(idioma);

            idiomaToolStripMenuItem.Text = traducciones["idiomaToolStripMenuItem"].Texto;
            administrarToolStripMenuItem.Text = traducciones["administrarToolStripMenuItem"].Texto;
            rolToolStripMenuItem.Text = traducciones["rolToolStripMenuItem"].Texto;
            administrarToolStripMenuItem1.Text = traducciones["administrarToolStripMenuItem1"].Texto;
            asignarToolStripMenuItem.Text = traducciones["asignarToolStripMenuItem"].Texto;
            citaToolStripMenuItem.Text = traducciones["citaToolStripMenuItem"].Texto;
            crearToolStripMenuItem.Text = traducciones["crearToolStripMenuItem"].Texto;
            consultarToolStripMenuItem.Text = traducciones["consultarToolStripMenuItem"].Texto;
            cerrarSesionToolStripMenuItem.Text = traducciones["cerrarSesionToolStripMenuItem"].Texto;
            MostrarDatosUsuario(traducciones);
        }

        private void MostrarDatosUsuario(IDictionary<string, ITraduccion> traducciones = null)
        {
            if (Session.Instancia.IsLogged())
            {
                lblUsuario.Text = $"{traducciones["lblUsuario"].Texto}: ";
                lblUsuarioDato.Text = Session.Instancia.Usuario.Email;
            }
            else
            {
                lblUsuario.Text = string.Empty;
                lblUsuarioDato.Text = string.Empty;
            }
        }

        private void cmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIdioma.SelectedItem != null)
            {
                IIdioma idioma = (IIdioma)cmbIdioma.SelectedItem;
                CambiarIdioma(idioma);

                _idiomaBLL.ActualizarDefault(idioma);
            }
        }
        private void CambiarIdioma(IIdioma idioma)
        {
            TraductorBLL.CambiarIdioma(idioma);
        }
        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Session.Instancia.LogOut();
            MostrarDatosUsuario();
            LogInForm();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CitaForm form = new CitaForm()
            {
                MdiParent = this
            };
            form.Show();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
