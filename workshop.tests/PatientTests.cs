using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;

namespace workshop.tests;

public class Tests
{

    [Test]
    public async Task GetAllPatientsNameFromSeed()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/patients");

        var patients = await response.Content.ReadFromJsonAsync<List<Patient>>();

        // Assert
        Assert.That(patients.Any(p => p.FullName.Equals("Johan Reitan")));
        Assert.That(patients.Any(p => p.FullName.Equals("Georg Reitan")));
        Assert.That(patients.Any(p => p.FullName.Equals("Greta Thunberg")));
    }

    [Test]
    public async Task GetAllDoctorsNameFromSeed()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/doctors");

        var doctors = await response.Content.ReadFromJsonAsync<List<Doctor>>();

        // Assert
        Assert.That(doctors.Any(p => p.FullName.Equals("Tora Klippen")));
        Assert.That(doctors.Any(p => p.FullName.Equals("Inger Hovland")));
        Assert.That(doctors.Any(p => p.FullName.Equals("Slim Kamel")));
    }

    [Test]
    public async Task GetAllAppointmentsBookingFromSeed()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointments");

        var appointments = await response.Content.ReadFromJsonAsync<List<Appointment>>();

        // Assert
        Assert.That(appointments.Any(a => a.Booking.Equals(DateTime.Parse("2020-05-04 20:04:30").ToUniversalTime())));
        Assert.That(appointments.Any(a => a.Booking.Equals(DateTime.Parse("2020-05-04 21:04:30").ToUniversalTime())));
    }

    [Test]
    public async Task GetPatientById()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/patients1");

        var patient = await response.Content.ReadFromJsonAsync<Patient>();

        // Assert
        Assert.That(patient.FullName.Equals("Johan Reitan"));
    }

    [Test]
    public async Task GetDoctorById()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/doctors1");

        var doctor = await response.Content.ReadFromJsonAsync<Doctor>();

        // Assert
        Assert.That(doctor.FullName.Equals("Tora Klippen"));
    }

    [Test]
    public async Task GetAppointmentById()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointments2");

        var appointment = await response.Content.ReadFromJsonAsync<AppointmentGet>();

        // Assert
        Assert.That(appointment.Doctor_fullName.Equals("Tora Klippen"));
    }

    [Test]
    public async Task GetAppointmentsByDoctor()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointmentsbydoctor/1");

        var appointments = await response.Content.ReadFromJsonAsync<List<AppointmentGet>>();

        // Assert
        Assert.That(appointments.All(a => a.Doctor_fullName.Equals("Tora Klippen")));
    }

    [Test]
    public async Task GetAppointmentsByPatients()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointmentsbypatient/1");

        var appointments = await response.Content.ReadFromJsonAsync<List<AppointmentGet>>();

        // Assert
        Assert.That(appointments.All(a => a.Patient_fullName.Equals("Johan Reitan")));
    }


    [Test]
    public async Task CreateDoctor()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.PostAsJsonAsync("/surgery/doctors", new DoctorPost() { FullName = "Jesus Christ Superstar"} );

        var doctor = await response.Content.ReadFromJsonAsync<DoctorGet>();

        // Assert
        Assert.That(doctor.FullName.Equals("Jesus Christ Superstar"));
    }

    [Test]
    public async Task CreatePatient()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.PostAsJsonAsync("/surgery/patients", new PatientPost() { FullName = "Chris Joslin" } );

        var patient = await response.Content.ReadFromJsonAsync<PatientGet>();

        // Assert
        Assert.That(patient.FullName.Equals("Chris Joslin"));
    }

    [Test]
    public async Task CreateAppointment()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.PostAsJsonAsync("/surgery/appointments", new AppointmentPost() { Booking = DateTime.MinValue.ToUniversalTime(), DoctorId = 1, PatientId = 1 });

        var appointment = await response.Content.ReadFromJsonAsync<AppointmentGet>();

        // Assert
        Assert.That(appointment.Patient_fullName.Equals("Johan Reitan"));
    }
}