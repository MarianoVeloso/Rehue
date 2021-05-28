using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public class Comision
    {
        private DateTime _fechaCreacion;

        public DateTime FechaCreacion
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
        }

        public Cita Cita
        {
            get => default;
            set
            {
            }
        }
    }
}
