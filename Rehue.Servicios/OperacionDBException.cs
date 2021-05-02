using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Servicios
{
    public class OperacionDBException : Exception
    {
        public OperacionDBException(string mensaje) : base(mensaje)
        {

        }
    }
}
