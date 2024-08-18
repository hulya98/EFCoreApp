using EFCoreApp.Domain.Mapers;

namespace EFCoreApp.Extensions
{
    public static class MapperExtensions
    {
        public static void AddMapperExtensions(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(MapProfile));
        }
    }
}
