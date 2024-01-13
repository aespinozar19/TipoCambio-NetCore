using domain.aplicacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Policy;

namespace apitipocambio.provider
{
    public static class ContainerProvider
    {
     
        public static IServiceCollection ConfigureDI(this IServiceCollection services, 
            string CadenaConexion)
        {
            ConfigureContainer(services , CadenaConexion);
            return services;
        }
        private static void ConfigureContainer(IServiceCollection services ,string _Conexion)
        {
            services.AddSingleton<IcrudTcDomain>(new crudTcDomain(_Conexion));
            services.AddSingleton<IConversionTCDomain>(new ConversionTCDomain(_Conexion));
            
        }
    }
}
