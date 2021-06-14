using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public abstract class Usuario : IUsuario
    {
        public Usuario()
        {
            _permisos = new List<IPermiso>();
        }
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private int _reputacion;

        public int Reputacion
        {
            get { return _reputacion; }
            set { _reputacion = value; }
        }


        private IList<IPermiso> _permisos;
        public IList<IPermiso> Permisos
        {
            get { return _permisos; }
            set { _permisos = value; }
        }

        private DateTime _fechaNacimiento;

        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }
    }
}
