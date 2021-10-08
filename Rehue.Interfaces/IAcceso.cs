using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Rehue.Interfaces
{
    public interface IAcceso
    {
        void Abrir();
        void CancelarTransaccion();
        void Cerrar();
        void ConfirmarTransaccion();
        SqlParameter CrearParametro(string storedProcedure, object valor, ParameterDirection direccion = ParameterDirection.Input);
        void IniciarTransaccion();
        DataTable Leer(string storedProcedure, List<SqlParameter> parametros = null);
        int Operar(string storedProcedure, List<SqlParameter> parametros);
        void RegistrarError(string error);
    }
}