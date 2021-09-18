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

namespace Rehue.RolForm
{
    public partial class RolAltaForm : Form, IIdiomaObserver
    {
        private readonly RolComponentBLL _rolBLL = new RolComponentBLL();
        private IList<IRol> _roles;
        public RolAltaForm()
        {
            InitializeComponent();
        }
        public void ActualizarIdioma(IIdioma idioma)
        {
            var traducciones = TraductorBLL.ObtenerTraducciones(idioma);

            lblNuevoRol.Text = traducciones["lblNuevoRol"].Texto;
            lblPermisosAsociadosARol.Text = traducciones["lblPermisosAsociadosARol"].Texto;
            lblSeleccionRolHijo.Text = traducciones["lblSeleccionRolHijo"].Texto;
            btnNuevoRol.Text = traducciones["btnNuevoRol"].Texto;
            btnEliminarHijo.Text = traducciones["btnEliminarHijo"].Texto;
        }

        private void RolAltaForm_Load(object sender, EventArgs e)
        {
            FormLoad();
        }
        private void FormLoad()
        {
            ActualizarIdioma(Session.Instancia.Usuario.Idioma);
            TraductorBLL.SuscribirForm(this);
            _roles = _rolBLL.ObtenerTodos();

            lstRoles.DataSource = null;
            lstRoles.DataSource = _roles;
            lstRoles.DisplayMember = "Nombre";
        }

        private void btnNuevoRol_Click(object sender, EventArgs e)
        {
            IRol rol = new Rol()
            {
                Nombre = txtNuevoRol.Text
            };

            try
            {
                _rolBLL.Guardar(rol);
            }
            catch (OperacionDBException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            FormLoad();
        }

        private void lstRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            IRol rol = (IRol)lstRoles.SelectedItem;
            if (rol != null)
            {
                lstPermisos.DataSource = null;
                lstPermisos.DataSource = rol.ObtenerHijos();
                lstPermisos.DisplayMember = "Nombre";

                lstPermisosDisponibles.DataSource = null;
                lstPermisosDisponibles.DataSource = _roles.Where(x => x.Id != rol.Id).ToList();
            }
        }

        private void btnEliminarHijo_Click(object sender, EventArgs e)
        {
            var padre = (IRol)lstRoles.SelectedItem;
            var hijo = (IRol)lstPermisosDisponibles.SelectedItem;

            if (hijo != null)
            {
                try
                {
                    if (!padre.ObtenerHijos().Any(x => x.Id == hijo.Id))
                        throw new Exception("Hijo no asignado");
                    _rolBLL.EliminarHijo(new Permiso() {IdPadre = padre.Id, Id = hijo.Id });
                    FormLoad();
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
        }

        private void RolAltaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TraductorBLL.DesuscribirForm(this);
        }

        private void btnAsignarHijo_Click(object sender, EventArgs e)
        {
            var padre = (IRol)lstRoles.SelectedItem;
            var hijo = (IRol)lstPermisosDisponibles.SelectedItem;

            try
            {
                _rolBLL.AgregarHijo(new Permiso() { IdPadre = padre.Id, Id = hijo.Id });
                FormLoad();
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
    }
}
