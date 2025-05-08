using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace workshop.tests;

public class Tests
{

    [Test]
    public async Task PatientEndpointTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        // Act
        var getAllResponse = await client.GetAsync("/patients/");
        var getResponse = await client.GetAsync("/patients/1");
        var getResponseString = await getResponse.Content.ReadAsStringAsync();
        // Assert
        Assert.IsTrue(getResponse.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.IsTrue(getResponse.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(getResponseString.Contains("Anna Smith"));
    }

    [Test]
    public async Task DoctorEndpointTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        // Act
        var getAllResponse = await client.GetAsync("/doctors/");
        var getResponse = await client.GetAsync("/doctors/1");
        var getResponseString = await getResponse.Content.ReadAsStringAsync();
        // Assert
        Assert.IsTrue(getResponse.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.IsTrue(getResponse.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(getResponseString.Contains("Joseph Morecola"));
    }

    [Test]
    public async Task AppointmentEndpointTest()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        // Act
        var getAllResponse = await client.GetAsync("/appointments/");
        var getResponse = await client.GetAsync("/appointments/1");
        var getByDoctorIDResponse = await client.GetAsync("/doctors/1/appointments");
        var getByPatientIDResponse = await client.GetAsync("/patients/1/appointments");
        var getResponseString = await getResponse.Content.ReadAsStringAsync();
        var getByDoctorIDResponseString = await getByDoctorIDResponse.Content.ReadAsStringAsync();
        var getByPatientIDResponseString = await getByPatientIDResponse.Content.ReadAsStringAsync();
        // Assert
        Assert.IsTrue(getResponse.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.IsTrue(getResponse.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(getResponseString.Contains("Anna Smith"));
        Assert.That(getResponseString.Contains("Joseph Morecola"));
        Assert.That(getResponseString.Contains("2024"));
        Assert.That(getByDoctorIDResponseString.Contains("Anna Smith"));
        Assert.That(getByPatientIDResponseString.Contains("Joseph Morecola"));
    }
}