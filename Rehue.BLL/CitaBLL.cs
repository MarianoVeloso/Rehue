using Rehue.BE;
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
        private readonly CitaDAL _servicio = new CitaDAL();
        private readonly GestorDigitoVHDAL _gestorDAL = GestorDigitoVHDAL.Instancia;

        public void CrearCita(ICita cita)
        {
            cita.DigitoH = GestorDV.Instancia.GenerarDVH(cita);
            VerificarDigitos();

            _servicio.CrearCita(cita);

            ActualizarDigitos(cita);

            _servicio.CrearRegistroCita(cita, Session.Instancia.Usuario.Id, EventoEnum.CrearCita);
        }

        public void ConfirmarCita(int idCita)
        {
            ICita cita = ObtenerCitaPorId(idCita);
            VerificarDigitos(cita);

            cita.FechaConfirmacion = DateTime.Now;
            _servicio.ConfirmarCita(cita);

            ActualizarDigitos(cita);

            _servicio.CrearRegistroCita(cita, Session.Instancia.Usuario.Id, EventoEnum.ConfirmarCita);
        }

        public void CancelarCita(int idCita)
        {
            ICita cita = ObtenerCitaPorId(idCita);
            VerificarDigitos(cita);

            cita.FechaCancelacion = DateTime.Now;
            _servicio.CancelarCita(cita);
            HabilitarMesa(cita);

            ActualizarDigitos(cita);

            _servicio.CrearRegistroCita(cita, Session.Instancia.Usuario.Id, EventoEnum.CancelarCita);
        }

        private void ActualizarDigitos(ICita cita = null)
        {
            if (cita != null)
            {
                cita.DigitoH = ObtenerHashH(cita);

                _servicio.ActualizarDigitoH(cita);
            }

            string hashV = ObtenerHashV(cita);

            _gestorDAL.ActualizarDigitoV(hashV, "Cita");
        }

        public void HabilitarMesa(ICita cita)
        {
            _servicio.HabilitarMesa(cita);

        }

        public ICita ObtenerCitaPorId(int idCita)
        {
            ICita cita = _servicio.ObtenerCitaPorId(idCita);
            VerificarDigitos(cita);
            return cita;
        }

        public void ObtenerCitasDeUsuarioLogeado()
        {
            Session.Instancia.Usuario.Citas = _servicio.ObtenerCitasPorUsuario(Session.Instancia.Usuario.Id, Session.Instancia.Usuario.IsInRol("Empresa"));
        }

        public List<ICita> ObtenerCitasConDenunciaSinGestion()
        {
            return _servicio.ObtenerCitasConDenunciaSinGestion();
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
            List<ICita> citas = _servicio.ObtenerCitasLazy();

            return GestorDV.Instancia.GenerarDVV(citas);
        }
    }
}
