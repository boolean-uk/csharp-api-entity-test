using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;

namespace workshop.tests;

public class Tests
{

    [Test]
    public async Task GetAllPatientsTest()
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
    public async Task GetPatientByIdTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/patients/1");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    //[Test]
    //public async Task CreatePatientTest()
    //{
    //    // Arrange
    //    var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
    //    var client = factory.CreateClient();

    //    var patient = new PostPatientDTO() { FullName = "John" };
    //    var payload = JsonConvert.SerializeObject(patient);
    //    var content = new StringContent(payload, Encoding.UTF8, "application/json");

    //    // Act
    //    var response = await client.PostAsync("/surgery/patients", content);

    //    // Assert
    //    Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    //    //Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    //}

    [Test]
    public async Task GetAllDoctorsTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/doctors");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task GetDoctorByIdTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/doctors/1");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    //[Test]
    //public async Task CreateDoctorTest()
    //{
    //    // Arrange
    //    var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
    //    var client = factory.CreateClient();

    //    var doctor = new PostDoctorDTO() { FullName="Doctor Peterson" };
    //    var payload = JsonConvert.SerializeObject(doctor);
    //    var content = new StringContent(payload, Encoding.UTF8, "application/json");

    //    // Act
    //    var response = await client.PostAsync("/surgery/doctors", content);

    //    // Assert
    //    Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    //    //Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    //}

    [Test]
    public async Task GetAppointmentsByDoctorIdTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointmentsbydoctor/1");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task GetAppointmentsByPatientIdTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointmentsbypatient/1");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task GetAppointmentByIdTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointments/{id}?bookingTime=2024-09-09T07%3A22%3A48.555134Z&doctorId=1&patientId=2");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    //[Test]
    //public async Task CreateAppointmentTest()
    //{
    //    // Arrange
    //    var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
    //    var client = factory.CreateClient();

    //    var appointment = new PostAppointmentDTO() { Booking = DateTime.UtcNow.ToString(), DoctorId=1, PatientId=2 };
    //    var payload = JsonConvert.SerializeObject(appointment);
    //    var content = new StringContent(payload, Encoding.UTF8, "application/json");

    //    // Act
    //    var response = await client.PostAsync("/surgery/appointments", content);

    //    // Assert
    //    Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    //    //Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    //}
}