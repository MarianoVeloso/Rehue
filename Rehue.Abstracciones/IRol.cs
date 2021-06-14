using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Abstracciones
{
    public interface IRol
    {
        IList<IRolComponent> ObtenerHijos();
        void AgregarPermiso(IRolComponent p);
        void QuitarPermisos();
    }
}
