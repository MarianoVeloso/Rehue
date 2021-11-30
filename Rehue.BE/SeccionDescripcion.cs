using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public class SeccionDescripcion : ISeccionDescripcion
    {
        public string Seccion { get; set; }
        public string Descripcion { get; set; }
    }
}
