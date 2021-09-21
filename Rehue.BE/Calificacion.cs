using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public class Calificacion
    {
        public string Comentario { get; set; }
        public decimal Puntaje { get; set; }
        public Cita Cita { get; set; }
    }
}
