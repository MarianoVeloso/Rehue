using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rehue.BE
{
    public class Rol : RolComponent, IRol
    {
        private List<IRolComponent> _hijos;
        public Rol()
        {
            _hijos = new List<IRolComponent>();
        }

        public int ObtenerId()
        {
            return Id;
        }

        public void QuitarPermisos()
        {
            _hijos.Clear();
        }
        public void AgregarPermiso(IRolComponent rol)
        {
            _hijos.Add(rol);
        }

        public  IList<IRolComponent> ObtenerHijos()
        {
            return _hijos.ToArray();
        }
    }
}