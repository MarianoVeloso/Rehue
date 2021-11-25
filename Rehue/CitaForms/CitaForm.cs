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
        private readonly MesaBLL _mesaBLL = new MesaBLL();
        private readonly Dictionary<string, Type> columns = new Dictionary<string, Type> {
            { "NumeroCN", typeof(string) },
            { "DescripcionCN", typeof(string) },
            { "CantidadComensalesCN", typeof(int) },
        };
        private int _mesaSeleccionada = new int();
        private List<IMesa> _mesas;

        public CitaForm()
        {
            InitializeComponent();
        }

        private void CitaForm_Load(object sender, EventArgs e)
        {
            TraductorBLL.SuscribirForm(this);
            ActualizarIdioma(Session.Instancia.Usuario.Idioma);

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
                Mesa = _mesas.Where(x => x.Id == _mesaSeleccionada).First(),
                Persona = (IPersona)Session.Instancia.Usuario,
                FechaEncuentro = dtPckrFecha.Value,
                FechaCreacion = DateTime.Now
            };
            try
            {
                ValidarCita(cita);

                _citaBLL.CrearCita(cita);
                MessageBox.Show(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["CitaCreada"].Texto);
            }
            catch (OperacionDBException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (DigitoException)
            {
                throw new OperacionDBException(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["DigitoException"].Texto);
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

        private void lstEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            _mesas = _mesaBLL.ObtenerPorIdEmpresa(((IEmpresa)lstEmpresas.SelectedItem).Id).Where(x => x.Reservada == false).ToList();
            dtMesas.DataSource = null;
            GrillaHelper.CrearGrilla(columns,
                new List<string> {"Id", "Descripcion", "CantidadComensales" }, _mesas, dtMesas );
        }

        private void ValidarCita(ICita cita)
        {
            if (cita.Mesa == null)
                throw new Exception(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ValidacionCitaMesaNoSeleccionada"].Texto);

            if (cita.CantidadComensales > cita.Mesa.CantidadComensales)
                throw new Exception(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ValidacionCitaMesa"].Texto);

            if (!_citaBLL.ValidarCitaCreacion())
                throw new Exception(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ValidacionCitaRangoHorario"].Texto);

            if (cita.FechaEncuentro < DateTime.Now)
                throw new Exception(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ValidacionCitaFechaInferior"].Texto);

        }

        private void CitaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TraductorBLL.DesuscribirForm(this);
        }


        private void dtMesas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0 && dtMesas.Rows.Count > 0 &&
                !string.IsNullOrEmpty(dtMesas.Rows[e.RowIndex].Cells[0].Value.ToString()))
            {
                _mesaSeleccionada = int.Parse(dtMesas.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }
    }
}
