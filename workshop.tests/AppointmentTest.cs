using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using workshop.wwwapi.Models.DTOs;

namespace workshop.tests
{
    public class AppointmentTest
    {
        private HttpClient _httpClient;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            _httpClient = factory.CreateClient();
        }

        [Test]
        public async Task GetAllAppointments()
        {

            // Act
            var response = await _httpClient.GetFromJsonAsync<List<AppointmentDTO>>("/appointments");

            // Assert
            Assert.That(response[0].DoctorId, Is.EqualTo(1));
            Assert.That(response[0].DoctorName, Is.EqualTo("Doctor Who"));
            Assert.That(response[0].PatientId, Is.EqualTo(1));
            Assert.That(response[0].PatientName, Is.EqualTo("Java Script"));
            Assert.That(response[0].BookingTime, Is.LessThan(DateTime.UtcNow));
        }

        [Test]
        public async Task GetAppointmentsByDoctorId()
        {

            // Act
            var response = await _httpClient.GetFromJsonAsync<List<DoctorAppointmentDTO>>("/appointments/doctor/1");

            // Assert
            Assert.That(response[0].PatientId, Is.EqualTo(1));
            Assert.That(response[0].PatientName, Is.EqualTo("Java Script"));
            Assert.That(response[0].BookingTime, Is.LessThan(DateTime.UtcNow));
        }

        [Test]
        public async Task GetAppointmentsByPatientId()
        {

            // Act
            var response = await _httpClient.GetFromJsonAsync<List<PatientAppointmentDTO>>("/appointments/patient/1");

            // Assert
            Assert.That(response[0].DoctorId, Is.EqualTo(1));
            Assert.That(response[0].DoctorName, Is.EqualTo("Doctor Who"));
            Assert.That(response[0].BookingTime, Is.LessThan(DateTime.UtcNow));
        }

        [Test]
        public async Task GetAppointmentByIds()
        {

            // Act
            var response = await _httpClient.GetFromJsonAsync<AppointmentDTO>("/appointments/1/1");

            // Assert
            Assert.That(response.DoctorId, Is.EqualTo(1));
            Assert.That(response.DoctorName, Is.EqualTo("Doctor Who"));
            Assert.That(response.PatientId, Is.EqualTo(1));
            Assert.That(response.PatientName, Is.EqualTo("Java Script"));
            Assert.That(response.BookingTime, Is.LessThan(DateTime.UtcNow));
        }
    }
}
