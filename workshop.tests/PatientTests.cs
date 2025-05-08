using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.tests;

[TestFixture]
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
        var response2 = await client.GetFromJsonAsync<List<PatientDto>>("surgery/patients"); // return patient DTOs

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(response2.Count, Is.AtLeast(3)); // assert that response at least has the two hard-coded entities
    }

    [Test]
    public async Task DoctorEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/doctors");
        var response2 = await client.GetFromJsonAsync<List<DoctorDto>>("surgery/doctors"); // return doctor DTOs

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(response2.Count, Is.AtLeast(2)); // assert that response at least has the two hard-coded entities
    }

    [Test]
    public async Task AppointmentEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/appointments");
        var response2 = await client.GetFromJsonAsync<List<AppointmentDto>>("surgery/appointments"); // return appointment DTOs

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(response2.Count, Is.AtLeast(4)); // assert that response at least has the four hard-coded entities
    }
}