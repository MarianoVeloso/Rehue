using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public class Backup : Entity, IBackup
    {
        public string Ubicacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Nombre { get; set; }
    }
}
