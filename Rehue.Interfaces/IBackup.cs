using System;

namespace Rehue.Interfaces
{
    public interface IBackup : IEntity
    {
        string Nombre { get; set; }
        DateTime FechaCreacion { get; set; }
        string Ubicacion { get; set; }
    }
}