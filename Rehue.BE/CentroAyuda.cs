using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public class CentroAyuda : ICentroAyuda
    {
        public string Formulario { get; set; }
        public string Descripcion { get; set; }

        public List<ISeccionDescripcion> Detalle { get; set; }
    }
}
