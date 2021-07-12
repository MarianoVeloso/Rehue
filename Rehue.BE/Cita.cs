using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rehue.BE
{
    public class Cita : Entity, ICita
    {
        private int _cantidadComensales;

        public int CantidadComensales
        {
            get { return _cantidadComensales; }
            set { _cantidadComensales = value; }
        }

        private IPersona _persona;

        public IPersona Persona
        {
            get { return _persona; }
            set { _persona = value; }
        }

        private IEmpresa _empresa;

        public IEmpresa Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }

        private DateTime _fechaCreacion;

        public DateTime FechaCreacion
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
        }

        private DateTime? _fechaModificacion;

        public DateTime? FechaModificacion
        {
            get { return _fechaModificacion; }
            set { _fechaModificacion = value; }
        }

        private DateTime? _fechaCancelacion;

        public DateTime? FechaCancelacion
        {
            get { return _fechaCancelacion; }
            set { _fechaCancelacion = value; }
        }
        private DateTime _fechaEncuentro;

        public DateTime FechaEncuentro
        {
            get { return _fechaEncuentro; }
            set { _fechaEncuentro = value; }
        }
        private IDenuncia _Denuncia;

        public IDenuncia Denuncia
        {
            get { return _Denuncia; }
            set { _Denuncia = value; }
        }
    }
}