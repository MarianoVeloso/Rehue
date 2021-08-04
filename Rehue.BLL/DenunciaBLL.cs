using Rehue.DAL;
using Rehue.Interfaces;
using Rehue.Servicios;
using Rehue.Servicios.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BLL
{
    public class DenunciaBLL
    {
        private readonly DenunciaDAL _denunciaDAL = new DenunciaDAL();

        public void CrearDenuncia(IDenuncia denuncia, int IdCita)
        {
            try
            {
                _denunciaDAL.CrearDenuncia(denuncia, IdCita);
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

        public List<IDenuncia> ObtenerDenunciaPorIdAdministrador(int idAdministrador)
        {
            try
            {
                return _denunciaDAL.ObtenerDenunciaPorIdAdministrador(idAdministrador);
            }
            catch (OperacionDBException)
            {
                throw new OperacionDBException(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ErrorObtenerInformacion"].Texto);
            }
            catch (Exception)
            {
                throw new OperacionDBException(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ErrorObtenerInformacion"].Texto);
            }
        }

        public void ConfirmarDenuncia(int idDenuncia)
        {
            try
            {
                _denunciaDAL.ConfirmarDenuncia(idDenuncia, Session.Instancia.Usuario.Id);
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
        public void CancelarDenuncia(int idDenuncia)
        {
            try
            {
                _denunciaDAL.CancelarDenuncia(idDenuncia, Session.Instancia.Usuario.Id);
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
