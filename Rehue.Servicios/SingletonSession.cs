using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Servicios
{
    public class SingletonSesion
    {
        private static SingletonSesion _instancia;
        private static Object _lock = new object();

        public IUsuario Usuario { get; set; }

        public void Login(IUsuario usuario)
        {
            Usuario = usuario;
        }

        public void Logout()
        {
            Usuario = null;
        }

        public static SingletonSesion Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new SingletonSesion();


                return _instancia;
            }
        }

        public bool IsLogged()
        {
            return false;
        }

        public bool IsInRole(TipoPermiso permiso)
        {
            return true;
        }
    }
}