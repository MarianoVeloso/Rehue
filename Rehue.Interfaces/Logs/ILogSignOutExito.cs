using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Interfaces.Eventos
{
    public interface ILogSignOutExito : ILog
    {
        int IdUsuario { get; set; }
    }
}
