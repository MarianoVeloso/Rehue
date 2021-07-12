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
    public class CitaBLL
    {
        private readonly CitaDAL _citaDAL = new CitaDAL();

        public void CrearCita(ICita cita)
        {
            try
            {
                _citaDAL.CrearCita(cita);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ErrorGuardarEntidad"].Texto);
            }
        }
        public void ObtenerCitasPendientesConfirmacion(IEmpresa empresa)
        {
            try
            {
                _citaDAL.ObtenerCitasPendientesConfirmacion(empresa.Id);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ErrorObtenerInformacion"].Texto);
            }
        }
        public void ObtenerCitasCanceladas(IEmpresa empresa)
        {
            try
            {
                _citaDAL.ObtenerCitasCanceladas(empresa.Id);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ErrorObtenerInformacion"].Texto);
            }
        }
    }
}
