using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Rehue.Interfaces
{
    public interface IServicio
    {
        SqlParameter CrearParametro(string nombre, object valor, ParameterDirection direccion = ParameterDirection.Input);
        DataTable Leer(string nombre, List<SqlParameter> parametros = null);
        void RealizarOperacion(string storedProcedure, List<SqlParameter> parameters = null);
    }
}