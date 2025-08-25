using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using workshop.wwwapi.Models;

namespace workshop.tests;

public class Tests
{
    private WebApplicationFactory<Program> _factory;
    private Doctor _testDoctor;
    private Patient _testPatient;

    [SetUp]
    public void SetUp()
    {
        _factory = new WebApplicationFactory<Program>();
        _testDoctor = new Doctor
        {
            Id = 1337,
            FullName = "TEST DOCTOR"
        };
        _testPatient = new Patient()
        {
            Id = 1337,
            FullName = "TEST PATIENT"
        };
    }

    [TearDown]
    public void TearDown()
    {
        _factory.Dispose();
    }

    [DatapointSource] public string[] Values = ["/api/doctors", "/api/patients", "/api/appointments"];

    [Theory]
    public async Task Get_Endpoints_ReturnSuccessAndCorrectContentType(string url)
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync(url);

        // Assert
        response.EnsureSuccessStatusCode();
        Debug.Assert(response.Content.Headers.ContentType != null);
        Assert.That(response.Content.Headers.ContentType.ToString(), Is.EqualTo("application/json; charset=utf-8"));
    }

    [Test]
    public async Task Get_Doctors_ReturnSuccessAndCorrectCount()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act and assert
        var response = await client.GetAsync("/api/doctors");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content.Headers.ContentType?.ToString(), Is.EqualTo("application/json; charset=utf-8"));

        // Act and assert
        var json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(doc.RootElement.ValueKind, Is.EqualTo(JsonValueKind.Array));
            Assert.That(doc.RootElement.GetArrayLength(),
                Is.GreaterThanOrEqualTo(3)); //Assumes 3 or more doctors in the database
        }
    }

    [Test]
    public async Task Get_Doctor_ReturnSuccessAndSensibleObject()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act and assert
        var response = await client.GetAsync($"/api/doctors/{1337}");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content.Headers.ContentType?.ToString(), Is.EqualTo("application/json; charset=utf-8"));

        // Act and assert
        var actual = await response.Content.ReadFromJsonAsync<Doctor>();
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.FullName, Is.EqualTo(_testDoctor.FullName));
    }

    [Test]
    public async Task Get_Patients_ReturnSuccessAndCorrectCount()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act and assert
        var response = await client.GetAsync("/api/patients");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content.Headers.ContentType?.ToString(), Is.EqualTo("application/json; charset=utf-8"));

        // Act and assert
        var json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(doc.RootElement.ValueKind, Is.EqualTo(JsonValueKind.Array));
            Assert.That(doc.RootElement.GetArrayLength(),
                Is.GreaterThanOrEqualTo(9)); //Assumes 9 or more Patients in the database
        }
    }
    
    [Test]
    public async Task Get_Patient_ReturnSuccessAndSensibleObject()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act and assert
        var response = await client.GetAsync($"/api/patients/{1337}");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content.Headers.ContentType?.ToString(), Is.EqualTo("application/json; charset=utf-8"));

        // Act and assert
        var actual = await response.Content.ReadFromJsonAsync<Patient>();
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.FullName, Is.EqualTo(_testPatient.FullName));
    }
}