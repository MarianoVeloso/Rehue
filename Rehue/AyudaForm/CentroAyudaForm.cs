using Rehue.BE;
using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rehue.AyudaForm
{
    public partial class CentroAyudaForm : Form
    {
        public CentroAyudaForm()
        {
            InitializeComponent();
        }

        private void CentroAyudaForm_Load(object sender, EventArgs e)
        {
            int x = 15;
            int y = 15;
            contentPanel.Controls.Clear();

            ICentroAyuda ayuda = new CentroAyuda()
            {
                Descripcion = "El formulario Cita brinda la posibilidad de crear una cita entre una entidad y el usuario final.",
                Detalle = new List<ISeccionDescripcion>
                {
                    new SeccionDescripcion{ Descripcion = "Este listado brinda la posibilidad de ver todas las empresas inscriptas en nuestra aplicación" , Seccion = "Listado de empresas" },
                    new SeccionDescripcion{ Descripcion = "Este listado muestra las mesas que se encuentran disponibles en la institución." , Seccion = "Mesas disponible" },
                    new SeccionDescripcion{ Descripcion = "La fecha de encuentro es el dia y la hora en la que se va a llevar a cabo la cita. La cantidad de comensales no puede ser superior a la mesa y no se puede crear una cita con una fecha antigua." , Seccion = "Fecha encuentro" },
                    new SeccionDescripcion{ Descripcion = "Cantidad de comensales que van a asistir a la cita" , Seccion = "Cantidad comensales" },
                    }
            };
            txtDescripcion.Text = ayuda.Descripcion;

            foreach (var item in ayuda.Detalle)
            {
                var control = new SeccionDescripcionUC(item.Seccion, item.Descripcion)
                {                    
                    Location = new Point(x, y)
                };
                contentPanel.Controls.Add(control);
                y += 60;
            }
        }
    }
}
