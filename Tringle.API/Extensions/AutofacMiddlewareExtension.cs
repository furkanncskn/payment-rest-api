using Autofac;
using Autofac.Extensions.DependencyInjection;
using Tringle.API.Modules;

namespace Tringle.API.Extensions
{
    public static class AutofacMiddlewareExtension
    {
        public static void ConfigureAutofac(this ConfigureHostBuilder host)
        {
            host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>
                (
                    builder => builder.RegisterModule(new AutofacModule()
                ));
        }
    }
}
