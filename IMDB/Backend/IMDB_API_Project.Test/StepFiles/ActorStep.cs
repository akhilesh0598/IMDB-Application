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
    [Scope(Feature = "Actor Resource")]
    [Binding]
    class ActorStep : BaseStep
    {
        public ActorStep(CustomWebApplicationFactory factory) : base(factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                // Mock Repository
                services.AddScoped(_ => ActorMock.ActorRepositoryMock.Object);
            });
        }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            ActorMock.MockResouces();
        }
    }
}