using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using workshop.wwwapi.DTO;

namespace workshop.tests;

public class SurgeryEndpointTests
{
    [Test]
    public async Task GetAllPatients_ReturnsListOfPatients()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/patients");
        response.EnsureSuccessStatusCode();

        var patients = await response.Content.ReadFromJsonAsync<List<PatientDTO>>();

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(patients, Is.Not.Null);
        Assert.That(patients.Count, Is.GreaterThan(0)); // Assuming there's seed data
    }

  

    [Test]
    public async Task GetPatientByInvalidId_ReturnsNotFound()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/patients/9999"); // Non-existent ID

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    



    [Test]
    public async Task GetAllDoctors_ReturnsListOfDoctors()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/doctors");
        response.EnsureSuccessStatusCode();

        var doctors = await response.Content.ReadFromJsonAsync<List<DoctorDTO>>();

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(doctors, Is.Not.Null);
        Assert.That(doctors.Count, Is.GreaterThan(0)); // Assuming there's seed data
    }

    [Test]
    public async Task CreateNewDoctor_ReturnsCreatedDoctor()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var newDoctor = new DoctorDTO { Name = "Dr. New Test Doctor" };

        // Act
        var response = await client.PostAsJsonAsync("/surgery/doctor", newDoctor);
        response.EnsureSuccessStatusCode();

        var createdDoctor = await response.Content.ReadFromJsonAsync<DoctorDTO>();

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(createdDoctor, Is.Not.Null);
        Assert.That(createdDoctor.Name, Is.EqualTo(newDoctor.Name));
    }

    [Test]
    public async Task GetDoctorByInvalidId_ReturnsNotFound()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/doctors/9999"); // Non-existent ID

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }
}


