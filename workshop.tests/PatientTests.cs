using Microsoft.AspNetCore.Mvc.Testing;

public class Tests
{

    [Test]
    public async Task PatientEndpointStatus()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var response = await client.GetAsync("/surgery/patients");
        var response1 = await client.GetAsync("/surgery/patients/1");

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        Assert.That(response1.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        var responseContent = await response1.Content.ReadAsStringAsync();
        Assert.That(responseContent.Contains("Nigel"), Is.True);

    }

    [Test]
    public async Task DoctorEndpointStatus()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var response = await client.GetAsync("/surgery/doctors");
        var response1 = await client.GetAsync("/surgery/doctors/1");

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        Assert.That(response1.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        var responseContent = await response1.Content.ReadAsStringAsync();
        Assert.That(responseContent.Contains("Doctor Phil"), Is.True);
    }

    [Test]
    public async Task AppointmentEndpointStatus()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var response = await client.GetAsync("/surgery/appointments");
        var response1 = await client.GetAsync("/surgery/appointments/doctor/1");
        var response2 = await client.GetAsync("/surgery/appointments/patient/1");
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(response1.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(response2.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        });
    }
}