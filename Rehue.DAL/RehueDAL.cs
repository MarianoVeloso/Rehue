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
        Servicio _servicio = new Servicio();
        public bool ValidarUsuario(string email)
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
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@email", entity.Email),
                _servicio.CrearParametro("@password", entity.Password),
                _servicio.CrearParametro("@id", 0, ParameterDirection.Output)
            };

            try
            {
                _servicio.Leer("validar_usuario_contraseña", parametros);

                return int.Parse(parametros[2].Value.ToString()) == 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
