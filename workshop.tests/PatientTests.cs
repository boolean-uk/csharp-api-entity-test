using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using workshop.wwwapi.Models;

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
        var json = await response.Content.ReadAsStringAsync();
        var patients = JsonConvert.DeserializeObject<IEnumerable<Patient>>(json);

        var patient = patients.First();
        // Assert
        Assert.That(patient.FullName, Is.EqualTo("John Doe"));
    }  
    
    [Test]
    public async Task DoctorEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/doctors");
        var json = await response.Content.ReadAsStringAsync();
        var doctors = JsonConvert.DeserializeObject<IEnumerable<Doctor>>(json);

        var doctor = doctors.First();
        // Assert
        Assert.That(doctor.FullName, Is.EqualTo("Meredith Grey"));
    }  
    
   
}