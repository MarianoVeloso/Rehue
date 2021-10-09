using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Servicios
{
    public class GestorDV
    {
        private static GestorDV _instancia;

        public static GestorDV Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new GestorDV();
                return _instancia;
            }
        }

        public string GenerarDVH<T>(T entity)
        {
            Type t = entity.GetType();
            string dvh = string.Empty;
            var props = t.GetProperties();
            foreach (var item in props)
            {
                var attrs = item.GetCustomAttributes(false);
                bool encriptar = attrs.Where(i => i.GetType().ToString().Contains("NonVerificableAttribute")).FirstOrDefault() != null ? false : true;

                if (encriptar)
                {
                    if (item.PropertyType.FullName.Equals(typeof(DateTime).FullName))
                    {
                        DateTime a = (DateTime)item.GetValue(entity);
                        dvh += a.ToString("ddmmyyyyhhmmss");
                    }
                    else
                    {
                        dvh += item.GetValue(entity)?.ToString();
                    }
                }
            }

            return Encriptador.GenerarDVMD5Hash(dvh);
        }
        public string GenerarDVV<T>(List<T> entities)
        {
            string response = string.Empty;

            foreach (var item in entities)
            {
                response += GenerarDVH(item);
            }

            return Encriptador.GenerarDVMD5Hash(response);
        }
    }
}
