using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Text;
using workshop.wwwapi.Repository;
using workshop.wwwapi.ViewModel;

namespace workshop.tests;

public class Tests
{

    //[Test]
    //public async Task PatientEndpointStatus()
    //{
    //    // Arrange
    //    var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
    //    var client = factory.CreateClient();

    //    // Act
    //    var response = await client.GetAsync("/patients");

    //    // Assert
    //    Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    //}

    [Test]
    public async Task CreatePatient()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        InputDTO input = new InputDTO() { FullName = "Crazy Patient" };
        var json = new StringContent(JsonConvert.SerializeObject(input), UTF8Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync("/patients/Create", json);

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
    }

    [Test]
    public async Task GetPatients()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/patients/GetAll");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task GetPatient()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync($"/patients/GetById{1}");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task CreateDoctor()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        InputDTO input = new InputDTO() { FullName = "Subpar Doctor" };
        var json = new StringContent(JsonConvert.SerializeObject(input), UTF8Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync("/doctors/Create", json);

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
    }

    [Test]
    public async Task GetDoctors()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/doctors/GetAll");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task GetDoctor()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync($"/doctors/GetById{1}");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task CreateAppointment()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        InputAppointmentDTO input = new InputAppointmentDTO { doctorId = 1, patientId = 1 };
        var json = new StringContent(JsonConvert.SerializeObject(input), UTF8Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync("/appointments/Create", json);

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
    }

    [Test]
    public async Task GetAppointments()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/appointments/GetAll");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task GetAppointment()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync($"/appointments/GetById{1}");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task GetAppointmentsByDoctor()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync($"/appointments/GetByDoctorId{1}");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task GetAppointmentsByPatient()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync($"/appointments/GetByPatientId{1}");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }
}