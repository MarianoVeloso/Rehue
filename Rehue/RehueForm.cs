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
using Rehue.BE.Bitacora;
using Rehue.BLL;
using Rehue.CitaForms;
using Rehue.IdiomaForms;
using Rehue.Interfaces;
using Rehue.Interfaces.Eventos;
using Rehue.LogIn;
using Rehue.RolForm;
using Rehue.Servicios;
using Rehue.Servicios.Bitacora;
using Rehue.BackupForms;
using Rehue.SubscripcionForms;
using Rehue.Logs;
using Rehue.Servicios.Helpers;
using System.Diagnostics;

namespace Rehue
{
    public partial class RehueForm : Form, IIdiomaObserver
    {
        private IDictionary<string, ITraduccion> _traducciones;
        private readonly IdiomaBLL _idiomaBLL = new IdiomaBLL();
        private readonly BitacoraBLL _bitacoraBLL = new BitacoraBLL();
        private readonly BackupBLL _backupBLL = new BackupBLL();
        public RehueForm()
        {
            InitializeComponent();
        }
        private void RehueForm_Load(object sender, EventArgs e)
        {
            try
            {
                VerificarBBDD();
                LoadForm();
                LogInForm();
            }
            catch (InstaladorException ex)
            {
                DialogResult result = MessageBox.Show(ex.Message, "Configuracion", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    Process.Start(@"C:\Rehue\Config\SQLServer.exe");
                    this.Close();
                }
            }
            catch (ConexionDBException ex)
            {
                MessageBox.Show(ex.Message);
                BackupForm form = new BackupForm(true);
                form.ShowDialog();
                RehueForm_Load(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void LoadForm()
        {
            TraductorBLL.SuscribirForm(this);

            var idioma = _idiomaBLL.ObtenerTodos();
            cmbIdioma.DataSource = null;
            cmbIdioma.DataSource = idioma;
        }

        private void VerificarBBDD()
        {
            _backupBLL.VerificarRegistroYConexion();
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
                ActualizarIdioma(Session.Instancia.Usuario.Idioma);
            }
            else if (Session.Instancia.Usuario.IsInRol("Persona"))
            {
                MostrarPersona();
                ActualizarIdioma(Session.Instancia.Usuario.Idioma);
            }
            else if (Session.Instancia.Usuario.IsInRol("Administrador"))
            {
                MostrarAdministrador();
                ActualizarIdioma(Session.Instancia.Usuario.Idioma);
            }
            else
            {
                MostrarUsuarioSinRoles();
                ActualizarIdioma(Session.Instancia.Usuario.Idioma);
            }

            var idioma = _idiomaBLL.ObtenerTodos();
            cmbIdioma.DataSource = null;
            cmbIdioma.DataSource = idioma;
        }

        private void MostrarUsuarioSinRoles()
        {
            idiomaToolStripMenuItem.Visible = false;
            rolToolStripMenuItem.Visible = false;
            citaToolStripMenuItem.Visible = false;
            crearToolStripMenuItem.Visible = false;
            denunciasToolStripMenuItem.Visible = false;
            subscripcionToolStripMenuItem.Visible = false;
            crearToolStripMenuItem2.Visible = false;
            comprarToolStripMenuItem.Visible = false;
            leerLogsToolStripMenuItem.Visible = false;
            menuToolStripMenuItem.Visible = false;
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
            mesaToolStripMenuItem.Visible = true;
            backupToolStripMenuItem.Visible = false;
            subscripcionToolStripMenuItem.Visible = true;
            comprarToolStripMenuItem.Visible = true;
            crearToolStripMenuItem2.Visible = false;
            leerLogsToolStripMenuItem.Visible = false;
            menuToolStripMenuItem.Visible = false;

            if (((IEmpresa)Session.Instancia.Usuario).ObtenerSubscripcion() != null)
            {
                menuToolStripMenuItem.Visible = true;
            }
            else
            {
                menuToolStripMenuItem.Visible = false;
            }
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
            mesaToolStripMenuItem.Visible = false;
            backupToolStripMenuItem.Visible = false;
            subscripcionToolStripMenuItem.Visible = false;
            crearToolStripMenuItem2.Visible = false;
            comprarToolStripMenuItem.Visible = false;
            leerLogsToolStripMenuItem.Visible = false;
            menuToolStripMenuItem.Visible = false;
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
            mesaToolStripMenuItem.Visible = false;
            backupToolStripMenuItem.Visible = true;
            subscripcionToolStripMenuItem.Visible = true;
            crearToolStripMenuItem2.Visible = true;
            leerLogsToolStripMenuItem.Visible = true;
            comprarToolStripMenuItem.Visible = false;
            menuToolStripMenuItem.Visible = false;
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
            mesaToolStripMenuItem.Text = _traducciones["mesaToolStripMenuItem"].Texto;
            lblUsuario.Text = $"{_traducciones["lblUsuario"].Texto}: ";
            gestionarToolStripMenuItem.Text = _traducciones["gestionarToolStripMenuItem"].Texto;
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
            try
            {
                BitacoraOperador<IUsuario>.Instancia.EstablecerBitacora(new BitacoraSignOut());
                ILogSignOut evento = (ILogSignOut)BitacoraOperador<IUsuario>.Instancia.ObtenerEvento(Session.Instancia.Usuario, $"El usuario {Session.Instancia.Usuario.ObtenerNombre()} se deslogeo correctamente.");
                _bitacoraBLL.RegistrarEventoLogOut(evento);

                Session.Instancia.LogOut();
            }
            catch (Exception)
            {
                throw;
            }

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

        private void gestionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarMesa form = new RegistrarMesa()
            {
                MdiParent = this
            };
            form.Show();
        }

        private void crearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BackupForm form = new BackupForm()
            {
                MdiParent = this
            };
            form.Show();
        }

        private void administrarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CrearSubscripcionForm form = new CrearSubscripcionForm()
            {
                MdiParent = this
            };
            form.Show();
        }

        private void comprarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComprarSubscripcionForm form = new ComprarSubscripcionForm();

            form.ShowDialog();
            MostrarEmpresa();
        }


        private void leerLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LeerLogsForm form = new LeerLogsForm()
            {
                MdiParent = this
            };
            form.Show();
        }
    }
}
