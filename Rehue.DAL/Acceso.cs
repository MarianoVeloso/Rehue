using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Rehue.DAL
{
    internal static class Acceso
    {
        private static SqlConnection _conexion;
        private static SqlTransaction _transaccion;
        public static void Abrir()
        {
            _conexion = new SqlConnection("Initial Catalog=Rehue; Data Source=.\\SqlExpress; Integrated Security=SSPI");
            _conexion.Open();
        }

        public static void Cerrar()
        {
            _conexion.Close();
            _conexion = null;
            GC.Collect();
        }

        public static SqlParameter CrearParametro(string storedProcedure, object valor, ParameterDirection direccion = ParameterDirection.Input)
        {
            DbType type;

            if (valor.GetType().Equals(typeof(bool)))
            {
                type = DbType.Byte;
            }
            else if (valor.GetType().Equals(typeof(string)))
            {
                type = DbType.String;
            }
            else if (valor.GetType().Equals(typeof(int)))
            {
                type = DbType.Int32;
            }
            else if (valor.GetType().Equals(typeof(DateTime)))
            {
                type = DbType.DateTime;
            }
            else if (valor.GetType().Equals(typeof(decimal)))
            {
                type = DbType.Decimal;
            }
            else
            {
                type = DbType.String;
            }

            SqlParameter p = new SqlParameter(storedProcedure, valor)
            {
                DbType = type,
                Direction = direccion
            };
            return p;
        }

        private static SqlCommand CrearComando(string storedProcedure, List<SqlParameter> parametros = null, CommandType tipo = CommandType.Text)
        {
            SqlCommand comando = new SqlCommand(storedProcedure, _conexion)
            {
                CommandType = tipo
            };

            if (parametros != null && parametros.Count > 0)
            {
                comando.Parameters.AddRange(parametros.ToArray());
            }

            return comando;
        }

        public static DataTable Leer(string storedProcedure, List<SqlParameter> parametros = null)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();

            Abrir();
            adaptador.SelectCommand = CrearComando(storedProcedure, parametros, CommandType.StoredProcedure);
            DataTable Tabla = new DataTable();
            adaptador.Fill(Tabla);

            Cerrar();
            return Tabla;
        }

        public static int Operar(string storedProcedure, List<SqlParameter> parametros)
        {
            SqlCommand comando = CrearComando(storedProcedure, parametros, CommandType.StoredProcedure);
            int res;

            if (_transaccion != null)
            {
                comando.Transaction = _transaccion;
            }

            try
            {
                res = comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                RegistrarError(ex.Message);
                CancelarTransaccion();
                res = -1;
            }
            catch (Exception ex)
            {
                RegistrarError(ex.InnerException.Message);
                CancelarTransaccion();
                res = -1;
            }

            return res;
        }

        public static void IniciarTransaccion()
        {
            if (_transaccion != null && _conexion.State == ConnectionState.Open)
            {
                _transaccion = _conexion.BeginTransaction();
            }
            else
            {
                _transaccion = _conexion.BeginTransaction();
            }
        }

        public static void ConfirmarTransaccion()
        {
            _transaccion.Commit();
            _transaccion.Dispose();
            _transaccion = null;

        }

        public static void CancelarTransaccion()
        {
            _transaccion.Rollback();
        }

        public static void RegistrarError(string error)
        {
            //Operar("registrar_error",
            //    new List<SqlParameter>
            //    {
            //        CrearParametro("@error", error),
            //        CrearParametro("@fecha", DateTime.Now)
            //    }
            //);
        }
    }
}
