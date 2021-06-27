using Rehue.BE;
using Rehue.Interfaces;
using Rehue.Servicios.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.DAL
{
    public class IdiomaDAL
    {
        private readonly Servicio _servicio = new Servicio();

        public IList<IIdioma> ObtenerIdiomas()
        {
            try
            {
                var resultado = _servicio.Leer("obtener_idiomas");

                List<IIdioma> idiomas = new List<IIdioma>();

                foreach (DataRow item in resultado.Rows)
                {
                    idiomas.Add(MapearIdioma(item));
                }

                return idiomas;
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        public IDictionary<string, ITraduccion> ObtenerTraducciones(int idIdioma)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@id", idIdioma)
            };

            try
            {
                var resultado = _servicio.Leer("obtener_traducciones", parametros);

                IDictionary<string, ITraduccion> _traducciones = new Dictionary<string, ITraduccion>();

                foreach (DataRow item in resultado.Rows)
                {
                    var etiqueta = item["nombre_etiqueta"].ToString();
                    _traducciones.Add(etiqueta,
                     new Traduccion()
                     {
                         Texto = item["traduccion_traduccion"].ToString(),

                         Etiqueta = new Etiqueta()
                         {
                             Id = int.Parse(item["id_etiqueta"].ToString()),
                             Nombre = etiqueta
                         }
                     });
                }

                return _traducciones;
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        private IIdioma MapearIdioma(DataRow item)
        {
            return new Idioma()
            {
                Id = int.Parse(item["id"].ToString()),
                Nombre = item["nombre"].ToString(),
                Default = bool.Parse(item["idioma_default"].ToString())

            };
        }

    }
}
