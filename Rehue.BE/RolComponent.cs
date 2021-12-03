using Rehue.Interfaces;

namespace Rehue.BE
{
    public abstract class RolComponent : Entity,  IRolComponent
    {
        public string Nombre { get; set; }
    }
}