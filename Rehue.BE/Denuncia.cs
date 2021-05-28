using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public class Denuncia
    {
        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        //private EstadoDenuncia _estado;

        //public EstadoDenuncia Estado
        //{
        //    get { return _estado; }
        //    set { _estado = value; }
        //}

        public Sancion Sancion
        {
            get => default;
            set
            {
            }
        }

        public Administrador Administrador
        {
            get => default;
            set
            {
            }
        }

        public EstadoDenuncia EstadoDenuncia
        {
            get => default;
            set
            {
            }
        }
    }
}
