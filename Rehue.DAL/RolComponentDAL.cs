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
    public class RolComponentDAL: ICrud<IRol>
    {
        private readonly Servicio _servicio = new Servicio();
        private static RolComponentDAL _instancia;
        public static RolComponentDAL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new RolComponentDAL();
                return _instancia;
            }
        }
        public IRol ObtenerPorId(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@id", id)
            };

            try
            {
                var resultado = _servicio.Leer("obtener_rol_por_id", parametros);

                IRol permiso = new Rol();

                foreach (DataRow item in resultado.Rows)
                {
                    permiso = MapearRol(item);
                }

                return permiso;
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
        public IList<IRol> ObtenerTodos()
        {
            try
            {
                var resultado = _servicio.Leer("obtener_permisos");

                return MapearRoles(resultado.Rows);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
        public void Guardar(IRol entity)
        {
            int id = 0;
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@nombre", entity.Nombre),
                _servicio.CrearParametro("@id", id, ParameterDirection.Output)

            };

            try
            {
                _servicio.RealizarOperacion("registrar_rol", parametros);

                entity.Id = int.Parse(parametros[1].Value.ToString());
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
        public void GuardarPermiso(IPermiso entity)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@idPadre", entity.IdPadre),
                _servicio.CrearParametro("@idHijo", entity.Id)
            };

            try
            {
                _servicio.RealizarOperacion("registrar_permiso_padreHijo", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
        public void Eliminar(IRol entity)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@id", entity.Id)
            };

            try
            {
                _servicio.RealizarOperacion("permiso_eliminar", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
        public void EliminarHijo(IPermiso entity)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@idHijo", entity.Id),
                _servicio.CrearParametro("@idPadre", entity.IdPadre)
            };

            try
            {
                _servicio.RealizarOperacion("eliminar_rol_padre_hijo", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
        public void AgregarHijo(IPermiso entity)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@idHijo", entity.Id),
                _servicio.CrearParametro("@idPadre", entity.IdPadre)
            };

            try
            {
                _servicio.RealizarOperacion("agregar_rol_padre_hijo", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
        public IList<IRol> ObtenerRolesYPermisosPorUsuario(int idUsuario)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@id", idUsuario)
            };

            var resultado = _servicio.Leer("Obtener_rol_por_usuario", parametros);

            return MapearRoles(resultado.Rows);
        }
        public void AsignarRolAUsuario(int idUsuario, int idRol)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@idUsuario", idUsuario),
                _servicio.CrearParametro("@idRol", idRol)
            };
            try
            {
                _servicio.RealizarOperacion("registrar_rol_usuario", parametros);

            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
        public void EliminarRolAUsuario(int idUsuario, int idRol)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@idUsuario", idUsuario),
                _servicio.CrearParametro("@idRol", idRol)
            };
            try
            {
                _servicio.RealizarOperacion("eliminar_rol_usuario", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }        
        private IList<IPermiso> ObtenerPermisosPorIdPadre(int idPadre)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@idPadre", idPadre)
            };

            try
            {
                var resultado = _servicio.Leer("obtener_permisos_por_idPadre", parametros);

                List<IPermiso> permisos = new List<IPermiso>();

                foreach (DataRow item in resultado.Rows)
                {
                    permisos.Add(MapearPermiso(item));
                }

                return permisos;
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
        private IRol MapearRol(DataRow row)
        {
            return new Rol()
            {
                Id = int.Parse(row["id"].ToString()),
                Nombre = row["nombre"].ToString()
            };
        }
        private IPermiso MapearPermiso(DataRow row)
        {
            return new Permiso()
            {
                Id = int.Parse(row["id"].ToString()),
                Nombre = row["nombre"].ToString(),
                IdPadre = int.Parse(row["idPadre"].ToString())
            };
        }
        private List<IRol> MapearRoles(DataRowCollection rows)
        {
            List<IRol> roles = new List<IRol>();

            foreach (DataRow item in rows)
            {
                var rol = MapearRol(item);

                var permisos = ObtenerPermisosPorIdPadre(rol.ObtenerId());

                foreach (IPermiso permiso in permisos)
                {
                    rol.AgregarPermiso(permiso);
                }
                roles.Add(rol);
            }

            return roles;
        }
    }
}
