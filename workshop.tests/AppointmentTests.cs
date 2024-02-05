using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace workshop.tests;

public class AppointmentTests
{
    
        [Test]
        public async Task AppointmentEndpointStatus()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();
    
            // Act
            var response = await client.GetAsync("/surgery/appointments");
    
            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }
    
        [Test]
        public async Task GetAppointmentByPatientId()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();
    
            // Act
            var response = await client.GetAsync("/surgery/appointments/patient/1");
    
            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }
    
        [Test]
        public async Task CreateAppointmentBadRequest()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();
    
            // Act
            var response = await client.PostAsJsonAsync("/surgery/appointments", new { FullName = "" });
    
            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }

        [Test]
        public async Task GetAppointmentByDoctorId()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();
    
            // Act
            var response = await client.GetAsync("/surgery/appointments/doctor/1");
    
            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }
}