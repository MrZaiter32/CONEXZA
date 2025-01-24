using Microsoft.EntityFrameworkCore;

namespace CONEXA.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Familia> Familias { get; set; }
        public DbSet<UnidadMedida> UnidadesMedida { get; set; } // Agregar aquí
    }
}


public class Producto
    {
        public int Id { get; set; }
        public required string Sku { get; set; } // Requerido al crear la instancia
        public required string Nombre { get; set; } // Requerido
        public string Descripcion { get; set; } = string.Empty; // Opcional
        public required int FamiliaId { get; set; } // Requerido
        public required Familia Familia { get; set; } // Relación requerida
        public required string UnidadMedida { get; set; } = "pieza"; // Requerido con valor predeterminado
        public int Existencias { get; set; } = 0; // Valor inicial
        public required decimal PrecioPublico { get; set; } // Requerido
        public required decimal Costo { get; set; } // Requerido
        public string Ubicacion { get; set; } = string.Empty; // Opcional

        // Campo para almacenar fotos (ruta o nombre del archivo)
        public string Foto { get; set; } = string.Empty; // Opcional
    }

    public class Familia
    {
        public int Id { get; set; }
        public required string Nombre { get; set; } // Requerido
        public string Descripcion { get; set; } = string.Empty; // Opcional
        public ICollection<Producto> Productos { get; set; } = new List<Producto>(); // Relación inicializada
    }

    public class MovimientoAlmacen
    {
        public int Id { get; set; }
        public required int ProductoId { get; set; } // Requerido
        public required Producto Producto { get; set; } // Relación requerida
        public required string TipoMovimiento { get; set; } // Requerido
        public required int Cantidad { get; set; } // Requerido
        public string Motivo { get; set; } = string.Empty; // Opcional
        public DateTime Fecha { get; set; } = DateTime.Now; // Valor inicial
        public string Usuario { get; set; } = string.Empty; // Opcional
    }

