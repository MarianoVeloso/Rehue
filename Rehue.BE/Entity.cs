using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public abstract class Entity : IEntity
    {
        [NonVerificableAttribute]
        public int Id { get; set; }
    }
}
