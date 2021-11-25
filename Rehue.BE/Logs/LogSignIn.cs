using Rehue.Interfaces.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE.Logs
{
    public class LogLogIn<IUsuario> : Log<IUsuario>, ILogSignIn 
    {
        public int IdUsuario { get; set; }
    }
}
