﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.Interfaces.Eventos
{
    public interface IEventoLogOutExito : IEvento
    {
        int IdUsuario { get; set; }
    }
}
