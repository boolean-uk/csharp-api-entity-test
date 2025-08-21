using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using workshop.wwwapi.DTOs.Doctor;
using workshop.wwwapi.DTOs.Patient;

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
            var response = await client.GetAsync("surgery/doctors");
            var content = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<List<DoctorDTO>>(content);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

            // Doctor 1
            Assert.That(json[0].Id, Is.EqualTo(1));
            Assert.That(json[0].FullName, Is.EqualTo("Dr. John Smith"));

            // Doctor 2
            Assert.That(json[1].Id, Is.EqualTo(2));
            Assert.That(json[1].FullName, Is.EqualTo("Dr. Jane Doe"));
        }

        [Test]
        public async Task DoctorByIdEndpointStatus()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("surgery/doctors/1");
            var content = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<DoctorDTO>(content);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

            Assert.That(json.Id, Is.EqualTo(1));
            Assert.That(json.FullName, Is.EqualTo("Dr. John Smith"));
        }

        [Test]
        public async Task AddDoctorEndpointStatus()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.PostAsJsonAsync("surgery/doctors/{id}", new DoctorDTO
            {
                FullName = "Someone Cooler"
            });

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
        }
    }
}
