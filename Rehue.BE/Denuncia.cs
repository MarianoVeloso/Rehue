using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public class Denuncia : Entity, IDenuncia
    {
        public string Descripcion { get; set; }
        public Sancion Sancion { get; set; }
        public IAdministrador Administrador { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaConfirmacion { get; set; }
        public DateTime? FechaCancelacion { get; set; }
    }
}
