using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace workshop.tests;

[TestFixture]
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
        var response1 = await client.GetAsync("/surgery/patients/1");
        var response2 = await client.GetAsync("/surgery/patients/3");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK, Is.True);
        Assert.That(response1.StatusCode == System.Net.HttpStatusCode.OK, Is.True);
        Assert.That(response2.StatusCode == System.Net.HttpStatusCode.NotFound, Is.True);
    }

    [Test]
    public async Task DoctorEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/doctors");
        var response1 = await client.GetAsync("/surgery/doctors/1");
        var response2 = await client.GetAsync("/surgery/doctors/3");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK, Is.True);
        Assert.That(response1.StatusCode == System.Net.HttpStatusCode.OK, Is.True);
        Assert.That(response2.StatusCode == System.Net.HttpStatusCode.NotFound, Is.True);
    }

    [Test]
    public async Task AppointmentEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointments");
        var response1 = await client.GetAsync("/surgery/appointments/1/1");
        var response2 = await client.GetAsync("/surgery/appointments/1/3");
        var response3 = await client.GetAsync("/surgery/appointmentsbydoctor/1");
        var response4 = await client.GetAsync("/surgery/appointmentsbypatient/1");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK, Is.True);
        Assert.That(response1.StatusCode == System.Net.HttpStatusCode.OK, Is.True);
        Assert.That(response2.StatusCode == System.Net.HttpStatusCode.BadRequest, Is.True);
        Assert.That(response3.StatusCode == System.Net.HttpStatusCode.OK, Is.True);
        Assert.That(response4.StatusCode == System.Net.HttpStatusCode.OK, Is.True);
    }
}