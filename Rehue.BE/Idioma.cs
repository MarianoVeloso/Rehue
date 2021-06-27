using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public class Idioma : Entity, IIdioma
    {
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private bool _default;

        public bool Default
        {
            get { return _default; }
            set { _default = value; }
        }
    }
}
