using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Interfaces
{
    public interface IEmpresa : IUsuario
    {
        string RazonSocial { get; set; }
        string CuitCuil { get; set; }
        string Ubicacion { get; set; }
    }
}
