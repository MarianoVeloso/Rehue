using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Interfaces
{
    public interface IPersona : IUsuario
    {
        int Reputacion { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        string Ubicacion { get; set; }
    }
}
