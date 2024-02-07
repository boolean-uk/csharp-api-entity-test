using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using workshop.wwwapi.Models;

namespace workshop.tests;

public class DoctorTests
{

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
    public async Task GetDoctorsResponse()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var expectedPayload = new List<Doctor>()
            {
                new Doctor { Id = 1, FullName = "Dr.Johanna" },
                new Doctor { Id = 2, FullName = "Dr.Jon" }
            };

        // Act
        var response = await client.GetAsync("/surgery/doctors");

        var responsePayload = await response.Content.ReadFromJsonAsync<IEnumerable<Doctor>>();

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        //Assert.That(responsePayload.Result.Count(), Is.EqualTo(3));
        for (int i = 0; i < expectedPayload.Count; i++)
        {
            Assert.That(responsePayload.ElementAtOrDefault(i).Id, Is.EqualTo(expectedPayload[i].Id));
            Assert.That(responsePayload.ElementAtOrDefault(i).FullName, Is.EqualTo(expectedPayload[i].FullName));
        }
    }
}