using Rehue.BE.Log;
using Rehue.Interfaces;
using Rehue.Interfaces.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE.Bitacora
{
    public class BitacoraLogInExito : Bitacora<IUsuario>
    {
        public override ILog CrearEvento(IUsuario entity)
        {
            return new LogSignInExito
            {
                FechaFin = DateTime.Now,
                FechaInicio = DateTime.Now,
                Mensaje = string.Format($"El usuario {entity.ObtenerNombre()} inició sesión correctamente."),
                IdUsuario = entity.Id
            };
        }
    }
}
