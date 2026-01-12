using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using workshop.wwwapi.DTOs;

namespace workshop.tests
{
    public class DoctorTests
    {

        [Test] // Test that endpoint for getting doctors works correctly and contains seeded doctors
        public async Task GetDoctors()
        {
            // Arrange: prepare request data
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();
            
            // Act: make an API call using the shared _client instance
            var response = await client.GetAsync("/doctors"); // send a GET request to the /doctors endpoint to get all doctors
            
            // Assert: check the response
            Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
            var contentStream = await response.Content.ReadAsStreamAsync(); // read the response content as a stream 
            var doctors = await JsonSerializer.DeserializeAsync<List<DoctorWithAppointmentsDto>>(
                contentStream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
            Assert.That(doctors, Is.Not.Null); // check that the doctors list is not null
            Assert.That(doctors.Count > 0); // check that the doctors list contains at least one doctor
            Assert.That(doctors.Any(d => d.FullName == "Dr. Arsene Wenger")); // check that on of the seeded doctor is in the list
        }

        [Test] // Test that endpoint for getting a doctor by ID returns the correct doctor
        public async Task GetDoctorById()
        {
            // Arrange: prepare request data
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();
            
            // Act: make an API call using the shared _client instance
            var response = await client.GetAsync("/doctors/1");
            
            // Assert: check the response
            Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
            var contentStream = await response.Content.ReadAsStreamAsync();
            var doctor = await JsonSerializer.DeserializeAsync<DoctorWithAppointmentsDto>(
                contentStream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
            
            Assert.That(doctor, Is.Not.Null);
            Assert.That(doctor.FullName, Is.EqualTo("Dr. Arsene Wenger"));
        }

        [Test] // Test that endpoint for adding a doctor works correctly
        public async Task AddDoctor()
        {
            // Arrange: prepare request data
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();
            var newDoctor = new PersonPostDto { FullName = "Dr. Jose Morinho" };
            var content = new StringContent(JsonSerializer.Serialize(newDoctor), Encoding.UTF8, "application/json");
            
            // Act: make an API call using the shared _client instance
            var response = await client.PostAsync("/doctors", content);
            
            // Assert: check the response
            Assert.That(response.StatusCode == System.Net.HttpStatusCode.Created);
            var contentStream = await response.Content.ReadAsStreamAsync();
            var addedDoctor = await JsonSerializer.DeserializeAsync<DoctorWithAppointmentsDto>(
                contentStream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
            
            Assert.That(addedDoctor, Is.Not.Null);
            Assert.That(addedDoctor.FullName, Is.EqualTo("Dr. Jose Morinho"));
        }
    }
}
