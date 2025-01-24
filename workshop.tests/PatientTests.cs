using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using workshop.wwwapi.DTO;
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
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
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
        var patients = JsonConvert.DeserializeObject<PatientResponseDTO>(json);

        var patient = patients.Patients.First();
        // Assert
        Assert.That(patient.FullName, Is.EqualTo("Johnny Lever"));
    }


}