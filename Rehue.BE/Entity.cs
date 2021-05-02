using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public interface IEntity
    {
        Guid Id { get; }
    }
    public abstract class Entity : IEntity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; }
    }
}
