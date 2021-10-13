using Rehue.BE.Eventos;
using Rehue.Interfaces.Eventos;
using Rehue.Servicios.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.DAL
{
    public class BitacoraDAL
    {
        private readonly Servicio _servicio = Servicio.Instancia;

        private static BitacoraDAL _instancia;
        public static BitacoraDAL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new BitacoraDAL();
                return _instancia;
            }
        }

        public void RegistrarEventoLogIn(IEventoLogInExito evento)
        {
            try
            {
                RegistrarEvento(evento);

                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@idUsuario", evento.IdUsuario),
                    _servicio.CrearParametro("@eventoId", evento.Id)
                };

                _servicio.RealizarOperacion("registrar_evento_detalle", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        public void RegistrarEventoLogIn(IEventoLogInError evento)
        {
            RegistrarEvento(evento);

            List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@idUsuario", evento.IdUsuario),
                    _servicio.CrearParametro("@eventoId", evento.Id)
                };

            _servicio.RealizarOperacion("registrar_evento_detalle", parametros);
        }

        public void RegistrarEventoLogOut(IEventoLogOutExito evento)
        {
            try
            {
                RegistrarEvento(evento);

                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@idUsuario", evento.IdUsuario),
                    _servicio.CrearParametro("@eventoId", evento.Id)
                };

                _servicio.RealizarOperacion("registrar_evento_detalle", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        private void RegistrarEvento(IEvento evento)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@FechaFin", evento.FechaFin),
                _servicio.CrearParametro("@FechaInicio", evento.FechaInicio),
                _servicio.CrearParametro("@Mensaje", evento.Mensaje),
                _servicio.CrearParametro("@id", evento.Id, ParameterDirection.Output),
            };

            _servicio.RealizarOperacion("registrar_evento", parametros);
            evento.Id = int.Parse(parametros[3].SqlValue.ToString());
        }
    }
}
