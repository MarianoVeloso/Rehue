using Rehue.Interfaces;
using Rehue.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public class Mesa : Entity, IMesa
    {
        public IEmpresa Empresa { get; set; }
        public int CantidadComensales { get; set; }
        public string Descripcion { get; set; }
        public bool Reservada { get; set; }
    }
}
