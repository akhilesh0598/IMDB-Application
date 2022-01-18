using IMDB_API_Project.Test.MockResources;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace IMDB_API_Project.Test.StepFiles
{
    [Scope(Feature = "Producer Resource")]
    [Binding]
    class ProducerStep : BaseStep
    {
        public ProducerStep(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Mock Repository
                    services.AddScoped(_ => ProducerMock.ProducerRepositoryMock.Object);
                    services.AddScoped(_ => ProducerMock.MovieRepositoryMock.Object);
                    services.AddScoped(_ => ProducerMock.ReviewRepositoryMock.Object);
                });
            }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            ProducerMock.MockResources();
        }
    }
}