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
        private readonly GestorDigitoVHDAL _gestorDAL = new GestorDigitoVHDAL();

        public void CrearCita(ICita cita)
        {
            try
            {
                cita.DigitoH = GestorDV.Instancia.GenerarDVH(cita);
                VerificarDigitos();

                _citaDAL.CrearCita(cita);

                ActualizarDigitos(cita);
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
                ICita cita = ObtenerCitaPorId(idCita);
                VerificarDigitos(cita);

                cita.FechaConfirmacion = DateTime.Now;
                _citaDAL.ConfirmarCita(cita);

                ActualizarDigitos(cita);
            }
            catch (OperacionDBException)
            {
                throw new OperacionDBException(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ErrorGuardarEntidad"].Texto);
            }
            catch (DigitoException)
            {
                throw new OperacionDBException(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["DigitoException"].Texto);
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
                ICita cita = ObtenerCitaPorId(idCita);
                VerificarDigitos(cita);

                cita.FechaCancelacion = DateTime.Now;
                _citaDAL.CancelarCita(cita);

                ActualizarDigitos(cita);
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

        private void ActualizarDigitos(ICita cita = null)
        {
            try
            {
                if (cita != null)
                {
                    cita.DigitoH = ObtenerHashH(cita);

                    _citaDAL.ActualizarDigitoH(cita);
                }

                string hashV = ObtenerHashV(cita);

                _gestorDAL.ActualizarDigitoV(hashV, "Cita");
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


        private void VerificarDigitos(ICita cita = null)
        {
            if (cita != null)
            {
                string hashH = ObtenerHashH(cita);

                if (_gestorDAL.VerificarDigitoH(cita.Id, hashH, "validarDVH_cita") == 0)
                    throw new DigitoException(string.Empty);
            }

            string hashV = ObtenerHashV(cita);
            if (_gestorDAL.VerificarTablaDigito("Cita") == 0)
            {
                _gestorDAL.CrearDigitoV(hashV, "Cita");
            }
            else
            {
                if (_gestorDAL.VerificarDigitoV(hashV, "Cita", "validarDVV_cita") == 0)
                    throw new DigitoException(string.Empty);
            }
        }

        private string ObtenerHashH(ICita cita)
        {
            return GestorDV.Instancia.GenerarDVH(cita);
        }
        private string ObtenerHashV(ICita cita)
        {
            List<ICita> citas = _citaDAL.ObtenerCitasLazy();

            return GestorDV.Instancia.GenerarDVV(citas);
        }
    }
}
