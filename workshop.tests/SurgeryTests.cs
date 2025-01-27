using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace workshop.tests;

public class Tests
{

    private WebApplicationFactory<Program> _factory;
    private HttpClient _client;

    [SetUp]
    public void SetUp()
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

    [Test]
    public async Task PatientEndpointStatus()
    {
        // Act
        var response = await _client.GetAsync("surgery/patients");

        // Assert
        Assert.That(System.Net.HttpStatusCode.OK, Is.EqualTo(response.StatusCode));
    }

    [Test]
    public async Task PatientEndpointCreate()
    {
        // Arrange
        var content = new StringContent("{\"FullName\":\"John Doe\"}", Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("surgery/patients", content);

        // Assert
        Assert.That(System.Net.HttpStatusCode.Created, Is.EqualTo(response.StatusCode));
    }

    [Test]
    public async Task DoctorGetAll()
    {
        // Act
        var response = await _client.GetAsync("surgery/doctors");

        // Assert
        Assert.That(System.Net.HttpStatusCode.OK, Is.EqualTo(response.StatusCode));
    }

    [Test]
    public async Task DoctorCreate()
    {
        // Arrange
        var content = new StringContent("{\"FullName\":\"Dr. Smith\"}", Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("surgery/doctors", content);

        // Assert
        Assert.That(System.Net.HttpStatusCode.Created, Is.EqualTo(response.StatusCode));
    }


    [Test]
    public async Task AppointmentGetAll()
    {
        // Act
        var response = await _client.GetAsync("surgery/appointments");

        // Assert
        Assert.That(System.Net.HttpStatusCode.OK, Is.EqualTo(response.StatusCode));
    }

    [Test]
    public async Task AppointmentCreate()
    {
        // Arrange
        var content = new StringContent("{\"DoctorId\": 1, \"PatientId\": 1, \"AppointmentDate\": \"2023-06-15T14:37:52Z\"}", Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("surgery/appointments", content);

        // Assert
        Assert.That(System.Net.HttpStatusCode.Created, Is.EqualTo(response.StatusCode));
    }
}