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
    public class MesaBLL
    {
        private readonly MesaDAL _mesaDAL = new MesaDAL();

        public void CrearMesa(IMesa mesa)
        {
            try
            {
                _mesaDAL.CrearMesa(mesa);
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
        public IMesa ObtenerPorId(int id)
        {
            try
            {
                return _mesaDAL.ObtenerPorId(id);
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
        public List<IMesa> ObtenerPorIdEmpresa(int idEmpresa)
        {
            try
            {
                return _mesaDAL.ObtenerPorIdEmpresa(idEmpresa);
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
        public void Eliminar(int id)
        {
            try
            {
                _mesaDAL.Eliminar(id);
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
        public bool ValidarMesaEnCita(int id)
        {
            try
            {
                IMesa mesa = _mesaDAL.ValidarMesaEnCita(id);

                if (mesa.Id == 0)
                    return false;
                return true;
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
