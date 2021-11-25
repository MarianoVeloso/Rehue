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
    public class MesaDAL
    {
        private readonly Servicio _servicio = Servicio.Instancia;

        private static MesaDAL _instancia;

        public static MesaDAL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new MesaDAL();
                return _instancia;
            }
        }

        public void CrearMesa(IMesa mesa)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@descripcion", mesa.Descripcion),
                _servicio.CrearParametro("@cantidadComensales", mesa.CantidadComensales),
                _servicio.CrearParametro("@idEmpresa", mesa.Empresa.Id)
            };

            try
            {
                _servicio.RealizarOperacion("registrar_mesa", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
        public void Eliminar(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@id", id)
            };

            try
            {
                _servicio.RealizarOperacion("eliminar_mesa", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
        public IMesa ValidarMesaEnCita(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@id", id)
            };

            try
            {
                IMesa mesa = new Mesa();
                var response = _servicio.Leer("validar_mesa_eliminacion", parametros);
                foreach (DataRow item in response.Rows)
                {
                    mesa = MapearMesa(item);
                }
                return mesa;
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
        public IMesa ObtenerPorId(int id)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@id", id)
                };

                IMesa mesa = new Mesa();
                var response = _servicio.Leer("obtener_mesa_por_id", parametros);
                foreach (DataRow item in response.Rows)
                {
                    mesa = MapearMesa(item);
                }

                return mesa;
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
        public List<IMesa> ObtenerPorIdEmpresa(int idEmpresa)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@idEmpresa", idEmpresa)
                };

                List<IMesa> mesas = new List<IMesa>();
                var response = _servicio.Leer("obtener_mesas_por_idEmpresa", parametros);
                foreach (DataRow item in response.Rows)
                {
                    mesas.Add(MapearMesa(item));
                }

                return mesas;
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
        private IMesa MapearMesa(DataRow row)
        {
            return new Mesa
            {
                Id = int.Parse(row["id"].ToString()),
                CantidadComensales = int.Parse(row["cantidadComensales"].ToString()),
                Descripcion = row["descripcion"].ToString(),
                Reservada = bool.Parse(row["reservada"].ToString()),
                Empresa = EmpresaDAL.Instancia.ObtenerPorId(int.Parse(row["IdEmpresa"].ToString()))
            };
        }
    }
}
