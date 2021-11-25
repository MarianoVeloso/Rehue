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
        public string RazonSocial { get; set; }
        private ISubscripcion _subscripcion { get; set; }
        public string Ubicacion { get; set; }
        public override string ObtenerNombre()
        {
            return $"{RazonSocial}";
        }

        public void AgregarSubscripcion(ISubscripcion subscripcion)
        {
            _subscripcion = subscripcion;
        }

        public ISubscripcion ObtenerSubscripcion()
        {
            return _subscripcion;
        }
    }
}
