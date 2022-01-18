using IMDB_API_Project;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace IMDB_API_Project.Test
{
    public class CustomWebApplicationFactory : WebApplicationFactory<TestStartup>
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            var createDefaultBuilder = Host.CreateDefaultBuilder();
            var configureWebHostDefaults= createDefaultBuilder.ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseEnvironment("Testing")
                    .UseSetting("https_port", "443")
                    .UseStartup<TestStartup>();
            });
            return configureWebHostDefaults;
        }
    }
}