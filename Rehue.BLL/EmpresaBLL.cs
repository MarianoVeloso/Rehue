﻿using Rehue.BE;
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
        private readonly RehueDAL _usuarioDAL = new RehueDAL();
        public void ValidarUsuario(string email)
        {
            try
            {
                bool inValido = _usuarioDAL.ValidarUsuario(email);

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
                bool inValido = _usuarioDAL.ValidarUsuarioContraseña(entity);

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
                throw new ErrorLogInException(ex.Message);
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
    }
}
