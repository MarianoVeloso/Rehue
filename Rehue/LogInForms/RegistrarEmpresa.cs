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
    public partial class RegistrarEmpresa : RegistroForm, IIdiomaObserver
    {
        private IIdioma _idioma;

        public IIdioma Idioma
        {
            get { return _idioma; }
            set { _idioma = value; }
        }
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
                Ubicacion = txtUbicacion.Text,
                Idioma = _idioma
            };

            try
            {
                _rehueBLL.ValidarEmail(empresa.Email, _idioma);
                _empresaBLL.Guardar(empresa);
                _rehueBLL.LogIn(empresa, _idioma);
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

        public void ActualizarIdioma(IIdioma idioma)
        {
            var traducciones = TraductorBLL.ObtenerTraducciones(idioma);

            lblEmail.Text = traducciones["lblEmail"].Texto;
            lblContraseña.Text = traducciones["lblContraseña"].Texto;
            lblTelefono.Text = traducciones["lblTelefono"].Texto;
            lblFechaNacimiento.Text = traducciones["lblFechaNacimiento"].Texto;
            lblDocumento.Text = traducciones["lblDocumento"].Texto;
            lblRazonSocial.Text = traducciones["lblRazonSocial"].Texto;
            lblUbicacion.Text = traducciones["lblUbicacion"].Texto;
            btnRegistrar.Text = traducciones["btnRegistrar"].Texto;
            btnCancelar.Text = traducciones["btnCancelar"].Texto;
            grpDatosBasicos.Text = traducciones["grpDatosBasicos"].Texto;
            grpOtrosDatos.Text = traducciones["grpOtrosDatos"].Texto;
        }

        private void RegistrarEmpresa_Load(object sender, EventArgs e)
        {
            TraductorBLL.SuscribirForm(this);
        }
    }
}
