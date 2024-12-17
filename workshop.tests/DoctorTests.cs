using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workshop.wwwapi.Dtoes.ViewModels;

namespace workshop.tests
{
    public class DoctorTests
    {
        [Test]
        public async Task DoctorsEndpointStatus()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("surgery/doctors");

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task DoctorsPostStatusCreated()
        {
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();
            DoctorPostModel input = new DoctorPostModel();
            input.Fullname = "Tester Testenson";
            var json = new StringContent(JsonConvert.SerializeObject(input), UTF8Encoding.UTF8, "application/json");

            var response = await client.PostAsync("surgery/doctors", json);

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
        }

        [Test]
        public async Task DoctorGetStatusOk()
        {
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();
            int id = 1;

            var response = await client.GetAsync($"surgery/doctors/{id}");

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task DoctorGetStatusNotFound()
        {
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();
            int id = 0;

            var response = await client.GetAsync($"surgery/doctors/{id}");

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NotFound);
        }
    }
}
