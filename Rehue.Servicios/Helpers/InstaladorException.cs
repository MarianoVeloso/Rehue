using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Servicios.Helpers
{
    public class InstaladorException : Exception
    {
        public InstaladorException(string mensaje) : base(mensaje)
        {

        }
    }
}
