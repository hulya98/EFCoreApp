using EFCoreApp.Domain;
using EFCoreApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreApp.Extensions
{
    public static class DbConnectionExtensions
    {
        public static void AddDbConnectionExtensions(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings.DefaultConnection")));

            builder.Services.AddIdentity<AppUser, AppRole>(options =>
               {
                   options.Password.RequireNonAlphanumeric = false;
                   options.Password.RequireDigit = false;
                   options.Password.RequireLowercase = false;
                   options.Password.RequireUppercase = false;
                   options.Password.RequiredLength = 1;

                   options.User.RequireUniqueEmail = true;

                   options.SignIn.RequireConfirmedEmail = true;
                   options.Lockout.MaxFailedAccessAttempts = 3;
                   options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
                   options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);


               }).AddEntityFrameworkStores<Context>()
                 .AddDefaultTokenProviders();//reset pass
        }
    }
}
