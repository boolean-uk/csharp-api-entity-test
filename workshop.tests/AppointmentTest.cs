using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workshop.wwwapi.Models;

namespace workshop.tests
{
    public class AppointmentTest
    {
        [Test]
        public async Task AppointmentEndpointStatus()
        {
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            var response = await client.GetAsync("/surgery/appointments");
            var responseContent = await response.Content.ReadAsStringAsync();

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(responseContent.Contains("id"));
            
        }
    }
}
