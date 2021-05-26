using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Abstracciones
{
    public interface IEmpresa : IUsuario
    {
        string RazonSocial { get; set; }
        string CuitCuil { get; set; }
    }
}
