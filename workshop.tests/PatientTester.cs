using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Text;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;

namespace workshop.tests;

public class PatientTester
{
    [Test]
    [Order(1)]
    public async Task PatientEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/patients");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    [Order(2)]
    public async Task GetAllPatients()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/patients");
        var content = await response.Content.ReadAsStringAsync();
        var patients = JsonConvert.DeserializeObject<List<PatientDTO>>(content);

        // Replace with the expected number of patients. The seed data has 2 patients, so the expected number should be 2,
        // but must be manually edited after each test run because the test creates a new patient.
        var expectedResult = 2; 
        var actualResult = patients.Count;
        // Assert

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    [Order(3)]
    public async Task GetPatientById_Success()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/patients/1");
        var content = await response.Content.ReadAsStringAsync();
        var patient = JsonConvert.DeserializeObject<PatientDTO>(content);

        var expectedResult = "Maynard James Keenan"; // Replace with the expected patient name
        var actualResult = patient.FullName;
        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    [Order(4)]
    public async Task GetPatientById_Fail()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        int unreachableId = 99999;

        // Act
        var response = await client.GetAsync($"surgery/patients/{unreachableId}");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NotFound);
    }


    [Test]
    [Order(5)]
    public async Task CreatePatient_Success()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var patientPost = new PatientPost
        {
            FullName = NameHelper.GetRandomName()
        };

        // Act
        var content = new StringContent(JsonConvert.SerializeObject(patientPost), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("surgery/patients", content);

        // Assert
        var responseBody = await response.Content.ReadAsStringAsync();
        var createdPatient = JsonConvert.DeserializeObject<Patient>(responseBody);

        Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);
        Assert.AreEqual(patientPost.FullName, createdPatient.FullName);
    }

    [Test]
    [Order(6)]
    public async Task CreatePatient_Fail()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var patientPostEmpty = new PatientPost
        {
            FullName = ""
        };
        var patientPostString = new PatientPost
        {
            FullName = "string"
        };

        var contentEmpty = new StringContent(JsonConvert.SerializeObject(patientPostEmpty), Encoding.UTF8, "application/json");
        var responseEmpty = await client.PostAsync("surgery/patients", contentEmpty);
        // Act
        var contentString = new StringContent(JsonConvert.SerializeObject(patientPostString), Encoding.UTF8, "application/json");
        var responseString = await client.PostAsync("surgery/patients", contentEmpty);

        // Assert
        Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, responseEmpty.StatusCode);
        Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, responseString.StatusCode);
    }
}