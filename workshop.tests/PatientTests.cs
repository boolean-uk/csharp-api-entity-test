using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using workshop.wwwapi.Data.DTO;
using workshop.wwwapi.Models;

namespace workshop.tests;

public class Tests
{

    [Test]
    public async Task PatientEndpointStatus()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var response = await client.GetAsync("surgery/patients");


        var actualJson = await response.Content.ReadAsStringAsync();


        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        //Assert.That(responsePayload.Result.Count(), Is.EqualTo(2));
        //Assert.That(responsePayload.Result.ElementAtOrDefault(0).Id, Is.EqualTo(expectedPayload[0].Id));
        //Assert.That(responsePayload.Result.ElementAtOrDefault(0).FullName, Is.EqualTo(expectedPayload[0].FullName));

    }
}