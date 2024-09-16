﻿using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workshop.wwwapi.Models;
using System.Text.Json;
using workshop.wwwapi.Models.TransferModels.Appointments;
using System.Net.Http.Json;
using System.Text.Json.Nodes;

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
            var response = await client.GetAsync("/appointments");
            var resAsString = await response.Content.ReadAsStringAsync();
            Payload<IEnumerable<AppointmentDTO>> deserialized = JsonSerializer.Deserialize<Payload<IEnumerable<AppointmentDTO>>>(resAsString);
            // It struggles to deserialize the Data part of the payload...

            // Assert
            // Payload
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.That(response?.RequestMessage?.Method.Method, Is.EqualTo("GET"));
            Assert.That(deserialized.status, Is.EqualTo("Success"));
            Assert.That(deserialized.creationTime, Is.EqualTo(DateTime.Now).Within(TimeSpan.FromMilliseconds(1000)));
            // Data
            Assert.IsTrue(resAsString.Contains("2010-03-05T00:00:00Z"));
            Assert.IsTrue(resAsString.Contains("2005-05-10T00:00:00Z"));
            Assert.IsTrue(resAsString.Contains("1995-05-10T00:00:00Z"));
            Assert.IsTrue(resAsString.Contains("\"doctor\":\"Jan Itor\""));
            Assert.IsTrue(resAsString.Contains("\"doctor\":\"Dr. Acula\""));
            Assert.IsTrue(resAsString.Contains("\"patient\":\"John Doe\""));
            Assert.IsTrue(resAsString.Contains("\"patient\":\"Jimmy Bob\""));
        }

        [Test]
        [TestCase(1, 1, "2010-03-05T00:00:00Z", "Jan Itor", "Jimmy Bob")]
        [TestCase(1, 5, "2005-05-10T00:00:00Z", "Jan Itor", "John Doe")]
        [TestCase(3, 5, "1995-05-10T00:00:00Z", "Dr. Acula", "John Doe")]
        public async Task SpecificAppointmentByIds(int doctorId, int patientId, string bookingTime, string doctorName, string patientName)
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/appointments/{doctorId}-{patientId}");
            var resAsString = await response.Content.ReadAsStringAsync();
            Payload<AppointmentDTO> deserialized = JsonSerializer.Deserialize<Payload<AppointmentDTO>>(resAsString);


            // Assert
            // Payload
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.That(response?.RequestMessage?.Method.Method, Is.EqualTo("GET"));
            Assert.That(deserialized.status, Is.EqualTo("Success"));
            Assert.That(deserialized.creationTime, Is.EqualTo(DateTime.Now).Within(TimeSpan.FromMilliseconds(1000)));
            // Data
            Assert.IsTrue(resAsString.Contains(bookingTime));
            Assert.IsTrue(resAsString.Contains($"\"doctor\":\"{doctorName}\""));
            Assert.IsTrue(resAsString.Contains($"\"patient\":\"{patientName}\""));
        }

        [Test]
        [TestCase(1, "Jan Itor", "Jimmy Bob")]
        [TestCase(1, "Jan Itor", "John Doe")]
        [TestCase(3, "Dr. Acula", "John Doe")]
        public async Task AppointmentsByDoctorId(int doctorId, string doctorName, string patientName)
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/appointments/doctors/{doctorId}");
            var resAsString = await response.Content.ReadAsStringAsync();
            Payload<AppointmentDTO> deserialized = JsonSerializer.Deserialize<Payload<AppointmentDTO>>(resAsString);


            // Assert
            // Payload
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.That(response?.RequestMessage?.Method.Method, Is.EqualTo("GET"));
            Assert.That(deserialized.status, Is.EqualTo("Success"));
            Assert.That(deserialized.creationTime, Is.EqualTo(DateTime.Now).Within(TimeSpan.FromMilliseconds(1000)));
            // Data
            Assert.IsTrue(resAsString.Contains($"\"doctor\":\"{doctorName}\""));
            Assert.IsTrue(resAsString.Contains($"\"patient\":\"{patientName}\""));
        }

        [Test]
        [TestCase(1, "Jan Itor", "Jimmy Bob")]
        [TestCase(5, "Jan Itor", "John Doe")]
        [TestCase(5, "Dr. Acula", "John Doe")]
        public async Task AppointmentsByPatientId(int patientId, string doctorName, string patientName)
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/appointments/patients/{patientId}");
            var resAsString = await response.Content.ReadAsStringAsync();
            Payload<AppointmentDTO> deserialized = JsonSerializer.Deserialize<Payload<AppointmentDTO>>(resAsString);

            // Assert
            // Payload
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.That(response?.RequestMessage?.Method.Method, Is.EqualTo("GET"));
            Assert.That(deserialized.status, Is.EqualTo("Success"));
            Assert.That(deserialized.creationTime, Is.EqualTo(DateTime.Now).Within(TimeSpan.FromMilliseconds(1000)));
            // Data
            Assert.IsTrue(resAsString.Contains($"\"doctor\":\"{doctorName}\""));
            Assert.IsTrue(resAsString.Contains($"\"patient\":\"{patientName}\""));
        }

        [Test]
        [TestCase(1, "Jan Itor", "Jimmy Bob")]
        [TestCase(2, "Jan Itor", "Jimmy Bob")]
        [TestCase(3, "Jan Itor", "John Doe")]
        [TestCase(4, "Jan Itor", "John Doe")]
        [TestCase(5, "Jan Itor", "John Doe")]
        [TestCase(6, "Dr. Acula", "John Doe")]
        public async Task AppointmentsByAppointmentId(int appointmentId, string doctorName, string patientName)
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/appointments/{appointmentId}");
            var resAsString = await response.Content.ReadAsStringAsync();
            Payload<AppointmentDTO> deserialized = JsonSerializer.Deserialize<Payload<AppointmentDTO>>(resAsString);

            // Assert
            // Payload
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.That(response?.RequestMessage?.Method.Method, Is.EqualTo("GET"));
            Assert.That(deserialized.status, Is.EqualTo("Success"));
            Assert.That(deserialized.creationTime, Is.EqualTo(DateTime.Now).Within(TimeSpan.FromMilliseconds(1000)));
            // Data
            Assert.IsTrue(resAsString.Contains($"\"doctor\":\"{doctorName}\""));
            Assert.IsTrue(resAsString.Contains($"\"patient\":\"{patientName}\""));
        }

    }
}
