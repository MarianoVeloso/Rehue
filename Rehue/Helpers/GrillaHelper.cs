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
        public static void CrearColumnasGridCita<T>(IDictionary<string, Type> headers, IList<string> keys, IList<T> items, DataGridView grid)
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
                        var lala = GetPropertyValue(item, key);
                        values.Add(lala);
                        //var keysSplitted = key.Split('.');
                        //if (keysSplitted.Length > 0)
                        //{


                        //PropertyInfo property = null;
                        //for (int i = 0; i < keysSplitted.Length; i++)
                        //{
                        //    if (i + 1 == keysSplitted.Length)
                        //    {
                        //        if (keysSplitted[i].Contains("(") && keysSplitted[i].Contains(")"))
                        //        {
                        //            MethodInfo methodInfo = property.GetGetMethod();

                        //            if (methodInfo != null)
                        //            {
                        //                object result = null;
                        //                //ParameterInfo[] parameters = methodInfo.GetParameters();
                        //                //object classInstance = Activator.CreateInstance(type, null);

                        //                //if (parameters.Length == 0)
                        //                //{
                        //                //    result = methodInfo.Invoke(classInstance, null);
                        //                //}
                        //                //else
                        //                //{
                        //                //result = methodInfo.Invoke(classInstance, null);
                        //                //}
                        //            }
                        //        }
                        //        values.Add(item.GetType().GetProperty(keysSplitted[i])?.GetValue(item, null));
                        //    }
                        //    else
                        //    {
                        //        if (property == null)
                        //        {
                        //            property = item.GetType().GetProperty(keysSplitted[i]);
                        //        }
                        //        else
                        //        {
                        //            if (i == keysSplitted.Length)
                        //            {
                        //                values.Add(property?.GetValue(item, null));
                        //            }
                        //            else
                        //            {
                        //                var type = property.GetType();
                        //                var property2 = item.GetType().GetProperty(keysSplitted[i]);

                        //                property = property.GetType().GetProperty(keysSplitted[i]);
                        //            }
                        //        }

                        //    }
                        //}
                        //}
                        //else
                        //{
                        //    values.Add(item.GetType().GetProperty(key)?.GetValue(item, null));
                        //}
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
                    var prop = src.GetType().GetProperty(propName);
                    return prop != null ? prop.GetValue(src, null) : null;
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
