﻿using Rehue.BE;
using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.DAL
{
    public class RehueDAL : Servicio
    {
        public bool ValidarEmail(string email)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                CrearParametro("@email", email)
            };
            var resultado = Leer("validar_usuario", parametros);

            return resultado.Rows.Count >= 1;
        }

        public int ObtenerIdUsuario(IUsuario entity, string hash)
        {
            int id = 0;
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                CrearParametro("@email", entity.Email),
                CrearParametro("@password", hash)
            };

            try
            {
                var resultado = Leer("obtener_id_usuario", parametros);

                foreach (DataRow item in resultado.Rows)
                {
                    id = int.Parse(item["id"].ToString());
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<IUsuario> ObtenerIdEmailUsuarios()
        {
            try
            {
                var resultado = Leer("obtener_usuarios");
                List<IUsuario> usuarios = new List<IUsuario>();
                foreach (DataRow row in resultado.Rows)
                {
                    usuarios.Add(MapearUsuario(row));
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private IUsuario MapearUsuario(DataRow row)
        {
            return new Persona
            {
                Id = int.Parse(row["id"].ToString()),
                Email = row["email"].ToString()
            };
        }
    }
}
