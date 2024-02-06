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
    public class DoctorTester
    {

        [Test]
        [Order(1)]
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
        [Order(2)]
        public async Task GetAllDoctors()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("surgery/doctors");
            var content = await response.Content.ReadAsStringAsync();
            var doctors = JsonConvert.DeserializeObject<List<DoctorDTO_L2>>(content);

            var expectedResult = 2; // Replace with the expected number of doctors
            var actualResult = doctors.Count;
            // Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        [Order(3)]
        public async Task GetDoctorById_Success()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("surgery/doctors/1");
            var content = await response.Content.ReadAsStringAsync();
            var patient = JsonConvert.DeserializeObject<DoctorDTO_L2>(content);

            var expectedResult = "Justin Chancellor"; // Replace with the expected patient name
            var actualResult = patient.FullName;
            // Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        [Order(4)]
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
        [Order(5)]
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

            Assert.That(System.Net.HttpStatusCode.Created, Is.EqualTo(response.StatusCode));
            Assert.That(patientPost.FullName, Is.EqualTo(createdDoctor.FullName));
        }

        [Test]
        [Order(6)]
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
            Assert.That(System.Net.HttpStatusCode.BadRequest, Is.EqualTo(responseEmpty.StatusCode));
            Assert.That(System.Net.HttpStatusCode.BadRequest, Is.EqualTo(responseString.StatusCode));
        }
    }
}
