using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Net.Http.Json;
using workshop.wwwapi.DTOs.Appointment;
using workshop.wwwapi.DTOs.Doctor;
using workshop.wwwapi.DTOs.Patient;
using workshop.wwwapi.Models;

namespace workshop.tests;

public class PatientTests
{
    [Test]
    public async Task PatientEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/patients");
        var content = await response.Content.ReadAsStringAsync();
        var json = JsonConvert.DeserializeObject<List<PatientDTO>>(content);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        // Patient 1
        Assert.That(json[0].Id, Is.EqualTo(1));
        Assert.That(json[0].FullName, Is.EqualTo("Elisabeth Røysland"));

        // Patient 2
        Assert.That(json[1].Id, Is.EqualTo(2));
        Assert.That(json[1].FullName, Is.EqualTo("Hanna Olsen"));
    }

    [Test]
    public async Task PatientByIdEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/patients/1");
        var content = await response.Content.ReadAsStringAsync();
        var json = JsonConvert.DeserializeObject<PatientDTO>(content);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        Assert.That(json.Id, Is.EqualTo(1));
        Assert.That(json.FullName, Is.EqualTo("Elisabeth Røysland"));
    }

    [Test]
    public async Task AddPatientEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.PostAsJsonAsync("surgery/patients/{id}", new PatientDTO
        {
            FullName = "Someone Cool"
        });

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
    }
}
