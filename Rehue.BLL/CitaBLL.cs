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
                cita.DigitoH = GestorDV.Instancia.GenerarDVH(cita);

                _citaDAL.CrearCita(cita);
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
        public void ConfirmarCita(int idCita)
        {
            try
            {
                _citaDAL.ConfirmarCita(idCita);
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
        public void CancelarCita(int idCita)
        {
            try
            {
                _citaDAL.CancelarCita(idCita);
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

        public ICita ObtenerCitaPorId(int idCita)
        {
            try
            {
                return _citaDAL.ObtenerCitaPorId(idCita);
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

        public void ObtenerCitasDeUsuarioLogeado()
        {
            try
            {
                Session.Instancia.Usuario.Citas = _citaDAL.ObtenerCitasPorUsuario(Session.Instancia.Usuario.Id, Session.Instancia.Usuario.IsInRol("Empresa"));
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
        public List<ICita> ObtenerCitasConDenunciaSinGestion()
        {
            try
            {
                return _citaDAL.ObtenerCitasConDenunciaSinGestion();
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

        public bool ValidarCitaCreacion()
        {
            ObtenerCitasDeUsuarioLogeado();
            ICita cita = Session.Instancia.Usuario.Citas.Where(x => (DateTime.Now - x.FechaCreacion).TotalHours < 2 && 
                                                                (x.FechaConfirmacion == null && x.FechaCancelacion == null)).FirstOrDefault();
            if (cita != null && cita.Id != 0)
                return false;
            return true;
        }
    }
}
