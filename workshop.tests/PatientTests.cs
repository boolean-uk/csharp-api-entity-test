using Microsoft.AspNetCore.Components.Forms;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.ViewModels;

namespace workshop.tests;

public class PatientTests
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
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task GetOnePatientTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/patients/1");
        var json = await response.Content.ReadAsStringAsync();
        var patient = JsonConvert.DeserializeObject<DTOPatient>(json);

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(patient.Name, Is.EqualTo("Brian Murphy"));
    }

    [Test]
    public async Task AddPatientTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        PersonPostModel input = new PersonPostModel() { Name = "Ally Beardsley" };
        var json = new StringContent(JsonConvert.SerializeObject(input), UTF8Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync("/surgery/patients", json);
        var json_patient = await response.Content.ReadAsStringAsync();
        var patient = JsonConvert.DeserializeObject<DTOPatient>(json_patient);

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
        Assert.That(patient.Name, Is.EqualTo("Ally Beardsley"));
    }
}

public class DoctorTests
{

    [Test]
    public async Task GetDoctorsTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/doctors");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task GetOneDoctorTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/doctors/1");
        var json = await response.Content.ReadAsStringAsync();
        var doctor = JsonConvert.DeserializeObject<DTODoctor>(json);

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(doctor.Name, Is.EqualTo("Ben Doyle"));
    }

    [Test]
    public async Task AddDoctorTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        PersonPostModel input = new PersonPostModel() { Name = "Amy J. Muller" };
        var json = new StringContent(JsonConvert.SerializeObject(input), UTF8Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync("/surgery/doctors", json);
        var json_doctor = await response.Content.ReadAsStringAsync();
        var doctor = JsonConvert.DeserializeObject<DTODoctor>(json_doctor);

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
        Assert.That(doctor.Name, Is.EqualTo("Amy J. Muller"));
    }
}

public class AppointmentTests
{

    [Test]
    public async Task GetAppointmentsTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/appointments");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task GetOneAppointmentTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/appointments/1/1");
        var json = await response.Content.ReadAsStringAsync();
        var appointment = JsonConvert.DeserializeObject<DTOAppointment>(json);

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(appointment.Doctor.Name, Is.EqualTo("Ben Doyle"));
    }

    [Test]
    public async Task AddAppointmentTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        AppointmentPostModel input = new AppointmentPostModel() { year = 1001, month = 2, day = 17, hour = 4, minute = 2, doctorId = 3, patientId = 4};
        var json = new StringContent(JsonConvert.SerializeObject(input), UTF8Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync("/surgery/appointments", json);
        var json_appointment = await response.Content.ReadAsStringAsync();
        var appointment = JsonConvert.DeserializeObject<DTOAppointment>(json_appointment);

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
        Assert.That(appointment.Patient.Name, Is.EqualTo("Zac Oyama"));
    }
}