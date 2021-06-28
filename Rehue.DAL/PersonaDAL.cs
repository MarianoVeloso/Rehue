using Rehue.BE;
using Rehue.Interfaces;
using Rehue.Servicios;
using Rehue.Servicios.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Rehue.DAL
{
    public class PersonaDAL : Servicio, ICrud<IPersona>
    {
        private readonly RolComponentDAL _permisosDAL= new RolComponentDAL();

        public IPersona ObtenerPorId(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                CrearParametro("@id", id)
            };

            try
            {
                var resultado = Leer("obtener_persona_por_id", parametros);

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
                var resultado = Leer("obtener_personas");

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
            string encryptPassword = Encriptador.Hash(entity.Contraseña);
            int id = 0;

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                CrearParametro("@email", entity.Email),
                CrearParametro("@password", encryptPassword),
                CrearParametro("@nombre", entity.Nombre),
                CrearParametro("@apellido", entity.Apellido),
                CrearParametro("@fechaNacimiento", entity.FechaNacimiento),
                CrearParametro("@ubicacion", entity.Ubicacion),
                CrearParametro("@telefono", entity.Telefono),
                CrearParametro("@documento", entity.Documento),
                CrearParametro("@id", id, ParameterDirection.Output)
            };

            try
            {
                RealizarOperacion("registar_persona", parametros);

                entity.Id = int.Parse(parametros[8].Value.ToString());
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        public void Eliminar(IPersona entity)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                CrearParametro("@id", entity.Id)
            };

            try
            {
                RealizarOperacion("usuario_eliminar", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }


        public void LogIn(string email, string password)
        {
            string encryptPassword = Encriptador.Hash(password);
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                CrearParametro("@email", email),
                CrearParametro("@password", encryptPassword)
            };
            try
            {
                var resultado = Leer("obtener_usuario", parametros);

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
                Telefono = row["email"].ToString(),

                //Roles = _permisosDAL.ObtenerRolesYPermisosPorUsuario(int.Parse(row["id"].ToString()))
            };
        }
    }
}
