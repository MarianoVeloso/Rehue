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
using Rehue.Abstracciones;

namespace Rehue.BLL
{
    public class PersonaBLL : ICrud<IPersona>
    {
        Servicio _servicio = new Servicio();

        public void ValidarUsuario(string email)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@email", email)
            };
            var resultado = _servicio.Leer("Validar_Usuario", parametros);

            if (resultado.Rows.Count >= 1)
                throw new ErrorLogInException("Usuario existente en la base de datos.");
        }

        public void ValidarUsuarioContraseña(IPersona entity)
        {
            string encryptPassword = Encriptador.Hash(entity.Password);

            int id = 0;

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@email", entity.Email),
                _servicio.CrearParametro("@password", encryptPassword),
                _servicio.CrearParametro("@id", id, ParameterDirection.Output)
            };

            _servicio.Leer("Validar_Usuario_Contraseña", parametros);

            id = int.Parse(parametros[2].Value.ToString());

            if (id == 0)
                throw new ErrorLogInException("Combinación de Usuario y Contraseña incorrecta.");
        }

        public IPersona GetById(int id)
        {
            return MapearPersona();
        }

        public IList<IPersona> GetAll()
        {
            return new List<IPersona> { MapearPersona() };
        }

        public void Save(IPersona entity)
        {
            string encryptPassword = Encriptador.Hash(entity.Password);
            int id = 0;

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@email", entity.Email),
                _servicio.CrearParametro("@password", encryptPassword),
                _servicio.CrearParametro("@id", id, ParameterDirection.Output)
            };

            try
            {
                _servicio.RealizarOperacion("Registar_Usuario", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }

            entity.Id = int.Parse(parametros[2].Value.ToString());

            Session.Instancia.Login(entity);
        }

        public void Delete(IPersona entity)
        {
            throw new NotImplementedException();
        }

        private IPersona MapearPersona()
        {
            return new Persona();
        }
    }
}
