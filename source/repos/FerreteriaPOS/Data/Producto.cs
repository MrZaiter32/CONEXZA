using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using FerreteriaPOS.Data;

namespace FerreteriaPOS.Models
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public record Producto([property: Key] int Id, [property: Required][property: MaxLength(100)] string Nombre, [property: Required] string Categoria, [property: Required] decimal Precio, int Stock, int TiendaId, Tienda Tienda) : IProducto
    {
        public Producto() : this(0, string.Empty, string.Empty, 0m, 0, 0, new Tienda { Nombre = string.Empty })
        {
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
