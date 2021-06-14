using Rehue.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public abstract class MenuComponent : IMenuComponent
    {
        private IEmpresa _empresa;

        public IEmpresa Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }

        private DateTime _fechaCreacion;

        public DateTime FechaCreacion
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
        }
    }
}
