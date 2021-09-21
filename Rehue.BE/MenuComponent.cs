using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public abstract class MenuComponent : Entity, IMenuComponent
    {
        public IEmpresa Empresa { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
