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
        var patients = JsonConvert.DeserializeObject<IEnumerable<PatientDTO>>(json);

        var patient = patients.First();
        // Assert
        Assert.That(patient.Name, Is.EqualTo("Dennis"));
    }

    [Test]
    public async Task CreatePatientCheck()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        PatientDTO input = new PatientDTO() { Name = "Thomas Flier" };
        var json = new StringContent(JsonConvert.SerializeObject(input), UTF8Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/patients", json);

        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task DoctorEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/doctors");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task DoctorCheck()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/doctors");
        var json = await response.Content.ReadAsStringAsync();
        var patients = JsonConvert.DeserializeObject<IEnumerable<PatientDTO>>(json);

        var patient = patients.First();
        // Assert
        Assert.That(patient.Name, Is.EqualTo("Doctor Osmani"));
    }

    [Test]
    public async Task CreateDoctorCheck()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        PatientDTO input = new PatientDTO() { Name = "Doctor Flier" };
        var json = new StringContent(JsonConvert.SerializeObject(input), UTF8Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/doctors", json);

        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }


    [Test]
    public async Task AppointmentEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/appointments");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }
}