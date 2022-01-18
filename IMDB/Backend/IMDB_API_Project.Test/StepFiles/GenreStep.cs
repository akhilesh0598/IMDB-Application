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
    [Scope(Feature = "Genre Resource")]
    [Binding]
    class GenreStep : BaseStep
    {
        public GenreStep(CustomWebApplicationFactory factory) : base(factory.WithWebHostBuilder(builder =>
         {
             builder.ConfigureServices(services =>
             {
                 // Mock Repository
                 services.AddScoped(_ => GenreMock.GenreRepositoryMock.Object);
             });
         }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            GenreMock.MockResources();
        }
    }
}