using EFCoreApp.DataAccess.Services.Abstract;
using EFCoreApp.DataAccess.Services.Concrete;

namespace EFCoreApp.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServiceExtensions(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICurrencyService, CurrencyService>();
            builder.Services.AddScoped<IBusinessUnitService, BusinessUnitService>();
        }
    }
}