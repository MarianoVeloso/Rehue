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
    public partial class RegistrarEmpresa : RegistroForm
    {
        private readonly EmpresaBLL _empresaBLL = new EmpresaBLL();
        private readonly RehueBLL _rehueBLL = new RehueBLL();
        public RegistrarEmpresa()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            IEmpresa empresa = new Empresa()
            {
                Email = txtEmail.Text,
                Contraseña = txtPassword.Text,
                Telefono = txtTelefono.Text,
                FechaNacimiento = dtFechaNacimiento.Value,
                RazonSocial = txtRazonSocial.Text,
                Documento = int.Parse(numDocumento.Value.ToString()),
                Ubicacion = txtUbicacion.Text
            };

            try
            {
                _rehueBLL.ValidarEmail(empresa.Email);
                _empresaBLL.Guardar(empresa);

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
