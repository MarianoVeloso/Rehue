﻿using Rehue.BE;
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
        private readonly PersonaDAL _personaDAL = new PersonaDAL();
        private readonly RehueDAL _ruehueDAL = new RehueDAL();

        public IPersona ObtenerPorId(int id)
        {
            return _personaDAL.ObtenerPorId(id);
        }

        public IList<IPersona> ObtenerTodos()
        {
            return _personaDAL.ObtenerTodos();
        }

        public void Guardar(IPersona entity)
        {
            try
            {
                _personaDAL.Guardar(entity);

                Session.Instancia.Login(entity);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        public void Eliminar(IPersona entity)
        {
            try
            {
                _personaDAL.Eliminar(entity);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
    }
}
