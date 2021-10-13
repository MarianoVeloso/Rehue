using Rehue.Interfaces.Bitacora;
using Rehue.Interfaces.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Servicios.Bitacora
{
    public class BitacoraOperador<T>
    {
        private IBitacora<T> _bitacora;

        private static BitacoraOperador<T> _instancia;

        public static BitacoraOperador<T> Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new BitacoraOperador<T>();
                return _instancia;
            }
        }

        public void EstablecerBitacora(IBitacora<T> bitacora)
        {
            _bitacora = bitacora;
        }

        public IEvento ObtenerEvento(T entity)
        {
            return _bitacora.CrearEvento(entity);
        }
    }
}
