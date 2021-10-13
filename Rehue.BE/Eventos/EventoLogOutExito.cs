using Rehue.Interfaces.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE.Eventos
{
    public class EventoLogOutExito : Evento, IEventoLogOutExito
    {
        public int IdUsuario { get; set; }
    }
}
