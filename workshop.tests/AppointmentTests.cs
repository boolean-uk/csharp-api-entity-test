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
    public class AppointmentTests
    {

        [Test] // Test that endpoint for getting appointments works correctly and contains seeded appointments
        public async Task GetAppointments()
        {
            // Arrange: prepare request data
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();
            
            // Act: make an API call using the shared _client instance
            var response = await client.GetAsync("/appointments"); // send a GET request to the /appointments endpoint to get all appointments
            
            // Assert: check the response
            Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
            var contentStream = await response.Content.ReadAsStreamAsync(); // read the response content as a stream 
            var appointments = await JsonSerializer.DeserializeAsync<List<AppointmentWithDetailsDto>>(
                contentStream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
            Assert.That(appointments, Is.Not.Null); // check that the appointments list is not null
            Assert.That(appointments.Count > 0); // check that the appointments list contains at least one appointment
            Assert.That(appointments.Any(a => a.PatientName == "Lionel Messi" && a.DoctorName == "Dr. Arsene Wenger")); // check that one of the seeded appointments is in the list
        }

        [Test] // Test that endpoint for getting an appointment by ID returns the correct appointment
        public async Task GetAppointmentById()
        {
            // Arrange: prepare request data
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();
            
            // Act: make an API call using the shared _client instance
            var response = await client.GetAsync("/appointments/1");
            
            // Assert: check the response
            Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
            var contentStream = await response.Content.ReadAsStreamAsync();
            var appointment = await JsonSerializer.DeserializeAsync<AppointmentWithDetailsDto>(
                contentStream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
            
            Assert.That(appointment, Is.Not.Null);
            Assert.That(appointment.PatientName, Is.EqualTo("Lionel Messi"));
            Assert.That(appointment.DoctorName, Is.EqualTo("Dr. Arsene Wenger"));
        }

        [Test] // Test that endpoint for creating an appointment works correctly
        public async Task AddAppointment()
        {
            // Arrange: prepare request data
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // create a new appointment object to be sent in the request body
            var newAppointment = new AppointmentPostDto
            {
                PatientId = 1, // Lionel Messi
                DoctorId = 2, // Dr. Alex Ferguson
                Booking = DateTime.UtcNow.AddDays(10) // booking for 5 days later
            };

            // convert the new appointment object to JSON and create a StringContent object to be sent in the request body
            var contentStream = new StringContent(
               JsonSerializer.Serialize(newAppointment),
               Encoding.UTF8,
               "application/json"
           );

            // Act: Send a POST request to the /appointments endpoint with the new appointment data
            var response = await client.PostAsync("/appointments", contentStream);

            // Assert: check the response
            Assert.That(response.StatusCode == System.Net.HttpStatusCode.Created);
            
            var createdAppointment = await JsonSerializer.DeserializeAsync<AppointmentWithDetailsDto>(
                await response.Content.ReadAsStreamAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
            
            Assert.That(createdAppointment, Is.Not.Null);
            Assert.That(createdAppointment.PatientName, Is.EqualTo("Lionel Messi"));
            Assert.That(createdAppointment.DoctorName, Is.EqualTo("Dr. Alex Ferguson"));
        }
    }
}
