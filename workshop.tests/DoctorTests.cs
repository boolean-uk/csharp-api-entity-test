using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace workshop.tests;

public partial class Tests
{

    public class Doctor
    {

        [Test]
        public async Task GetAll_DoctorEndpointStatus()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("doctors");

            // Assert
            Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
        }
        [TestCase(1, HttpStatusCode.OK)]
        [TestCase(321, HttpStatusCode.NotFound)]
        public async Task Get_DoctorEndpointStatus(int doctorId, HttpStatusCode expected)
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync($"doctors/{doctorId}");
            

            // Assert
            Assert.That(response.StatusCode == expected);
        }
    }

}