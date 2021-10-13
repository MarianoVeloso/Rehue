using Rehue.BE.Eventos;
using Rehue.Interfaces;
using Rehue.Interfaces.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE.Bitacora
{
    public class BitacoraLogInError : Bitacora<IUsuario>
    {
        public override IEvento CrearEvento(IUsuario entity)
        {
            return new EventoLogInError
            {
                FechaFin = DateTime.Now,
                FechaInicio = DateTime.Now,
                Mensaje = string.Format($"El usuario {entity.ObtenerNombre()} se registró erróneamente en el sitio."),
                IdUsuario = entity.Id
            };
        }
    }
}
