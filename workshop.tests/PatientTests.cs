using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.tests;

public class Tests
{
    [Test]
    public async Task PatientEndpoint()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        client.Timeout = TimeSpan.FromSeconds(15);

        // Act
        //Console.WriteLine(response.ToString());

        // Assert
        var response = await client.GetAsync("/surgery/patients");
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
        var res = await response.Content.ReadFromJsonAsync<List<PatientGetDTO>>();
        Assert.That(
            res,
            Is.Not.Not.Not.Not.Not.Not.Not.Not.Not.Not.Not.Not.Not.Not.Not.Not.Not.Null
        );
        Assert.That(res![0].FullName, Is.EqualTo("Patient Boberson"));

        var postPatient = new PatientPostDto { FullName = "testman" };
        var response3 = await client.PostAsJsonAsync("/surgery/patient/create", postPatient);
        Assert.That(response3.StatusCode == System.Net.HttpStatusCode.OK);
        var res3 = await response3.Content.ReadFromJsonAsync<PatientGetDTO>();
        Assert.That(res3, Is.Not.Null);
        Assert.That(res3!.FullName, Is.EqualTo("testman"));
    }

    [Test]
    public async Task PatientGetOne()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        client.Timeout = TimeSpan.FromSeconds(15);
        var response2 = await client.GetAsync("/surgery/patient/1");
        Assert.That(response2.StatusCode == System.Net.HttpStatusCode.OK);
        var res2 = await response2.Content.ReadFromJsonAsync<PatientGetDTO>();
        Assert.That(res2, Is.Not.Null);
        Assert.That(res2!.FullName, Is.EqualTo("Patient Boberson"));
    }

    [Test]
    public async Task DoctorTest()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        client.Timeout = TimeSpan.FromSeconds(15);

        var res1 = await client.GetAsync("/surgery/doctors");
        Assert.That(res1.StatusCode == System.Net.HttpStatusCode.OK);
        var ent1 = await res1.Content.ReadFromJsonAsync<List<DoctorGetDto>>();
        Assert.That(ent1, Is.Not.Null);
        Assert.That(ent1![0].FullName, Is.EqualTo("Bob Boberson"));

        var res2 = await client.GetAsync("/surgery/doctor/1");
        Assert.That(res2.StatusCode == System.Net.HttpStatusCode.OK);
        var ent2 = await res2.Content.ReadFromJsonAsync<DoctorGetDto>();
        Assert.That(ent2, Is.Not.Null);
        Assert.That(ent2!.FullName, Is.EqualTo("Bob Boberson"));

        var postDoc = new DoctorPostDto { FullName = "testman" };
        var res3 = await client.PostAsJsonAsync("/surgery/doctor/create", postDoc);
        Assert.That(res3.StatusCode == System.Net.HttpStatusCode.OK);
        var ent3 = await res3.Content.ReadFromJsonAsync<DoctorGetDto>();
        Assert.That(ent3, Is.Not.Null);
        Assert.That(ent3!.FullName, Is.EqualTo("testman"));
    }

    [Test]
    public async Task AppByDoc()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        client.Timeout = TimeSpan.FromSeconds(15);

        var res1 = await client.GetAsync("/surgery/appointmentsbydoctor/1");
        Assert.That(res1.StatusCode == System.Net.HttpStatusCode.OK);
        var ent1 = await res1.Content.ReadFromJsonAsync<List<AppointmentWithoutDoctor>>();
        Assert.That(ent1, Is.Not.Null);
        Assert.That(ent1![0].PatientId, Is.EqualTo(1));
    }

    [Test]
    public async Task AppByPat()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        client.Timeout = TimeSpan.FromSeconds(15);

        var res1 = await client.GetAsync("/surgery/appointmentsbypatient/1");
        Assert.That(res1.StatusCode == System.Net.HttpStatusCode.OK);
        var ent1 = await res1.Content.ReadFromJsonAsync<List<AppointmentWithoutPatient>>();
        Assert.That(ent1, Is.Not.Null);
        Assert.That(ent1![0].DoctorId, Is.EqualTo(1));
    }

    [Test]
    public async Task Apps()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        client.Timeout = TimeSpan.FromSeconds(15);

        var res1 = await client.GetAsync("/surgery/appointments");
        Assert.That(res1.StatusCode == System.Net.HttpStatusCode.OK);
        var ent1 = await res1.Content.ReadFromJsonAsync<List<AppointmentGetDto>>();
        Assert.That(ent1, Is.Not.Null);
        Assert.That(ent1![0].DoctorId, Is.EqualTo(1));
        Assert.That(ent1![0].PatientId, Is.EqualTo(1));
    }

    [Test]
    public async Task App()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        client.Timeout = TimeSpan.FromSeconds(15);

        var res = await client.GetAsync("/surgery/appointment/1");
        Assert.That(res.StatusCode == System.Net.HttpStatusCode.OK);
        var ent = await res.Content.ReadFromJsonAsync<AppointmentGetDto>();
        Assert.That(ent, Is.Not.Null);
        Assert.That(ent!.DoctorId, Is.EqualTo(1));
        Assert.That(ent!.PatientId, Is.EqualTo(1));
    }

    [Test]
    public async Task CreateApp()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        client.Timeout = TimeSpan.FromSeconds(15);

        var postApp = new AppointmentPostDto
        {
            DoctorId = 2,
            PatientId = 2,
            Booking = DateTime.UtcNow,
        };
        var res = await client.PostAsJsonAsync("/surgery/appointment/create", postApp);
        Assert.That(res.StatusCode == System.Net.HttpStatusCode.OK);
        var ent = await res.Content.ReadFromJsonAsync<AppointmentGetDto>();
        Assert.That(ent, Is.Not.Null);
        Assert.That(ent!.DoctorId, Is.EqualTo(2));
        Assert.That(ent!.PatientId, Is.EqualTo(2));
    }
}

