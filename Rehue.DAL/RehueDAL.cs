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
    public class RehueDAL
    {
        private readonly Servicio _servicio = new Servicio();
        public bool ValidarEmail(string email)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@email", email)
            };
            var resultado = _servicio.Leer("validar_usuario", parametros);

            return resultado.Rows.Count >= 1;
        }

        public bool ValidarUsuarioContraseña(IUsuario entity)
        {
            int id = 0;
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@email", entity.Email),
                _servicio.CrearParametro("@password", entity.Contraseña)
            };

            try
            {
                var resultado = _servicio.Leer("validar_usuario_contraseña", parametros);


                foreach (DataRow item in resultado.Rows)
                {
                    id = int.Parse(item["id"].ToString());
                }

                if (id == 0)
                {
                    return false;
                }
                else
                {
                    entity.Id = int.Parse(parametros[2].Value.ToString());

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
