using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Interfaces
{
    public interface IUsuario
    {
        int Id { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        IList<IRol> Roles { get; set; }
        int Reputacion { get; set; }
        DateTime FechaNacimiento { get; set; }
        string Telefono { get; set; }
    }
}
