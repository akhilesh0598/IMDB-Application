using Dapper;
using IMDB_API_Project.Test.MockResources;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace IMDB_API_Project.Test.StepFiles
{
    [Scope(Feature = "Movie Resource")]
    [Binding]
    class MovieStep : BaseStep
    {
        public MovieStep(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Mock Repository
                    services.AddScoped(_ => MovieMock.MovieRepositoryMock.Object);
                    services.AddScoped(_ => MovieMock.ReviewRepositoryMock.Object);
                    services.AddScoped(_ => MovieMock.ActorRepositoryMock.Object);
                    services.AddScoped(_ => MovieMock.GenreRepositoryMock.Object);
                    services.AddScoped(_ => MovieMock.ProducerRepositoryMock.Object);
                });
            }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            MovieMock.MockResources();
        }
    }
}