using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rehue.BE
{
    public class Menu
    {
        private Empresa _empresa;

        public Empresa Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }

        private List<Item> _items;
        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        private bool _activo;
        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }

        private DateTime _fechaCreacion;
        public DateTime FechaCreacion
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
        }
    }
}