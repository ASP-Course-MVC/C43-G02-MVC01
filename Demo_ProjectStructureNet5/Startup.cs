using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Demo_ProjectStructureNet5
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            ////Inside This function we add services which we need in the project to the Dependency injection Container.
            ////This Container is in "Kestrel" Console App for services use the Dependency injection.
            ////So any service you need to make it work with DI Approach, put it inside this function "ConfigureServices()"
            ////services.AddMvc();//Add Controllers - Views - Razor Pages - API [Work in App with MVC & RazorPages & API]
            //services.AddMvcCore();//Add Controllers [Add Minimal essential MVC services ]
            //services.AddRazorPages ();//Add Views - RazorPages [Work in App with "RazorPages" only ]
            //services.AddControllers();//Support API Controllers [Work in App with "API" only ]
            services.AddControllersWithViews();//Add MVC Controllers [Work in App with "MVC" only] but support API Controllers
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Configure the middlewares that will applied on the HTTP request.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();//Middleware for errors
            }

            app.UseRouting();//Middleware for routing [Tell the request the way that it will pass through based on the routing table [EndPoints table]]

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });//Middleware for Endpoint route mapping.
        }
    }
}
