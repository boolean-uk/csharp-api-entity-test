using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace workshop.tests;

public class Tests
{

    [Test]
    public async Task GetPatients()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/patients");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }
    [Test]
    public async Task GetPatient()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/patient/1");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }
    [Test]
    public async Task GetDoctors()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/doctors");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }
    [Test]
    public async Task GetDoctor()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/doctor/1");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }
    [Test]
    public async Task GetAppointments()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointments");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }
    [Test]
    public async Task GetAppointment()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointment/1");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }
    [Test]
    public async Task GetAppointmentByDoctor()
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
    public async Task GetAppointmentByPatient()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointmentsbypatient/1");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }
    [Test]
    public async Task WrongIdAppointment()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointment/333333");

        // Assert
        Assert.That(response.StatusCode != System.Net.HttpStatusCode.OK);
    }
}