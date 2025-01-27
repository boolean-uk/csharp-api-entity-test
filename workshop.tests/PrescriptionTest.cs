using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;

namespace workshop.tests;

public partial class Tests
{

  public class Prescription
    {
        [Test]
        public async Task GetAll_PrescriptionEndpointStatus()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => {

            });
            //factory.ClientOptions.BaseAddress.
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("prescriptions");

            // Assert
            Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);

        }

        [TestCase(1, 1, HttpStatusCode.OK)]
        public async Task Get_PrescriptionEndpointStatus(int? doctorId, int? patientId, HttpStatusCode expected)
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            string doctorId_str = doctorId != null ? $"doctor_id={doctorId}&" : "";
            string patientId_str = patientId != null ? $"patient_id={patientId}" : "";

            var response = await client.GetAsync($"prescriptions?{doctorId_str}{patientId_str}");


            // Assert
            Assert.That(response.StatusCode == expected);
        }


        [TestCase(1, null, HttpStatusCode.OK)]
        public async Task Get_doctor_PrescriptionEndpointStatus(int? doctorId, int? patientId, HttpStatusCode expected)
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            string doctorId_str = doctorId != null ? $"doctor_id={doctorId}&" : "";
            string patientId_str = patientId != null ? $"patient_id={patientId}" : "";

            var response = await client.GetAsync($"prescriptions?{doctorId_str}{patientId_str}");

            if (response.IsSuccessStatusCode)
            {
                var a = await response.Content.ReadAsStringAsync();
                var option = new JsonSerializerSettings { };

                var myObject = JsonConvert.DeserializeObject<wwwapi.DTO.Response.Prescription.GetDoctors>(a);

            }
            // Assert
            Assert.That(response.StatusCode == expected);
        }

        [TestCase(null, 5, HttpStatusCode.OK)]
        public async Task Get_patients_PrescriptionEndpointStatus(int? doctorId, int? patientId, HttpStatusCode expected)
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            string doctorId_str = doctorId != null ? $"doctor_id={doctorId}&" : "";
            string patientId_str = patientId != null ? $"patient_id={patientId}" : "";

            var response = await client.GetAsync($"prescriptions?{doctorId_str}{patientId_str}");

            if (response.IsSuccessStatusCode)
            {
                var a = await response.Content.ReadAsStringAsync();
                var option = new JsonSerializerSettings { };

                var myObject = JsonConvert.DeserializeObject<wwwapi.DTO.Response.Prescription.GetPatients>(a);

            }
            // Assert
            Assert.That(response.StatusCode == expected);
        }
    }


}