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

namespace Rehue.CitaForms
{
    public partial class CitaForm : Form, IIdiomaObserver
    {
        private readonly EmpresaBLL _empresaBLL = new EmpresaBLL();
        private readonly CitaBLL _citaBLL = new CitaBLL();
        public CitaForm()
        {
            InitializeComponent();
        }

        private void CitaForm_Load(object sender, EventArgs e)
        {
            var empresas = _empresaBLL.ObtenerTodos();

            lstEmpresas.DataSource = null;
            lstEmpresas.DataSource = empresas;
            lstEmpresas.DisplayMember = "RazonSocial";
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            ICita cita = new Cita()
            {
                CantidadComensales = (int)numComensales.Value,
                Empresa = (IEmpresa)lstEmpresas.SelectedItem,
                Persona = (IPersona)Session.Instancia.Usuario,
                FechaEncuentro = dtPckrFecha.Value,
                FechaCreacion = DateTime.Now
            };
            try
            {
                _citaBLL.CrearCita(cita);
                MessageBox.Show(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["CitaCreada"].Texto);
            }
            catch (OperacionDBException ex)
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

            lblComensales.Text = traducciones["Comensales"].Texto;
            lblFecha.Text = traducciones["lblFecha"].Texto;
            grpCrearCita.Text = traducciones["grpCrearCita"].Texto;
            btnCrear.Text = traducciones["btnCrear"].Texto;
        }
    }
}
