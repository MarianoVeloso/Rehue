namespace Rehue.Interfaces
{
    public interface IItem : IMenuComponent
    {
        int IdPadre { get; set; }
        decimal Costo { get; set; }
        string Descripcion { get; set; }
    }
}