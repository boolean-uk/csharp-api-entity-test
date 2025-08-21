using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using workshop.wwwapi.DTOs.Doctor;
using workshop.wwwapi.Models;

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
            var response = await client.GetAsync("surgery/appointments");
            var content = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<List<Appointment>>(content);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

            // Appointment 1
            Assert.That(json[0].Id, Is.EqualTo(1));
            Assert.That(json[0].AppointmentDate, Is.EqualTo(DateTime.SpecifyKind(new DateTime(2025, 10, 1, 10, 0, 0), DateTimeKind.Utc)));
            Assert.That(json[0].Doctor.Id, Is.EqualTo(1));
            Assert.That(json[0].Patient.Id, Is.EqualTo(1));

            // Appointment 2
            Assert.That(json[1].Id, Is.EqualTo(2));
            Assert.That(json[1].AppointmentDate, Is.EqualTo(DateTime.SpecifyKind(new DateTime(2025, 10, 2, 11, 0, 0), DateTimeKind.Utc)));
            Assert.That(json[1].Doctor.Id, Is.EqualTo(1));
            Assert.That(json[1].Patient.Id, Is.EqualTo(1));

            // Appointment 3
            Assert.That(json[2].Id, Is.EqualTo(3));
            Assert.That(json[2].AppointmentDate, Is.EqualTo(DateTime.SpecifyKind(new DateTime(2025, 10, 1, 10, 0, 0), DateTimeKind.Utc)));
            Assert.That(json[2].Doctor.Id, Is.EqualTo(2));
            Assert.That(json[2].Patient.Id, Is.EqualTo(2));

            // Appointment 4
            Assert.That(json[3].Id, Is.EqualTo(4));
            Assert.That(json[3].AppointmentDate, Is.EqualTo(DateTime.SpecifyKind(new DateTime(2025, 10, 3, 12, 0, 0), DateTimeKind.Utc)));
            Assert.That(json[3].Doctor.Id, Is.EqualTo(2));
            Assert.That(json[3].Patient.Id, Is.EqualTo(1));
        }

        [Test]
        public async Task AppointmentByIdEndpointStatus()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("surgery/appointments/1");
            var content = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<Appointment>(content);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

            Assert.That(json.Id, Is.EqualTo(1));
            Assert.That(json.AppointmentDate, Is.EqualTo(DateTime.SpecifyKind(new DateTime(2025, 10, 1, 10, 0, 0), DateTimeKind.Utc)));
            Assert.That(json.Doctor.Id, Is.EqualTo(1));
            Assert.That(json.Patient.Id, Is.EqualTo(1));
        }

        [Test]
        public async Task AddAppointmentEndpointStatus()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.PostAsJsonAsync("surgery/appointments/{id}", new Appointment
            {
                AppointmentDate = DateTime.SpecifyKind(new DateTime(2025, 10, 10, 09, 0, 0), DateTimeKind.Utc),
                DoctorId = 1,
                PatientId = 1
            });

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
        }
    }
}
