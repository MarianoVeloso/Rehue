using Rehue.Interfaces;
using Rehue.Servicios;
using Rehue.Servicios.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BLL
{
    public static class TraductorBLL
    {
        static IList<IIdiomaObserver> _observers = new List<IIdiomaObserver>();
        private static IdiomaBLL _idiomaBLL = new IdiomaBLL();

        public static void CambiarIdioma(IIdioma idioma)
        {
            if (Session.Instancia.IsLogged() == true)
            {
                Session.Instancia.Usuario.Idioma = idioma;
                Notificar(idioma);
            }
        }

        private static void Notificar(IIdioma idioma)
        {
            foreach (var o in _observers)
            {
                o.ActualizarIdioma(idioma);
            }
        }

        public static void SuscribirForm(IIdiomaObserver o)
        {
            _observers.Add(o);
        }
        public static void DesuscribirForm(IIdiomaObserver o)
        {
            _observers.Remove(o);
        }

        public static IIdioma ObtenerIdiomaDefault()
        {
            return ObtenerIdiomas().Where(i => i.Default).FirstOrDefault();
        }
        public static IList<IIdioma> ObtenerIdiomas()
        {
            try
            {
                return _idiomaBLL.ObtenerTodos();
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ErrorLogInException"].Texto);
                throw new ErrorLogInException(ex.Message);
            }
        }
        public static IDictionary<string, ITraduccion> ObtenerTraducciones(IIdioma idioma = null)
        {
            if (idioma == null)
            {
                idioma = ObtenerIdiomaDefault();
            }

            try
            {
                //cmd.CommandText = "select t.id_idioma,t.traduccion as traduccion_traduccion, e.id_etiqueta,e.nombre as nombre_etiqueta from traducciones t inner join etiquetas e on t.id_etiqueta=e.id_etiqueta where t.id_idioma = @id_idioma";

                return _idiomaBLL.ObtenerTraducciones(idioma.Id);

            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
    }
}
