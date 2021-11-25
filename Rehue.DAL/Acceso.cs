using Newtonsoft.Json;
using Rehue.BE;
using Rehue.Interfaces;
using Rehue.Servicios.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Rehue.DAL
{
    internal class Acceso : IAcceso
    {
        private SqlConnection _conexion;
        private SqlTransaction _transaccion;
        public void Abrir()
        {
            _conexion = new SqlConnection("Initial Catalog=Rehue; Data Source=.\\SqlExpress; Integrated Security=SSPI");
            _conexion.Open();
        }
        public void AbrirMaster()
        {
            _conexion = new SqlConnection("Initial Catalog=master; Data Source=.\\SqlExpress; Integrated Security=SSPI");
            _conexion.Open();
        }

        public void Cerrar()
        {
            _conexion.Close();
            _conexion = null;
            GC.Collect();
        }

        public SqlParameter CrearParametro(string paramName, object valor, ParameterDirection direccion = ParameterDirection.Input)
        {
            DbType type;

            SqlParameter p;

            if (valor == null)
                return new SqlParameter(paramName, DBNull.Value)
                {
                    Direction = direccion
                };

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

            p = new SqlParameter(paramName, valor)
            {
                DbType = type,
                Direction = direccion
            };
            return p;
        }

        private SqlCommand CrearComando(string storedProcedure, List<SqlParameter> parametros = null, CommandType tipo = CommandType.Text)
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

        public DataTable Leer(string storedProcedure, List<SqlParameter> parametros = null)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();

            Abrir();
            adaptador.SelectCommand = CrearComando(storedProcedure, parametros, CommandType.StoredProcedure);
            DataTable Tabla = new DataTable();
            adaptador.Fill(Tabla);

            Cerrar();
            return Tabla;
        }

        public int Operar(string storedProcedure, List<SqlParameter> parametros)
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
                RegistrarError(ex);
                if (_transaccion != null)
                    CancelarTransaccion();
                res = -1;
            }
            catch (Exception ex)
            {
                CancelarTransaccion();
                res = -1;
            }

            return res;
        }

        public void IniciarTransaccion()
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

        public void ConfirmarTransaccion()
        {
            _transaccion.Commit();
            _transaccion.Dispose();
            _transaccion = null;

        }

        public void CancelarTransaccion()
        {
            _transaccion.Rollback();
        }

        public bool VerificarConexion()
        {
            string conStr = "Initial Catalog=Rehue; Data Source=.\\SqlExpress; Integrated Security=SSPI";
            string cmdText = "SELECT * FROM master.dbo.sysdatabases WHERE name ='" + "Rehue" + "'";
            bool isExist = false;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(cmdText, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            isExist = reader.HasRows;
                        }
                    }
                    con.Close();
                }
                catch (Exception)
                {

                }
            }
            return isExist;
        }

        public void RegistrarError(Exception ex)
        {
            XMLWriterException.Escribir(ex);
        }
    }
}
