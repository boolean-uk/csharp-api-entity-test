using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Text;
using workshop.wwwapi.Models;

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
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }
    
    [Test]
    public async Task DoctorEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/doctors");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task GetPatientEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/patient/1");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task GetDoctorEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/doctor/1");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task PatientAppointmentEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/appointmentsbypatient/1");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task DoctorAppointmentEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/appointmentsbydoctor/1");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }
    [Test]
    public async Task CreateDoctor()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        // Act
        var response = await client.PostAsync("surgery/doctors/{FullName}?doctor=Per%20Ola%20Normann", null);

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task CreateAppointment()//Will only work once since its a composit key :)
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        // Act
        var response = await client.PostAsync("surgery/appointments/5/2", null);

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }
}