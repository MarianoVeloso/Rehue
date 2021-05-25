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
    public class UsuarioBLL : AbstractBLL<IUsuario>
    {
        private readonly IServicio _servicio = new Servicio();

        public void ValidarUsuario(string nombre)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@nombre", nombre)
            };
            var resultado = _servicio.Leer("Validar_Usuario", parametros);

            if (resultado.Rows.Count >= 1)
                throw new ErrorLogInException("Usuario existente en la base de datos.");
        }
        public IUsuario ValidarUsuarioContraseña(string nombre, string password)
        {
            string encryptPassword = Encriptador.Hash(password);

            int id = 0;

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@nombre", nombre),
                _servicio.CrearParametro("@password", encryptPassword),
                _servicio.CrearParametro("@id", id, ParameterDirection.Output)
            };

            _servicio.Leer("Validar_Usuario_Contraseña", parametros);

            id = int.Parse(parametros[2].Value.ToString());

            if (id == 0)
                throw new ErrorLogInException("Combinación de Usuario y Contraseña incorrecta.");

            return CrearUsuario(nombre, encryptPassword, id);
        }

        public IUsuario RegistrarUsuario(string nombre, string password)
        {
            string encryptPassword = Encriptador.Hash(password);
            int id = 0;
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@nombre", nombre),
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

            id = int.Parse(parametros[2].Value.ToString());

            return CrearUsuario(nombre, encryptPassword, id);
        }

        public void LogIn(IUsuario usuario)
        {
            Session.Instancia.Login(usuario);
        }

        public void LogOut()
        {
            //Session.Instancia.LogOut();
            //Session.Instancia.QuitarFocoDirectorio();
        }

        private IUsuario CrearUsuario(string nombre, string password, int id)
        {
            Usuario usuario = new Usuario { Nombre = nombre, Password = password };
            LogIn(usuario);

            return usuario;
        }
    }
}
