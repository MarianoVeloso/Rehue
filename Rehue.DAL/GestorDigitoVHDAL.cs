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
    public class GestorDigitoVHDAL
    {
        private readonly Servicio _servicio = Servicio.Instancia;

        private static GestorDigitoVHDAL _instancia;

        public static GestorDigitoVHDAL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new GestorDigitoVHDAL();
                return _instancia;
            }
        }

        public int VerificarDigitoH(int id, string hash, string storeProcedure)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@hash", hash),
                    _servicio.CrearParametro("@id", id)
                };

                var response = _servicio.Leer(storeProcedure, parametros);

                return response.Rows.Count;
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

        public int VerificarDigitoV(string hash, string tabla, string storeProcedure)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@hash", hash),
                    _servicio.CrearParametro("@tabla", tabla)
                };

                var response = _servicio.Leer(storeProcedure, parametros);

                return response.Rows.Count;
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

        public int VerificarTablaDigito(string tabla)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@tabla", tabla)
                };

                var response = _servicio.Leer("verificar_tabla_digito", parametros);

                return response.Rows.Count;
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

        public void CrearDigitoV(string hash, string tabla)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@tabla", tabla),
                    _servicio.CrearParametro("@hash", hash)
                };

                _servicio.RealizarOperacion("crear_tabla_digito", parametros);
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

        public void ActualizarDigitoV(string hashNuevo, string tabla)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@hashNuevo", hashNuevo),
                    _servicio.CrearParametro("@tabla", tabla)

                };
                _servicio.RealizarOperacion("actualizar_digitoV", parametros);
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
    }
}
