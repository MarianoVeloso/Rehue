using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public class Empresa : Usuario, IEmpresa
    {
        public int Reputacion { get; set; }
        public string RazonSocial { get; set; }
        public Subscripcion Subscripcion { get; set; }
        public string Ubicacion { get; set; }
        public int MyProperty { get; set; }
        public override string ObtenerNombre()
        {
            return $"{RazonSocial}";
        }
    }
}
