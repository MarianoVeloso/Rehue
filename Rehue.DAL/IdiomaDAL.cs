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
        private readonly Servicio _servicio = Servicio.Instancia;

        private static IdiomaDAL _instancia;

        public static IdiomaDAL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new IdiomaDAL();
                return _instancia;
            }
        }

        public void ActualizarDefault(int idUsuario, int idIdioma)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@idUsuario", idUsuario),
                    _servicio.CrearParametro("@idIdioma", idIdioma)
                };
                _servicio.RealizarOperacion("actualizar_default", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
        public void GuardarIdioma(string nombre)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@nombre", nombre)
                };
                _servicio.RealizarOperacion("registrar_idioma", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
        public void CrearTraduccion(int idIdioma, int idEtiqueta, string traduccion)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@idIdioma", idIdioma),
                    _servicio.CrearParametro("@idEtiqueta", idEtiqueta),
                    _servicio.CrearParametro("@traduccion", traduccion),
                };
                _servicio.RealizarOperacion("registrar_traduccion", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
        public IList<IEtiqueta> ObtenerEtiquetas()
        {
            try
            {
                var resultado = _servicio.Leer("obtener_etiquetas");

                List<IEtiqueta> idiomas = new List<IEtiqueta>();

                foreach (DataRow item in resultado.Rows)
                {
                    idiomas.Add(MapearEtiqueta(item));
                }

                return idiomas;
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
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
        public IIdioma ObtenerIdiomaPorId(int idIdioma)
        {
            try
            {

                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    _servicio.CrearParametro("@id", idIdioma)
                };

                var resultado = _servicio.Leer("obtener_idioma_por_id", parametros);

                IIdioma idioma = new Idioma();

                foreach (DataRow item in resultado.Rows)
                {
                    idioma = MapearIdioma(item);
                }

                return idioma;
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
                _servicio.CrearParametro("@idIdioma", idIdioma)
            };

            try
            {
                var resultado = _servicio.Leer("obtener_traducciones", parametros);

                IDictionary<string, ITraduccion> _traducciones = new Dictionary<string, ITraduccion>();

                foreach (DataRow item in resultado.Rows)
                {
                    var etiqueta = item["nombre"].ToString();
                    _traducciones.Add(etiqueta,
                     new Traduccion()
                     {
                         Texto = item["traduccion"].ToString(),

                         Etiqueta = new Etiqueta()
                         {
                             Id = int.Parse(item["idetiqueta"].ToString()),
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
                Default = bool.Parse(item["Defecto"].ToString())
            };
        }
        private IEtiqueta MapearEtiqueta(DataRow item)
        {
            return new Etiqueta()
            {
                Id = int.Parse(item["id"].ToString()),
                Nombre = item["nombre"].ToString()
            };
        }
    }
}
