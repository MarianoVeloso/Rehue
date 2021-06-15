using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rehue.BE
{
    public class Menu : MenuComponent, IMenu
    {
        private List<IMenuComponent> _items;
        public Menu()
        {
            _items = new List<IMenuComponent>();
        }

        public void QuitarItems()
        {
            _items.Clear();
        }
        public void AgregarItem(IMenuComponent c)
        {
            _items.Add(c);
        }

        public IList<IMenuComponent> ObtenerItems()
        {
            return _items;
        }
    }
}