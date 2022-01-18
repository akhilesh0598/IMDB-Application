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
    [Scope(Feature = "Review Resource")]
    [Binding]
    class ReviewStep : BaseStep
    {
        public ReviewStep(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Mock Repository and other Service
                    services.AddScoped(_ => ReviewMock.MovieRepositoryMock.Object);
                    services.AddScoped(_ => ReviewMock.ReviewRepositoryMock.Object);
                    services.AddScoped(_ => ReviewMock.ActorRepositoryMock.Object);
                    services.AddScoped(_ => ReviewMock.GenreRepositoryMock.Object);
                    services.AddScoped(_ => ReviewMock.ProducerRepositoryMock.Object);
                });
            }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            ReviewMock.MockResources();
        }
    }
}