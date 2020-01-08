using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Autofaciocweb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //BuildWebHost(args).Run();
            //var host = WebHost.CreateDefaultBuilder(args)
            //    .UseKestrel(options => options.AddServerHeader = false)
            //    .UseStartup<Startup>()
            //    .Build();
            //host.Run();
            webHost(args).Run();

        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseKestrel(options=>options.AddServerHeader=false)
                .UseStartup<Startup>()
                .Build();
        public static IWebHost webHost(string[] args)
        {
            var host = WebHost.CreateDefaultBuilder(args)
                 .UseKestrel(options => options.AddServerHeader = false)
                 .UseStartup<Startup>();

            return host.Build();
        }

    }
}
