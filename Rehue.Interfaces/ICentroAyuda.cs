using System.Collections.Generic;

namespace Rehue.Interfaces
{
    public interface ICentroAyuda
    {
        string Descripcion { get; set; }
        List<ISeccionDescripcion> Detalle { get; set; }
    }
}