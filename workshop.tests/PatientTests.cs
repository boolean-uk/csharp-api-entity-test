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
        var response = await client.GetAsync("surgery/patients"); 

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }


    [TestCase(1)]
    public async Task PatientIdEndpointStatus(int id)
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync($"/surgery/patients/{id}");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
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
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [TestCase(1)]
    public async Task DoctorIDEndpointStatus(int id)
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync($"/surgery/doctors/{id}");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task AppointmentEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointments");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

    }


    [TestCase(1)]
    public async Task AppointmentsByDoctorIdEndpointStatus(int id)
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync($"/surgery/appointments/by_doctor/{id}");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

    }

    [TestCase(1)]
    public async Task AppointmentsByPatientIdEndpointStatus(int id)
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync($"/surgery/appointments/by_patient/{id}");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

    }
}