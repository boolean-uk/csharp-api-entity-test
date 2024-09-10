using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Text;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;

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
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task DoctorsEndpointStatus()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var response = await client.GetAsync("surgery/doctors");

        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

    }

    [Test]
    public async Task AppointmentsEndpointStatus()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var response = await client.GetAsync("surgery/appointments");

        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

    }

    [Test]
    public async Task CreatePatientEndpointStatus()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        DTOPatient inputPatient = new DTOPatient() { PatientName = "Nigel Rocks" };
        var json = new StringContent(JsonConvert.SerializeObject(inputPatient), UTF8Encoding.UTF8, "application/json");


        var response = await client.PostAsync("surgery/patients/{patientName}", json);

        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

    }

    [Test]
    public async Task CreateDoctorEndpointStatus()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        Doctor inputDoctor = new Doctor() { FullName = "Liza Kunis" };
        var json = new StringContent(JsonConvert.SerializeObject(inputDoctor), UTF8Encoding.UTF8, "application/json");


        var response = await client.PostAsync("surgery/patients/{doctorname}", json);

        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

    }

}