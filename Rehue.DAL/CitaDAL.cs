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
        private readonly Servicio _servicio = Servicio.Instancia;

        private static CitaDAL _instancia;
        public static CitaDAL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CitaDAL();
                return _instancia;
            }
        }

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
                _servicio.CrearParametro("@idCita", cita.Id, ParameterDirection.Output),
            };
            try
            {
                _servicio.RealizarOperacion("registrar_cita", parametros);

                cita.Id = int.Parse(parametros.Where(x => x.ParameterName == "@idCita").FirstOrDefault().Value.ToString());

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


        public void CrearRegistroCita(ICita cita, int IdUsuarioAccion, EventoEnum evento)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@IdUsuarioCreador", cita.Persona.Id),
                _servicio.CrearParametro("@idCita", cita.Id),
                _servicio.CrearParametro("@idMesa", cita.Mesa.Id),
                _servicio.CrearParametro("@cantidadComensales", cita.CantidadComensales),
                _servicio.CrearParametro("@fechaCreacion", cita.FechaCreacion),
                _servicio.CrearParametro("@fechaEncuentro", cita.FechaEncuentro),
                _servicio.CrearParametro("@DigitoH", cita.DigitoH),
                _servicio.CrearParametro("@IdEvento", (int)evento),
                _servicio.CrearParametro("@IdUsuarioAccion", IdUsuarioAccion),
                _servicio.CrearParametro("@fechaAccion", DateTime.Now),
                _servicio.CrearParametro("@FechaCancelacion", cita.FechaCancelacion),
                _servicio.CrearParametro("@FechaConfirmacion", cita.FechaConfirmacion)
            };
            try
            {
                _servicio.RealizarOperacion("registrar_cita_registro", parametros);
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
        public List<ICita> ObtenerCitasLazy()
        {
            try
            {
                var response = new DataTable();

                response = _servicio.Leer("obtener_citas");

                List<ICita> citas = new List<ICita>();

                foreach (DataRow item in response.Rows)
                {
                    citas.Add(LazyMapearCita(item));
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

        public void ConfirmarCita(ICita cita)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@idCita", cita.Id),
                    _servicio.CrearParametro("@fechaConfirmacion", cita.FechaConfirmacion),

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
        public void CancelarCita(ICita cita)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@idCita", cita.Id),
                    _servicio.CrearParametro("@fechaCancelacion", cita.FechaCancelacion),

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

        public void ActualizarDigitoH(ICita cita)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@id", cita.Id),
                    _servicio.CrearParametro("@digitoH", cita.DigitoH),

                };
                _servicio.RealizarOperacion("actualizar_digito_cita", parametros);
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
        public void HabilitarMesa(ICita cita)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@idMesa", cita.Mesa.Id)

                };

                _servicio.RealizarOperacion("habilitar_mesa", parametros);
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
                Mesa = MesaDAL.Instancia.ObtenerPorId(int.Parse(row["idMesa"].ToString())),
                Persona = PersonaDAL.Instancia.ObtenerPorId(int.Parse(row["idUsuario"].ToString())),
                FechaCancelacion = row["fechaCancelacion"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(row["fechaCancelacion"].ToString()),
                FechaCreacion = DateTime.Parse(row["fechaCreacion"].ToString()),
                FechaEncuentro = DateTime.Parse(row["FechaEncuentro"].ToString()),
                FechaConfirmacion = row["FechaConfirmacion"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(row["FechaConfirmacion"].ToString()),
                Denuncia = DenunciaDAL.Instancia.ObtenerDenunciaPorIdCita(int.Parse(row["id"].ToString())),
                DigitoH = row["DigitoH"].ToString()
            };
        }

        private ICita LazyMapearCita(DataRow row)
        {
            return new Cita
            {
                Id = int.Parse(row["id"].ToString()),
                CantidadComensales = int.Parse(row["cantidadComensales"].ToString()),
                FechaCancelacion = row["fechaCancelacion"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(row["fechaCancelacion"].ToString()),
                FechaCreacion = DateTime.Parse(row["fechaCreacion"].ToString()),
                FechaEncuentro = DateTime.Parse(row["FechaEncuentro"].ToString()),
                FechaConfirmacion = row["FechaConfirmacion"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(row["FechaConfirmacion"].ToString()),
                DigitoH = row["DigitoH"].ToString()
            };
        }
    }
}
