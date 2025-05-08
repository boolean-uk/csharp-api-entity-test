using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Payload;

namespace workshop.tests;

public class Tests
{

    [Test]
    public async Task PatientEndpointsStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/patients");
        var status = response.StatusCode;
        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    }

    [Test]
    public async Task DoctorEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/doctors");
        var status = response.StatusCode;
        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    }

    [Test]
    public async Task AppointmentsEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointments");
        var status = response.StatusCode;
        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    }

    [Test]
    public async Task CreatePatientOnlyCreatesUniquePatients()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        Random r = new Random();

        // Act
        var patientDTO = new CreatePatientDTO() {FullName = "Patient patientson"};
        var content = new StringContent(JsonSerializer.Serialize(patientDTO), Encoding.UTF8, "application/json");
        var responsePost = await client.PostAsync("/surgery/patients", content);
        

        var response2 = await client.PostAsync("/surgery/patients", content);

        var status = response2.StatusCode;
        
        // Assert
        Assert.That(response2.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Conflict));
        
    }

    [Test]
    public async Task CreateDoctorOnlyCreatesUniquePatients()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        Random r = new Random();

        // Act
        var patientDTO = new CreateDoctorDTO() {FullName = "Patient patientson"};
        var content = new StringContent(JsonSerializer.Serialize(patientDTO), Encoding.UTF8, "application/json");
        await client.PostAsync("/surgery/doctors", content);
        

        var responsePost = await client.PostAsync("/surgery/doctors", content);

        
        // Assert
        Assert.That(responsePost.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Conflict));
        
    }

    [Test]
    public async Task CreateAppointmentsOnlyCreatesUniquePatients()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
       

        // Act
        var patientDTO = new CreateAppointmentDTO() {DoctorId = 1, PatientId = 2, Booking = DateTime.Now.ToUniversalTime()};
        var content = new StringContent(JsonSerializer.Serialize(patientDTO), Encoding.UTF8, "application/json");
        var responsePost = await client.PostAsync("/surgery/appointment", content);
        

        var response2 = await client.PostAsync("/surgery/appointment", content);

        var status = response2.StatusCode;
        
        // Assert
        Assert.That(response2.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Conflict));
        
    }

    [Test]
    public async Task CreatePatientCreatesPatient()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
       

        // Act
        string fullname = "Patient patientson the second";
        var patientDTO = new CreatePatientDTO() {FullName = fullname};
        var content = new StringContent(JsonSerializer.Serialize(patientDTO), Encoding.UTF8, "application/json");
        await client.PostAsync("/surgery/patients", content);
        
      
        var response = await client.GetAsync("/surgery/patients");
        var result = await response.Content.ReadFromJsonAsync<Payload<IEnumerable<PatientGetDTO>>>();
        
        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        Assert.That(result.Data.Any(p => p.FullName == fullname));

        
    }

        [Test]
    public async Task CreateDoctorCreatesDoctor()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
      

        // Act
        string fullname = "Doctor Doctorson the second";
        var doctorDTO = new CreatePatientDTO() {FullName = fullname};
        var content = new StringContent(JsonSerializer.Serialize(doctorDTO), Encoding.UTF8, "application/json");
        await client.PostAsync("/surgery/doctors", content);
        
      
        var response = await client.GetAsync("/surgery/doctors");
        var result = await response.Content.ReadFromJsonAsync<Payload<IEnumerable<DoctorGetDTO>>>();
        
        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        Assert.That(result.Data.Any(p => p.FullName == fullname));

        
    }

        [Test]
    public async Task CreateAppointmentCreatesAppointment()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        

        // Act
        DateTime now = DateTime.Now.ToUniversalTime();
        int doctorId = 1;
        int patientId = 2;
        CreateAppointmentDTO a = new CreateAppointmentDTO(){DoctorId = doctorId, PatientId = patientId, Booking = now};
        var content = new StringContent(JsonSerializer.Serialize(a), Encoding.UTF8, "application/json");
        var re1 = await client.PostAsync("/surgery/appointment", content);
        var r1 = await re1.Content.ReadFromJsonAsync<Payload<AppointmentGetDTO>>();
      
        var response = await client.GetAsync("/surgery/appointments");
        var result = await response.Content.ReadFromJsonAsync<Payload<IEnumerable<AppointmentGetDTO>>>();
        
        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        

        Assert.That(result.Data.Any(a => a.Doctor == "Dr. Audrey Hepburn" && a.Patient == "Lowe Trump"));

        
    }
    
}