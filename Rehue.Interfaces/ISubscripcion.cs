using System;

namespace Rehue.Interfaces
{
    public interface ISubscripcion : IEntity
    {
        DateTime FechaCreacion { get; set; }
        bool PuedeCrearMenu { get; set; }
        string Descripcion { get; set; }
        decimal Costo { get; set; }
    }
}