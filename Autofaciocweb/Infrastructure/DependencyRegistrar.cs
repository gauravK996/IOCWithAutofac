using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofaciocweb.Models;

namespace Autofaciocweb.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Registrar(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterType<Game>().As<IGame>().InstancePerLifetimeScope();
            builder.RegisterType<Student>().As<IStudent>().InstancePerLifetimeScope();
            //throw new NotImplementedException();
        }
    }
}
