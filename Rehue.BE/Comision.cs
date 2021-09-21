using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public class Comision
    {
        public DateTime FechaCreacion { get; set; }
        public Cita Cita { get; set; }
    }
}
