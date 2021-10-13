using Rehue.Interfaces.Eventos;

namespace Rehue.Interfaces.Bitacora
{
    public interface IBitacora<T>
    {
        IEvento CrearEvento(T entity);
    }
}