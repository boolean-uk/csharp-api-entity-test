using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;
using workshop.wwwapi.Models;

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
    public async Task DoctorEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/doctors");
        var expectedResult = new List<Doctor>()
        {
                new Doctor { Id = 1, FullName = "Dr Fill" },
                new Doctor { Id = 2, FullName = "Dr Jo" },
               
                
        };
        var responseResult = response.Content.ReadFromJsonAsync<IEnumerable<Doctor>>();

        //Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        Assert.That(responseResult.Result.Count(), Is.EqualTo(expectedResult.Count()));
        for (int i = 0; i < expectedResult.Count; i++)
        {
            Assert.That(responseResult.Result.ElementAtOrDefault(i).Id, Is.EqualTo(expectedResult[i].Id));
            Assert.That(responseResult.Result.ElementAtOrDefault(i).FullName, Is.EqualTo(expectedResult[i].FullName));
        }

    }

    [Test]
    public async Task DoctorNotFoundEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/doctors/100");

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
    }

    [Test]
    public async Task AppointmentsEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointments/");

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    }
}