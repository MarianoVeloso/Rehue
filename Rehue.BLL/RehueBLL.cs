﻿using Rehue.DAL;
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
    public class RehueBLL
    {
        private readonly RehueDAL _rehueDAL = new RehueDAL();
        private readonly PersonaBLL _personaBLL = new PersonaBLL();
        private readonly EmpresaBLL _empresaBLL = new EmpresaBLL();
        private readonly AdministradorBLL _administradorBLL = new AdministradorBLL();

        public void ValidarEmail(string email)
        {
            try
            {
                bool inValido = _rehueDAL.ValidarEmail(email);

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

        public void ValidarUsuarioContraseña(IUsuario entity)
        {
            entity.Contraseña = Encriptador.Hash(entity.Contraseña);

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

        public void LogIn(IUsuario entity)
        {
            IEmpresa empresa = _empresaBLL.ObtenerPorId(entity.Id);

            if (empresa != null)
            {
                Session.Instancia.Login(empresa);
            }
            else
            {
                IPersona persona = _personaBLL.ObtenerPorId(entity.Id);

                if (persona != null)
                {
                    Session.Instancia.Login(persona);
                }
                else
                {
                    IAdministrador administrador = _administradorBLL.ObtenerPorId(entity.Id);
                    Session.Instancia.Login(administrador);
                }
            }
        }
    }
}
