using Rehue.Interfaces;
using Rehue.Servicios;
using Rehue.Servicios.Helpers;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Rehue.DAL
{
    public class Servicio
    {
        protected void RealizarOperacion(string storedProcedure, List<SqlParameter> parameters = null)
        {
            Acceso.Abrir();
            Acceso.IniciarTransaccion();

            int res = Acceso.Operar(storedProcedure, parameters);

            if (res != -1)
            {
                Acceso.ConfirmarTransaccion();
                Acceso.Cerrar();
            }
            else
            {
                throw new OperacionDBException("Ocurrió un error al intentar realizar la operación");
            }

        }

        protected SqlParameter CrearParametro(string nombre, object valor, ParameterDirection direccion = ParameterDirection.Input)
        {
            return Acceso.CrearParametro(nombre, valor, direccion);
        }

        protected DataTable Leer(string nombre, List<SqlParameter> parametros = null)
        {
            return Acceso.Leer(nombre, parametros);
        }
    }
}
