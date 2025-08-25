using Microsoft.AspNetCore.Mvc.Testing;
using workshop.wwwapi.Models;


namespace workshop.tests;

//With help from Reduan

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

    [DatapointSource] public string[] Values = ["/api/DoctorEndpoint", "/api/PatientsEndpoint", "/api/AppointmentEndpoint"];

    [Theory]
    public async Task Get_Endpoints_ReturnSuccessAndCorrectContentType(string url)
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync(url);

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.That(response.Content.Headers.ContentType.ToString(), Is.EqualTo("application/json; charset=utf-8"));
    }
}