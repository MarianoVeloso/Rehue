using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rehue.BE
{
    public abstract class RolComponent : Entity,  IRolComponent
    {
        public string Nombre { get; set; }
    }
}