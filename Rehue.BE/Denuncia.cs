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
        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public Sancion Sancion
        {
            get => default;
            set
            {
            }
        }
        private IAdministrador _administrador;

        public IAdministrador Administrador
        {
            get { return _administrador; }
            set { _administrador = value; }
        }

        private DateTime _fechaCreacion;

        public DateTime FechaCreacion
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
        }

        private DateTime? _fechaConfirmacion;

        public DateTime? FechaConfirmacion
        {
            get { return _fechaConfirmacion; }
            set { _fechaConfirmacion = value; }
        }
        
        private DateTime? _fechaCancelacion;

        public DateTime? FechaCancelacion
        {
            get { return _fechaCancelacion; }
            set { _fechaCancelacion = value; }
        }
    }
}
