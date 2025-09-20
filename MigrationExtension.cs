using Microsoft.EntityFrameworkCore;

namespace KavicBlockchain;

public static class MigrationExtension
{
    public static void ApplyMigrations<T>(this IServiceProvider services) where T : DbContext
    {
        using var scope = services.CreateScope();
        var scopedServices = scope.ServiceProvider;
        var context = scopedServices.GetRequiredService<T>();
        context.Database.Migrate();
        scope.Dispose();
    }
}
