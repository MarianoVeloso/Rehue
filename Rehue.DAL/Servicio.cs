using Rehue.Interfaces;
using Rehue.Servicios;
using Rehue.Servicios.Helpers;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Rehue.DAL
{
    internal class Servicio
    {
        private readonly IAcceso acceso = new Acceso();

        private static Servicio _instancia;

        public static Servicio Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new Servicio();
                return _instancia;
            }
        }
        public void RealizarOperacion(string storedProcedure, List<SqlParameter> parameters = null)
        {
            acceso.Abrir();
            acceso.IniciarTransaccion();

            int res = acceso.Operar(storedProcedure, parameters);

            if (res != -1)
            {
                acceso.ConfirmarTransaccion();
                acceso.Cerrar();
            }
            else
            {
                acceso.Cerrar();
                throw new OperacionDBException("Ocurrió un error al intentar realizar la operación");
            }

        }

        public void RealizarOperacionSinTransaccion(string storedProcedure, List<SqlParameter> parameters = null)
        {
            acceso.Abrir();
            int res = acceso.Operar(storedProcedure, parameters);
            acceso.Cerrar();

            if (res == -1)
            {
                throw new OperacionDBException("Ocurrió un error al intentar realizar la operación");
            }

        }

        public void RestaurarBackup(string storedProcedure, List<SqlParameter> parameters = null)
        {
            acceso.AbrirMaster();

            int res = acceso.Operar(storedProcedure, parameters);
            acceso.Cerrar();
        }

        public SqlParameter CrearParametro(string nombre, object valor, ParameterDirection direccion = ParameterDirection.Input)
        {
            return acceso.CrearParametro(nombre, valor, direccion);
        }

        public DataTable Leer(string nombre, List<SqlParameter> parametros = null)
        {
            return acceso.Leer(nombre, parametros);
        }

        public bool VerificarConexion()
        {
            return acceso.VerificarConexion();
        }
    }
}
