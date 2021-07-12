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

        public List<ICita> ObtenerCitasPendientesConfirmacion(int idEmpresa)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    CrearParametro("@idEmpresa", idEmpresa)
                };


                var response = Leer("obtener_cita_pendiente", parametros);
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
        }

        public List<ICita> ObtenerCitasCanceladas(int idEmpresa)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    CrearParametro("@idEmpresa", idEmpresa)
                };

                var response = Leer("obtener_cita_canceladas", parametros);
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
        }

        private ICita MapearCita(DataRow row)
        {
            return new Cita
            {
                Id = int.Parse(row["id"].ToString()),
                CantidadComensales = int.Parse(row["cantidadComensales"].ToString()),
                Empresa = _empresaDAL.ObtenerPorId(int.Parse(row["idEmpresa"].ToString())),
                Persona = _personaDAL.ObtenerPorId(int.Parse(row["idUsuario"].ToString())),
                FechaCancelacion = DateTime.Parse(row["fechaCancelacion"].ToString()),
                FechaCreacion = DateTime.Parse(row["fechaCreacion"].ToString()),
                FechaModificacion = DateTime.Parse(row["fechaModificacion"].ToString()),
            };
        }
    }
}
