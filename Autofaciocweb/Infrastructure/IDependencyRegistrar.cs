using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autofaciocweb.Infrastructure
{
   public interface IDependencyRegistrar
    {

        void Registrar(ContainerBuilder builder,ITypeFinder typeFinder);

    }
}
