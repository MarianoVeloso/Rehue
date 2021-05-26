using Rehue.Abstracciones;
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
    class EmpresaBLL : ICrud<IEmpresa>
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

        public void ValidarUsuarioContraseña(IEmpresa entity)
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

        public IEmpresa GetById(int id)
        {
            return MapearPersona();
        }

        public IList<IEmpresa> GetAll()
        {
            return new List<IEmpresa> { MapearPersona() };
        }

        public void Save(IEmpresa entity)
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

        public void Delete(IEmpresa entity)
        {
            throw new NotImplementedException();
        }

        private IEmpresa MapearPersona()
        {
            return new Empresa();
        }
    }
}
