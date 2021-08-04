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
        private IDictionary<string, ITraduccion> _traducciones;
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
            TraductorBLL.SuscribirForm(this);

            var idioma = _idiomaBLL.ObtenerTodos();
            cmbIdioma.DataSource = null;
            cmbIdioma.DataSource = idioma;
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
            else if (Session.Instancia.Usuario.IsInRol("Empresa"))
            {
                MostrarEmpresa();
            }
            else if (Session.Instancia.Usuario.IsInRol("Persona"))
            {
                MostrarPersona();
            }
            else if (Session.Instancia.Usuario.IsInRol("Administrador"))
            {
                MostrarAdministrador();
            }
            else
            {
                MostrarUsuarioSinRoles();
            }
        }

        private void MostrarUsuarioSinRoles()
        {
            idiomaToolStripMenuItem.Visible = false;
            rolToolStripMenuItem.Visible = false;
            citaToolStripMenuItem.Visible = false;
            crearToolStripMenuItem.Visible = false;
            denunciasToolStripMenuItem.Visible = false;
            cmbIdioma.Text = Session.Instancia.Usuario.Idioma.Nombre;
            MostrarDatosUsuario();
        }

        private void MostrarEmpresa()
        {
            idiomaToolStripMenuItem.Visible = false;
            rolToolStripMenuItem.Visible = false;
            citaToolStripMenuItem.Visible = true;
            crearToolStripMenuItem.Visible = false;
            denunciasToolStripMenuItem.Visible = false;
            consultarToolStripMenuItem.Visible = true;
            cmbIdioma.Text = Session.Instancia.Usuario.Idioma.Nombre;
            MostrarDatosUsuario();
        }

        private void MostrarPersona()
        {
            idiomaToolStripMenuItem.Visible = false;
            rolToolStripMenuItem.Visible = false;
            citaToolStripMenuItem.Visible = true;
            crearToolStripMenuItem.Visible = true;
            denunciasToolStripMenuItem.Visible = false;
            consultarToolStripMenuItem.Visible = true;
            cmbIdioma.Text = Session.Instancia.Usuario.Idioma.Nombre;
            MostrarDatosUsuario();
        }

        private void MostrarAdministrador()
        {
            idiomaToolStripMenuItem.Visible = true;
            rolToolStripMenuItem.Visible = true;
            citaToolStripMenuItem.Visible = false;
            denunciasToolStripMenuItem.Visible = true;
            citaToolStripMenuItem.Visible = true;
            crearToolStripMenuItem.Visible = false;
            consultarToolStripMenuItem.Visible = false;
            cmbIdioma.Text = Session.Instancia.Usuario.Idioma.Nombre;
            MostrarDatosUsuario();
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
            _traducciones = TraductorBLL.ObtenerTraducciones(idioma);

            idiomaToolStripMenuItem.Text = _traducciones["idiomaToolStripMenuItem"].Texto;
            administrarToolStripMenuItem.Text = _traducciones["administrarToolStripMenuItem"].Texto;
            rolToolStripMenuItem.Text = _traducciones["rolToolStripMenuItem"].Texto;
            administrarToolStripMenuItem1.Text = _traducciones["administrarToolStripMenuItem1"].Texto;
            asignarToolStripMenuItem.Text = _traducciones["asignarToolStripMenuItem"].Texto;
            citaToolStripMenuItem.Text = _traducciones["citaToolStripMenuItem"].Texto;
            crearToolStripMenuItem.Text = _traducciones["crearToolStripMenuItem"].Texto;
            consultarToolStripMenuItem.Text = _traducciones["consultarToolStripMenuItem"].Texto;
            denunciasToolStripMenuItem.Text = _traducciones["denunciasToolStripMenuItem"].Texto;
            lblUsuario.Text = $"{_traducciones["lblUsuario"].Texto}: ";
        }

        private void MostrarDatosUsuario()
        {
            if (Session.Instancia.IsLogged())
            {
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

            foreach (Form frm in this.MdiChildren)
            {
                frm.Dispose();
                frm.Close();
            }

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
            ConsultarCitaForm form = new ConsultarCitaForm()
            {
                MdiParent = this
            };
            form.Show();
        }

        private void denunciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionarDenunciaForm form = new GestionarDenunciaForm()
            {
                MdiParent = this
            };
            form.Show();
        }
    }
}
