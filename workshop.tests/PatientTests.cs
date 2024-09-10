using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Repository;

namespace workshop.tests;

public class Tests
{

    [Test]
    public async Task GetPatientsEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/patients");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task GetPatientEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/patient/1");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task CreatePatientEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();


        // Act
        var response = await client.GetAsync("/surgery/createpatient");

        // Assert

    }
    [Test]
    public async Task GetDoctorsEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();


        // Act
        var response = await client.GetAsync("/surgery/doctors");

        // Assert

    }
    [Test]
    public async Task GetDoctorEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();


        // Act
        var response = await client.GetAsync("/surgery/doctor/1");

        // Assert

    }
    [Test]
    public async Task CreateDoctorEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();


        // Act
        var response = await client.GetAsync("/surgery/createdoctor");

        // Assert

    }
    [Test]
    public async Task GetAppointmentsEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();


        // Act
        var response = await client.GetAsync("/surgery/appointments");

        // Assert


    }

    [Test]
    public async Task GetAppointmentDrAndPatientEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();


        // Act
        var response = await client.GetAsync("/surgery/appointmentsbydoctorandpatient");

        // Assert

    }
    [Test]
    public async Task GetAppointmentPatientEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();


        // Act
        var response = await client.GetAsync("/surgery/appointmentsbypatient");

        // Assert

    }
    [Test]
    public async Task GetAppointmentDrEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();


        // Act
        var response = await client.GetAsync("/surgery/appointmentsbydoctor");

        // Assert

    }
    [Test]
    public async Task CreateAppointmentEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();


        // Act
        var response = await client.GetAsync("/surgery/createappointment");

        // Assert

    }
}