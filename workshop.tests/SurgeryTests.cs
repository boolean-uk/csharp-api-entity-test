using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using workshop.wwwapi.DTO;

namespace workshop.tests;

public class Tests
{
    private HttpClient _client;
    
    [SetUp]
    public void Setup()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        
        _client = factory.CreateClient();
    }

    [Test]
    public async Task PatientEndpointStatus()
    {
        // Arrange

        // Act
        var response = await _client.GetAsync("surgery/patients");

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
    
    [Test]
    public async Task PostPatientEndpoint()
    {
        // Arrange
        var patient = new PatientPost();
        patient.FullName = "Jonas Doe";

        PatientResponse newPatient = null;

        // Act
        var response = await _client.PostAsync("surgery/patients", new StringContent(JsonSerializer.Serialize(patient), Encoding.UTF8, "application/json"));
        
        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
    }

    [Test]
    public async Task GetDoctorsEndpoint()
    {
        // Arrange

        // Act
        var response = await _client.GetAsync("surgery/doctors");

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
}