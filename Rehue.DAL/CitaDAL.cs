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
    public class CitaDAL : Servicio
    {
        private readonly EmpresaDAL _empresaDAL = new EmpresaDAL();
        private readonly PersonaDAL _personaDAL = new PersonaDAL();
        private readonly DenunciaDAL _denunciaDAL = new DenunciaDAL();
        public void CrearCita(ICita cita)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                CrearParametro("@idPersona", cita.Persona.Id),
                CrearParametro("@idEmpresa", cita.Empresa.Id),
                CrearParametro("@cantidadComensales", cita.CantidadComensales),
                CrearParametro("@fechaCreacion", cita.FechaCreacion),
                CrearParametro("@fechaEncuentro", cita.FechaEncuentro),
            };

            try
            {
                RealizarOperacion("registrar_cita", parametros);
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
                var response = Leer("obtener_citas_con_denuncia");
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
                    CrearParametro("@id", idCita)
                };

                ICita cita = new Cita();
                var response = Leer("obtener_cita_por_id", parametros);
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
                    CrearParametro("@idUsuario", idUsuario)
                };
                var response = new DataTable();

                if (esEmpresa)
                {
                    response = Leer("obtener_citas_empresa", parametros);
                }
                else
                {
                    response = Leer("obtener_citas_usuario", parametros);
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
                    CrearParametro("@idCita", idCita),
                    CrearParametro("@fechaConfirmacion", DateTime.Now),

                };

                RealizarOperacion("confirmar_cita", parametros);
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
                    CrearParametro("@idCita", idCita),
                    CrearParametro("@fechaCancelacion", DateTime.Now),

                };
                RealizarOperacion("cancelar_cita", parametros);
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
                Empresa = _empresaDAL.ObtenerPorId(int.Parse(row["idEmpresa"].ToString())),
                Persona = _personaDAL.ObtenerPorId(int.Parse(row["idUsuario"].ToString())),
                FechaCancelacion = row["fechaCancelacion"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(row["fechaCancelacion"].ToString()),
                FechaCreacion = DateTime.Parse(row["fechaCreacion"].ToString()),
                FechaEncuentro = DateTime.Parse(row["FechaEncuentro"].ToString()),
                FechaConfirmacion = row["FechaConfirmacion"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(row["FechaConfirmacion"].ToString()),
                Denuncia = row.Table.Columns.Contains("idDenuncia") ? _denunciaDAL.ObtenerDenunciaPorId(int.Parse(row["idDenuncia"].ToString())) : null
            };
        }
    }
}
