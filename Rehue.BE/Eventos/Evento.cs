using Rehue.Interfaces.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE.Eventos
{
    public class Evento: Entity, IEvento
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Mensaje { get; set; }
    }
}
