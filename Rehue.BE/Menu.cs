using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rehue.BE
{
    public class Menu : MenuComponent, IMenu
    {
        private List<IItem> _items;
        public Menu()
        {
            _items = new List<IItem>();
        }

        public int ObtenerId()
        {
            return Id;
        }

        public void QuitarItems()
        {
            _items.Clear();
        }

        public void AgregarItem(IItem c)
        {
            _items.Add(c);
        }

        public IList<IItem> ObtenerItems()
        {
            return _items;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}