using System;

namespace Rehue.Interfaces
{
    public interface ISubscripcion : IEntity
    {
        DateTime FechaCaducidad { get; set; }
        DateTime FechaCreacion { get; set; }
        decimal Costo { get; set; }
        string Descripcion { get; set; }
        string Codigo { get; set; }
    }
}