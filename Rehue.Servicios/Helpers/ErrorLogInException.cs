using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Servicios.Helpers
{
    public class ErrorLogInException : Exception
    {
        public ErrorLogInException(string mensaje) : base(mensaje)
        {

        }
    }
}
