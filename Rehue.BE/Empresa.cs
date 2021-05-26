using Rehue.Abstracciones;
using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public class Empresa : IEmpresa
    {
        public Empresa()
        {
            _permisos = new List<IPermiso>();
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        private IList<IPermiso> _permisos;

        public IList<IPermiso> Permisos
        {
            get { return _permisos; }
            set { _permisos = value; }
        }

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
    }
}
