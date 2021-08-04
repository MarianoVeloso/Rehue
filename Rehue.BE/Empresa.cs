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
        private int _reputacion;

        public int Reputacion
        {
            get { return _reputacion; }
            set { _reputacion = value; }
        }

        private string _razonSocial;
        public string RazonSocial
        {
            get { return _razonSocial; }
            set { _razonSocial = value; }
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
        public override string ObtenerNombre()
        {
            return $"{RazonSocial}";
        }
    }
}
