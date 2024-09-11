using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.AppointmentDTOs;

namespace workshop.tests;

public class PatientTests
{

    private WebApplicationFactory<Program> _factory;
    private HttpClient _client;

    [SetUp]
    public void Setup()
    {
        // Setup the WebApplicationFactory and HttpClient for each test
        _factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        _client = _factory.CreateClient();
    }

    [TearDown]
    public void TearDown()
    {
        _client.Dispose();
        _factory.Dispose();
    }

    [Test]
    public async Task GetSeededPatients()
    {
        // Act
        var response = await _client.GetAsync("/surgery/patients");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

        var patients = await response.Content.ReadFromJsonAsync<List<GetPatientDTO>>();
        Assert.IsNotNull(patients);
        Assert.IsTrue(patients.Count > 0);  // Verify that seeded data is returned
        Assert.IsTrue(patients.Any(p => p.FullName == "John Doe")); // Example assertion for seeded data
    }

    [Test]
    public async Task GetPatient()
    {
        var patientId = new Guid("5457a2b2-c98b-403d-9ca7-6ddd2de5144a"); 
        var requestUrl = $"/surgery/patients/{patientId}";

        var response = await _client.GetAsync(requestUrl);

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var patient = await response.Content.ReadFromJsonAsync<Patient>();

        Assert.IsNotNull(patient);
        Assert.AreEqual(patientId, patient.Id);
        Assert.AreEqual("Jane Smith", patient.FullName);
    }

    [Test]
    public async Task CreatePatient()
    {
        var newPatientJson = new
        {
            FullName = "James Bond"
        };

        var content = new StringContent(
            JsonConvert.SerializeObject(newPatientJson),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _client.PostAsync("/surgery/patients", content);

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode); 

        var createdPatient = await response.Content.ReadFromJsonAsync<Patient>(); 

        Assert.AreEqual("James Bond", createdPatient.FullName); 
    }

}