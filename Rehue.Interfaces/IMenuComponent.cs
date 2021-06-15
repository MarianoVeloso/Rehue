using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Interfaces
{
    public interface IMenuComponent
    {
        IEmpresa Empresa { get; set; }
        DateTime FechaCreacion { get; set; }
    }
}
