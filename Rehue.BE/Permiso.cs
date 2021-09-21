using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rehue.BE
{
    public class Permiso : RolComponent, IPermiso
    {
        public int IdPadre { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}