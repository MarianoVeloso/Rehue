using Rehue.Interfaces.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE.Eventos
{
    public class EventoLogInExito : Evento, IEventoLogInExito
    {
        public int IdUsuario { get; set; }
    }
}
