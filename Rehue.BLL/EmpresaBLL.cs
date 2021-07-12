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
        private readonly EmpresaDAL _empresaDAL = new EmpresaDAL();

        public IEmpresa ObtenerPorId(int id)
        {
            return _empresaDAL.ObtenerPorId(id);
        }

        public IList<IEmpresa> ObtenerTodos()
        {
            return _empresaDAL.ObtenerTodos();
        }

        public void Guardar(IEmpresa entity)
        {
            try
            {
                _empresaDAL.Guardar(entity);

                Session.Instancia.Login(entity);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(TraductorBLL.ObtenerTraducciones(entity.Idioma)["ErrorGuardarEntidad"].Texto);
            }
        }

        public void Eliminar(IEmpresa entity)
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
        public void LogIn(IEmpresa entity)
        {
            Session.Instancia.Login(entity);
        }
    }
}
