using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autofaciocweb.Infrastructure
{
    public interface IMainEngine
    {
        void Initilize(IServiceCollection services);
        IServiceProvider Configureservice(IServiceCollection services, IConfigurationRoot configurationRoot);
        void ConfigureRequestPipeline(IApplicationBuilder builder);
        T Resolve<T>() where T : class;
        object Resolve(Type type);
        IEnumerable<T> ResolveAll<T>();
        object ResolveUnregType(Type type);
    }
}
