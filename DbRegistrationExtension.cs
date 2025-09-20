using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace KavicBlockchain;

public static class DbRegistrationExtension
{
    public static void AddAllDbContexts(this IServiceCollection services, IConfiguration configuration, string connectionStringName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var contextTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(DbContext)));

        var addDbContextMethod = typeof(EntityFrameworkServiceCollectionExtensions)
            .GetMethods()
            .FirstOrDefault(m => m.Name == nameof(EntityFrameworkServiceCollectionExtensions.AddDbContext) && m.IsGenericMethod);

        if (addDbContextMethod == null)
        {
            throw new InvalidOperationException("Could not find AddDbContext method.");
        }

        foreach (var contextType in contextTypes)
        {
            var genericMethod = addDbContextMethod.MakeGenericMethod(contextType);

            genericMethod.Invoke(null, new object[]
            {
                services,
                (Action<DbContextOptionsBuilder>)(options =>
                    options.UseSqlServer(configuration.GetConnectionString(connectionStringName))),
                ServiceLifetime.Scoped,
                ServiceLifetime.Scoped
            });
        }
    }
}
