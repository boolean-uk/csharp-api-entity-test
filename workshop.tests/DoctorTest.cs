using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;

namespace workshop.tests
{
    public class DoctorTest
    {
        [Test]
        public async Task DoctorEndpointStatus()
        {
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            var response = await client.GetAsync("/surgery/doctors");
            var responseContent = await response.Content.ReadAsStringAsync();
 
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(responseContent.Contains("Britney Pears"));
        }
    }
}
