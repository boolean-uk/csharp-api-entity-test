using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models.DTOs;
using workshop.wwwapi.Repository;

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
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task GetPatientsTest()
    {
        DbContextOptions<DatabaseContext> options = new DbContextOptions<DatabaseContext>();
        var databaseContext = new DatabaseContext(options);
        var repository = new Repository(databaseContext);
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var response = await client.GetFromJsonAsync<PatientDtoApps>("/surgery/patient/2");
        Assert.That(response.FullName == "Dominic Solanke", Is.True);


    }

    [Test]
    public async Task GetAllPatients()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var response = await client.GetFromJsonAsync<List<PatientDtoApps>>("/surgery/patients");
        Assert.That(response.Any(x => x.FullName == "Dominic Solanke"), Is.True);
    }
}