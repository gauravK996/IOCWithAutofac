using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Autofaciocweb.Infrastructure
{
    public class TypeFinder : ITypeFinder
    {
        //public IEnumerable<Type> FindClassesoftype<T>(bool onlyConcreateClass = true)
        //{

        //    return FindClassesoftype(typeof(T), onlyConcreateClass);
        //    //throw new NotImplementedException();
        //}
        // recreate 
        public IEnumerable<Type> FindClassesoftype<T>(bool onlyConcreateClass = true)
        {
            return FindClassesodftype(typeof(T), onlyConcreateClass);
        }

        //public IEnumerable<Type> FindClassesoftype(Type assigntypeform, bool OnlyConcreateclass = true)
        //{
        //    return FindClassesOfType(assigntypeform, GetAssemblies(), OnlyConcreateclass);
        //    //throw new NotImplementedException();
        //}
        public IEnumerable<Type> FindClassesodftype(Type assigntypeform, bool onlyConcreateclass = true)
        {
            var assemblyname = new List<string>();
            var Assebly = new List<Assembly>();
            
            // AppDomain.CurrentDomain.Load()
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var match = Regex.IsMatch(assembly.FullName, "^System|^mscorlib|^Microsoft|^AjaxControlToolkit|^Antlr3|^AutoMapper|^Castle|^ComponentArt|^CppCodeProvider|^DotNetOpenAuth|^EntityFramework|^EPPlus|^FluentValidation|^ImageResizer|^itextsharp|^log4net|^MaxMind|^MbUnit|^MiniProfiler|^Mono.Math|^MvcContrib|^Newtonsoft|^NHibernate|^nunit|^Org.Mentalis|^PerlRegex|^QuickGraph|^Recaptcha|^Remotion|^RestSharp|^Rhino|^Telerik|^Iesi|^TestDriven|^TestFu|^UserAgentStringLibrary|^VJSharpCodeProvider|^WebActivator|^WebDev|^WebGrease", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                var match2 = Regex.IsMatch(assembly.FullName, ".*", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                var result2 = !match && match2;

                if (result2)
                {
                    if (!assemblyname.Contains(assembly.FullName))
                    {
                        Assebly.Add(assembly);
                        assemblyname.Add(assembly.FullName);
                    }
                }
   
            }

            var Loadname = new List<string>();
            foreach (var dc in Assebly)
            {
                Loadname.Add(dc.FullName);
            }
            var currentdir = AppContext.BaseDirectory;
            foreach (var v in Directory.GetFiles(currentdir, "*.dll"))
            {
                var a = AssemblyName.GetAssemblyName(v);
                var matchme = Regex.IsMatch(a.FullName, assemblySkipLoadingPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                
                var matchme2 = Regex.IsMatch(a.FullName,assemblySkipLoadingPattern,RegexOptions.IgnoreCase|RegexOptions.Compiled);
                var resultme = !matchme && matchme2;
                if(resultme && Loadname.Contains(a.FullName))
                {
                    AppDomain.CurrentDomain.Load(a);
                }

            }
            assemblyname=new List<string>() { };
            Assebly = new List<Assembly>() { };


            foreach (var final in AppDomain.CurrentDomain.GetAssemblies())
            {
                var match = Regex.IsMatch(final.FullName, "^System|^mscorlib|^Microsoft|^AjaxControlToolkit|^Antlr3|^AutoMapper|^Castle|^ComponentArt|^CppCodeProvider|^DotNetOpenAuth|^EntityFramework|^EPPlus|^FluentValidation|^ImageResizer|^itextsharp|^log4net|^MaxMind|^MbUnit|^MiniProfiler|^Mono.Math|^MvcContrib|^Newtonsoft|^NHibernate|^nunit|^Org.Mentalis|^PerlRegex|^QuickGraph|^Recaptcha|^Remotion|^RestSharp|^Rhino|^Telerik|^Iesi|^TestDriven|^TestFu|^UserAgentStringLibrary|^VJSharpCodeProvider|^WebActivator|^WebDev|^WebGrease", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                var match2 = Regex.IsMatch(final.FullName, ".*", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                var result2 = !match && match2;
                if(result2)
                {
                    assemblyname.Add(final.FullName);
                    Assebly.Add(final);

                }
            }

            var result = new List<Type>();
            foreach (var v in Assebly)
            {
                Type[] Dtype = null;
                Dtype = v.GetTypes();
                foreach (var cl in Dtype)
                {
                    if (assigntypeform.IsAssignableFrom(cl))
                    {
                        if(!cl.IsInterface)
                        {
                            if (onlyConcreateclass)
                            {
                                if (cl.IsClass && !cl.IsAbstract)
                                {
                                    result.Add(cl);
                                }
                            }
                            else
                            {
                                result.Add(cl);
                            }
                        }

                    }
                }
            }
            return result;
        }

        public IEnumerable<Type> FindClassesoftype(IEnumerable<Assembly> assemblies, bool OnlyConcreateclass = true)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Type> FindClassesOfType(Type assigntypefrom,IEnumerable<Assembly> assemblies,bool onlyConcreateClass=true)
        {
            var result = new List<Type>();
            try
            {
                foreach (var a in assemblies)
                {
                    Type[] cType = null;
                    try
                    {
                        cType = a.GetTypes();
                    }
                    catch
                    {

                        throw;
                    }
                    if (cType != null)
                    {
                        foreach (var type in cType)
                        {
                            if (assigntypefrom.IsAssignableFrom(type))
                            {
                                if (!type.IsInterface)
                                {
                                    if (onlyConcreateClass)
                                    {
                                        if (type.IsClass && !type.IsAbstract)
                                        {
                                            result.Add(type);
                                        }
                                    }
                                    else
                                    {
                                        result.Add(type);
                                    }
                                }
                            }

                        }
                    }


                }
            }
            catch
            {

            }
            return result;
        }
        //public IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true)
        //{
        //    var result = new List<Type>();
        //    try
        //    {
        //        foreach (var a in assemblies)
        //        {
        //            Type[] types = null;
        //            try
        //            {
        //                types = a.GetTypes();
        //            }
        //            catch
        //            {
        //                //Entity Framework 6 doesn't allow getting types (throws an exception)
        //                if (!true)
        //                {
        //                    throw;
        //                }
        //            }
        //            if (types != null)
        //            {
        //                foreach (var t in types)
        //                {
        //                    if (assignTypeFrom.IsAssignableFrom(t) || 
        //                        (assignTypeFrom.IsGenericTypeDefinition && DoesTypeImplementOpenGeneric(t, assignTypeFrom)))
        //                    {
        //                        if (!t.IsInterface)
        //                        {
        //                            if (onlyConcreteClasses)
        //                            {
        //                                if (t.IsClass && !t.IsAbstract)
        //                                {
        //                                    result.Add(t);
        //                                }
        //                            }
        //                            else
        //                            {
        //                                result.Add(t);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (ReflectionTypeLoadException ex)
        //    {
        //        var msg = string.Empty;
        //        foreach (var e in ex.LoaderExceptions)
        //            msg += e.Message + Environment.NewLine;

        //        var fail = new Exception(msg, ex);
        //        Debug.WriteLine(fail.Message, fail);

        //        throw fail;
        //    }
        //    return result;
        //}

        //
        protected virtual bool DoesTypeImplementOpenGeneric(Type type, Type openGeneric)
        {
            try
            {
                var genericTypeDefinition = openGeneric.GetGenericTypeDefinition();
                foreach (var implementedInterface in type.FindInterfaces((objType, objCriteria) => true, null))
                {
                    if (!implementedInterface.IsGenericType)
                        continue;

                    var isMatch = genericTypeDefinition.IsAssignableFrom(implementedInterface.GetGenericTypeDefinition());
                    return isMatch;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        //get bin directory
        //public virtual string GetBinDirectory()
        //{
        //    return System.AppContext.BaseDirectory;
        //}
        public virtual string GetBinDirectory()
        {
            return System.AppContext.BaseDirectory;
        }

        public virtual AppDomain App
        {
            get { return AppDomain.CurrentDomain; }
        }
        //public virtual AppDomain App
        //{
        //    get { return AppDomain.CurrentDomain; }
        //}
        //

        private bool _binFolderAssembliesLoaded;
        //public IList<Assembly> GetAssemblies()
        //{
        //    if (true && !_binFolderAssembliesLoaded)
        //    {
        //        _binFolderAssembliesLoaded = true;
        //        var binpath = GetBinDirectory();
        //        LoadMatchingAssemblies(binpath);
        //    }
        //    return GetAssembliesplus();

        //}
        public IList<Assembly> GetAssemblies()
        {
            if (true && !_binFolderAssembliesLoaded)
            {
                _binFolderAssembliesLoaded = true;
                var binpath = GetBinDirectory();
                LoadMatchingAssemblies(binpath);
            }
            return GetAssembliesPlus();

        }
        //public IList<Assembly> GetAssembliesplus()
        //{
        //    var AddasemblyNmae = new List<string>();
        //    var assembly = new List<Assembly>();
        //    if (true)
        //    {
        //        AddaseemblyAppDomain(AddasemblyNmae, assembly);
        //    }
        //    return assembly;
        //}
        public IList<Assembly> GetAssembliesPlus()
        {
            var addasseName = new List<string>();
            var assemebly = new List<Assembly>();
            if (true)
            {
                AddaseemblyAppDomain(addasseName, assemebly);
            }
            return assemebly;
        }
        protected virtual void LoadMatchingAssemblies(string directoryPath)
        {
            //var v = new ViewDataDictionary();
            var loadedAssemblyNames = new List<string>();
            foreach (var a in GetAssemblies())
            {
                loadedAssemblyNames.Add(a.FullName);
            }

            if (!Directory.Exists(directoryPath))
            {
                return;
            }

            foreach (var dllPath in Directory.GetFiles(directoryPath, "*.dll"))
            {
                try
                {
                    var an = AssemblyName.GetAssemblyName(dllPath);
                    if(Macthes(an.FullName) && !loadedAssemblyNames.Contains(an.FullName))
                    {
                        App.Load(an);
                    }

                    //old loading stuff
                    //Assembly a = Assembly.ReflectionOnlyLoadFrom(dllPath);
                    //if (Matches(a.FullName) && !loadedAssemblyNames.Contains(a.FullName))
                    //{
                    //    App.Load(a.FullName);
                    //}
                }
                catch (BadImageFormatException ex)
                {
                    Trace.TraceError(ex.ToString());
                }
            }
        }

        // add to configure assemeblies
        //public void AddConfiguredAssemblies(List<string> addasembly,List<Assembly> assemblies)
        //{
        //    foreach(var assemblyname)

        //}
        //public void AddaseemblyAppDomain(IList<string> aseemblyname,IList<Assembly> assemblies)
        //{
        //    foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        //    {
        //        if(Macthes(assembly.FullName))
        //        {

        //            if(!aseemblyname.Contains(assembly.FullName))
        //            {
        //                assemblies.Add(assembly);
        //                aseemblyname.Add(assembly.FullName);
        //            }
        //        }
                
        //    }
        //}
        public void AddaseemblyAppDomain(IList<string> aseeblyname, IList<Assembly> assemblies)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (Macthes(assembly.FullName))
                {
                    if (!aseeblyname.Contains(assembly.FullName))
                    {
                        assemblies.Add(assembly);
                        aseeblyname.Add(assembly.FullName);
                    }

                }
            }
        }
        
        string assemblySkipLoadingPattern = "^System|^mscorlib|^Microsoft|^AjaxControlToolkit|^Antlr3|^AutoMapper|^Castle|^ComponentArt|^CppCodeProvider|^DotNetOpenAuth|^EntityFramework|^EPPlus|^FluentValidation|^ImageResizer|^itextsharp|^log4net|^MaxMind|^MbUnit|^MiniProfiler|^Mono.Math|^MvcContrib|^Newtonsoft|^NHibernate|^nunit|^Org.Mentalis|^PerlRegex|^QuickGraph|^Recaptcha|^Remotion|^RestSharp|^Rhino|^Telerik|^Iesi|^TestDriven|^TestFu|^UserAgentStringLibrary|^VJSharpCodeProvider|^WebActivator|^WebDev|^WebGrease";
        string assemblyRestrictToLoadingPattern = ".*";
        // macth name of assemebly 

        public bool Macthes(string fullname)
        {
            bool val = Matches(fullname, assemblySkipLoadingPattern);
            bool val2 =Matches(fullname, assemblyRestrictToLoadingPattern);
            return !val && val2;

        }

        public bool Matches(string fullname,string pattern)
        {
            return Regex.IsMatch(fullname, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        public IEnumerable<Type> FindClassesoftype(Type assigntypeform, bool OnlyConcreateclass = true)
        {
            throw new NotImplementedException();
        }
    }
}
