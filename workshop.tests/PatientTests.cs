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
    
    [Test]
    public async Task CreatePatient()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        DoctorPatientPostModel model = new DoctorPatientPostModel() 
        {
            FullName = "Test"
        };

        // Act
        var json = new StringContent(JsonConvert.SerializeObject(model), UTF8Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/surgery/create/patients/", json);

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.Created);
    }
}