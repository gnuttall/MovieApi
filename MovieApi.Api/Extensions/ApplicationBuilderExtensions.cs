using Microsoft.EntityFrameworkCore;
using MovieApi.Data;

namespace MovieApi.Extensions;

internal static class ApplicationBuilderExtensions
{
    public static void EnsureMigrationOfContext(this IApplicationBuilder builder, bool recreate = false)
    {
        using var scope = builder.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        
        if (recreate)
        {
            context.Database.EnsureDeleted();
        }
        context.Database.Migrate();
    }
}