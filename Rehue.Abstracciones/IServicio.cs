using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Abstracciones
{
    public interface IServicio
    {
        void RealizarOperacion(string storedProcedure, List<SqlParameter> parameters = null);
        SqlParameter CrearParametro(string nombre, object valor, ParameterDirection direccion = ParameterDirection.Input);
        DataTable Leer(string nombre, List<SqlParameter> parametros = null);
    }
}
