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
    public class SubscripcionDAL
    {
        private readonly Servicio _servicio = Servicio.Instancia;

        private static SubscripcionDAL _instancia;
        public static SubscripcionDAL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new SubscripcionDAL();
                return _instancia;
            }
        }

        public void CrearSubscripcion(ISubscripcion subscripcion)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@Codigo", subscripcion.Codigo),
                    _servicio.CrearParametro("@FechaCreacion", subscripcion.FechaCreacion),
                    _servicio.CrearParametro("@FechaCaducidad", subscripcion.FechaCaducidad),
                    _servicio.CrearParametro("@Descripcion", subscripcion.Descripcion),
                    _servicio.CrearParametro("@Costo", subscripcion.Costo)

                };

                _servicio.RealizarOperacion("crear_subscripcion", parametros);
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

        public List<ISubscripcion> ObtenerTodos()
        {
            try
            {
                var resultado = _servicio.Leer("obtener_subscripciones");

                List<ISubscripcion> subscripcion = new List<ISubscripcion>();

                foreach (DataRow item in resultado.Rows)
                {
                    subscripcion.Add(MapearSubscripcion(item));
                }

                return subscripcion;
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

        public ISubscripcion ObtenerPorId(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@id", id)
            };
            try
            {
                var resultado = _servicio.Leer("obtener_subscripcione_por_id", parametros);

                ISubscripcion subscripcion = new Subscripcion();

                foreach (DataRow item in resultado.Rows)
                {
                    subscripcion = MapearSubscripcion(item);
                }

                return subscripcion;
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

        public void PagarSubscripcion(int idEmpresa, int idSubscripcion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@idEmpresa", idEmpresa),
                _servicio.CrearParametro("@idSubscripcion", idSubscripcion)
            };
            try
            {
                _servicio.RealizarOperacion("crear_subscripcion", parametros);
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

        private ISubscripcion MapearSubscripcion(DataRow row)
        {
            return new Subscripcion()
            {
                Id = int.Parse(row["id"].ToString()),
                Codigo = row["Codigo"].ToString(),
                Descripcion = row["description"].ToString(),
                FechaCaducidad = DateTime.Parse(row["FechaCaducidad"].ToString()),
                FechaCreacion = DateTime.Parse(row["FechaCreacion"].ToString())
            };
        }
    }
}
