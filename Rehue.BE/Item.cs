using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rehue.BE
{
    public class Item : MenuComponent, IItem
    {
        public int IdPadre { get; set; }
        public decimal Costo { get; set; }
        public string Descripcion { get; set; }
    }
}