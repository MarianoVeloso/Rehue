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

        public static void CambiarIdioma(IIdioma idioma)
        {
            if (Session.Instancia.IsLogged() == true)
            {
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
            string asdasd = o.ToString();
            bool wtf = _observers.Any(x => x.ToString() == o.ToString());

            if (!_observers.Any(x => x.ToString() == o.ToString()))
                _observers.Add(o);
        }
        public static void DesuscribirForm(IIdiomaObserver o)
        {
            _observers.Remove(o);
        }
        public static IIdioma ObtenerIdiomaDefault()
        {
            return ObtenerIdiomas().FirstOrDefault();
        }
        public static IList<IIdioma> ObtenerIdiomas()
        {
            try
            {
                IdiomaBLL _idiomaBLL = new IdiomaBLL();
                return _idiomaBLL.ObtenerTodos();
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ErrorLogInException"].Texto);
            }
        }
        public static IDictionary<string, ITraduccion> ObtenerTraducciones(IIdioma idioma)
        {
            try
            {
                IdiomaBLL _idiomaBLL = new IdiomaBLL();
                return _idiomaBLL.ObtenerTraducciones(idioma.Id);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
    }
}
