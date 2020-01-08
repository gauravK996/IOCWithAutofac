using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autofaciocweb.Infrastructure
{
    public class EngineContext
    {

        //public static IMainEngine EngineCreate()
        //{
        //    if(Singleton<IMainEngine>.Instance == null)
        //    {
        //        Singleton<IMainEngine>.Instance = new MainEngine();
        //    }
        //    return Singleton<IMainEngine>.Instance; 

        //}
        public static IMainEngine EngineCreate()
        {
            //if()
            if(Singleton<IMainEngine>.Instance==null)
            {
                Singleton<IMainEngine>.Instance = new MainEngine();
            }
            return Singleton<IMainEngine>.Instance;
        }
    }
}
