using Rehue.Interfaces.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE.Log
{
    public class LogSignInExito : Log, ILogSignInExito
    {
        public int IdUsuario { get; set; }
    }
}
