using FerreteriaPOS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configurar DbContext con SQL Server
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // A�adir servicios de controladores para APIs
        builder.Services.AddControllers();

        // Configurar Swagger
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "FerreteriaPOS API",
                Version = "v1",
                Description = "API para gestionar productos y ventas en Ferreter�a POS."
            });
        });

        var app = builder.Build();

        // Configuraci�n para desarrollo
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FerreteriaPOS API v1");
                c.RoutePrefix = string.Empty; // Swagger estar� en la ra�z
            });
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();

        // Mapear controladores
        app.MapControllers();

        app.Run();
    }
}
