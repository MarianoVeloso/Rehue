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

namespace Rehue.SubscripcionForms
{
    public partial class ComprarSubscripcionForm : Form
    {
        readonly SubscripcionBLL _servicio = new SubscripcionBLL();
        public ComprarSubscripcionForm()
        {
            InitializeComponent(); 
            LoadForm();
        }

        private void LoadForm()
        {
            lstPromociones.DataSource = null;
            lstPromociones.DataSource = _servicio.ObtenerTodos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ISubscripcion subscripcion = (ISubscripcion)lstPromociones.SelectedItem;

            try
            {
                ValidarSubscripcion();
                _servicio.PagarSubscripcion(Session.Instancia.Usuario.Id, subscripcion.Id);
                MessageBox.Show("Subscripcion creada con éxito!");
                this.Close();
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

        private void ValidarSubscripcion()
        {
            if(((IEmpresa)Session.Instancia.Usuario).ObtenerSubscripcion () != null){
                throw new Exception("Usted ya posee una subscripción activa.");
            }
        }
    }
}
