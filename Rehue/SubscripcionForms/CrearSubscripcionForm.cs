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

namespace Rehue.SubscripcionForms
{
    public partial class CrearSubscripcionForm : Form
    {
        readonly SubscripcionBLL _servicio = new SubscripcionBLL();
        public CrearSubscripcionForm()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ISubscripcion subscripcion = new Subscripcion
                {
                    Costo = ObtenerMonto(),
                    Descripcion = txtDescripcion.Text,
                    FechaCreacion = DateTime.Now,
                    PuedeCrearMenu = chbxPuedeCrearMenu.Checked
                };
                _servicio.CrearSubscripcion(subscripcion);
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

        private decimal ObtenerMonto()
        {
            decimal result;
            if (!decimal.TryParse(txtCosto.Text, out result))
                throw new Exception("Ingrese un monto correcto para operar.");
            return result;
        }
    }
}
