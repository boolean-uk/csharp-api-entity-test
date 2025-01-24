using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using workshop.wwwapi.DTOs;

namespace workshop.tests;

[TestFixture]
public class PatientsEndpointTests
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
    public void TearDown()
    {
        _client.Dispose();
        _factory.Dispose();
    }

    // Remeber that this test will only work the first time since the next test creates another Patient, so the Assert.That(patients.Length, Is.EqualTo(2)); would be false.
    [Test, Order(1)]
    public async Task GetSeedPatients()
    {
        var response = await _client.GetAsync("/patient");
        response.EnsureSuccessStatusCode();

        var patients = await response.Content.ReadFromJsonAsync<PatientDTO[]>();

        Assert.That(patients, Is.Not.Null);
        Assert.That(patients.Length, Is.EqualTo(2));

        var p1 = patients[0];

        Assert.That(p1.Id, Is.EqualTo(1));
        Assert.That(p1.FirstName, Is.EqualTo("Mattis"));
        Assert.That(p1.LastName, Is.EqualTo("Henriksen"));

        var p2 = patients[1];

        Assert.That(p2.Id, Is.EqualTo(2));
        Assert.That(p2.FirstName, Is.EqualTo("Mathilde"));
        Assert.That(p2.LastName, Is.EqualTo("Larsen"));
    }

    [Test, Order(2)]
    public async Task CreatePatientTest()
    {
        var createPatientDto = new CreatePatientDTO
        {
            FirstName = "Sivert",
            LastName = "Hagen"
        };

        var response = await _client.PostAsJsonAsync("/patient", createPatientDto);
        response.EnsureSuccessStatusCode();

        var createdPatient = await response.Content.ReadFromJsonAsync<PatientDTO>();

        Assert.That(createdPatient, Is.Not.Null);
        Assert.That(createPatientDto.FirstName, Is.EqualTo(createdPatient.FirstName));
        Assert.That(createPatientDto.LastName, Is.EqualTo(createdPatient.LastName));
    }
}
