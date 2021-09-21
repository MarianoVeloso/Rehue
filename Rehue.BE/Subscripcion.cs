using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rehue.BE
{
    public class Subscripcion
    {
        public DateTime FechaCreacion { get; set; }

        public DateTime FechaCaducidad { get; set; }

        public int Monto { get; set; }
    }
}