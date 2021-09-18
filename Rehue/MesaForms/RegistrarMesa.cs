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
    public partial class RegistrarMesa : Form, IIdiomaObserver
    {
        private readonly MesaBLL _mesaBLL = new MesaBLL();
        private int _idMesa;

        public RegistrarMesa()
        {
            InitializeComponent();
        }
        private void FormLoad()
        {
            TraductorBLL.SuscribirForm(this);
            ActualizarIdioma(Session.Instancia.Usuario.Idioma);

            dtMesas.DataSource = null;
            dtMesas.DataSource = _mesaBLL.ObtenerPorIdEmpresa(Session.Instancia.Usuario.Id).Select(x => new
            {
                Numero = x.Id,
                CantidadComensales = x.CantidadComensales,
                Descripcion = x.Descripcion,
                Reservada = x.Reservada
            }).ToList();
            _idMesa = 0;
        }
        public void ActualizarIdioma(IIdioma idioma)
        {
            var traducciones = TraductorBLL.ObtenerTraducciones(idioma);

            lblCantidadComensales.Text = traducciones["lblCantidadComensales"].Texto;
            lblDescripcion.Text = traducciones["lblDescripcion"].Texto;
            lblMesas.Text = traducciones["lblMesas"].Texto;
            btnCrear.Text = traducciones["btnCrear"].Texto;            
        }


        private void btnCrear_Click(object sender, EventArgs e)
        {
            IMesa mesa = new Mesa()
            {
                CantidadComensales = (int)numComensales.Value,
                Descripcion = txtDescripcion.Text,
                Empresa = (IEmpresa)Session.Instancia.Usuario
            };
            try
            {
                _mesaBLL.CrearMesa(mesa);
                FormLoad();
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

        private void RegistrarMesa_Load(object sender, EventArgs e)
        {
            FormLoad();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            try
            {
                ValidarMesa();
                _mesaBLL.Eliminar(_idMesa);
                FormLoad();
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

        private void ValidarMesa()
        {
            if (_idMesa == 0)
                throw new Exception(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ValidacionCitaMesaNoSeleccionada"].Texto);

            //if(!_mesaBLL.ValidarMesaEnCita(_idMesa))
            //    throw new Exception(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ValidacionMesaActiva"].Texto);
        }

        private void dtMesas_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dtMesas.Rows.Count > 0 && dtMesas.Rows[e.RowIndex].Cells[0].Value != null)
            {
                _idMesa = int.Parse(dtMesas.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void RegistrarMesa_FormClosed(object sender, FormClosedEventArgs e)
        {
            TraductorBLL.DesuscribirForm(this);
        }
    }
}
