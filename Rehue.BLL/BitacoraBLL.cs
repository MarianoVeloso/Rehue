using Rehue.DAL;
using Rehue.Interfaces;
using Rehue.Interfaces.Eventos;
using Rehue.Servicios;
using Rehue.Servicios.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BLL
{
    public class BitacoraBLL
    {

        private readonly BitacoraDAL _bitacoraDAL = BitacoraDAL.Instancia;
        public void RegistrarEventoLogIn(ILogSignIn evento)
        {
            try
            {
                _bitacoraDAL.RegistrarEventoLogIn(evento);
            }
            catch (OperacionDBException)
            {
                throw new OperacionDBException(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ErrorGuardarEntidad"].Texto);
            }
            catch (Exception)
            {
                throw new OperacionDBException(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ErrorGuardarEntidad"].Texto);
            }
        }
        public void RegistrarEventoLogOut(ILogSignOut evento)
        {
            try
            {
                _bitacoraDAL.RegistrarEventoLogOut(evento);
            }
            catch (OperacionDBException)
            {
                throw new OperacionDBException(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ErrorGuardarEntidad"].Texto);
            }
            catch (Exception)
            {
                throw new OperacionDBException(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ErrorGuardarEntidad"].Texto);
            }
        }
    }
}
