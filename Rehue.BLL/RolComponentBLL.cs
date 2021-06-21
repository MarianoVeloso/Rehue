using Rehue.DAL;
using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BLL
{
    public class RolComponentBLL
    {
        private readonly RolComponentDAL _rolDAL = new RolComponentDAL();

        public IRol GetById(int id)
        {
            try
            {
                return _rolDAL.ObtenerPorId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IList<IRol> GetAll()
        {
            try
            {
                return _rolDAL.ObtenerTodos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Save(IRol entity)
        {
            try
            {
                _rolDAL.Guardar(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Delete(IRol entity)
        {
            try
            {
                _rolDAL.Eliminar(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IList<IRol> ObtenerPorUsuario(int idUsuario)
        {
            return _rolDAL.ObtenerRolesYPermisosPorUsuario(idUsuario);
        }
    }
}
