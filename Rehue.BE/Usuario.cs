using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public class Usuario : IUsuario
    {
        public Usuario()
        {
            _permisos = new List<IPermiso>();
        }
        public string Email { get; set; }
        public string Password { get; set; }


        private IList<IPermiso> _permisos;
        public IList<IPermiso> Permisos
        {
            get
            {
                return _permisos;
            }
        }
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Nombre { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
