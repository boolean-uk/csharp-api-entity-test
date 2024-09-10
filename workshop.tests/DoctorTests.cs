using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Text;

namespace workshop.tests;

public partial class Tests
{

    [Test]
    public async Task DoctorEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("http://localhost:5045/surgery/doctors");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);


        // Act
        var response1 = await client.GetAsync("http://localhost:5045/surgery/doctors?id=21&name=TestDoc");

        // Assert
        Assert.IsTrue(response1.StatusCode == System.Net.HttpStatusCode.OK);
    }

}