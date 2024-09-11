using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Frozen;
using System.Text;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.ViewModels;

namespace workshop.tests;

public class Tests
{

    [Test]
    public async Task GetPatients()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/patients");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task PatientCheck()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/patients");
        var json = await response.Content.ReadAsStringAsync();
        var patients = JsonConvert.DeserializeObject<GetPatientsResponse>(json);
        var patient = patients.Patients.First();

        // Assert
        Assert.That(patient.Name, Is.EqualTo("John Doe"));
    }

    [Test]
    public async Task CreatePatient()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        PatientPostModel patient = new PatientPostModel() { FirstName = "Test", LastName = "Testman" };
        var json = new StringContent(JsonConvert.SerializeObject(patient), UTF8Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/surgery/patients", json);
        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task GetDoctors()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var response = await client.GetAsync("/surgery/doctors");

        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task DoctorCheck()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/doctors");
        var json = await response.Content.ReadAsStringAsync();
        var doctors = JsonConvert.DeserializeObject<GetDoctorsResponse>(json);
        var doctor = doctors.Doctors.First();

        // Assert
        Assert.That(doctor.Name, Is.EqualTo("Hannibal Lecter"));
    }

    [Test]
    public async Task GetAppointments()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointments");

        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task AppointmentCheck()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointments");
        var json = await response.Content.ReadAsStringAsync();
        var appointments = JsonConvert.DeserializeObject<GetAppointmentsResponse>(json);
        var appointment = appointments.Appointments.First();

        // Assert
        Assert.That(appointment.DoctorId, Is.EqualTo(1));
        Assert.That(appointment.PatientId, Is.EqualTo(1));
    }

    [Test]
    public async Task GetAppointmentsById()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        int param1 = 1;
        int param2 = 2;
        var response = await client.GetAsync($"/surgery/appointments/{param1}/{param2}");

        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }
}