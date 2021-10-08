using Rehue.BE;
using Rehue.Interfaces;
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
    public class DenunciaDAL
    {
        private readonly IServicio _servicio = new Servicio();
        private readonly AdministradorDAL _administradorDAL = new AdministradorDAL(); 

        public void CrearDenuncia(IDenuncia denuncia, int idCita)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@descripcion", denuncia.Descripcion),
                _servicio.CrearParametro("@idCita", idCita),
                _servicio.CrearParametro("@fechaCreacion", denuncia.FechaCreacion)
            };

            try
            {
                _servicio.RealizarOperacion("crear_denuncia", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new OperacionDBException(ex.Message);
            }
        }

        public void ConfirmarDenuncia(int idDenuncia, int idAdministrador)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@idDenuncia", idDenuncia),
                _servicio.CrearParametro("@fechaConfirmacion", DateTime.Now),
                _servicio.CrearParametro("@idAdministrador", idAdministrador)
            };

            try
            {
                _servicio.RealizarOperacion("confirmar_denuncia", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new OperacionDBException(ex.Message);
            }
        }

        public void CancelarDenuncia(int idDenuncia, int idAdministrador)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@idDenuncia", idDenuncia),
                _servicio.CrearParametro("@fechaCancelacion", DateTime.Now),
                _servicio.CrearParametro("@idAdministrador", idAdministrador)
            };

            try
            {
                _servicio.RealizarOperacion("cancelar_denuncia", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new OperacionDBException(ex.Message);
            }
        }

        public IDenuncia ObtenerDenunciaPorId(int id)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@id", id)
                };

                IDenuncia denuncia = new Denuncia();
                var response = _servicio.Leer("obtener_denuncia_por_id", parametros);
                foreach (DataRow item in response.Rows)
                {
                    denuncia = MapearDenuncia(item);
                }

                return denuncia;
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

        public IDenuncia ObtenerDenunciaPorIdCita(int idCita)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@idCita", idCita)
                };

                IDenuncia denuncia = new Denuncia();
                var response = _servicio.Leer("obtener_denuncia_por_id_cita", parametros);
                foreach (DataRow item in response.Rows)
                {
                    denuncia = MapearDenuncia(item);
                }

                return denuncia;
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
        public List<IDenuncia> ObtenerDenunciaPorIdAdministrador(int idAdministrador)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@idAdministrador", idAdministrador)
                };

                List<IDenuncia> denuncias = new List<IDenuncia>();
                var response = _servicio.Leer("obtener_denuncia_por_id_administrador", parametros);
                foreach (DataRow item in response.Rows)
                {
                    denuncias.Add(MapearDenuncia(item));
                }

                return denuncias;
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

        private IDenuncia MapearDenuncia(DataRow row)
        {
            return new Denuncia()
            {
                Id = int.Parse(row["id"].ToString()),
                Descripcion = row["descripcion"].ToString(),
                FechaCreacion = DateTime.Parse(row["fechaCreacion"].ToString()),
                Administrador = row["idAdministrador"] == DBNull.Value ? null : _administradorDAL.ObtenerPorId(int.Parse(row["IdAdministrador"].ToString())),
                FechaCancelacion = row["FechaCancelacion"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(row["FechaCancelacion"].ToString()),
                FechaConfirmacion = row["FechaConfirmacion"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(row["FechaConfirmacion"].ToString())
            };
        }
    }
}
