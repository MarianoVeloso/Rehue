using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.DAL.Registro
{
    public class RegistroCitaDAL
    {
        private readonly Servicio _servicio = Servicio.Instancia;

        private static RegistroCitaDAL _instancia;
        public static RegistroCitaDAL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new RegistroCitaDAL();
                return _instancia;
            }
        }

    }
}
