using Rehue.BE.Eventos;
using Rehue.Interfaces.Bitacora;
using Rehue.Interfaces.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE.Bitacora
{
    public abstract class Bitacora<T> : IBitacora<T>
    {
        public abstract IEvento CrearEvento(T entity);
    }
}
