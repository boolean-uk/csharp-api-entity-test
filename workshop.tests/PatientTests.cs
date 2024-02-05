using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace workshop.tests;

[TestFixture]
public class Tests
{
    private WebApplicationFactory<Program> factory;

    [OneTimeSetUp]
    public void Setup()
    {
        factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder => { });
    }

    [Test]
    public async Task PatientEndpointStatus()
    {
        // Arrange
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/patients/");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task DoctorEndpointStatus()
    {
        // Arrange
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/doctors/");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task AppointmentEndpointStatus()
    {
        // Arrange
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointments/");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }
}