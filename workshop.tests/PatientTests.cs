using System.Net.Http.Json;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.tests;

public class Tests
{
    private WebApplicationFactory<Program> _factory;
    private HttpClient _client;

    [SetUp]
    public void Setup()
    {
        _factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        _client = _factory.CreateClient();
    }

    [TearDown]
    public void Dispose()
    {
        _factory?.Dispose();
    }

    [Test]
    public async Task PatientEndpointStatus()
    {
        // Act
        var response = await _client.GetAsync("surgery/patients/");

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    }

    [Test]
    public async Task TestGetPatients()
    {
        var response = await _client.GetAsync("surgery/patients/");

        var patients = await response.Content.ReadFromJsonAsync<List<PatientDTO>>();

        Assert.That(patients[0].fullName == "Tom");
        Assert.That(patients[1].fullName == "Jerry");
    }

    [Test]
    public async Task TestGetDoctors()
    {
        var response = await _client.GetAsync("surgery/doctors/");

        var doctors = await response.Content.ReadFromJsonAsync<List<DoctorDTO>>();

        Assert.That(doctors[0].FullName == "Dr. House");
        Assert.That(doctors[1].FullName == "Dr. Grey");
    }
}