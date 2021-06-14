using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Abstracciones
{
    public interface IMenu
    {
        IEmpresa Empresa { get; set; }
        List<IItem> Items { get; set; }
        DateTime FechaCreacion { get; set; }
        void AgregarItem(IMenuComponent p);
        void QuitarItems();
        IList<IMenuComponent> ObtenerItems();
    }
}
