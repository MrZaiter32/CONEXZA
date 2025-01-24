using Microsoft.EntityFrameworkCore;
using FerreteriaPOS.Models;

namespace FerreteriaPOS.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Tablas en la base de datos
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
    }
}
