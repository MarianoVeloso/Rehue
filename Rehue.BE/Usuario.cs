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

        private List<ICita> _citas;

        public List<ICita> Citas
        {
            get { return _citas; }
            set { _citas = value; }
        }

        public abstract string ObtenerNombre();

        public List<ICita> ObtenerCitasPendienteConfirmacion()
        {
            return _citas.Where(x => x.FechaConfirmacion.HasValue == false && x.FechaCancelacion.HasValue == false).ToList();
        }

        public List<ICita> ObtenerCitaPendienteResolucion()
        {
            return _citas.Where(x => x.Denuncia.FechaConfirmacion.HasValue == false && x.Denuncia.Id != 0).ToList();
        }

        public List<ICita> ObtenerCitasConfirmadas()
        {
            return _citas.Where(x => x.FechaCancelacion.HasValue == false && x.FechaConfirmacion.HasValue &&
                                x.Denuncia.Id == 0).ToList();
        }
        public List<ICita> ObtenerCitasCanceladas()
        {
            return _citas.Where(x => x.FechaCancelacion.HasValue).ToList();
        }

        public bool IsInRol(string rol)
        {
            return _roles.Any(x => x.Nombre == rol);
        }
        public bool HasPermisson(string pNombre)
        {
            bool result = false;
            foreach (var rol in _roles)
            {
                if (!result)
                    result = rol.ObtenerHijos().Any(x => x.Nombre.ToLower() == pNombre.ToLower());
            }

            return result;
        }
    }
}
