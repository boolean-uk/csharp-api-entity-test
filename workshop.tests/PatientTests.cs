using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.tests;

public class Tests
{

    [Test]
    public async Task PatientEndpointStatusAndResponseData()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/patients");
        var responseContent = await response.Content.ReadAsStringAsync();
        var responseData = JsonConvert.DeserializeObject<List<Patient>>(responseContent);

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.IsTrue(responseData.Any(p => p.FullName == "George Banan"));
    }



}

