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
    public class EmpresaDAL : ICrud<IEmpresa>
    {
        private readonly Servicio _servicio = Servicio.Instancia;
        private readonly SubscripcionDAL _subscripcionDAL = SubscripcionDAL.Instancia;

        private static EmpresaDAL _instancia;
        public static EmpresaDAL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new EmpresaDAL();
                return _instancia;
            }
        }

        public IEmpresa ObtenerPorId(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@id", id)
            };

            try
            {
                var resultado = _servicio.Leer("obtener_empresa_por_id", parametros);

                IEmpresa empresa = new Empresa();

                foreach (DataRow item in resultado.Rows)
                {
                    empresa = MapearEmpresa(item);
                }

                return empresa;
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IList<IEmpresa> ObtenerTodos()
        {
            try
            {
                var resultado = _servicio.Leer("obtener_empresas");

                List<IEmpresa> empresa = new List<IEmpresa>();

                foreach (DataRow item in resultado.Rows)
                {
                    empresa.Add(MapearEmpresa(item));
                }

                return empresa;
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Guardar(IEmpresa entity)
        {
            string encryptPassword = Encriptador.GenerarHashMD5(entity.Contraseña);
            int id = 0;

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@email", entity.Email),
                _servicio.CrearParametro("@password", encryptPassword),
                _servicio.CrearParametro("@razonSocial", entity.RazonSocial),
                _servicio.CrearParametro("@cuitCuil", entity.Documento),
                _servicio.CrearParametro("@fechaNacimiento", entity.FechaNacimiento),
                _servicio.CrearParametro("@ubicacion", entity.Ubicacion),
                _servicio.CrearParametro("@telefono", entity.Telefono),
                _servicio.CrearParametro("@idIdioma", entity.Idioma.Id),
                _servicio.CrearParametro("@id", id, ParameterDirection.Output)
            };

            try
            {
                _servicio.RealizarOperacion("registar_empresa", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            entity.Id = int.Parse(parametros[8].Value.ToString());
        }
        public void Eliminar(IEmpresa entity)
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private IEmpresa MapearEmpresa(DataRow row)
        {
            IEmpresa empresa = new Empresa()
            {
                Id = int.Parse(row["id"].ToString()),
                RazonSocial = row["razonSocial"].ToString(),
                Documento = int.Parse(row["documento"].ToString()),
                Email = row["email"].ToString(),
                FechaNacimiento = DateTime.Parse(row["fechaNacimiento"].ToString()),
                Roles = RolComponentDAL.Instancia.ObtenerRolesYPermisosPorUsuario(int.Parse(row["id"].ToString())),
                Idioma = IdiomaDAL.Instancia.ObtenerIdiomaPorId(int.Parse(row["IdIdioma"].ToString()))
            };
            if (row["IdSubscripcion"] != DBNull.Value)
                empresa.AgregarSubscripcion(_subscripcionDAL.ObtenerPorId(int.Parse(row["IdSubscripcion"].ToString())));
            return empresa;
        }
    }
}
