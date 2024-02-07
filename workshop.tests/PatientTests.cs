using Microsoft.AspNetCore.Mvc.Testing;

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
        var response1 = await client.GetAsync("/surgery/patients/1");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.IsTrue(response1.StatusCode == System.Net.HttpStatusCode.OK);
    }
    [Test]
    public async Task DoctorEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/doctors");
        var response1 = await client.GetAsync("/surgery/doctors/1");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.IsTrue(response1.StatusCode == System.Net.HttpStatusCode.OK);
    }
}