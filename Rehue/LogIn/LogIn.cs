using Rehue.BE;
using Rehue.BLL;
using Rehue.Interfaces;
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

namespace Rehue.LogIn
{
    public partial class LogIn : Form
    {
        private readonly RehueBLL _rehueBLL = new RehueBLL();
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            RegistrarPersona form = new RegistrarPersona();

            form.ShowDialog();

        }

        private void btnRegistrarEmpresa_Click(object sender, EventArgs e)
        {
            RegistrarEmpresa form = new RegistrarEmpresa();

            form.ShowDialog();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {

            try
            {

                _rehueBLL.ValidarEmail(txtUsuario.Text);

                //este metodo teoricamente ya devuelve el Id de la persona si esta logeada correctamente
                IUsuario persona = new Persona() { Email = txtUsuario.Text, Contraseña = txtContraseña.Text };
                _rehueBLL.ValidarUsuarioContraseña(persona);

                _rehueBLL.LogIn(persona);

                this.Close();
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
