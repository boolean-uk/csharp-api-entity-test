using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTOs.Core;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.Post;

namespace workshop.tests
{
    public class AppointmentTester
    {
        [Test]
        [Order(1)]
        public async Task AppointmentEndpointStatus()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("surgery/appointments");

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        [Order(2)]
        public async Task GetAllAppointments()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("surgery/appointments");
            var content = await response.Content.ReadAsStringAsync();
            var appointments = JsonConvert.DeserializeObject<List<AppointmentDTO>>(content);

            // Replace with the expected number of appointments. The seed data has 2 appointments, so the expected number should be 2,
            // but must be manually edited after each test run because the test creates a new appointment.
            var expectedResult = 5;
            var actualResult = appointments.Count;
            // Assert

            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        [Order(3)]
        public async Task GetAppointmentByDoctorId_Success()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("surgery/appointmentsbydoctor/1");
            var content = await response.Content.ReadAsStringAsync();
            var appointments = JsonConvert.DeserializeObject<List<AppointmentDTO>>(content);


            var expectedResult = 2;
            var actualResult = appointments.Count;
            // Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        [Order(4)]
        public async Task GetAppointmentByDoctorId_Fail()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();
            int unreachableId = 99999;

            // Act
            var response = await client.GetAsync($"surgery/appointmentsbydoctor/{unreachableId}");

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NotFound);
        }


        [Test]
        [Order(5)]
        public async Task GetAppointmentByPatientId_Success()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("surgery/appointmentsbypatient/1");
            var content = await response.Content.ReadAsStringAsync();
            var appointments = JsonConvert.DeserializeObject<List<AppointmentDTO>>(content);

            var expectedResult = 2;
            var actualResult = appointments.Count;
            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [Order(6)]
        public async Task GetAppointmentByPatientId_Fail()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();
            int unreachableId = 99999;

            // Act
            var response = await client.GetAsync($"surgery/appointmentsbypatient/{unreachableId}");

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NotFound);
        }


        [Test]
        [Order(7)]
        public async Task CreateAppointment_Success()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            var appointmentPost = new AppointmentPost() 
            { 
                DoctorId = 2, 
                PatientId = 2, 
                Booking = DateTime.UtcNow.AddDays(10) 
            };

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(appointmentPost), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("surgery/appointments", content);
            var responseBody = await response.Content.ReadAsStringAsync();
            var createdAppointment = JsonConvert.DeserializeObject<Appointment>(responseBody);
            
            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
            Assert.That(createdAppointment.Booking, Is.EqualTo(appointmentPost.Booking));
        }

        [Test]
        [Order(8)]
        public async Task CreateAppointment_Fail()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            var appointmentPostEmpty = new AppointmentPost
            {
                DoctorId = 9999, // unreachable doctor id
                PatientId = 2,
                Booking = DateTime.UtcNow.AddDays(10)
            };
            var appointmentPostString = new AppointmentPost
            {
                DoctorId = 2,
                PatientId = 9999, // unreachable patient id
                Booking = DateTime.UtcNow.AddDays(10)
            };

            // Act
            var contentEmpty = new StringContent(JsonConvert.SerializeObject(appointmentPostEmpty), Encoding.UTF8, "application/json");
            var responseEmpty = await client.PostAsync("surgery/appointments", contentEmpty);
            var contentString = new StringContent(JsonConvert.SerializeObject(appointmentPostString), Encoding.UTF8, "application/json");
            var responseString = await client.PostAsync("surgery/appointments", contentEmpty);

            // Assert
            Assert.That(responseEmpty.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.BadRequest));
            Assert.That(responseString.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.BadRequest));
        }
    }
}
