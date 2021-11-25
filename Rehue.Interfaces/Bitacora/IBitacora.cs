using Rehue.Interfaces.Eventos;

namespace Rehue.Interfaces.Bitacora
{
    public interface IBitacora<T>
    {
        ILog<T> CrearEvento(T entity, string mensaje);
    }
}