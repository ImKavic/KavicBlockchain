using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KavicBlockchain.Data;

public static class DefaultDecimalConfiguration
{
    public static void ApplyDecimalConfiguration(this ModelBuilder modelBuilder)
    {
        foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (IMutableProperty property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(decimal))
                {
                    property.SetPrecision(32);
                    property.SetScale(18);
                }
            }
        }
    }
}
