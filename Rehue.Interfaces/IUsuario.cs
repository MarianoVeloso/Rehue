using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Interfaces
{
    public interface IUsuario : IEntity
    {
        int Documento { get; set; }
        string Email { get; set; }
        string Contraseña { get; set; }
        IList<IRol> Roles { get; set; }
        DateTime FechaNacimiento { get; set; }
        string Telefono { get; set; }
        IIdioma Idioma { get; set; }
        List<ICita> Citas { get; set; }
        List<ICita> ObtenerCitasPendienteConfirmacion();
        List<ICita> ObtenerCitasConDenuncia();
        List<ICita> ObtenerCitasConfirmadas();
        List<ICita> ObtenerCitasCanceladas();
        bool IsInRol(string rol);
        string ObtenerNombre();
        bool HasPermisson(string rol);
    }
}
