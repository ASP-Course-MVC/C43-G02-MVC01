using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Demo_ProjectStructureNet5
{

    ///.NET 5.0 version - There are program file and startup file.
    ///public class Program
    ///{
    ///    //Entry Point
    ///    public static void Main(string[] args)
    ///    {
    ///        CreateHostBuilder(args).Build().Run();
    ///    }
    ///
    ///    public static IHostBuilder CreateHostBuilder(string[] args) =>//This Function Build/Create The Host "Kestrel"
    ///        Host.CreateDefaultBuilder(args)
    ///            .ConfigureWebHostDefaults(webBuilder =>
    ///            {
    ///                webBuilder.UseStartup<Startup>();//CreateHostBuilder() take Configuration of this host "Kestrel" from this class "Startup".
    ///            });
    ///}

    //Upgrade to.NET 9.0 - There is only program file which contain code of startup file.
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Create HostBuilder "Kestrel" -> var WebApplicationBuilder = WebApplication.CreateBuilder();
            //2. Configure Services of the Host "Kestrel" -> WebApplicationBuilder.Services.AddControllersWithViews();
            //3. Build This HostBuilder to return the "Kestrel" to configure it's pipeline -> var app = WebApplicationBuilder.Build();
            //4. Configure The WebApp "Kestrel" Environment and Request Pipeline.
            //5. Run the WebApp -> app.Run()

            var WebApplicationBuilder = WebApplication.CreateBuilder();//Instead of function "CreateHostBuilder()"

            #region Configure Services

            WebApplicationBuilder.Services/*DI Container*/.AddControllersWithViews();

            #endregion

            var app = WebApplicationBuilder.Build();//Build the WebApplicationBuilder.

            #region Configure HTTP Request Pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

            #endregion

            app.Run();

        }

    }
}
