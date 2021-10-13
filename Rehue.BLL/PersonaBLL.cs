using Rehue.BE;
using Rehue.Interfaces;
using Rehue.Servicios;
using Rehue.Servicios.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Rehue.DAL;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BLL
{
    public class PersonaBLL : ICrud<IPersona>
    {
        private readonly PersonaDAL _servicio = new PersonaDAL();

        public IPersona ObtenerPorId(int id)
        {
            return _servicio.ObtenerPorId(id);
        }

        public IList<IPersona> ObtenerTodos()
        {
            return _servicio.ObtenerTodos();
        }

        public void Guardar(IPersona entity)
        {
            try
            {
                _servicio.Guardar(entity);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ErrorBaseDeDatos"].Texto);
            }
        }

        public void Eliminar(IPersona entity)
        {
            try
            {
                _servicio.Eliminar(entity);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ErrorBaseDeDatos"].Texto);
            }
        }
    }
}
