using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using workshop.wwwapi.Models.DTOs;

namespace workshop.tests
{
    public class DoctorTest
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
        public async Task GetAllDoctors()
        {

            // Act
            var response = await _httpClient.GetFromJsonAsync<List<DoctorDTO>>("/Doctors");

            // Assert
            Assert.That(response[0].DoctorId, Is.EqualTo(1));
            Assert.That(response[0].Appointments.Count(), Is.EqualTo(1));
            Assert.That(response[0].Appointments.First().PatientId, Is.EqualTo(1));
            Assert.That(response[0].DoctorName, Is.EqualTo("Doctor Who"));
        }

        [Test]
        public async Task GetDoctorById()
        {

            // Act
            var response = await _httpClient.GetFromJsonAsync<DoctorDTO>("/Doctors/1");

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.DoctorId, Is.EqualTo(1));
            Assert.That(response.Appointments.Count(), Is.EqualTo(1));
            Assert.That(response.Appointments.First().PatientId, Is.EqualTo(1));
            Assert.That(response.DoctorName, Is.EqualTo("Doctor Who"));
        }

        [Test]
        public async Task CreateDoctor()
        {

            // Act
            var before = await _httpClient.GetFromJsonAsync<List<DoctorDTO>>("/Doctors");
            var bC = before!.Count;
            var response = await _httpClient.PostAsJsonAsync<CreateDoctorDTO>("/Doctors", new() { DoctorId = bC + 1, DoctorName = $"Dr How {bC + 1}" });
            var value = await response.Content.ReadFromJsonAsync<DoctorDTO>();
            var after = await _httpClient.GetFromJsonAsync<List<DoctorDTO>>("/Doctors");
            var aC = after!.Count;

            // Assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.That(value, Is.Not.Null);
            Assert.That(value.DoctorId, Is.EqualTo(bC + 1));
            Assert.That(value.DoctorName, Is.EqualTo($"Dr How {bC + 1}"));
            Assert.That(value.Appointments.Count(), Is.EqualTo(0));
            Assert.That(aC, Is.EqualTo(bC + 1));
        }
    }
}
