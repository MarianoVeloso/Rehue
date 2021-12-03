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

namespace Rehue.MenuForms
{
    public partial class MenuDetalle : Form
    {
        public IList<IMenu> Menu { get; set; }
        public MenuDetalle()
        {
            InitializeComponent();
        }

        private void MenuDetalle_Load(object sender, EventArgs e)
        {
            lstMenu.DataSource = null;
            lstMenu.DataSource = Menu.Where(x => x.ObtenerItems().Count > 0).ToList();
        }

        private void lstMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            IMenu menu = ObtenerMenuSeleccionado();

            if (menu != null)
            {
                Dictionary<string, Type> columns = new Dictionary<string, Type> {
                    { "MenuNombreCN", typeof(string) },
                    { "DescripcionCN", typeof(string) },
                    { "CostoCN", typeof(int) },
                };

                GrillaHelper.CrearGrilla(columns,
                    new List<string> { "Nombre", "Descripcion", "Costo" }, menu.ObtenerItems(), dtItemsEnMenu);
            }
        }
        private IMenu ObtenerMenuSeleccionado()
        {
            return (IMenu)lstMenu.SelectedItem;
        }
    }
}
