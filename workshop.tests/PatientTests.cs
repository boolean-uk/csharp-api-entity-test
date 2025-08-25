using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Text;
using workshop.wwwapi.Data;
using workshop.wwwapi.Repository;

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
        var response = await client.GetAsync("/surgery/patients");

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    }
    [Test]
    public async Task GetAllDoctors()
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
    public async Task GetAllAppointments()
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
    public async Task CreatePatient()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var content = new StringContent(JsonConvert.SerializeObject(
            new { FullName = "Test" }), 
            Encoding.UTF8, 
            "application/json"
            );

        // Act
        var response = await client.PostAsync("/surgery/patients", content);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
    }

    [Test]
    public async Task CreateDoctor()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var content = new StringContent(JsonConvert.SerializeObject(
            new { FullName = "Test" }),
            Encoding.UTF8,
            "application/json"
            );

        // Act
        var response = await client.PostAsync("/surgery/doctors", content);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
    }

    [Test]
    public async Task CreateAppointments()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var content = new StringContent(JsonConvert.SerializeObject(
            new { PatientId = 1,
                  PatientName = "Test1",
                  DoctorId = 1,
                  DoctorName = "DrTest",
                  AppointmentDate = DateTime.UtcNow,
            }),
            Encoding.UTF8,
            "application/json"
            );

        // Act
        var response = await client.PostAsync("/surgery/appointments", content);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
    }

}