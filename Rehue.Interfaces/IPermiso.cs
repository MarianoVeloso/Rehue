using System.Collections.Generic;
using Rehue.Interfaces;

namespace Rehue.Interfaces
{
    public interface IPermiso : IRolComponent
    {
        int IdPadre { get; set; }
    }
}
