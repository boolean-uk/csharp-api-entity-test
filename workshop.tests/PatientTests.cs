using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace workshop.tests;

public class Tests
{

    [TestCase("/patients", System.Net.HttpStatusCode.OK)]
    [TestCase("/patients/1", System.Net.HttpStatusCode.OK)]
    public async Task PatientEndpointStatus(string endpoint, System.Net.HttpStatusCode statusCode )
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync(endpoint);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(statusCode));

    }

    
    [TestCase("/doctors", System.Net.HttpStatusCode.OK)]
    [TestCase("/doctors/1", System.Net.HttpStatusCode.OK)]
    public async Task DoctorEndpointStatus(string endpoint, System.Net.HttpStatusCode statusCode)
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync(endpoint);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(statusCode));
    }

    [TestCase("/appointments", System.Net.HttpStatusCode.OK)]
    [TestCase("/appointmentsbydoctor/1", System.Net.HttpStatusCode.OK)]
    [TestCase("/appointmentsbypatient/1", System.Net.HttpStatusCode.OK)]
    public async Task AppointmentEndpointStatus(string endpoint, System.Net.HttpStatusCode statusCode)
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync(endpoint);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(statusCode));
    }

}

