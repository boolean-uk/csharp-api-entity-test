using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;
using workshop.wwwapi.DTOs;

namespace workshop.tests;

public class Tests
{


    // Test1: PatientEndpoints
    [Test]
    public async Task PatientEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/patients");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    //Test2: Gett patiens
    
    [Test]
    public async Task TestGetPatientsEndpoint()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
       // var response = await client.GetAsync("patients/");
        var response = await client.GetFromJsonAsync<List<OutPatientDTO>>("patients/");

        // Assert
        Assert.That(response.Count, Is.AtLeast(2));
    }

    //Test3: Get a patient
    [Test]
    public async Task TestGetAPatientEndpoint()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("patients/1");
        var response2 = await client.GetAsync("patients/100");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.IsTrue(response2.StatusCode == System.Net.HttpStatusCode.NotFound);
    }


    // Test3: DoctorEndpoints
    [Test]
    public async Task DoctortEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/doctor");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    //Test3: Get Doctors
    [Test]
    public async Task TestGetDoctorsEndpoint()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
       
        var response = await client.GetFromJsonAsync<List<OutDoctorDTO>>("doctor/");

        // Assert
        Assert.That(response.Count, Is.AtLeast(2));
    }

    //Test4: Get a doctor
    [Test]
    public async Task TestGetADoctorEndpoint()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("doctor/1");
        var response2 = await client.GetAsync("doctor/100");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.IsTrue(response2.StatusCode == System.Net.HttpStatusCode.NotFound);
    }

    //Test5: Add a doctor
    [Test]
    public async Task TestAddDoctorEndpoint()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        object newDoc = new
        {
            FullName = "Test test",
           
        };

        // Act
        await client.PostAsJsonAsync("doctor/", newDoc);
        var response = await client.GetFromJsonAsync<List<OutDoctorDTO>>("doctor/");

        // Assert
        Assert.That(response.Count is 4);
    }


    // Test3: AppointmentEndpoints
    [Test]
    public async Task AppointmentEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/appointment");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    //Test6: Get all appointments
    [Test]
    public async Task TestGetAppointmentsEndpoint()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act

        var response = await client.GetFromJsonAsync<List<OutAppointmentDTO>>("appointment/");

        // Assert
        Assert.That(response.Count, Is.AtLeast(2));
    }

    //Test7: Get an appointment
    [Test]
    public async Task TestgetAnAppointmentEndpoint()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
      

        // Act
        var response = await client.GetAsync("appointment/GetAppointmentById{id}?PantientId=1&DoctorId=1");
        var response2 = await client.GetAsync("appointment/GetAppointmentById{id}?PantientId=4&DoctorId=4");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.IsTrue(response2.StatusCode == System.Net.HttpStatusCode.NotFound);
    }






}