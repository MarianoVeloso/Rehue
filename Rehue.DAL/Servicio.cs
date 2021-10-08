using Rehue.Interfaces;
using Rehue.Servicios;
using Rehue.Servicios.Helpers;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Rehue.DAL
{
    internal class Servicio : IServicio
    {
        private readonly IAcceso acceso = new Acceso();

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
                throw new OperacionDBException("Ocurrió un error al intentar realizar la operación");
            }

        }

        public SqlParameter CrearParametro(string nombre, object valor, ParameterDirection direccion = ParameterDirection.Input)
        {
            return acceso.CrearParametro(nombre, valor, direccion);
        }

        public DataTable Leer(string nombre, List<SqlParameter> parametros = null)
        {
            return acceso.Leer(nombre, parametros);
        }
    }
}
