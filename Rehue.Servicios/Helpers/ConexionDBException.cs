using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Rehue.Servicios.Helpers
{
    public class ConexionDBException : Exception
    {
        public ConexionDBException(string mensaje) : base(mensaje)
        {
            XMLWriterException.Escribir(this);
        }
    }
}
