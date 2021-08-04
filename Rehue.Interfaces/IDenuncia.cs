using System;

namespace Rehue.Interfaces
{
    public interface IDenuncia: IEntity
    {
        IAdministrador Administrador { get; set; }
        string Descripcion { get; set; }
        DateTime FechaCreacion { get; set; }
        DateTime? FechaConfirmacion{ get; set; }
        DateTime? FechaCancelacion{ get; set; }
    }
}