using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public class Persona : Usuario, IPersona
    {
        public int Reputacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Ubicacion { get; set; }
        public override string ObtenerNombre()
        {
            return $"{Nombre} {Apellido}";
        }
    }
}
