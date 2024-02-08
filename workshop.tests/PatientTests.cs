using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace workshop.tests;

public class Tests
{

    WebApplicationFactory<Program> factory;
    HttpClient client;

    [SetUp]
    public async Task Setup()
    {
        factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        client = factory.CreateClient();
    }

    [Test]
    public async Task PatientEndpointStatus()
    {
        // Arrange

        // Act
        var response = await client.GetAsync("/surgery/patients");

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    }

    [Test]
    public async Task PatientById()
    {
        var response = await client.GetAsync("/surgery/patients/1");

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    }
    [Test]
    public async Task DoctorEndpointStatus()
    {
        // Arrange

        // Act
        var response = await client.GetAsync("/surgery/doctors");

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    }

    [Test]
    public async Task DoctorById()
    {
        var response = await client.GetAsync("/surgery/doctors/1");

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    }
    [Test]
    public async Task AppointmentEndpointStatus()
    {
        // Arrange

        // Act
        var response = await client.GetAsync("/surgery/appointments");

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    }

    [Test]
    public async Task AppointmentById()
    {
        var response = await client.GetAsync("/surgery/appointments/1/1");

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    }
}