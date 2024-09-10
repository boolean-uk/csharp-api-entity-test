using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using System.Text;
using workshop.wwwapi.DTO;
using workshop.wwwapi.ViewModels;

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
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    }

    [Test]
    public async Task GetPatients()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var response = await client.GetAsync("surgery/patients");
        var content = await response.Content.ReadAsStringAsync();

        Assert.Multiple(() =>
        {
            Assert.That(content, Is.Not.Null.Or.Empty);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        });
    }

    [Test]
    public async Task CreatePatient()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        PatientPostModel input = new PatientPostModel() { FullName = "Crazy Patient" };

        var response = await client.PostAsJsonAsync("surgery/patients/", input);
        var content = await response.Content.ReadAsStringAsync();

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
            Assert.That(content, Is.Not.Null.Or.Empty);
        });
    }


    [Test]
    public async Task GetDoctors()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var response = await client.GetAsync("surgery/doctors");
        var content = await response.Content.ReadAsStringAsync();

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(content, Is.Not.Null.Or.Empty);
        });
    }

    [Test]
    public async Task CreateDoctor()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        DoctorPostModel input = new () { FullName = "Crazy Patient" };

        var response = await client.PostAsJsonAsync("surgery/doctors/", input);
        var content = await response.Content.ReadAsStringAsync();

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
            Assert.That(content, Is.Not.Null.Or.Empty);
        });
    }

    [Test]
    public async Task GetAppointments()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var response = await client.GetAsync("surgery/appointments");
        var content = await response.Content.ReadAsStringAsync();

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(content, Is.Not.Null.Or.Empty);
        });
    }

    [Test]
    public async Task CreateAppointment()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        AppointmentPostModel input = new AppointmentPostModel() { Booking = DateTime.UtcNow, DoctorId = 2, PatientId = 4 };

        var response = await client.PostAsJsonAsync("surgery/appointments/", input);
        var content = await response.Content.ReadAsStringAsync();

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
            Assert.That(content, Is.Not.Null.Or.Empty);
        });
    }

}