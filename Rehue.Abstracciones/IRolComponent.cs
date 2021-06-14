using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Abstracciones
{
    public interface IRolComponent
    {
        int Id { get; set; }
        string Nombre { get; set; }
    }
}
