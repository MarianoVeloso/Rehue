using Rehue.DAL;
using Rehue.Interfaces;
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

        public void Guardar(IIdioma entity)
        {
            throw new NotImplementedException();
        }

        public IIdioma ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<IIdioma> ObtenerTodos()
        {
            return _idiomaDAL.ObtenerIdiomas();
        }
        public IDictionary<string, ITraduccion> ObtenerTraducciones(int idIdioma)
        {
            return _idiomaDAL.ObtenerTraducciones(idIdioma);
        }
    }
}
