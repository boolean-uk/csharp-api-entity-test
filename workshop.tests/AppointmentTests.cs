using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace workshop.tests;

public partial class Tests
{

    
    public class Appointments
    {
        [Test]
        public async Task GetAll_AppointmentEndpointStatus()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("appointments");

            // Assert
            Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [TestCase(1, 1, HttpStatusCode.OK)]
        [TestCase(1, 5, HttpStatusCode.NotFound)]
        public async Task Get_AppointmentEndpointStatus(int? doctorId, int? patientId, HttpStatusCode expected)
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync($"appointments?doctor_id={doctorId}&patient_id={patientId}");

            if (response.IsSuccessStatusCode)
            {
                var a = await response.Content.ReadAsStringAsync();
                var option = new JsonSerializerSettings { };

                var myObject = JsonConvert.DeserializeObject<wwwapi.DTO.Response.Appointment.Get>(a);

            }
            // Assert
            Assert.That(response.StatusCode == expected);
        }


        [TestCase(1, null, HttpStatusCode.OK)]
        public async Task Get_doctor_AppointmentEndpointStatus(int? doctorId, int? patientId, HttpStatusCode expected)
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            string doctorId_str = doctorId != null ? $"doctor_id={doctorId}&" : "";
            string patientId_str = patientId != null ? $"patient_id={patientId}" : "";

            var response = await client.GetAsync($"appointments?{doctorId_str}{patientId_str}");

            if (response.IsSuccessStatusCode)
            {
                var a = await response.Content.ReadAsStringAsync();
                var option = new JsonSerializerSettings { };

                var myObject = JsonConvert.DeserializeObject<wwwapi.DTO.Response.Appointment.GetDoctors>(a);

            }
            // Assert
            Assert.That(response.StatusCode == expected);
        }

        [TestCase(null, 5, HttpStatusCode.OK)]
        public async Task Get_patients_AppointmentEndpointStatus(int? doctorId, int? patientId, HttpStatusCode expected)
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            string doctorId_str = doctorId != null ? $"doctor_id={doctorId}&" : "";
            string patientId_str = patientId != null ? $"patient_id={patientId}" : "";

            var response = await client.GetAsync($"appointments?{doctorId_str}{patientId_str}");

            if (response.IsSuccessStatusCode)
            {
                var a = await response.Content.ReadAsStringAsync();
                var option = new JsonSerializerSettings { };

                var myObject = JsonConvert.DeserializeObject<wwwapi.DTO.Response.Appointment.GetPatients>(a);

            }
            // Assert
            Assert.That(response.StatusCode == expected);
        }
    }
}