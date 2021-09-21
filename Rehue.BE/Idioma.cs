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
        public string Nombre { get; set; }
        public bool Default { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
