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
        string Nombre { get; set; }
        string Password { get; set; }
    }
}
