using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Net.Http.Json;
using workshop.wwwapi.DTO;

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
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task PatientGetAllResponseTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/patients");
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.That(content, Does.Contain("name"));
        Assert.That(content, Does.Contain("Tiger Woods"));
        Assert.That(content, Does.Contain("Jack Nicklaus"));
        Assert.That(content, Does.Contain("Arnold Palmer"));
        Assert.That(content, Does.Contain("id"));
        Assert.That(content, Does.Contain("doctor"));
        Assert.That(content, Does.Contain("appointment"));
    }

    [Test]
    public async Task PatientCreateResponseTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var patient = new PatientView() { Name = "John Tester" };
        var contentJson = JsonContent.Create(patient);

        // Act
        var response = await client.PostAsync("/surgery/patients", contentJson);
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(content, Does.Contain("name"));
        Assert.That(content, Does.Contain("John Tester"));
        Assert.That(content, Does.Contain("appointment"));
        Assert.That(content, Does.Not.Contain("id")); // response for this should not include an id for now...
    }


    [Test]
    public async Task DoctorEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/doctors");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task DoctorGetAllResponseTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/doctors");
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.That(content, Does.Contain("name"));
        Assert.That(content, Does.Contain("Usain Bolt"));
        Assert.That(content, Does.Contain("Tyson Gay"));
        Assert.That(content, Does.Contain("id"));
        Assert.That(content, Does.Contain("patient"));
        Assert.That(content, Does.Contain("appointment"));
    }

    [Test]
    public async Task DoctorCreateResponseTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var patient = new DoctorView() { Name = "Dr Tester" };
        var contentJson = JsonContent.Create(patient);

        // Act
        var response = await client.PostAsync("/surgery/doctors", contentJson);
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(content, Does.Contain("name"));
        Assert.That(content, Does.Contain("Dr Tester"));
        Assert.That(content, Does.Contain("appointment"));
        Assert.That(content, Does.Not.Contain("id")); // response for this should not include an id for now...
    }

    [Test]
    public async Task AppointmentEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointments");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task AppointmentGetAllResponseTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointments");
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.That(content, Does.Contain("fullName"));
        Assert.That(content, Does.Contain("doctor"));
        Assert.That(content, Does.Contain("patient"));
        Assert.That(content, Does.Contain("id"));
        Assert.That(content, Does.Contain("Usain Bolt"));
        Assert.That(content, Does.Contain("Jack Nicklaus"));
        Assert.That(content, Does.Contain("booking"));
        Assert.That(content, Does.Contain("2024"));
    }

    // NB: This test will be successful on the first run, but not afterwards, unless you change the doctor and patient id
    // since we are using a composite key of patientid and doctorid... for some reason......
    [Test]
    public async Task AppointmentCreateResponseTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var patient = new AppointmentView() { Booking = DateTime.Parse("2024/10/10").ToUniversalTime(), DoctorId = 1, PatientId = 3 };
        var contentJson = JsonContent.Create(patient);

        // Act
        var response = await client.PostAsync("/surgery/appointments", contentJson);
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(content, Does.Contain("fullName"));
        Assert.That(content, Does.Contain("Usain Bolt"));
        Assert.That(content, Does.Contain("Arnold Palmer"));
        Assert.That(content, Does.Contain("booking"));
        Assert.That(content, Does.Contain("2024"));
    }
}