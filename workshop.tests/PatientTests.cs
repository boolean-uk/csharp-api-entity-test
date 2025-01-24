using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;

namespace workshop.tests;

public class Tests
{

    [Test]
    public async Task PatientEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        // Act
        var response = await client.GetAsync("/patients");
        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    }


    //Make sure the data is the same as provided in the seeder
    [Test]
    public async Task TestGetPatients()
    {
        Seeder seeder = new Seeder();
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var response = await client.GetAsync("/patients");
        var content = await response.Content.ReadAsStringAsync();
        var patients = JsonSerializer.Deserialize<List<PatientDto>>(content);
        Assert.That(patients.Count, Is.EqualTo(seeder.Patients.Count));
    }

    [Test]
    public async Task TestGetDoctors()
    {
        Seeder seeder = new Seeder();
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var response = await client.GetAsync("/doctor");
        var content = await response.Content.ReadAsStringAsync();
        var doctors = JsonSerializer.Deserialize<List<Doctor>>(content);
        Assert.That(doctors.Count, Is.EqualTo(seeder.Doctors.Count));
    }

    [Test]
    public async Task TestGetAppointments()
    {
        Seeder seeder = new Seeder();
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var response = await client.GetAsync("/appointment");
        var content = await response.Content.ReadAsStringAsync();
        var appointments = JsonSerializer.Deserialize<List<AppointmentDto>>(content);
        Assert.That(appointments[0].Doctor, Is.EqualTo(seeder.Appointments[0].Doctor));
        Assert.That(appointments[0].Patient, Is.EqualTo(seeder.Appointments[0].Patient));
    }

    [Test]
    public async Task TestGetAppointmentsByPatient()
    {
        Seeder seeder = new Seeder();
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var response = await client.GetAsync("/appointment/patient/1");
        var content = await response.Content.ReadAsStringAsync();
        var appointments = JsonSerializer.Deserialize<List<AppointmentDto>>(content);
        Assert.That(appointments.Count, Is.EqualTo(1));
        Assert.That(appointments[0].Doctor, Is.EqualTo(seeder.Appointments[0].Doctor));
        Assert.That(appointments[0].Patient, Is.EqualTo(seeder.Appointments[0].Patient));
    }
}