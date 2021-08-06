using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//llamamos entity framwork cre..
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
//lalamos nuestra libreria models
using CodeFirstProject.Models;

namespace CodeFirstProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();


            //configuramos primero nuestra cadena de conexion...
            var connectionString = @"Server=DESKTOP-198DM7M;Database=SchoolDatabase;Trusted_Connection=True";
            //luego realizamos la inversion de dependencia...y llamamos el servicio dbcontext..
            //llamamos el using a Models para utilizar nuestra clase de contexto..
            services.AddDbContext<MyDataContentClass>(options => options.UseSqlServer(connectionString));
            //this is the end of the project...
            //AFTER THIS OPEN COMMAND LINE PM PACKAGE MANAGER
            //tye the next instrucctions....
            /*
             Add-Migration NAMEOFMIGRATION
            Update-Database

            end of the codefirst project...
             */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
