using Rehue.Abstracciones;
using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public class Persona : IPersona
    {
        public Persona()
        {
            _permisos = new List<IPermiso>();
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        private IList<IPermiso> _permisos;

        public IList<IPermiso> Permisos
        {
            get { return _permisos; }
            set { _permisos = value; }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _apellido;

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
    }
}
