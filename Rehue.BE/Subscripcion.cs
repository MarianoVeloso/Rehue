using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rehue.BE
{
    public class Subscripcion
    {
        private DateTime _fechaCreacion;

        public DateTime FechaCreacion
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
        }

        private DateTime _fechaCaducidad;

        public DateTime FechaCaducidad
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
        }

        private int _monto;

        public int Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }
    }
}