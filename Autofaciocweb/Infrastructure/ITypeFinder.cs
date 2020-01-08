using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Autofaciocweb.Infrastructure
{
    public interface ITypeFinder
    {
        IEnumerable<Type> FindClassesoftype<T>(bool onlyConcreateClass = true);
        IEnumerable<Type> FindClassesoftype(Type assigntypeform, bool OnlyConcreateclass = true);
        IEnumerable<Type> FindClassesoftype(IEnumerable<Assembly> assemblies, bool OnlyConcreateclass = true);
        IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true);
        IList<Assembly> GetAssemblies();
    }
}
