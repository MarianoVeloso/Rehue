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
    public class AdministradorDAL :ICrud<IAdministrador>
    {
        private readonly Servicio _servicio = Servicio.Instancia;

        private static AdministradorDAL _instancia;
        public static AdministradorDAL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new AdministradorDAL();
                return _instancia;
            }
        }
        public IAdministrador ObtenerPorId(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@id", id)
            };

            try
            {
                var resultado = _servicio.Leer("obtener_adminsitrador_por_id", parametros);

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
                var resultado = _servicio.Leer("obtener_administradores");

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
            string encryptPassword = Encriptador.GenerarHashMD5(entity.Contraseña);
            int id = 0;

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@email", entity.Email),
                _servicio.CrearParametro("@password", encryptPassword),
                _servicio.CrearParametro("@fechaNacimiento", entity.FechaNacimiento),
                _servicio.CrearParametro("@telefono", entity.Telefono),
                _servicio.CrearParametro("@id", id, ParameterDirection.Output)
            };

            try
            {
                _servicio.RealizarOperacion("registar_administrador", parametros);
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
        private IAdministrador MapearAdministrador(DataRow row)
        {
            return new Administrador()
            {
                Id = int.Parse(row["id"].ToString()),
                Email = row["email"].ToString(),
                FechaNacimiento = DateTime.Parse(row["fechaNacimiento"].ToString()),
                Roles = RolComponentDAL.Instancia.ObtenerRolesYPermisosPorUsuario(int.Parse(row["id"].ToString())),
                Idioma = IdiomaDAL.Instancia.ObtenerIdiomaPorId(int.Parse(row["IdIdioma"].ToString()))

            };
        }
    }
}
