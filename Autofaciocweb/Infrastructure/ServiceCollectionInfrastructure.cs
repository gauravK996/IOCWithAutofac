using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autofaciocweb.Infrastructure
{
    //public static class ServiceCollectionInfrastructure
    //{
    //    public static IServiceProvider ConfigureAppService(this IServiceCollection services,IConfigurationRoot configurationRoot)
    //    {
    //        services.AddHttpcontextAcsessor();
            //var Engine = EngineContext.EngineCreate();
    //        Engine.Initilize(services);
    //        var serviceprovider = Engine.Configureservice(services, configurationRoot);
    //        return serviceprovider;

    //    }

    //    //feature of HTTP 
    //    public static void AddHttpcontextAcsessor(this IServiceCollection services)
    //    {
    //        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    //    }

    //}

    public static class ServiceCollectionInfrastructur
    {
        public static IServiceProvider ConfigureAppService(this IServiceCollection services, IConfigurationRoot configurationRoot)
        {
            var Engine = EngineContext.EngineCreate();
            Engine.Initilize(services);
            var serviceprovider = Engine.Configureservice(services,configurationRoot);
            return serviceprovider;
        }
    }
}
