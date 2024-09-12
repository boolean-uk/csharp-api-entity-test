using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Text;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;

namespace workshop.tests;

public class Tests
{
    [Test]
    public async Task GetAllPatientsTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/patients");
        var json = await response.Content.ReadAsStringAsync();
        var patients = JsonConvert.DeserializeObject<IEnumerable<Patient>>(json);

        var patient = patients.First();

        // Assert
        Assert.That(patient.FullName, Is.EqualTo("John Doe"));
    }
}