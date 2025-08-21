using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Collections.Generic;
using System.Net.Http.Json;
using workshop.wwwapi.DTOs;

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
        var response = await client.GetAsync("surgery/patients");

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        var reader = response.Content.ReadFromJsonAsync<IEnumerable<PatientDTO>>();
        Assert.That(reader.Result.First().Fullname == "Ola Nordmann");
    }

    [Test]
    public async Task TestGetPatientBId()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/patient{id}?patientId=1");
 
        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK) );
        Assert.That(response.Content.ReadFromJsonAsync<PatientDTO>().Result.Fullname == "Ola Nordmann");
    }

    [Test]
    public async Task TestGetDoctorBId()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/doctor{id}?doctorId=1");

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        Assert.That(response.Content.ReadFromJsonAsync<DoctorDTO>().Result.Name == "Kari Doctor");
    }
    [Test]
    public async Task GetAllDoctors()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/doctors");

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        var reader = response.Content.ReadFromJsonAsync<IEnumerable<DoctorDTO>>();
        Assert.That(reader.Result.First().Name == "Kari Doctor");
    }
    [Test]
    public async Task GetAllAppointments()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/appointments");

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        var reader = response.Content.ReadFromJsonAsync<IEnumerable<AppointmentDTO>>();
        Assert.That(reader.Result.Any(a => a.PatientName == "Ola Nordmann" && a.DoctorName == "Kari Doctor" ));
    }

    [Test]
    public async Task TestGetAppointmentByDoctor()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/appointmentsbydoctor/1");

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        var reader = response.Content.ReadFromJsonAsync<IEnumerable<AppointmentDTO>>();
        Assert.That(reader.Result.Any(a => a.PatientName == "Ola Nordmann" && a.DoctorName == "Kari Doctor"));
    }

    [Test]
    public async Task TestCreatePatient()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.PostAsJsonAsync("surgery/patients", new PatientDTO { Fullname = "Peter" });

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        Assert.That(response.Content.ReadFromJsonAsync<PatientDTO>().Result.Fullname, Is.EqualTo("Peter"));
    }

    [Test]
    public async Task TestCreateDoctor()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.PostAsJsonAsync("surgery/doctor", new DoctorDTO { Name = "Peter" });

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        Assert.That(response.Content.ReadFromJsonAsync<DoctorDTO>().Result.Name, Is.EqualTo("Peter"));
    }
    [Test]
    public async Task TestCreateAppointment()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.PostAsJsonAsync("surgery/appointment", new AppointmentPost { doctorId=2, patientId=2});
        var app = response.Content.ReadFromJsonAsync<AppointmentDTO>().Result;

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        Assert.That(app.PatientName, Is.EqualTo("Kari Nordmann"));
        Assert.That(app.DoctorName, Is.EqualTo("Jens Doctor"));
    }
}