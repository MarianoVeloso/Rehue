using Rehue.BE.Helpers;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Rehue.DAL
{
    internal abstract class GenericMapper
    {
        private readonly Acceso acceso = new Acceso();
        internal int RealizarOperacion(string storedProcedure, List<SqlParameter> parameters = null)
        {
            acceso.Abrir();
            acceso.IniciarTransaccion();

            int res = acceso.Operar(storedProcedure, parameters);

            if (res == 1)
            {
                acceso.ConfirmarTransaccion();
            }
            else
            {
                throw new OperacionDBException("Ocurrió un error al intentar realizar la operación");
            }

            acceso.Cerrar();

            return res;
        }

        internal SqlParameter CrearParametro(string nombre, object valor, ParameterDirection direccion = ParameterDirection.Input)
        {
            return acceso.CrearParametro(nombre, valor, direccion);
        }

        internal DataTable Leer(string nombre, List<SqlParameter> parametros = null)
        {
            return acceso.Leer(nombre, parametros);
        }
    }
}
