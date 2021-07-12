using System;

namespace Rehue.Interfaces
{
    public interface ICita : IEntity
    {
        int CantidadComensales { get; set; }
        IDenuncia Denuncia { get; set; }
        IEmpresa Empresa { get; set; }
        IPersona Persona { get; set; }
        DateTime? FechaCancelacion { get; set; }
        DateTime FechaCreacion { get; set; }
        DateTime? FechaModificacion { get; set; }
        DateTime FechaEncuentro { get; set; }
    }
}