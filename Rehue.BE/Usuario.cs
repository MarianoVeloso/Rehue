using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public abstract class Usuario : Entity, IUsuario
    {
        public Usuario()
        {
            _roles = new List<IRol>();
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private DateTime _fechaNacimiento;
        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        private string _contraseña;
        public string Contraseña
        {
            get { return _contraseña; }
            set { _contraseña = value; }
        }

        private IList<IRol> _roles;
        public IList<IRol> Roles
        {
            get { return _roles; }
            set { _roles = value; }
        }

        private string _telefono;

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        private int _documento;

        public int Documento
        {
            get { return _documento; }
            set { _documento = value; }
        }
        private IIdioma _idioma;

        public IIdioma Idioma
        {
            get { return _idioma; }
            set { _idioma = value; }
        }

    }
}
