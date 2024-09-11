using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Text;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;

namespace workshop.tests;

public class Tests
{

    [Test]
    public async Task PatientEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/patients");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task PatientCheck()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/patients");
        var json = await response.Content.ReadAsStringAsync();
     
        var patients = JsonConvert.DeserializeObject<IEnumerable<Patient>>(json);

        var patient = patients.First();
    
        // Assert
        Assert.That(patient.FullName, Is.EqualTo("Dennis"));
    }

    [Test]
    public async Task CreatePatientTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        PatientDTO input = new PatientDTO() { FullName = "John Carew" };
        var json = new StringContent(JsonConvert.SerializeObject(input), UTF8Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync("/patients", json);

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }
}