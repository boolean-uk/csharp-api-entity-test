/*using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using workshop.wwwapi.Models;

namespace workshop.tests;

public class Tests
{
    [SetUp]
    public void SetUp()
    {

    }

    [Test]
    public async Task GetPatient()
    {
        // Arrange 
        // This creates an instance of the server with a default app builder 
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        // the client is the name of the server instance
        var client = factory.CreateClient();

        // Act
        // ask for a get request for the patients endpoints
        var response = await client.GetAsync("/patients");

        // Assert
        // That returns a response object, and checks if the Status code is equal to OK.
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));


    // For this instance creation you need to add this line of code in the Program.cs
    // -->  public partial class Program { } // needed for testing - please ignore   
}
    *//*
        [Test]
        public async Task PatientEndpointStatus()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/patients");

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }*//*
}*/