using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Interfaces
{
    public interface IMenu : IMenuComponent
    {
        int ObtenerId();
        IList<IItem> ObtenerItems();
        void AgregarItem(IItem c);
        void QuitarItems();
    }
}
