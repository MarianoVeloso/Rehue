using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Interfaces
{
    public interface ICrud<T>
    {
        T ObtenerPorId(int id);
        IList<T> ObtenerTodos();
        void Guardar(T entity);
        void Eliminar(T entity);
    }
}
