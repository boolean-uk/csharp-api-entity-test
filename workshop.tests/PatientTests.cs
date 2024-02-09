using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Linq.Expressions;
using System.Net.Http.Json;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;

namespace workshop.tests;

public class Tests
{


    // Patient Tests

    [Test]
    public async Task PatientEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/patients");
        var response1 = await client.GetAsync("/surgery/patients/1");
        //var response2 = await client.PostAsync("/surgery/create_a_patient", );


        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(response1.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task PatientResponseTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        //Expected
        var expectedPatientPayload = new List<Patient>()
        {
            new Patient { Id = 1, FullName = "Marcus" },
            new Patient { Id = 2, FullName = "Anna" },
            new Patient { Id = 3, FullName = "Pontus"},
           
        };

        // Act
        var response = await client.GetAsync("/surgery/patients");
        
        var responsePayload = response.Content.ReadFromJsonAsync<IEnumerable<patientDTO>>();
        
        // Assert

        Assert.That(responsePayload != null);

        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);

        Assert.That(responsePayload.Result.Count, Is.EqualTo(expectedPatientPayload.Count));
        for(int i = 0; i < expectedPatientPayload.Count; i++)
        {
            Assert.That(responsePayload.Result.ElementAtOrDefault(i).id, Is.EqualTo(expectedPatientPayload[i].Id));
            Assert.That(responsePayload.Result.ElementAtOrDefault(i).name, Is.EqualTo(expectedPatientPayload[i].FullName));
        }

    }


    //Doctor Tests


    [Test]
    public async Task DoctorEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/doctors");
        var response1 = await client.GetAsync("/surgery/doctors/1");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(response1.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task DoctorResponseTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        //Expected
        var expectedDoctorPayload = new List<doctorDTO>()
        {
            new doctorDTO(new Doctor { Id = 1, FullName = "Victor"}),
            new doctorDTO (new Doctor { Id = 2, FullName = "Oliver"}),
            new doctorDTO (new Doctor { Id = 3, FullName = "James"})

        };

        // Act
        var response = await client.GetAsync("/surgery/doctors");

        var responsePayload = response.Content.ReadFromJsonAsync<IEnumerable<doctorDTO>>();

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);

        Assert.That(responsePayload.Result.Count, Is.EqualTo(expectedDoctorPayload.Count));
        for (int i = 0; i < expectedDoctorPayload.Count; i++)
        {
            Assert.That(responsePayload.Result.ElementAtOrDefault(i).id, Is.EqualTo(expectedDoctorPayload[i].id));
            Assert.That(responsePayload.Result.ElementAtOrDefault(i).name, Is.EqualTo(expectedDoctorPayload[i].name));
        }

    }


    //Appointment Tests




    [Test]
    public async Task AppointmentEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        DateTime dateTime = DateTime.Parse("1954-01-01 23:59:59 +0000").ToUniversalTime();
        var obj = new {DoctorId = 3, PatientId = 1, appointmentDate = dateTime };
        
        // Act
        var response = await client.GetAsync("/surgery/appointments");
        var response1 = await client.GetAsync($"/surgery/appointments/patient_and_doctor/1/1");
        var response2 = await client.GetAsync("/surgery/appointments/doctor/1");
        var response3 = await client.GetAsync("/surgery/appointments/patient/1");
        //var response4 = await client.PostAsJsonAsync("/surgery/appointments", obj);

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(response1.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(response2.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(response3.StatusCode == System.Net.HttpStatusCode.OK);
        //Assert.That(response4.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task AppointmentResponseTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        //Expected
        DateTime dateTime = DateTime.Parse("1954-01-01 23:59:59 +0000").ToUniversalTime();
        
        
        var expectedAppointmentPayload = new List<Appointment>()
        {
            new Appointment() {DoctorId = 2, PatientId = 1, appointmentDate = dateTime},//    0
            new Appointment() {DoctorId = 1, PatientId = 1, appointmentDate = dateTime},//    1
            new Appointment() {DoctorId = 3, PatientId = 2, appointmentDate = dateTime},//    2
            new Appointment() {DoctorId = 1, PatientId = 2, appointmentDate = dateTime},//    3
            new Appointment() {DoctorId = 3, PatientId = 3, appointmentDate = dateTime},//    4
            new Appointment() {DoctorId = 2, PatientId = 3, appointmentDate = dateTime},//    5
            //new Appointment() {DoctorId = 3, PatientId = 1, appointmentDate = dateTime}

        };

        // Act
        var response = await client.GetAsync("/surgery/appointments");

        var responsePayload = response.Content.ReadFromJsonAsync<IEnumerable<Appointment>>();

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

        Assert.That(responsePayload.Result.Count, Is.EqualTo(expectedAppointmentPayload.Count));
        for (int i = 0; i < expectedAppointmentPayload.Count; i++)
        {
            //went through and tested each value individualy (replased i with a number in the table 0-5). for some reason some of the appointments in the table has switched orders in the table
            Assert.That(responsePayload.Result.ElementAtOrDefault(i).DoctorId, Is.EqualTo(expectedAppointmentPayload[i].DoctorId));
            Assert.That(responsePayload.Result.ElementAtOrDefault(i).PatientId, Is.EqualTo(expectedAppointmentPayload[i].PatientId));
           
            Assert.That(responsePayload.Result.ElementAtOrDefault(i).appointmentDate, Is.EqualTo(expectedAppointmentPayload[i].appointmentDate));
        }

    }

    
}