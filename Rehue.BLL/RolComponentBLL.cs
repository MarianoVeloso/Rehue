using Rehue.DAL;
using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BLL
{
    public class RolComponentBLL : ICrud<IRol>
    {
        private readonly RolComponentDAL _rolDAL = new RolComponentDAL();

        public IRol ObtenerPorId(int id)
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
        public IList<IRol> ObtenerTodos()
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

        public void Guardar(IRol entity)
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
        public void Eliminar(IRol entity)
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
