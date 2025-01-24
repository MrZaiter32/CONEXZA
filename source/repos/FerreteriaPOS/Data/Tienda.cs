using System.ComponentModel.DataAnnotations;

namespace FerreteriaPOS.Models
{
    public class Tienda : IEquatable<Tienda?>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Nombre { get; set; }

        [MaxLength(200)]
        public string Direccion { get; set; } = string.Empty;

        public ICollection<Producto> Productos { get; set; } = new List<Producto>();

        public override bool Equals(object? obj)
        {
            return Equals(obj as Tienda);
        }

        public bool Equals(Tienda? other)
        {
            return other is not null &&
                   Id == other.Id &&
                   Nombre == other.Nombre &&
                   Direccion == other.Direccion &&
                   EqualityComparer<ICollection<Producto>>.Default.Equals(Productos, other.Productos);
        }

        public static bool operator ==(Tienda? left, Tienda? right)
        {
            return EqualityComparer<Tienda>.Default.Equals(left, right);
        }

        public static bool operator !=(Tienda? left, Tienda? right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
