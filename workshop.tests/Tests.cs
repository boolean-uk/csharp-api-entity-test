using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;
using workshop.wwwapi.Models;

namespace workshop.tests;

[TestFixture] 
public class EndpointTests
{
    private HttpClient _client;

    [SetUp] 
    public void Setup()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        _client = factory.CreateClient();
    }

    // Patient
    [Test]
    public async Task PatientEndpointStatus()
    {
        // Act
        var response = await _client.GetAsync("/patients");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task GetPatients()
    {
        // Act
        var response = await _client.GetAsync("/patients");
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();

        // Assert
        StringAssert.Contains("John Doe", responseString); 
        StringAssert.Contains("Jane Doe", responseString);
    }

    [Test]
    public async Task CreatePatient()
    {
        // Arrange
        InputPatient inputPatient = new InputPatient { FullName = "Robert Doe" };
        var jsonContent = JsonConvert.SerializeObject(inputPatient);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/patients", content);
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();

        // Assert
        StringAssert.Contains("Robert Doe", responseString);
    }

    // Doctor
    [Test]
    public async Task DoctorEndpointStatus()
    {
        // Act
        var response = await _client.GetAsync("/doctors");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task GetDoctors()
    {
        // Act
        var response = await _client.GetAsync("/doctors");
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();

        // Assert
        StringAssert.Contains("Dr. Smith", responseString);
        StringAssert.Contains("Dr. Johnson", responseString);
    }

    [Test]
    public async Task CreateDoctor()
    {
        // Arrange
        InputDoctor inputDoctor = new InputDoctor { FullName = "Dr. Brown" };
        var jsonContent = JsonConvert.SerializeObject(inputDoctor);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/doctors", content);
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();

        // Assert
        StringAssert.Contains("Dr. Brown", responseString);
    }

    // Appointment
    [Test]
    public async Task AppointmentEndpointStatus()
    {
        // Act
        var response = await _client.GetAsync("/appointments");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task GetAppointments()
    {
        // Act
        var response = await _client.GetAsync("/appointments");
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();

        // Assert
        StringAssert.Contains("John Doe", responseString);
        StringAssert.Contains("Jane Doe", responseString);
        StringAssert.Contains("Dr. Smith", responseString);
        StringAssert.Contains("Dr. Johnson", responseString);
    }
}
