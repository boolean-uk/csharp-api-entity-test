using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;

namespace workshop.tests
{
    public class DoctorTester
    {

        [Test]
        public async Task DoctorEndpointStatus()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("surgery/doctors");

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task GetAllDoctors()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("surgery/doctors");
            var content = await response.Content.ReadAsStringAsync();
            var doctors = JsonConvert.DeserializeObject<List<DoctorDTO>>(content);

            var expectedResult = 2; // Replace with the expected number of doctors
            var actualResult = doctors.Count;
            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task GetDoctorById_Success()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("surgery/doctors/1");
            var content = await response.Content.ReadAsStringAsync();
            var patient = JsonConvert.DeserializeObject<DoctorDTO>(content);

            var expectedResult = "Justin Chancellor"; // Replace with the expected patient name
            var actualResult = patient.FullName;
            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task GetDoctorById_Fail()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();
            int unreachableId = 99999;

            // Act
            var response = await client.GetAsync($"surgery/doctors/{unreachableId}");

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NotFound);
        }


        [Test]
        public async Task CreateDoctor_Success()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            var patientPost = new DoctorPost
            {
                FullName = NameHelper.GetRandomName()
            };

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(patientPost), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("surgery/doctors", content);

            // Assert
            var responseBody = await response.Content.ReadAsStringAsync();
            var createdDoctor = JsonConvert.DeserializeObject<Doctor>(responseBody);

            Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);
            Assert.AreEqual(patientPost.FullName, createdDoctor.FullName);
        }

        [Test]
        public async Task CreateDoctor_Fail()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            var patientPostEmpty = new DoctorPost
            {
                FullName = ""
            };
            var patientPostString = new DoctorPost
            {
                FullName = "string"
            };

            var contentEmpty = new StringContent(JsonConvert.SerializeObject(patientPostEmpty), Encoding.UTF8, "application/json");
            var responseEmpty = await client.PostAsync("surgery/doctors", contentEmpty);
            // Act
            var contentString = new StringContent(JsonConvert.SerializeObject(patientPostString), Encoding.UTF8, "application/json");
            var responseString = await client.PostAsync("surgery/doctors", contentEmpty);

            // Assert
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, responseEmpty.StatusCode);
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, responseString.StatusCode);
        }
    }
}
