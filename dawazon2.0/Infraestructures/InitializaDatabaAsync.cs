using dawazonBackend.Common.Database;
using Serilog;

namespace dawazon2._0.Infraestructures;

public static class InitializaDatabaAsync
{
    /// <summary>
    /// Inicializa la base de datos PostgreSQL y MongoDB.
    /// Desarrollo: Elimina y recrea la BD, siembra datos.
    /// Producción: Solo crea tablas si no existen.
    /// </summary>
    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        Log.Information("Inicializando base de datos...");

        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DawazonDbContext>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        
        await context.Database.EnsureCreatedAsync();
        logger.LogInformation("Base de datos verificada (tablas creadas si no existían)");
        
    }
}