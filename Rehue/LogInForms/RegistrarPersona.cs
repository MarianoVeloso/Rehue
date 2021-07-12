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
    public partial class RegistrarPersona : RegistroForm, IIdiomaObserver
    {
        private IIdioma _idioma;

        public IIdioma Idioma
        {
            get { return _idioma; }
            set { _idioma = value; }
        }

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
                Ubicacion = txtUbicacion.Text,
                Idioma = _idioma,
                Documento = int.Parse(numDocumento.Value.ToString())
            };

            try
            {
                _rehueBLL.ValidarEmail(persona.Email, _idioma);
                _personaBLL.Guardar(persona);
                _rehueBLL.LogIn(persona, _idioma);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void ActualizarIdioma(IIdioma idioma)
        {
            var traducciones = TraductorBLL.ObtenerTraducciones(idioma);

            lblEmail.Text = traducciones["lblEmail"].Texto;
            lblContraseña.Text = traducciones["lblContraseña"].Texto;
            lblTelefono.Text = traducciones["lblTelefono"].Texto;
            lblFechaNacimiento.Text = traducciones["lblFechaNacimiento"].Texto;
            lblDocumento.Text = traducciones["lblDocumento"].Texto;
            lblNombre.Text = traducciones["lblNombre"].Texto;
            lblApellido.Text = traducciones["lblApellido"].Texto;
            lblUbicacion.Text = traducciones["lblUbicacion"].Texto;
            btnRegistrar.Text = traducciones["btnRegistrar"].Texto;
            btnCancelar.Text = traducciones["btnCancelar"].Texto;
            grpDatosBasicos.Text = traducciones["grpDatosBasicos"].Texto;
            grpOtrosDatos.Text = traducciones["grpOtrosDatos"].Texto;
        }

        private void RegistrarPersona_Load(object sender, EventArgs e)
        {
            TraductorBLL.SuscribirForm(this);
        }
    }
}
