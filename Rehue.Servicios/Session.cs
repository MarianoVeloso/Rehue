using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Servicios
{
    public class Session
    {
        private static Session _instancia;

        public static Session Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new Session();
                return _instancia;
            }
        }

        public IUsuario Usuario { get; set; }

        public void Login(IUsuario usuario)
        {
            Usuario = usuario;
        }

        public void LogOut()
        {
            Usuario = null;
        }

        public bool IsLogged()
        {
            return Usuario != null;
        }
    }
}