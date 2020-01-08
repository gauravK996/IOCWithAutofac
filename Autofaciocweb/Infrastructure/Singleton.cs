using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autofaciocweb.Infrastructure
{
    public class Singleton
    {
        static Singleton()
        {

        }
        //public Singleton Instanace { get { return new Singleton(); } }
    }

    //public class Singleton<T> : Singleton
    //{
    //     static T instance;
    //    public static T Instance
    //    {
    //        get { return instance; }
    //        set {
    //               instance = value;
    //             }
    //    }
    //}
    //ddd
    public class Singleton<T>
    {
        static T instance;
        public static T Instance
        {
            get { return instance; }
            set { instance = value; }
        }
    }
}
