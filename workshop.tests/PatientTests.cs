using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

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
        var response1 = await client.GetAsync("/surgery/patients");
        var response2 = await client.GetAsync("/surgery/patients/1");
        var response3 = await client.GetAsync("/surgery/patients/100");

        // Assert
        Assert.IsTrue(response1.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.IsTrue(response2.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.IsTrue(response3.StatusCode == System.Net.HttpStatusCode.NotFound);
    }

    [Test]
    public async Task DoctorEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response1 = await client.GetAsync("/surgery/doctors");
        var response2 = await client.GetAsync("/surgery/doctors/1");
        var response3 = await client.GetAsync("/surgery/doctors/100");

        // Assert
        Assert.IsTrue(response1.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.IsTrue(response2.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.IsTrue(response3.StatusCode == System.Net.HttpStatusCode.NotFound);

    }

    [Test]
    public async Task AppointmentEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response1 = await client.GetAsync("/surgery/appointments");
        var response2 = await client.GetAsync("/surgery/appointmentsbydoctor/1");
        var response3 = await client.GetAsync("/surgery/appointmentsbydoctor/100");
        var response4 = await client.GetAsync("/surgery/appointmentsbypatient/1");
        var response5 = await client.GetAsync("/surgery/appointmentsbypatient/100");

        // Assert
        Assert.IsTrue(response1.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.IsTrue(response2.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.IsTrue(response3.StatusCode == System.Net.HttpStatusCode.NotFound);
        Assert.IsTrue(response4.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.IsTrue(response5.StatusCode == System.Net.HttpStatusCode.NotFound);


    }
}