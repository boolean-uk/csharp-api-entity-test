using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework.Constraints;
using System.Net.Http.Json;
using workshop.wwwapi.Models;

namespace workshop.tests;

public class Tests
{
    [Test]
    public async Task PatientEndpointStatus()
    {
        var expectedPayload = new List<Patient>()
        {
            new Patient { Id = 1, FullName = "Klara Andersson" },
                new Patient { Id = 2, FullName = "Peter Andersson" },
                new Patient { Id = 3, FullName = "Arvid Andersson" },
                new Patient { Id = 4, FullName = "Klara Högstedt" },
                new Patient { Id = 5, FullName = "Helda" }
        };

        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/patients");
        var responsePayload = response.Content.ReadFromJsonAsync<IEnumerable<Patient>>();

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(responsePayload.Result.Count(), Is.EqualTo(5));
    }
}