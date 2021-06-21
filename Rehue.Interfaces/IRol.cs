using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Interfaces
{
    public interface IRol : IRolComponent
    {
        int ObtenerId();
        IList<IRolComponent> ObtenerHijos();
        void AgregarPermiso(IRolComponent rol);
        void QuitarPermisos();
    }
}
