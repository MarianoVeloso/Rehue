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
    public partial class AsignarRoles : Form, IIdiomaObserver
    {
        private readonly RolComponentBLL _rolBLL = new RolComponentBLL();
        private readonly RehueBLL _rehueBLL = new RehueBLL();

        public AsignarRoles()
        {
            InitializeComponent();
        }

        private void AsignarRoles_Load(object sender, EventArgs e)
        {
            FormLoad();
        }

        private void FormLoad()
        {
            ActualizarIdioma(Session.Instancia.Usuario.Idioma);
            TraductorBLL.SuscribirForm(this);

            lstRoles.DataSource = null;
            lstUsuarios.DataSource = null;

            lstRoles.DataSource = _rolBLL.ObtenerTodos();

            lstUsuarios.DataSource = _rehueBLL.ObtenerIdEmailUsuarios();
            lstUsuarios.DisplayMember = "Email";
        }

        private void lstUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            IUsuario usuario = (IUsuario)lstUsuarios.SelectedItem;

            if (usuario != null)
            {
                lstRolesDeUsuario.DataSource = null;
                lstRolesDeUsuario.DataSource = _rolBLL.ObtenerPorUsuario(usuario.Id);
            }
        }

        private void btnAsignarRol_Click(object sender, EventArgs e)
        {
            IUsuario usuario = (IUsuario)lstUsuarios.SelectedItem;
            IRol rol = (IRol)lstRoles.SelectedItem;

            if (usuario != null || rol != null)
            {
                try
                {
                    _rolBLL.AsignarRolAUsuario(usuario, rol);
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

        private void btnEliminarRol_Click(object sender, EventArgs e)
        {
            IUsuario usuario = (IUsuario)lstUsuarios.SelectedItem;
            IRol rol = (IRol)lstRolesDeUsuario.SelectedItem;

            if (usuario != null || rol != null)
            {
                try
                {
                    _rolBLL.EliminarRolAUsuario(usuario, rol);
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

        public void ActualizarIdioma(IIdioma idioma)
        {
            var traducciones = TraductorBLL.ObtenerTraducciones(idioma);

            lblRol.Text = traducciones["lblRol"].Texto;
            lblUsuarios.Text = traducciones["lblUsuarios"].Texto;
            btnAsignarRol.Text = traducciones["btnAsignarRol"].Texto;
            btnEliminarRol.Text = traducciones["btnEliminarRol"].Texto;
            lblRolesDeUsuario.Text = traducciones["lblRolesDeUsuario"].Texto;
        }

        private void AsignarRoles_FormClosed(object sender, FormClosedEventArgs e)
        {
            TraductorBLL.DesuscribirForm(this);
        }
    }
}
