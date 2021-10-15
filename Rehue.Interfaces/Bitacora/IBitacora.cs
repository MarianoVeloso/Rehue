using Rehue.Interfaces.Eventos;

namespace Rehue.Interfaces.Bitacora
{
    public interface IBitacora<T>
    {
        ILog CrearEvento(T entity);
    }
}