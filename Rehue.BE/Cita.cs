using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rehue.BE
{
    public class Cita : Entity, ICita
    {
        public int CantidadComensales { get; set; }
        public IPersona Persona { get; set; }
        public IMesa Mesa { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaCancelacion { get; set; }
        public DateTime? FechaConfirmacion { get; set; }
        public DateTime FechaEncuentro { get; set; }
        public IDenuncia Denuncia { get; set; }
        [NonVerificableAttribute]
        public string DigitoH { get; set; }
    }
}