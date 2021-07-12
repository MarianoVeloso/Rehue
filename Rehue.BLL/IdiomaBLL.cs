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
        private readonly IdiomaDAL _idiomaDAL = new IdiomaDAL();
        public void Eliminar(IIdioma entity)
        {
            throw new NotImplementedException();
        }
        public void ActualizarDefault(IIdioma idiomaDefault)
        {
            if(Session.Instancia.IsLogged())
            {
                IUsuario usuario = Session.Instancia.Usuario;

                _idiomaDAL.ActualizarDefault(usuario.Id, idiomaDefault.Id);
            }
        }
        public void Guardar(IIdioma entity)
        {
            try
            {
                _idiomaDAL.GuardarIdioma(entity.Nombre);
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
            return _idiomaDAL.ObtenerIdiomas();
        }
        public IList<IEtiqueta> ObtenerEtiquetas()
        {
            return _idiomaDAL.ObtenerEtiquetas();
        }
        public void GuardarTraduccion(IDictionary<IEtiqueta, ITraduccion> traducciones, IIdioma idioma)
        {
            try
            {
                foreach (var item in traducciones)
                {
                    _idiomaDAL.CrearTraduccion(idioma.Id, item.Key.Id, item.Value.Texto);
                }
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ErrorBaseDeDatos"].Texto);
            }

        }
        public IDictionary<string, ITraduccion> ObtenerTraducciones(int idIdioma)
        {
            return _idiomaDAL.ObtenerTraducciones(idIdioma);
        }
    }
}
