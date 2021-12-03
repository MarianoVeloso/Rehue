using Rehue.BE;
using Rehue.DAL;
using Rehue.Interfaces;
using Rehue.Servicios;
using Rehue.Servicios.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BLL
{
    public class EmpresaBLL : ICrud<IEmpresa>
    {
        private readonly EmpresaDAL _servicio = new EmpresaDAL();
        private readonly MenuComponentDAL _menuServicio = new MenuComponentDAL();

        public IEmpresa ObtenerPorId(int id)
        {
            return _servicio.ObtenerPorId(id);
        }

        public IList<IEmpresa> ObtenerTodos()
        {
            return _servicio.ObtenerTodos();
        }

        public void Guardar(IEmpresa entity)
        {
            try
            {
                _servicio.Guardar(entity);
            }
            catch (OperacionDBException)
            {
                throw new OperacionDBException(TraductorBLL.ObtenerTraducciones(entity.Idioma)["ErrorGuardarEntidad"].Texto);
            }
        }

        public void Eliminar(IEmpresa entity)
        {
            try
            {
                _servicio.Eliminar(entity);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        public IList<IMenu> ObtenerMenu(IEmpresa empresa)
        {
            if (empresa.ObtenerSubscripcion() != null)
            {
                return _menuServicio.ObtenerTodos(empresa.Id);
            }
            else
            {
                throw new Exception("La empresa no posee un menú disponible.");
            }
        }
    }
}
