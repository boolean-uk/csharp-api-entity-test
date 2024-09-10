using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop.tests
{
    public partial class Tests
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
            Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);


            // Act
            var response1 = await client.GetAsync("appointments?doctorId=2&patientId=2&dateTime=2024-11-16T00%3A00%3A00.000Z");

            // Assert
            Assert.IsTrue(response1.StatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}
