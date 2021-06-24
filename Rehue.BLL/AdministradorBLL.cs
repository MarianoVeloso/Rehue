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
    public class AdministradorBLL : ICrud<IAdministrador>
    {
        private readonly AdministradorDAL _empresaDAL = new AdministradorDAL();

        public IAdministrador ObtenerPorId(int id)
        {
            return _empresaDAL.ObtenerPorId(id);
        }

        public IList<IAdministrador> ObtenerTodos()
        {
            return _empresaDAL.ObtenerTodos();
        }

        public void Guardar(IAdministrador entity)
        {
            try
            {
                _empresaDAL.Guardar(entity);

                Session.Instancia.Login(entity);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        public void Eliminar(IAdministrador entity)
        {
            try
            {
                _empresaDAL.Eliminar(entity);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
    }
}
