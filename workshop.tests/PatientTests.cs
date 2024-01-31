using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;
using workshop.wwwapi;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;



namespace workshop.tests;

public class PatientTests
{

    [SetUp]
    public void SetUp()
    {

    }

    [Test]
    public async Task PatientEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/patients");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task GetPatientResponse()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var expectedPayload = new List<Patient>()
            {
                new Patient { Id = 1, FullName = "May Doe" },
                new Patient { Id = 2, FullName = "John Smith" },
                new Patient { Id = 3, FullName = "Henry Johnson" }
            };

        var response = await client.GetAsync("/surgery/patients");

        var responsePayload = response.Content.ReadFromJsonAsync<IEnumerable<Patient>>();

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));


        // Assert.That(responsePayload.Result.Count(), Is.EqualTo(3));
        Assert.That(responsePayload.Result.ElementAtOrDefault(0).Id, Is.EqualTo(expectedPayload[0].Id));
        Assert.That(responsePayload.Result.ElementAtOrDefault(0).FullName, Is.EqualTo(expectedPayload[0].FullName));

        Assert.That(responsePayload.Result.ElementAtOrDefault(1).Id, Is.EqualTo(expectedPayload[1].Id));
        Assert.That(responsePayload.Result.ElementAtOrDefault(1).FullName, Is.EqualTo(expectedPayload[1].FullName));

        Assert.That(responsePayload.Result.ElementAtOrDefault(2).Id, Is.EqualTo(expectedPayload[2].Id));
        Assert.That(responsePayload.Result.ElementAtOrDefault(2).FullName, Is.EqualTo(expectedPayload[2].FullName));
    }

    [Test]
    public async Task GetOnePatientResponse()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var expectedPayload = new List<Patient>()
            {
                new Patient { Id = 1, FullName = "May Doe" }
            };

        var response = await client.GetAsync("/surgery/patients/1");

        var responsePayload = response.Content.ReadFromJsonAsync<Patient>();

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        Assert.That(responsePayload.Result.Id, Is.EqualTo(expectedPayload[0].Id));
        Assert.That(responsePayload.Result.FullName, Is.EqualTo(expectedPayload[0].FullName));

    }


    [Test]
    public async Task CreatePatientResponse()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var res = await client.GetAsync("/surgery/patients");
        int amount = res.Content.ReadFromJsonAsync<IEnumerable<Patient>>().Result.Count();

        var expectedPayload = new List<Patient>()
            {
                new Patient { Id = amount + 1, FullName = "Gary Way" }
            };

        var obj = new
        {
            FullName = "Gary Way",
        };

        JsonContent content = JsonContent.Create(obj);

        var response = await client.PostAsync("/surgery/patients", content);

        var responsePayload = response.Content.ReadFromJsonAsync<Patient>();

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        Assert.That(responsePayload.Result.FullName, Is.EqualTo(expectedPayload[0].FullName));

    }
}