using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public class Calificacion
    {
        private string _comentario;

        public string Comentario
        {
            get { return _comentario; }
            set { _comentario = value; }
        }

        private decimal _puntaje;

        public decimal Puntaje
        {
            get { return _puntaje; }
            set { _puntaje = value; }
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
