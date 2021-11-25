using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Interfaces.Eventos
{
    public interface ILog<T>: IEntity
    {
        DateTime FechaInicio { get; set; }
        DateTime FechaFin { get; set; }
        string Mensaje { get; set; }
    }
}
