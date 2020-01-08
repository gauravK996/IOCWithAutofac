using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofaciocweb.Data;
using Autofaciocweb.Infrastructure;
using Autofaciocweb.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Autofaciocweb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IConfigurationRoot Configuration2 { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<SchoolDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("ssss")));
            try
            {
                services.AddDbContext<SchoolDbContext>(optionsAction => optionsAction.UseSqlServer(Configuration.GetConnectionString("Myconnection")));
            }
            catch(Exception ex)
            {

            }
                services.AddMvc();
            //var builder = new ContainerBuilder();
            //builder.RegisterType<Student>().As<IStudent>().SingleInstance();
            //builder.RegisterType<Course>().As<ICourse>();
            //builder.RegisterType<Game>().As<IGame>();
            //builder.Populate(services);
            //var container = builder.Build();
            //return container.Resolve<IServiceProvider>();
            //return new AutofacServiceProvider(container);
            //services.AddSingleton<IStudent, Student>();
            //services.AddTransient<ICourse, Course>();
            //services.AddTransient<IGame, Game>();
            return services.ConfigureAppService(Configuration2);

        }

        //This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //using (var get = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            //{
            //    var context=get.ServiceProvider.GetRequiredService<SchoolDbContext>();
            //    context.Database.Migrate();

            //}
                if (env.IsDevelopment())
                {
                    app.UseBrowserLink();
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
