using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rehue.BE
{
    public class Subscripcion : Entity, ISubscripcion
    {
        public DateTime FechaCreacion { get; set; }
        public bool PuedeCrearMenu { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}