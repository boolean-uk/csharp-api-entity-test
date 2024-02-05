using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using workshop.wwwapi.Models.DTOs;

namespace workshop.tests;

public class PatientTest
{
    private HttpClient _httpClient;

    [SetUp]
    public void SetUp()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        _httpClient = factory.CreateClient();
    }

    [Test]
    public async Task GetAllPatients()
    {

        // Act
        var response = await _httpClient.GetFromJsonAsync<List<PatientDTO>>("/patients");

        // Assert
        Assert.That(response[0].PatientId, Is.EqualTo(1));
        Assert.That(response[0].Appointments.Count(), Is.EqualTo(1));
        Assert.That(response[0].Appointments.First().DoctorId, Is.EqualTo(1));
        Assert.That(response[0].PatientName, Is.EqualTo("Java Script"));
    }

    [Test]
    public async Task GetPatientById()
    {

        // Act
        var response = await _httpClient.GetFromJsonAsync<PatientDTO>("/patients/1");

        // Assert
        Assert.That(response, Is.Not.Null);
        Assert.That(response.PatientId, Is.EqualTo(1));
        Assert.That(response.Appointments.Count(), Is.EqualTo(1));
        Assert.That(response.Appointments.First().DoctorId, Is.EqualTo(1));
        Assert.That(response.PatientName, Is.EqualTo("Java Script"));
    }

    [Test]
    public async Task CreatePatient()
    {

        // Act
        var before = await _httpClient.GetFromJsonAsync<List<PatientDTO>>("/patients");
        var bC = before!.Count;
        var response = await _httpClient.PostAsJsonAsync<CreatePatientDTO>("/patients", new() { PatientId = bC + 1, PatientName = $"Py Thon {bC + 1}" });
        var value = await response.Content.ReadFromJsonAsync<PatientDTO>();
        var after = await _httpClient.GetFromJsonAsync<List<PatientDTO>>("/patients");
        var aC = after!.Count;

        // Assert
        Assert.That(response.IsSuccessStatusCode, Is.True);
        Assert.That(value, Is.Not.Null);
        Assert.That(value.PatientId, Is.EqualTo(bC + 1));
        Assert.That(value.PatientName, Is.EqualTo($"Py Thon {bC + 1}"));
        Assert.That(value.Appointments.Count(), Is.EqualTo(0));
        Assert.That(aC, Is.EqualTo(bC + 1));
    }
}