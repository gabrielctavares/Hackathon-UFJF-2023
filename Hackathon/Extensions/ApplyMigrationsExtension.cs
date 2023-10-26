using Hackathon.Data;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Extensions
{
    public static class ApplyMigrationsExtension
    {
        public static WebApplication ApplyMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<DataContext>();
            context.Database.Migrate();

            return app;
        }
    }
}
