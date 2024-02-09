using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;
using workshop.wwwapi.Models;

namespace workshop.tests
{
    public class Tests
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            _client = factory.CreateClient();
        }

        [Test]
        public async Task PatientEndpointStatus()
        {
            // Arrange
            var expectedData = new List<Patient>
            {
                new Patient { Id = 1, FullName = "Elias Soprani" },
                new Patient { Id = 2, FullName = "Olga Alm" },
                new Patient { Id = 3, FullName = "Oskar Damkilde" },
                new Patient { Id = 4, FullName = "Gabriel Letell" },
                new Patient { Id = 5, FullName = "Samuel Vacha" },
                new Patient { Id = 6, FullName = "Theodor Johansson" }
            };

            // Act
            var response = await _client.GetAsync("/patients");
            response.EnsureSuccessStatusCode(); // Throw if not a success code

            var responseData = await response.Content.ReadAsStringAsync();
            var actualData = JsonConvert.DeserializeObject<List<Patient>>(responseData);

            // Assert
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            CollectionAssert.AreEqual(expectedData, actualData);
        }
    }

    public class PatientEqualityComparer : IEqualityComparer<Patient>
    {
        public bool Equals(Patient x, Patient y)
        {
            return x.Id == y.Id && x.FullName == y.FullName;
        }

        public int GetHashCode(Patient obj)
        {
            return (obj.Id, obj.FullName).GetHashCode();
        }
    }
}
