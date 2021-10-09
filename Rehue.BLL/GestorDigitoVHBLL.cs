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
    public class GestorDigitoVHBLL
    {
        private readonly GestorDigitoVHDAL _gestorDAL = new GestorDigitoVHDAL();
        private readonly CitaDAL _citaDAL = new CitaDAL();

        public void VerificarCitaDigitos(ICita cita)
        {
            string hashH = GestorDV.Instancia.GenerarDVH(cita);

            if (_gestorDAL.VerificarDigitoH(cita.Id, hashH, "validarDVH_cita") == 0)
                throw new DigitoException(string.Empty);

            List<ICita> citas = _citaDAL.ObtenerCitasLazy();

            string hashV = GestorDV.Instancia.GenerarDVV(citas);

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
    }
}
