using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Interfaces.Eventos
{
    public interface ILogSignOut : ILog<IUsuario>
    {
        int IdUsuario { get; set; }
    }
}
