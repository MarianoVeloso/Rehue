using Rehue.Interfaces;
using System;

namespace Rehue.BE
{
    public abstract class MenuComponent : Entity, IMenuComponent
    {
        public string Nombre { get; set; }
    }
}
