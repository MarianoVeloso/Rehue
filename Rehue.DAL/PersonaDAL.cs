﻿using Rehue.BE;
using Rehue.Interfaces;
using Rehue.Servicios;
using Rehue.Servicios.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Rehue.DAL
{
    public class PersonaDAL : ICrud<IPersona>
    {
        private readonly Servicio _servicio = new Servicio();
        private readonly RolComponentDAL _permisosDAL= new RolComponentDAL();

        public IPersona ObtenerPorId(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@id", id)
            };

            try
            {
                var resultado = _servicio.Leer("obtener_persona_por_id", parametros);

                IPersona persona = new Persona();

                foreach (DataRow item in resultado.Rows)
                {
                    persona = MapearPersona(item);
                }

                return persona;
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        public IList<IPersona> ObtenerTodos()
        {
            try
            {
                var resultado = _servicio.Leer("obtener_personas");

                List<IPersona> persona = new List<IPersona>();

                foreach (DataRow item in resultado.Rows)
                {
                    persona.Add(MapearPersona(item));
                }

                return persona;
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        public void Guardar(IPersona entity)
        {
            string encryptPassword = Encriptador.Hash(entity.Password);
            int id = 0;

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@email", entity.Email),
                _servicio.CrearParametro("@password", encryptPassword),
                _servicio.CrearParametro("@nombre", entity.Nombre),
                _servicio.CrearParametro("@apellido", entity.Apellido),
                _servicio.CrearParametro("@fechaNacimiento", entity.FechaNacimiento),
                _servicio.CrearParametro("@ubicacion", entity.Ubicacion),
                _servicio.CrearParametro("@telefono", entity.Telefono),
                _servicio.CrearParametro("@id", id, ParameterDirection.Output)
            };

            try
            {
                _servicio.RealizarOperacion("registar_persona", parametros);

                entity.Id = int.Parse(parametros[7].Value.ToString());
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }

            LogIn(entity.Nombre, entity.Password);
        }

        public void Eliminar(IPersona entity)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@id", entity.Id)
            };

            try
            {
                _servicio.RealizarOperacion("usuario_eliminar", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }


        public void LogIn(string nombre, string password)
        {
            string encryptPassword = Encriptador.Hash(password);
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@nombre", nombre),
                _servicio.CrearParametro("@password", encryptPassword)
            };
            try
            {
                var resultado = _servicio.Leer("obtener_usuario", parametros);

                IPersona persona = new Persona();
                foreach (DataRow item in resultado.Rows)
                {
                    persona = MapearPersona(item);
                }

                Session.Instancia.Login(persona);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        private IPersona MapearPersona(DataRow row)
        {
            return new Persona()
            {
                Id = int.Parse(row["id"].ToString()),
                Nombre = row["nombre"].ToString(),
                Apellido = row["apellido"].ToString(),
                Email = row["email"].ToString(),
                FechaNacimiento = DateTime.Parse(row["fechaNacimiento"].ToString()),
                Ubicacion = row["ubicacion"].ToString(),
                Roles = _permisosDAL.ObtenerRolesYPermisosPorUsuario(int.Parse(row["id"].ToString()))
            };
        }
    }
}
