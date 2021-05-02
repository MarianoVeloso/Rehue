using Rehue.BE;
using System.Collections.Generic;

namespace Rehue.Interfaces.BE
{
    public interface IPermiso : IEntity
    {
        string Nombre { get; set; }
        void AgregarPermiso(IPermiso p);
        void QuitarPermiso(IPermiso p);
        IList<IPermiso> ObtenerHijos();
    }
}
