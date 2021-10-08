using System;

namespace Rehue.Interfaces
{
    public interface ICita : IEntity, IDigitoVerificador
    {
        int CantidadComensales { get; set; }
        IDenuncia Denuncia { get; set; }
        IMesa Mesa { get; set; }
        IPersona Persona { get; set; }
        DateTime? FechaCancelacion { get; set; }
        DateTime FechaCreacion { get; set; }
        DateTime FechaEncuentro { get; set; }
        DateTime? FechaConfirmacion { get; set; }
    }
}