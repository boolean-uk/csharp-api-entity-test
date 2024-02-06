using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workshop.wwwapi.Models;
using System.Text.Json;
using workshop.wwwapi.Models.TransferModels.People;

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
            var response = await client.GetAsync("/doctors");
            var resAsString = await response.Content.ReadAsStringAsync();
            Payload<IEnumerable<PatientDTO>> deserialized = JsonSerializer.Deserialize<Payload<IEnumerable<PatientDTO>>>(resAsString);

            // Assert
            // Payload
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.That(response?.RequestMessage?.Method.Method, Is.EqualTo("GET"));
            Assert.That(deserialized.status, Is.EqualTo("Success"));
            Assert.That(deserialized.creationTime, Is.EqualTo(DateTime.Now).Within(TimeSpan.FromMilliseconds(100)));
            // Data
            Assert.IsTrue(resAsString.Contains("Jan Itor"));
            Assert.IsTrue(resAsString.Contains("Dr. Acula"));
        }

        [Test]
        [TestCase(1, "Jan Itor")]
        [TestCase(3, "Dr. Acula")]
        public async Task RetrieveSpecificDoctorById(int id, string expectedName)
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/doctors/{id}");
            var resAsString = await response.Content.ReadAsStringAsync();
            Payload<PatientDTO> deserialized = JsonSerializer.Deserialize<Payload<PatientDTO>>(resAsString);


            // Assert
            // Payload
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.That(response?.RequestMessage?.Method.Method, Is.EqualTo("GET"));
            Assert.That(deserialized.status, Is.EqualTo("Success"));
            Assert.That(deserialized.creationTime, Is.EqualTo(DateTime.Now).Within(TimeSpan.FromMilliseconds(100)));
            // Data
            Assert.IsTrue(resAsString.Contains(expectedName));
        }
    }
}
