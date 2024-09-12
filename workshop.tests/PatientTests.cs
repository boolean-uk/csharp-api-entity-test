using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;

using System.Net.Http.Json;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.Payloads;
using workshop.wwwapi.Repository;
using workshop.wwwapi.Endpoints;
using System.Text;

namespace workshop.tests;

public class Tests
{

    private WebApplicationFactory<Program> _factory;

    [SetUp]
    public void Setup()
    {
        _factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
    }

    [TearDown]
    public void TearDow()
    {
        _factory.Dispose();
    }

    [Test]
    public async Task GetPatients_ReturnesExpectedData()
    {
        var client = _factory.CreateClient();


        var expectedPayload = new List<Patient>
        {
            new Patient { Id = 1, FullName = "Johan Johansson"},
            new Patient { Id = 2, FullName = "Sven Svensson"},
            new Patient { Id = 3, FullName = "Anders Andresson"},
            new Patient { Id = 4, FullName = "Erik Eriksson"},
            new Patient { Id = 5, FullName = "Emma Eriksson"},
            new Patient { Id = 6, FullName = "Knut Knutsson"},
            new Patient { Id = 7, FullName = "Bengt Bengtsson"},
            new Patient { Id = 8, FullName = "Jesper Jespersson"}
        };


        var response = await client.GetAsync("/surgery/patients");
        var responsePayload = await response.Content.ReadFromJsonAsync<IEnumerable<PatientOnlyDTO>>();

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        Assert.That(responsePayload.Count(), Is.EqualTo(8));

        Assert.That(responsePayload.ElementAtOrDefault(0).Id, Is.EqualTo(expectedPayload[0].Id));
        Assert.That(responsePayload.ElementAtOrDefault(0).patient_full_name, Is.EqualTo($"{expectedPayload[0].FullName}"));

        Assert.That(responsePayload.ElementAtOrDefault(1).Id, Is.EqualTo(expectedPayload[1].Id));
        Assert.That(responsePayload.ElementAtOrDefault(1).patient_full_name, Is.EqualTo($"{expectedPayload[1].FullName}"));

        Assert.That(responsePayload.ElementAtOrDefault(2).Id, Is.EqualTo(expectedPayload[2].Id));
        Assert.That(responsePayload.ElementAtOrDefault(2).patient_full_name, Is.EqualTo($"{expectedPayload[2].FullName}"));

        Assert.That(responsePayload.ElementAtOrDefault(3).Id, Is.EqualTo(expectedPayload[3].Id));
        Assert.That(responsePayload.ElementAtOrDefault(3).patient_full_name, Is.EqualTo($"{expectedPayload[3].FullName}"));

        Assert.That(responsePayload.ElementAtOrDefault(4).Id, Is.EqualTo(expectedPayload[4].Id));
        Assert.That(responsePayload.ElementAtOrDefault(4).patient_full_name, Is.EqualTo($"{expectedPayload[4].FullName}"));

        Assert.That(responsePayload.ElementAtOrDefault(5).Id, Is.EqualTo(expectedPayload[5].Id));
        Assert.That(responsePayload.ElementAtOrDefault(5).patient_full_name, Is.EqualTo($"{expectedPayload[5].FullName}"));

        Assert.That(responsePayload.ElementAtOrDefault(6).Id, Is.EqualTo(expectedPayload[6].Id));
        Assert.That(responsePayload.ElementAtOrDefault(6).patient_full_name, Is.EqualTo($"{expectedPayload[6].FullName}"));

        Assert.That(responsePayload.ElementAtOrDefault(7).Id, Is.EqualTo(expectedPayload[7].Id));
        Assert.That(responsePayload.ElementAtOrDefault(7).patient_full_name, Is.EqualTo($"{expectedPayload[7].FullName}"));

    }

    [Test]
    public async Task CreatePatient_ReturnExpectedData()
    {
        var client = _factory.CreateClient();

        string name = "Temp Tempsson";

        //https://learn.microsoft.com/en-us/windows/uwp/networking/httpclient
        StringContent content = new StringContent(
            $"{{ \"full_name\": \"{name}\" }}",
            UnicodeEncoding.UTF8,
            "application/json");
        

        var response = await client.PostAsync("/surgery/patients", content);

        var responsePayload = await response.Content.ReadAsStringAsync();


        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
        Assert.That(responsePayload, Contains.Substring(name));

    }

}
    

   
