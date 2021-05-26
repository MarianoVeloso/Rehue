using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Abstracciones
{
    public interface IPersona : IUsuario
    {
        string Nombre { get; set; }
        string Apellido { get; set; }
    }
}
