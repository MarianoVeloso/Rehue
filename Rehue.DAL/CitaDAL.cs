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
    public class CitaDAL
    {
        private readonly PersonaDAL _personaDAL = new PersonaDAL();
        private readonly DenunciaDAL _denunciaDAL = new DenunciaDAL();
        private readonly MesaDAL _mesaDal = new MesaDAL();
        private readonly IServicio _servicio = new Servicio();

        public void CrearCita(ICita cita)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@idPersona", cita.Persona.Id),
                _servicio.CrearParametro("@idMesa", cita.Mesa.Id),
                _servicio.CrearParametro("@cantidadComensales", cita.CantidadComensales),
                _servicio.CrearParametro("@fechaCreacion", cita.FechaCreacion),
                _servicio.CrearParametro("@fechaEncuentro", cita.FechaEncuentro),
                _servicio.CrearParametro("@DigitoH", cita.DigitoH),
            };
            try
            {
                _servicio.RealizarOperacion("registrar_cita", parametros);

                parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@idMesa", cita.Mesa.Id),
                };

                _servicio.RealizarOperacion("reservar_mesa", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
        public List<ICita> ObtenerCitasConDenunciaSinGestion()
        {
            try
            {
                List<ICita> citas = new List<ICita>();
                var response = _servicio.Leer("obtener_citas_con_denuncia");
                foreach (DataRow item in response.Rows)
                {
                    citas.Add(MapearCita(item));
                }

                return citas;
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
        public ICita ObtenerCitaPorId(int idCita)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@id", idCita)
                };

                ICita cita = new Cita();
                var response = _servicio.Leer("obtener_cita_por_id", parametros);
                foreach (DataRow item in response.Rows)
                {
                    cita = MapearCita(item);
                }

                return cita;
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
        public List<ICita> ObtenerCitasPorUsuario(int idUsuario, bool esEmpresa)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@idUsuario", idUsuario)
                };
                var response = new DataTable();

                if (esEmpresa)
                {
                    response = _servicio.Leer("obtener_citas_empresa", parametros);
                }
                else
                {
                    response = _servicio.Leer("obtener_citas_usuario", parametros);
                }
                List<ICita> citas = new List<ICita>();

                foreach (DataRow item in response.Rows)
                {
                    citas.Add(MapearCita(item));
                }

                return citas;
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
        public void ConfirmarCita(int idCita)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@idCita", idCita),
                    _servicio.CrearParametro("@fechaConfirmacion", DateTime.Now),

                };

                _servicio.RealizarOperacion("confirmar_cita", parametros);
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
        public void CancelarCita(int idCita)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@idCita", idCita),
                    _servicio.CrearParametro("@fechaCancelacion", DateTime.Now),

                };
                _servicio.RealizarOperacion("cancelar_cita", parametros);
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
        private ICita MapearCita(DataRow row)
        {
            return new Cita
            {
                Id = int.Parse(row["id"].ToString()),
                CantidadComensales = int.Parse(row["cantidadComensales"].ToString()),
                Mesa = _mesaDal.ObtenerPorId(int.Parse(row["idMesa"].ToString())),
                Persona = _personaDAL.ObtenerPorId(int.Parse(row["idUsuario"].ToString())),
                FechaCancelacion = row["fechaCancelacion"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(row["fechaCancelacion"].ToString()),
                FechaCreacion = DateTime.Parse(row["fechaCreacion"].ToString()),
                FechaEncuentro = DateTime.Parse(row["FechaEncuentro"].ToString()),
                FechaConfirmacion = row["FechaConfirmacion"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(row["FechaConfirmacion"].ToString()),
                Denuncia = _denunciaDAL.ObtenerDenunciaPorIdCita(int.Parse(row["id"].ToString())),
                DigitoH = row["DigitoH"].ToString()
            };
        }
    }
}
