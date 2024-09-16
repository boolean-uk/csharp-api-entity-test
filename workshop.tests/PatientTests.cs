using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.DTOs.Appointments;
using workshop.wwwapi.DTOs.Patients;

namespace workshop.tests;

public class Tests
{

    HttpClient client;

    [SetUp]
    public void SetUp()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        client = factory.CreateClient();
    }

    [Test]
    public async Task PatientEndpointStatus()
    {
        // Act
        var response = await client.GetAsync("/surgery/patients");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task GetPatientByIdStatus()
    {
        var response = await client.GetAsync("/surgery/patients/1");

        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

        response = await client.GetAsync("/surgery/patients/99999");

        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NotFound);
    }

    [Test]
    public async Task AddPatient()
    {
        object newUser = new
        {
            FirstName = "Test",
            LastName = "User"
        };
        var response = await client.PostAsJsonAsync("/surgery/patients", newUser);
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.Created, Is.True);
    }

    [Test]
    public async Task GetAllPatients()
    {
        var response = await client.GetFromJsonAsync<List<GetPatientDTO>>("/surgery/patients");
        Assert.That(response.Any(x => x.FirstName == "Test"), Is.True);
    }

    [Test]
    public async Task AddDoctor()
    {
        GetDoctorDTO dto = new()
        {
            Name = "Dr. Test"
        };
        var response = await client.PostAsJsonAsync("/surgery/doctors", dto);
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.Created, Is.True);
    }

    [Test]
    public async Task GetAllDoctors()
    {
        var response = await client.GetFromJsonAsync<List<GetDoctorDTO>>("/surgery/doctors");
        Assert.That(response.Any(x => x.Name == "Dr. Phil"), Is.True);
    }

    [Test]
    public async Task GetAllAppointments()
    {
        var response = await client.GetFromJsonAsync<List<GetAppointmentDTO>>("/surgery/appointments");
        Assert.That(response.Count, Is.AtLeast(2));
    }
}