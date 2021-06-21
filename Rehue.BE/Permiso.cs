using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rehue.BE
{
    public class Permiso : RolComponent, IPermiso
    {
        private int _idPadre;

        public int IdPadre
        {
            get { return _idPadre; }
            set { _idPadre = value; }
        }
    }
}