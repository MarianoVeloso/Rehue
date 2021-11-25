using Rehue.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rehue.Servicios.Helpers
{
    public static class GrillaHelper
    {
        public static void CrearGrilla<T>(IDictionary<string, Type> headers, IList<string> keys, IList<T> items, DataGridView grid)
        {
            DataTable dt = new DataTable();

            try
            {
                foreach (var item in headers)
                {
                    DataColumn colNumero = new DataColumn
                    {
                        DataType = Type.GetType(item.Value.FullName),
                        ColumnName = TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)[item.Key].Texto
                    };
                    dt.Columns.Add(colNumero);
                }


                foreach (var item in items)
                {
                    List<object> values = new List<object>();

                    foreach (var key in keys)
                    {
                        var prop = GetPropertyValue(item, key);
                        values.Add(prop);
                    }

                    dt.Rows.Add(values.ToArray());
                }

                grid.DataSource = null;
                grid.DataSource = dt;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private static object GetPropertyValue(object src, string propName)
        {
            if (propName.Contains("."))
            {
                var temp = propName.Split(new char[] { '.' }, 2);
                return GetPropertyValue(GetPropertyValue(src, temp[0]), temp[1]);
            }
            else
            {
                if(propName.Contains("(") && propName.Contains(")"))
                {
                    string funcName = propName.Replace("(", string.Empty).Replace(")", string.Empty);
                    var prop = src.GetType().GetMethod(funcName);
                    return prop != null ? prop.Invoke(src, null) : null;
                }
                else
                {
                    var prop = src.GetType().GetProperty(propName);
                    return prop != null ? prop.GetValue(src, null) : null;
                }
            }
        }
    }
}
