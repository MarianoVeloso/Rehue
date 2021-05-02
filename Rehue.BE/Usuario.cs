using Rehue.Interfaces.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public interface IUsuario
    {
        string Email { get; set; }
        string Password { get; set; }
        IList<IPermiso> Permisos { get; }
    }
    public class Usuario : Entity, IUsuario
    {

        private IList<IPermiso> _permisos;

        public Usuario()
        {
            _permisos = new List<IPermiso>();
        }
        public string Email { get; set; }
        public string Password { get; set; }


        public IList<IPermiso> Permisos
        {
            get
            {
                return _permisos;
            }
        }
    }
}
