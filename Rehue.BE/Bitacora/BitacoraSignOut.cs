using Rehue.BE.Logs;
using Rehue.Interfaces;
using Rehue.Interfaces.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE.Bitacora
{
    public class BitacoraSignOut : Bitacora<IUsuario>
    {
        public override ILog<IUsuario> CrearEvento(IUsuario entity, string mensaje)
        {
            return new LogSignOut<IUsuario>
            {
                FechaFin = DateTime.Now,
                FechaInicio = DateTime.Now,
                Mensaje = string.Format(mensaje),
                IdUsuario = entity.Id
            };
        }
    }
}
