using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Migrations;
using workshop.wwwapi.Models;

namespace workshop.tests;

public class Tests
{

    [Test]
    public async Task PatientGetAllEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/patients");

        var patients = await response.Content.ReadFromJsonAsync<List<PatientDTO>>();
        PatientDTO? seed1 = patients.Find(a => a.FullName.Equals("Trym Berger"));
        PatientDTO? seed2 = patients.Find(a => a.FullName.Equals("Mathew Walker"));

        // Assert
        Assert.That(seed1 is not null);
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(seed2 is not null);
    }
    [Test]
    public async Task PatientGetByIdEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/patients/1");

        var patient = await response.Content.ReadFromJsonAsync<PatientDTO>();

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(patient is not null);
        Assert.That(patient.FullName, Is.EqualTo("Trym Berger"));
    }

    [Test]
    public async Task DoctorGetAllEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/doctors");

        var doctors = await response.Content.ReadFromJsonAsync<List<DoctorDTO>>();
        DoctorDTO? seed1 = doctors.Find(a => a.FullName.Equals("Jan-Erik Berger"));
        DoctorDTO? seed2 = doctors.Find(a => a.FullName.Equals("Mette Skurtveit"));

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(seed2 is not null);
        Assert.That(seed2 is not null);
    }
    [Test]
    public async Task DoctorGetByIdEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/doctors/1");

        var doctor = await response.Content.ReadFromJsonAsync<DoctorDTO>();

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(doctor is not null);
        Assert.That(doctor.FullName, Is.EqualTo("Jan-Erik Berger"));
    }

    [Test]
    public async Task AppointmentGetAllEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointments");

        var appointments = await response.Content.ReadFromJsonAsync<List<AppointmentDTO>>();
        AppointmentDTO? seed1 = appointments.Find(a => a.DoctorName.Equals("Jan-Erik Berger"));
        AppointmentDTO? seed2 = appointments.Find(a => a.PatientName.Equals("Mathew Walker"));

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(seed2 is not null);
        Assert.That(seed2 is not null);
    }
    [Test]
    public async Task AppointmentGetByIdEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointments/1");

        var appointments = await response.Content.ReadFromJsonAsync<AppointmentDTO>();

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(appointments is not null);
        Assert.That(appointments.DoctorName, Is.EqualTo("Mette Skurtveit"));
    }

    [Test]
    public async Task AppointmentGetByDoctorIdEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointments/doctor/1");

        var appointment = await response.Content.ReadFromJsonAsync<List<AppointmentDTO>>();
        AppointmentDTO? seed1 = appointment.Find(a => a.DoctorName.Equals("Jan-Erik Berger"));

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(appointment.Count is not 0);
        Assert.That(seed1 is not null);
    }

    [Test]
    public async Task AppointmentGetByPatientIdEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointments/patient/1");

        var appointment = await response.Content.ReadFromJsonAsync<List<AppointmentDTO>>();
        AppointmentDTO? seed1 = appointment.Find(a => a.PatientName.Equals("Trym Berger"));

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(appointment.Count is not 0);
        Assert.That(seed1 is not null);
    }

    [Test]
    public async Task PatientCreateEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act

        PatientDTO patient = new();
        Random r = new Random();
        Int64 number = r.NextInt64();
        patient.FullName = $"Test Person {number}";

        var response = await client.PostAsJsonAsync("surgery/patients", patient);

        var newpatient = await response.Content.ReadFromJsonAsync<PatientDTO>();

        // Assert
        Assert.That(newpatient is not null);
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.Created);
        Assert.That(newpatient.FullName, Is.EqualTo($"Test Person {number}"));
    }

    [Test]
    public async Task DoctorCreateEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act

        DoctorDTO doctor = new();
        Random r = new Random();
        Int64 number = r.NextInt64();
        doctor.FullName = $"Test Doctor {number}";

        var response = await client.PostAsJsonAsync("surgery/doctors", doctor);

        var newdoctor = await response.Content.ReadFromJsonAsync<DoctorDTO>();

        // Assert
        Assert.That(newdoctor is not null);
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.Created);
        Assert.That(newdoctor.FullName, Is.EqualTo($"Test Doctor {number}"));
    }

    [Test]
    public async Task AppointmentCreateEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        DateTime time = DateTime.Now.ToUniversalTime();

        // Act

        AppointmentPost appoint = new();
        Random r = new Random();
        Int64 number = r.NextInt64();
        appoint.PatientID = 1;
        appoint.DoctorID = 1;
        appoint.Booking = time;

        var response = await client.PostAsJsonAsync("surgery/appointments", appoint);

        var newappoint = await response.Content.ReadFromJsonAsync<AppointmentDTO>();

        // Assert
        Assert.That(newappoint is not null);
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.Created);
        Assert.That(newappoint.PatientName, Is.EqualTo("Trym Berger"));
        Assert.That(newappoint.DoctorName, Is.EqualTo("Jan-Erik Berger"));
    }
}