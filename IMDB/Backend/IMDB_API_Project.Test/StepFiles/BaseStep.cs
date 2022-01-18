using IMDB_API_Project.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace IMDB_API_Project.Test.StepFiles
{
    class BaseStep
    {
        protected WebApplicationFactory<TestStartup> Factory;
        protected HttpClient Client { get; set; }
        protected HttpResponseMessage Response { get; set; }

        public BaseStep(WebApplicationFactory<TestStartup> baseFactory)
        {
            Factory = baseFactory;
        }

        [Given(@"I am a client")]
        public void ImClient()
        {
            Client = Factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri($"http://localhost/")
            });
        }

        [Then(@"Response code must be '(.*)'")]
        public void ThenResponseCodeMustBe(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Assert.Equal(expectedStatusCode, Response.StatusCode);
        }

        [Then(@"Response data must look like '(.*)'")]
        public void CompareResponse(string p0)
        {
            var responseData = Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Assert.Equal(p0, responseData);
        }

        [When(@"I make GET Request '(.*)'")]
        public virtual async Task MakeGet(string resourceEndpoint)
        {
            var uri = new Uri(resourceEndpoint, UriKind.Relative);
            Response = await Client.GetAsync(uri);
        }

        [When(@"I make PUT Request '(.*)' with the following Data '(.*)'")]
        public void MakePut(string resourceEndPoint, string putDataJson)
        {
            var postRelativeUri = new Uri(resourceEndPoint, UriKind.Relative);
            var content = new StringContent(putDataJson, Encoding.UTF8, "application/json");
            Response = Client.PutAsync(postRelativeUri, content).GetAwaiter().GetResult();
        }

        [When(@"I make POST Request to '(.*)' with the following Data '(.*)'")]
        public void MakePost(string resourceEndPoint, string postDataJson)
        {
            var postRelativeUri = new Uri(resourceEndPoint, UriKind.Relative);
            var content = new StringContent(postDataJson, Encoding.UTF8, "application/json");
            Response = Client.PostAsync(postRelativeUri, content).GetAwaiter().GetResult();
        }

        [When(@"I make DELETE Request '(.*)'")]
        public void MakeDelete(string resourceEndPoint)
        {
            var postRelativeUri = new Uri(resourceEndPoint, UriKind.Relative);
            Response = Client.DeleteAsync(postRelativeUri).GetAwaiter().GetResult();
        }
    }
}