using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

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
        Assert.That(response.StatusCode==System.Net.HttpStatusCode.OK);
    }
    [Test]
    public async Task DoctorsEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/Doctors");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }
    [Test]
    public async Task GetDoctorByIdEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/Doctor/1");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }
    [Test]
    public async Task appointmentsBydoctorEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointmentsbydoctor/1");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }
    [Test]
    public async Task getPatientEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/patient1");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }
}