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
            Roles = new List<IRol>();
        }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Contraseña { get; set; }
        public IList<IRol> Roles { get; set; }
        public string Telefono { get; set; }
        public int Documento { get; set; }
        public IIdioma Idioma { get; set; }
        public List<ICita> Citas { get; set; }

        public abstract string ObtenerNombre();

        public List<ICita> ObtenerCitasPendienteConfirmacion()
        {
            return Citas.Where(x => x.FechaConfirmacion.HasValue == false && x.FechaCancelacion.HasValue == false).ToList();
        }

        public List<ICita> ObtenerCitaPendienteResolucion()
        {
            return Citas.Where(x => x.Denuncia.FechaConfirmacion.HasValue == false && x.Denuncia.Id != 0).ToList();
        }

        public List<ICita> ObtenerCitasConfirmadas()
        {
            return Citas.Where(x => x.FechaCancelacion.HasValue == false && x.FechaConfirmacion.HasValue &&
                                x.Denuncia.Id == 0).ToList();
        }
        public List<ICita> ObtenerCitasCanceladas()
        {
            return Citas.Where(x => x.FechaCancelacion.HasValue).ToList();
        }

        public bool IsInRol(string rol)
        {
            return Roles.Any(x => x.Nombre == rol);
        }
        public bool HasPermisson(string pNombre)
        {
            bool result = false;
            foreach (var rol in Roles)
            {
                if (!result)
                    result = rol.ObtenerHijos().Any(x => x.Nombre.ToLower() == pNombre.ToLower());
            }

            return result;
        }
    }
}
