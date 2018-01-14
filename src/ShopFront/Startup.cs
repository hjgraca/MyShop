using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ShopFront
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            Console.WriteLine($"SHOP_PRODUCTS_API_URL = {Configuration["SHOP_PRODUCTS_API_URL"]}");
            Console.WriteLine($"SHOP_RECOMMANDATIONS_API_URL = {Configuration["SHOP_RECOMMANDATIONS_API_URL"]}");
            Console.WriteLine($"SHOP_RATINGS_API_URL = {Configuration["SHOP_RATINGS_API_URL"]}");
        }

       public static IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            // settings
            services.Configure<ShopFront.Models.Settings>(settings => 
            {
                settings.ProductsApiUrl = Configuration["SHOP_PRODUCTS_API_URL"];
                settings.RecommendationsApiUrl = Configuration["SHOP_RECOMMANDATIONS_API_URL"];
                settings.RatingsApiUrl = Configuration["SHOP_RATINGS_API_URL"];
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
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
