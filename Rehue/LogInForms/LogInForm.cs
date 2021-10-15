using Rehue.BE;
using Rehue.BE.Bitacora;
using Rehue.BLL;
using Rehue.Interfaces;
using Rehue.Interfaces.Eventos;
using Rehue.Servicios;
using Rehue.Servicios.Bitacora;
using Rehue.Servicios.Helpers;
using System;
using System.Windows.Forms;

namespace Rehue.LogIn
{
    public partial class LogInForm : Form, IIdiomaObserver
    {
        private readonly RehueBLL _rehueBLL = new RehueBLL();

        private IIdioma _idioma;

        public IIdioma Idioma
        {
            get { return _idioma; }
            set { _idioma = value; }
        }


        public LogInForm()
        {
            InitializeComponent();
        }

        public void ActualizarIdioma(IIdioma idioma)
        {
            Traducir(idioma);
        }

        private void Traducir(IIdioma idioma = null)
        {
            var traducciones = TraductorBLL.ObtenerTraducciones(idioma);

            lblUsuario.Text = traducciones["lblUsuarioLogIn"].Texto;
            lblContraseña.Text = traducciones["lblContraseñaLogIn"].Texto;
            btnIniciarSesion.Text = traducciones["btnIniciarSesion"].Texto;
            btnRegistrarEmpresa.Text = traducciones["btnRegistrarEmpresa"].Texto;
            btnRegistrarUsuario.Text = traducciones["btnRegistrarUsuario"].Texto;
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            RegistrarPersona form = new RegistrarPersona();
            form.Idioma = _idioma;
            form.Show();
        }

        private void btnRegistrarEmpresa_Click(object sender, EventArgs e)
        {
            RegistrarEmpresa form = new RegistrarEmpresa();
            form.Idioma = _idioma;
            form.Show();
        }
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            IUsuario persona = new Persona() { Email = txtUsuario.Text, Contraseña = txtContraseña.Text };

            try
            {
                _rehueBLL.ValidarUsuarioContraseña(persona, _idioma);
                _rehueBLL.LogIn(persona, _idioma);

                BitacoraOperador<IUsuario>.Instancia.EstablecerBitacora(new BitacoraLogInExito());
                ILogSignInExito evento = (ILogSignInExito)BitacoraOperador<IUsuario>.Instancia.ObtenerEvento(Session.Instancia.Usuario);
                BitacoraBLL.Instancia.RegistrarEventoLogIn(evento);

                this.Close();
            }
            catch (ErrorLogInException ex)
            {
                BitacoraOperador<IUsuario>.Instancia.EstablecerBitacora(new BitacoraLogInError());
                ILogSignInError evento = (ILogSignInError)BitacoraOperador<IUsuario>.Instancia.ObtenerEvento(persona);
                BitacoraBLL.Instancia.RegistrarEventoLogInError(evento);

                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                BitacoraOperador<IUsuario>.Instancia.EstablecerBitacora(new BitacoraLogInError());
                ILogSignInError evento = (ILogSignInError)BitacoraOperador<IUsuario>.Instancia.ObtenerEvento(persona);
                BitacoraBLL.Instancia.RegistrarEventoLogInError(evento);

                MessageBox.Show(ex.Message);
            }
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {
            TraductorBLL.SuscribirForm(this);
            ActualizarIdioma(_idioma);
        }

        private void LogInForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TraductorBLL.DesuscribirForm(this);
        }
    }
}
