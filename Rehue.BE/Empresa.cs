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
        private string _razonSocial;

        public string RazonSocial
        {
            get { return _razonSocial; }
            set { _razonSocial = value; }
        }

        private string _cuitCuil;

        public string CuitCuil
        {
            get { return _cuitCuil; }
            set { _cuitCuil = value; }
        }

        public Subscripcion Subscripcion
        {
            get => default;
            set
            {
            }
        }

        private string _ubicacion;

        public string Ubicacion
        {
            get { return _ubicacion; }
            set { _ubicacion = value; }
        }
    }
}
