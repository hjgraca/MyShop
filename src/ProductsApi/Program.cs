using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore;

namespace ProductsApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        // public static void Main(string[] args)
        // {
        //     var config = new ConfigurationBuilder()
        //         .AddCommandLine(args)
        //         .AddEnvironmentVariables(prefix: "ASPNETCORE_")
        //         .AddEnvironmentVariables(prefix: "SHOP_")
        //         .Build();
            
        //     var host = new WebHostBuilder()
        //         .UseConfiguration(config)
        //         .UseKestrel()
        //         .UseContentRoot(Directory.GetCurrentDirectory())
        //         .UseIISIntegration()
        //         .UseStartup<Startup>()
        //         .Build();

        //     host.Run();
        // }
    }
}
