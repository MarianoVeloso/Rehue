using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rehue.BE
{
    public class Cita
    {
        private string _ubicacion;

        public string Ubicacion
        {
            get { return _ubicacion; }
            set { _ubicacion = value; }
        }

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private int _cantidadComensales;

        public int CantidadComensales
        {
            get { return _cantidadComensales; }
            set { _cantidadComensales = value; }
        }


        public Persona Persona
        {
            get => default;
            set
            {
            }
        }

        public Empresa Empresa
        {
            get => default;
            set
            {
            }
        }

        public EstadoCita EstadoCita
        {
            get => default;
            set
            {
            }
        }

        public Denuncia Denuncia
        {
            get => default;
            set
            {
            }
        }
    }
}