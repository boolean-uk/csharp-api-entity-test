using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace workshop.tests
{
    public class DoctorTests
    {
        [Test]
        public async Task DoctorEndpointStatus()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("http://localhost:5045/surgery/doctors");

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

            response = await client.GetAsync("http://localhost:5045/surgery/appointmentsbydoctor/1");

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

            response = await client.GetAsync("http://localhost:5045/surgery/doctors/1");

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}
