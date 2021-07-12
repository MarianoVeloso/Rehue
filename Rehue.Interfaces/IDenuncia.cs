using System;

namespace Rehue.Interfaces
{
    public interface IDenuncia
    {
        IAdministrador Administrador { get; set; }
        string Descripcion { get; set; }
        DateTime FechaCreacion { get; set; }
        DateTime FechaModificacion { get; set; }
    }
}