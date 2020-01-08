using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Autofaciocweb.Infrastructure
{
    public class MainEngine : IMainEngine
    {
        public void ConfigureRequestPipeline(IApplicationBuilder builder)
        {
            throw new NotImplementedException();
        }

        //public IServiceProvider Configureservice(IServiceCollection services, IConfigurationRoot configurationRoot)
        //{
        //    // REGISTRAR  dEPENDENCY INJECTION
        //    //var typefinder = new TypeFinder();
        //    //Registerdependencies(services, typefinder);
        //    //return ServiceProvider;
        //    // throw new NotImplementedException();
        //}
        public IServiceProvider Configureservice(IServiceCollection services, IConfigurationRoot configurationRoot)
        {
            var typefinder = new TypeFinder();
            Registerdependencies(services, typefinder);
            return ServiceProvider;
        }
        public IServiceProvider serviceProvider2 { get; set; }

        public void Initilize(IServiceCollection services)
        {
            services.AddMvcCore();
        }

        public T Resolve<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            throw new NotImplementedException();
        }

        public object ResolveUnregType(Type type)
        {
            throw new NotImplementedException();
        }
        public IServiceProvider ServiceProvider { get; set; }
        //dfd
        public IServiceProvider Registerdependencies(IServiceCollection services,ITypeFinder typeFinder)
        {

            var containbuilder = new ContainerBuilder();

            containbuilder.RegisterInstance(this).As<IMainEngine>().SingleInstance();
            containbuilder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();
            // find registrar depen
            var dependencyReg = typeFinder.FindClassesoftype<IDependencyRegistrar>();

            var Instance = dependencyReg
                .Select(depgk => (IDependencyRegistrar)Activator.CreateInstance(depgk));
            foreach (var chalsolve in Instance)
            {
                chalsolve.Registrar(containbuilder, typeFinder);
            }
            containbuilder.Populate(services);

            ServiceProvider = new AutofacServiceProvider(containbuilder.Build());
            return ServiceProvider;
            //var contanbuilder = new ContainerBuilder();
            //contanbuilder.RegisterInstance(this).As<IMainEngine>().SingleInstance();
            //contanbuilder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();
            //var Makedep = typeFinder.FindClassesoftype<IDependencyRegistrar>();
        }
    }
}
