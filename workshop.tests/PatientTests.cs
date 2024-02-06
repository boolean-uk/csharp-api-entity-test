using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using workshop.wwwapi.Endpoints;

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
        var response = await client.GetAsync("patients");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
       // Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        
    }

      
}