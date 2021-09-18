using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Interfaces
{
    public interface IMesa : IEntity
    {
        IEmpresa Empresa { get; set; }
        int CantidadComensales { get; set; }
        string Descripcion { get; set; }
        bool Reservada { get; set; }
    }
}
