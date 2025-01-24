using FerreteriaPOS.Data;

namespace FerreteriaPOS.Models
{
    public interface IProducto
    {
        string Categoria { get; init; }
        int Id { get; init; }
        string Nombre { get; init; }
        decimal Precio { get; init; }
        int Stock { get; init; }
        Tienda Tienda { get; init; }
        int TiendaId { get; init; }

        void Deconstruct(out int Id, out string Nombre, out string Categoria, out decimal Precio, out int Stock, out int TiendaId, out Tienda Tienda);
        bool Equals(object? obj);
        bool Equals(Producto? other);
        int GetHashCode();
        string ToString();
    }
}