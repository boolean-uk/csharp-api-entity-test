using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Text.Json;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.PureModels;
using workshop.wwwapi.Models.TransferModels;

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
        var resAsString = await response.Content.ReadAsStringAsync();
        Payload<IEnumerable<PatientDTO>> deserialized = JsonSerializer.Deserialize<Payload<IEnumerable<PatientDTO>>>(resAsString);

        // Assert
        // Payload
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(response?.RequestMessage?.Method.Method, Is.EqualTo("GET"));
        Assert.That(deserialized.status, Is.EqualTo("Success"));
        Assert.That(deserialized.creationTime, Is.EqualTo(DateTime.Now).Within(TimeSpan.FromMilliseconds(100)));
        // Data
        Assert.IsTrue(resAsString.Contains("John Doe"));
        Assert.IsTrue(resAsString.Contains("Jimmy Bob"));
    }

    [Test]
    [TestCase(5, "John Doe")]
    [TestCase(1, "Jimmy Bob")]
    public async Task RetrieveSpecificPatientById(int id, string expectedName)
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync($"/surgery/patients/{id}");
        var resAsString = await response.Content.ReadAsStringAsync();
        Payload<PatientDTO> deserialized = JsonSerializer.Deserialize<Payload<PatientDTO>>(resAsString);


        // Assert
        // Payload
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(response?.RequestMessage?.Method.Method, Is.EqualTo("GET"));
        Assert.That(deserialized.status, Is.EqualTo("Success"));
        Assert.That(deserialized.creationTime, Is.EqualTo(DateTime.Now).Within(TimeSpan.FromMilliseconds(100)));
        // Data
        Assert.IsTrue(resAsString.Contains(expectedName));
    }

}