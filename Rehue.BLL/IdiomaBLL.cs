using Rehue.BE;
using Rehue.DAL;
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
    public class IdiomaBLL : ICrud<IIdioma>
    {
        private readonly IdiomaDAL _servicio = new IdiomaDAL();

        public string ObtenerTraduccionDeIdiomaDefault(string etiqueta, IList<IIdioma> idiomas )
        {
            return TraductorBLL.ObtenerTraducciones(idiomas.Where( _ => _.Default).FirstOrDefault()).Keys.Contains(etiqueta) == false ? string.Empty 
                    : TraductorBLL.ObtenerTraducciones(idiomas.Where(_ => _.Default).FirstOrDefault())[etiqueta].Texto;
        }
        public void Eliminar(IIdioma entity)
        {
            throw new NotImplementedException();
        }
        public void ActualizarDefault(IIdioma idiomaDefault)
        {
            if(Session.Instancia.IsLogged())
            {
                _servicio.ActualizarDefault(Session.Instancia.Usuario.Id, idiomaDefault.Id);

                Session.Instancia.Usuario.Idioma = idiomaDefault;
            }
        }
        public void Guardar(IIdioma entity)
        {
            try
            {
                _servicio.GuardarIdioma(entity.Nombre);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ErrorBaseDeDatos"].Texto);
            }
        }
        public IIdioma ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
        public IList<IIdioma> ObtenerTodos()
        {
            return _servicio.ObtenerIdiomas();
        }
        public IList<IEtiqueta> ObtenerEtiquetas()
        {
            return _servicio.ObtenerEtiquetas();
        }
        public void GuardarTraduccion(IDictionary<IEtiqueta, ITraduccion> traducciones, IIdioma idioma)
        {
            try
            {
                foreach (var item in traducciones)
                {
                    _servicio.CrearTraduccion(idioma.Id, item.Key.Id, item.Value.Texto);
                }
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ErrorBaseDeDatos"].Texto);
            }

        }
        public IDictionary<string, ITraduccion> ObtenerTraducciones(int idIdioma)
        {
            return _servicio.ObtenerTraducciones(idIdioma);
        }
    }
}
