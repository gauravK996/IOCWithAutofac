using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofaciocweb.Models;

namespace Autofaciocweb.Infrastructure
{
    public class Depencyreg2 : IDependencyRegistrar
    {
        public void Registrar(ContainerBuilder builder, ITypeFinder typeFinder)
        {


            //builder.RegisterType<Course>().As<ICourse>().InstancePerLifetimeScope();
           // throw new NotImplementedException();
        }
    }
}
