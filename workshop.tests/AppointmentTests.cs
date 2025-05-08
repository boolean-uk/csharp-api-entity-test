using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace workshop.tests
{
    public class AppointmentTests
    {
        [Test]
        public async Task AppointmentEndpointStatus()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("http://localhost:5045/surgery/appointments");

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

            // Act
            response = await client.GetAsync("http://localhost:5045/surgery/appointments/{id}?patientId=1&doctorId=1");

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

            // Act
            response = await client.GetAsync("http://localhost:5045/surgery/appointments/patient/1");

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}
