using EFCoreApp.DataAccess.Repositories.Abstract;
using EFCoreApp.DataAccess.Repositories.Concrete;
using EFCoreApp.DataAccess.UnitOfWork;

namespace EFCoreApp.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddRepositoryExtensions(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            builder.Services.AddScoped<IBusinessUnitRepository, BusinessUnitRepository>();
        }
    }
}
