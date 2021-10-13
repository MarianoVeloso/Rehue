using Rehue.Interfaces.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE.Eventos
{
    public class EventoLogInError : Evento, IEventoLogInError
    {
        public int IdUsuario { get; set; }
    }
}
