using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Rehue.DAL
{
    internal static class Acceso
    {
        private static SqlConnection conexion;
        private static SqlTransaction transaccion;
        public static void Abrir()
        {
            conexion = new SqlConnection("Initial Catalog=Rehue; Data Source=.\\SqlExpress; Integrated Security=SSPI");
            conexion.Open();
        }

        public static void Cerrar()
        {
            conexion.Close();
            conexion = null;
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
            SqlCommand comando = new SqlCommand(storedProcedure, conexion)
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

            if (transaccion != null)
            {
                comando.Transaction = transaccion;
            }

            try
            {
                res = comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                RegistrarError(ex.InnerException.Message);
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
            if (transaccion != null && conexion.State == ConnectionState.Open)
            {
                transaccion = conexion.BeginTransaction();
            }
            else
            {
                transaccion = conexion.BeginTransaction();
            }
        }

        public static void ConfirmarTransaccion()
        {
            transaccion.Commit();
            transaccion.Dispose();
            transaccion = null;

        }

        public static void CancelarTransaccion()
        {
            transaccion.Rollback();
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
