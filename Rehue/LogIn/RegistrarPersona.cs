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
    public partial class RegistrarPersona : RegistroForm
    {
        private readonly PersonaBLL _personaBLL = new PersonaBLL();
        private readonly RehueBLL _rehueBLL = new RehueBLL();
        public RegistrarPersona()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            IPersona persona = new Persona()
            {
                Email = txtEmail.Text,
                Contraseña = txtPassword.Text,
                Telefono = txtTelefono.Text,
                FechaNacimiento = dtFechaNacimiento.Value,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Ubicacion = txtUbicacion.Text
            };

            try
            {
                _rehueBLL.ValidarUsuario(persona.Email);
                _personaBLL.Guardar(persona);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
