using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Interfaces
{
    public interface IMenu
    {
        DateTime FechaCreacion { get; set; }
        IList<IMenuComponent> ObtenerItems();
        void AgregarItem(IMenuComponent c);
        void QuitarItems();
    }
}
