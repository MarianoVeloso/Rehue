using Rehue.Interfaces.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE.Log
{
    public class LogSignOutExito : Log, ILogSignOutExito
    {
        public int IdUsuario { get; set; }
    }
}
