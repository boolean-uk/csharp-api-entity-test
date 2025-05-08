using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using workshop.wwwapi.DTO;
using System.Net.Http.Json;


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
        var response = await client.GetAsync("/surgery/patients");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task PatientEndpointSeedData()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        // Act
        var response = await client.GetAsync("/surgery/patients");
        response.EnsureSuccessStatusCode();

        var patients = await response.Content.ReadFromJsonAsync<List<PatientDTO>>();

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(patients, Is.Not.Null);

        // Verify the seeded data
        Assert.That(patients[0].FullName, Is.EqualTo("Martin Marson"));
        Assert.That(patients[1].FullName, Is.EqualTo("Bob Bobson"));
        Assert.That(patients[2].FullName, Is.EqualTo("Alice Alisson"));
    }

    [Test]
    public async Task DoctorEndpointSeedData()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        // Act
        var response = await client.GetAsync("/surgery/doctors");
        response.EnsureSuccessStatusCode();

        var doctors = await response.Content.ReadFromJsonAsync<List<DoctorDTO>>();

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(doctors, Is.Not.Null);

        // Verify the seeded data
        Assert.That(doctors[0].FullName, Is.EqualTo("Mike Mikeson"));
        Assert.That(doctors[1].FullName, Is.EqualTo("Robin Robinson"));
    }

    [Test]
    public async Task AppointmentsEndpointSeedData()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        // Act
        var response = await client.GetAsync("/surgery/appointments");
        response.EnsureSuccessStatusCode();

        var data = await response.Content.ReadFromJsonAsync<List<AppointmentDTO>>();

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(data, Is.Not.Null);

        // Verify the seeded data
        Assert.That(data[0].DoctorId, Is.EqualTo(1));
        Assert.That(data[0].PatientId, Is.EqualTo(1));
        Assert.That(data[1].DoctorId, Is.EqualTo(2));
        Assert.That(data[1].PatientId, Is.EqualTo(3));
    }

    [Test]
    public async Task TestGetPatientByID()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        // Act
        var response = await client.GetAsync("/surgery/patients/1");
        response.EnsureSuccessStatusCode();

        var data = await response.Content.ReadFromJsonAsync<PatientDTO>();

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(data, Is.Not.Null);

        // Verify the seeded data
        Assert.That(data.FullName, Is.EqualTo("Martin Marson"));
    }

    [Test]
    public async Task TestGetDoctorByID()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        // Act
        var response = await client.GetAsync("/surgery/doctors/1");
        response.EnsureSuccessStatusCode();

        var data = await response.Content.ReadFromJsonAsync<DoctorDTO>();

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(data, Is.Not.Null);

        // Verify the seeded data
        Assert.That(data.FullName, Is.EqualTo("Mike Mikeson"));
    }

    [Test]
    public async Task TestGetAppointmentByID()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        // Act
        var response = await client.GetAsync("/surgery/appointments/1/1");
        response.EnsureSuccessStatusCode();

        var data = await response.Content.ReadFromJsonAsync<AppointmentDTO>();

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(data, Is.Not.Null);

        // Verify the seeded data
        Assert.That(data.DoctorName, Is.EqualTo("Mike Mikeson"));
        Assert.That(data.PatientName, Is.EqualTo("Martin Marson"));
    }

    [Test]
    public async Task CreatePatient()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        //Act
        var input = new PatientPost() { FullName = "Test Patient" };

        var response = await client.PostAsJsonAsync("surgery/patients/", input);
        var data = await response.Content.ReadFromJsonAsync<PatientDTO>();

        //Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(data, Is.Not.Null);

        Assert.That(data.FullName, Is.EqualTo($"{input.FullName}"));
    }

    [Test]
    public async Task CreateDoctor()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        //Act
        var input = new DoctorPost() { FullName = "Test Doctor" };

        var response = await client.PostAsJsonAsync("surgery/doctors/", input);
        var data = await response.Content.ReadFromJsonAsync<DoctorDTO>();

        //Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(data, Is.Not.Null);

        Assert.That(data.FullName, Is.EqualTo($"{input.FullName}"));
    }

    [Test]
    public async Task CreateAppointment()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        //Act 
        var input = new AppointmentPost() { Booking = new DateTime(2025, 2, 03, 10, 0, 0, DateTimeKind.Utc), DoctorId = 3, PatientId = 3 };

        var response = await client.PostAsJsonAsync("surgery/appointments/", input);
        var data = await response.Content.ReadFromJsonAsync<AppointmentDTO>();

        //Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(data, Is.Not.Null);

        Assert.That(data.DoctorId, Is.EqualTo(input.DoctorId));
        Assert.That(data.PatientId, Is.EqualTo(input.PatientId));
    }
}