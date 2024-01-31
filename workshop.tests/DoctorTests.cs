using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;
using workshop.wwwapi;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;



namespace workshop.tests;

public class DoctorTests
{

    [SetUp]
    public void SetUp()
    {

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

    [Test]
    public async Task GetDoctorResponse()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var expectedPayload = new List<Doctor>()
            {
                new Doctor { Id = 1, FullName = "Mr. Dentist" },
                new Doctor { Id = 2, FullName = "Mrs. Cardiologist" }
            };

        var response = await client.GetAsync("/surgery/doctors");

        var responsePayload = response.Content.ReadFromJsonAsync<IEnumerable<Doctor>>();

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));


        Assert.That(responsePayload.Result.Count(), Is.EqualTo(2));
        Assert.That(responsePayload.Result.ElementAtOrDefault(0).Id, Is.EqualTo(expectedPayload[0].Id));
        Assert.That(responsePayload.Result.ElementAtOrDefault(0).FullName, Is.EqualTo(expectedPayload[0].FullName));

        Assert.That(responsePayload.Result.ElementAtOrDefault(1).Id, Is.EqualTo(expectedPayload[1].Id));
        Assert.That(responsePayload.Result.ElementAtOrDefault(1).FullName, Is.EqualTo(expectedPayload[1].FullName));

    }

    [Test]
    public async Task GetOneDoctorResponse()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var expectedPayload = new List<Doctor>()
            {
                new Doctor { Id = 1, FullName = "Mr. Dentist" }
            };

        var response = await client.GetAsync("/surgery/doctors/1");

        var responsePayload = response.Content.ReadFromJsonAsync<Doctor>();

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        Assert.That(responsePayload.Result.Id, Is.EqualTo(expectedPayload[0].Id));
        Assert.That(responsePayload.Result.FullName, Is.EqualTo(expectedPayload[0].FullName));

    }


    [Test]
    public async Task CreateDoctorResponse()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var expectedPayload = new List<Doctor>()
            {
                new Doctor { Id = 0, FullName = "Lenny Wu" }
            };

        var obj = new
        {
            FullName = "Lenny Wu",
        };

        JsonContent content = JsonContent.Create(obj);

        var response = await client.PostAsync("/surgery/doctors", content);

        var responsePayload = response.Content.ReadFromJsonAsync<Doctor>();

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        Assert.That(responsePayload.Result.Id, Is.EqualTo(expectedPayload[0].Id));
        Assert.That(responsePayload.Result.FullName, Is.EqualTo(expectedPayload[0].FullName));

    }
}