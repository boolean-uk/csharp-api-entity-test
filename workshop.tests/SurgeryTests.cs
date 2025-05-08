using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models.PatientModels;

namespace workshop.tests;

public class Tests
{

    
    [Test]
    public async Task PatientsEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/patients");

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    }

    [Test]
    public async Task PatientsEndpointVerifySeed()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/patients");
        var jsonContent = await response.Content.ReadAsStringAsync();
        var patients = JsonConvert.DeserializeObject<List<Patient>>(jsonContent);

        // Assert
        Assert.That(patients.Count, Is.AtLeast(10));
    }

    [Test]
    public async Task DoctorEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/doctors");

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    }

    [Test]
    public async Task DoctorEndpointVerifySeed()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/doctors");
        var jsonContent = await response.Content.ReadAsStringAsync();
        var content = JsonConvert.DeserializeObject<List<Patient>>(jsonContent);

        // Assert
        Assert.That(content.Count, Is.AtLeast(5));
    }

    [Test]
    public async Task AppointmentsEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointments");

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    }

    [Test]
    public async Task AppointmentsEndpointVerifySeed()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointments");
        var jsonContent = await response.Content.ReadAsStringAsync();
        var content = JsonConvert.DeserializeObject<List<Patient>>(jsonContent);

        // Assert
        Assert.That(content.Count, Is.AtLeast(10));
    }
}

