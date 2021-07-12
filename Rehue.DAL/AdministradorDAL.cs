using Rehue.BE;
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

namespace Rehue.DAL
{
    public class AdministradorDAL : Servicio, ICrud<IAdministrador>
    {
        private readonly RolComponentDAL _permisosDAL = new RolComponentDAL();
        private readonly IdiomaDAL _idiomaDAL = new IdiomaDAL();

        public IAdministrador ObtenerPorId(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                CrearParametro("@id", id)
            };

            try
            {
                var resultado = Leer("obtener_adminsitrador_por_id", parametros);

                IAdministrador administrador = new Administrador();

                foreach (DataRow item in resultado.Rows)
                {
                    administrador = MapearAdministrador(item);
                }

                return administrador;
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
        public IList<IAdministrador> ObtenerTodos()
        {
            try
            {
                var resultado = Leer("obtener_administradores");

                List<IAdministrador> empresa = new List<IAdministrador>();

                foreach (DataRow item in resultado.Rows)
                {
                    empresa.Add(MapearAdministrador(item));
                }

                return empresa;
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        public void Guardar(IAdministrador entity)
        {
            string encryptPassword = Encriptador.Hash(entity.Contraseña);
            int id = 0;

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                CrearParametro("@email", entity.Email),
                CrearParametro("@password", encryptPassword),
                CrearParametro("@fechaNacimiento", entity.FechaNacimiento),
                CrearParametro("@telefono", entity.Telefono),
                CrearParametro("@id", id, ParameterDirection.Output)
            };

            try
            {
                RealizarOperacion("registar_administrador", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }

            entity.Id = int.Parse(parametros[2].Value.ToString());

            Session.Instancia.Login(entity);
        }

        public void Eliminar(IAdministrador entity)
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

        private IAdministrador MapearAdministrador(DataRow row)
        {
            return new Administrador()
            {
                Id = int.Parse(row["id"].ToString()),
                Email = row["email"].ToString(),
                FechaNacimiento = DateTime.Parse(row["fechaNacimiento"].ToString()),
                Roles = _permisosDAL.ObtenerRolesYPermisosPorUsuario(int.Parse(row["id"].ToString())),
                Idioma = _idiomaDAL.ObtenerIdiomaPorId(int.Parse(row["IdIdioma"].ToString()))

            };
        }
    }
}
