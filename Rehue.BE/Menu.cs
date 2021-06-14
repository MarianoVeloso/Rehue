using Rehue.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rehue.BE
{
    public class Menu : IMenu
    {
        private List<IMenuComponent> _hijos;
        public Menu()
        {
            _hijos = new List<IMenuComponent>();
        }

        private IEmpresa _empresa;

        public IEmpresa Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }

        private List<IItem> _items;
        public List<IItem> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        private DateTime _fechaCreacion;
        public DateTime FechaCreacion
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
        }

        public void QuitarItems()
        {
            _hijos.Clear();
        }
        public void AgregarItem(IMenuComponent c)
        {
            _hijos.Add(c);
        }

        public IList<IMenuComponent> ObtenerItems()
        {
            return _hijos;
        }
    }
}