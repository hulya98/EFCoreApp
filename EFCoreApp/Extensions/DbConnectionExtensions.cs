using EFCoreApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCoreApp.Extensions
{
    public static class DbConnectionExtensions
    {
        public static void AddDbConnectionExtensions(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings.DefaultConnection")));
        }
    }
}
