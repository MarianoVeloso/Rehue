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

        public bool Default { get; set; }

        public override string ToString()
        {
            return _nombre;
        }
    }
}
