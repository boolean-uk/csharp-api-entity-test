using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace workshop.tests;

public class Tests
{
    [TestCase("/surgery/patients", System.Net.HttpStatusCode.OK)]
    [TestCase("/surgery/patients/1", System.Net.HttpStatusCode.OK)]
    public async Task PatientEndpointStatus(string endpoint, System.Net.HttpStatusCode statusCode)
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var response = await client.GetAsync(endpoint);
        Assert.That(response.StatusCode, Is.EqualTo(statusCode));
    }
    
    [TestCase("/surgery/doctors", System.Net.HttpStatusCode.OK)]
    [TestCase("/surgery/doctors/1", System.Net.HttpStatusCode.OK)]
    public async Task DoctorEndpointStatus(string endpoint, System.Net.HttpStatusCode statusCode)
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var response = await client.GetAsync(endpoint);
        Assert.That(response.StatusCode, Is.EqualTo(statusCode));
    }
    
    [TestCase("/surgery/appointmentsbydoctor/1", System.Net.HttpStatusCode.OK)]
    [TestCase("/surgery/appointmentsbypatient/1", System.Net.HttpStatusCode.OK)]
    [TestCase("/surgery/appointment/1/1", System.Net.HttpStatusCode.OK)]
    [TestCase("/surgery/appointments", System.Net.HttpStatusCode.OK)]
    public async Task AppointmentEndpointStatus(string endpoint, System.Net.HttpStatusCode statusCode)
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var response = await client.GetAsync(endpoint);
        Assert.That(response.StatusCode, Is.EqualTo(statusCode));
    }
}