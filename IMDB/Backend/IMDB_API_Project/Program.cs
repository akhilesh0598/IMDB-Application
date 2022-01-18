using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace IMDB_API_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var crateHostBuilder = CreateHostBuilder(args);
            var build = crateHostBuilder.Build();
            build.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var createDefaultBuilder = Host.CreateDefaultBuilder(args);
            var configureWebHostDefaults = createDefaultBuilder.ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                 });
            return configureWebHostDefaults;
        }
    }
}