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
    public class Rehue
    {
        private readonly RehueDAL _rehueDAL = new RehueDAL();

        public void ValidarUsuario(string email)
        {
            try
            {
                bool inValido = _rehueDAL.ValidarUsuario(email);

                if (inValido)
                    throw new ErrorLogInException("Usuario existente en la base de datos.");
            }
            catch (ErrorLogInException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        public void ValidarUsuarioContraseña(IEmpresa entity)
        {
            entity.Password = Encriptador.Hash(entity.Password);

            try
            {
                bool inValido = _rehueDAL.ValidarUsuarioContraseña(entity);

                if (inValido)
                    throw new ErrorLogInException("Combinación de Usuario y Contraseña incorrecta.");
            }
            catch (ErrorLogInException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
    }
}
