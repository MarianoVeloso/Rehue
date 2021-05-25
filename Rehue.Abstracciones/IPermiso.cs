using System.Collections.Generic;
using Rehue.Interfaces;

namespace Rehue.Interfaces
{
    public interface IPermiso
    {
        int Id { get; set; }
        string Nombre { get; set; }
        void AgregarPermiso(IPermiso p);
        void QuitarPermiso(IPermiso p);
        IList<IPermiso> ObtenerHijos();
    }
}
