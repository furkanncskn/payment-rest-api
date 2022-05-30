using Tringle.Service.Mappers;

namespace Tringle.API.Extensions
{
    public static class AutoMapperMiddlewareExtension
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(assemblies =>
                    assemblies.AddMaps
                    (
                        typeof(AccountMapProfile),
                        typeof(TransactionMapProfile)
                    ));
        }
    }
}
