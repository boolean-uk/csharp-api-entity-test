using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Net;
using System.Text;

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
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }
    [Test]
    public async Task PatientGetAll()
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
    public async Task PatientAdd()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var content = new StringContent(JsonConvert.SerializeObject(new
        {
            FullName = "Ola Larsen",
        }), Encoding.UTF8, "application/json");


        // Act

        var response = await client.PostAsync("/surgery/", content);

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.Created);
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
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }
    [Test]
    public async Task DoctorGetAll()
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
    public async Task DoctorAdd()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var content = new StringContent(JsonConvert.SerializeObject(new
        {
            FullName = "Kari Andersen",
        }), Encoding.UTF8, "application/json");


        // Act
        var response = await client.PostAsync("/surgery/doctor", content);

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.Created);
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
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }
    [Test]
    public async Task AppointmentGetAll()
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
    public async Task AppointmentAdd()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var content = new StringContent(JsonConvert.SerializeObject(new
        {
            PatientId = 1,
            DoctorId = 1,
        }), Encoding.UTF8, "application/json");


        // Act
        var response = await client.PostAsync("/surgery/appointment/", content);

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.Created);
    }

}