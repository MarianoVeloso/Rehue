using Rehue.BLL;
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
using Rehue.BE;
using Menu = Rehue.BE.Menu;
using Rehue.Servicios.Helpers;

namespace Rehue.MenuForms
{
    public partial class AdministrarMenu : Form
    {
        private readonly MenuComponentBLL _menuComponentBLL = new MenuComponentBLL();
        private IList<IMenu> _menues;

        public AdministrarMenu()
        {
            InitializeComponent();
            FormLoad();
        }

        private void FormLoad()
        {
            lstItemsDisponibles.DataSource = null;
            lstMenu.DataSource = null;
            _menues = _menuComponentBLL.ObtenerTodos();
            lstMenu.DataSource = _menues;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IMenu menu = new Menu()
                {
                    Nombre = txtMenuNombre.Text
                };
                _menuComponentBLL.Guardar(menu);
                FormLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAsignarItem_Click(object sender, EventArgs e)
        {
            IMenu menu = (IMenu)lstMenu.SelectedItem;
            int id = _menues.Where(_ => _.Nombre == txtNombreItem.Text).First().Id;
            IItem item = new Item()
            {
                Costo = decimal.Parse(txtCosto.Text),
                Descripcion = txtDescripcion.Text,
                IdPadre = menu.ObtenerId(),
                Nombre = txtNombreItem.Text,
                Id = id
            };

            try
            {
                _menuComponentBLL.AgregarHijo(item);
                FormLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminarItem_Click(object sender, EventArgs e)
        {
            IMenu menu = ObtenerMenuSeleccionado();
            IItem item = (IItem)lstItemsDisponibles.SelectedItem;

            item.IdPadre = menu.Id;

            _menuComponentBLL.EliminarHijo(item);
        }

        private void lstItemsDisponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            IMenu item = (IMenu)lstItemsDisponibles.SelectedItem;
            if (item != null && item.Id != 0)
            {
                txtNombreItem.Text = item.Nombre;
            }
        }

        private void lstMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            IMenu menu = ObtenerMenuSeleccionado();

            try
            {
                if (menu != null)
                {
                    lstItemsDisponibles.DataSource = null;
                    lstItemsDisponibles.DataSource = _menues.Where(x => x.Id != menu.Id).ToList();

                    Dictionary<string, Type> columns = new Dictionary<string, Type> {
                    { "MenuNombreCN", typeof(string) },
                    { "DescripcionCN", typeof(string) },
                    { "CostoCN", typeof(decimal) },
                };

                    GrillaHelper.CrearGrilla(columns,
                        new List<string> { "Nombre", "Descripcion", "Costo" }, menu.ObtenerItems(), dtItemsEnMenu);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private IMenu ObtenerMenuSeleccionado()
        {
            return (IMenu)lstMenu.SelectedItem;
        }
    }
}
