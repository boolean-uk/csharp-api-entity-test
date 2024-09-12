using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Text;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Endpoints;
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
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task PatientCheck()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/patients");
        var json = await response.Content.ReadAsStringAsync();
     
        var patients = JsonConvert.DeserializeObject<IEnumerable<Patient>>(json);

        var patient = patients.First();
    
        // Assert
        Assert.That(patient.FullName, Is.EqualTo("Dennis"));
    }

    [Test]
    public async Task CreatePatientTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        PatientDTO input = new PatientDTO() { FullName = "John Carew" };
        var json = new StringContent(JsonConvert.SerializeObject(input), UTF8Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync("/patients", json);

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task DoctorCheck()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/doctors");
        var json = await response.Content.ReadAsStringAsync();

        var doctors = JsonConvert.DeserializeObject<IEnumerable<Doctor>>(json);

        var doctor = doctors.First();

        // Assert
        Assert.That(doctor.FullName, Is.EqualTo("Doctor Osmani"));
    }

    [Test]
    public async Task CreateDoctorTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        DoctorDTO input = new DoctorDTO() { FullName = "Doctor Carew" };
        var json = new StringContent(JsonConvert.SerializeObject(input), UTF8Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync("/doctors", json);

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task AppointmentCheck()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/appointments");
        var json = await response.Content.ReadAsStringAsync();

        var appointments = JsonConvert.DeserializeObject<IEnumerable<Appointment>>(json);

        var appointment = appointments.First();

        // Assert
        Assert.That(appointment.Patient.FullName, Is.EqualTo("Dennis"));
    }

    
    [Test]
    public async Task CreateAppointmentTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        AppointmentCreateDTO input = new AppointmentCreateDTO() { AppointmentDate = DateTime.UtcNow + TimeSpan.FromMinutes(30), doctorId = 3, patientId = 6};
        
        var json = new StringContent(JsonConvert.SerializeObject(input), UTF8Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync("/appointments", json);

        // Assert
       Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }
    
}