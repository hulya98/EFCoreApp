using EFCoreApp.DataAccess.Constants;
using EFCoreApp.DataAccess.Services.Abstract;
using EFCoreApp.DataAccess.Services.Concrete;
using EFCoreApp.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EFCoreApp.Extensions
{
    public static class IdentityExtensions
    {
        public static void AddIdentityExtensions(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IUserStore<User>, UserStore>();
            builder.Services.AddTransient<IRoleStore<Role>, RoleStore>();

            builder.Services.AddIdentity<User, Role>();

            _ = builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = true;

                    o.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKeyConstants.Key)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            builder.Services.AddTransient<IAccountService, AccountService>();

        }
    }
}
