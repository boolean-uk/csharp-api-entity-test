using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Text;
using workshop.wwwapi.Dtoes.ViewModels;

namespace workshop.tests;

public class PatientTests
{

    [Test]
    public async Task PatientsEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/patients");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task PatientPostStatusCreated()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        PatientPostModel input = new PatientPostModel();
        input.FirstName = "Test";
        input.LastName = "Person";
        var json = new StringContent(JsonConvert.SerializeObject(input), UTF8Encoding.UTF8, "application/json");

        var response = await client.PostAsync("surgery/patients", json);

        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
    }

    [Test]
    public async Task PatientGetStatusOk()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        int id = 1;

        var response = await client.GetAsync($"surgery/patients/{id}");

        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task PatientGetStatusNotFound()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        int id = 0;

        var response = await client.GetAsync($"surgery/patients/{id}");

        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NotFound);
    }
}