using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public class Etiqueta : Entity, IEtiqueta
    {
        public string Nombre { get; set; }
    }
}
