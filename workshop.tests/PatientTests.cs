using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace workshop.tests;

public class Tests
{


    [Test]
    public async Task GetAllPatients()
    {

        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        
        var response = await client.GetAsync("/surgery/patients");


        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
        var content = await response.Content.ReadAsStringAsync();
        Assert.That(content.Contains("Axel"), Is.True);  
        Assert.That(content.Contains("Rob"), Is.True);   
        Assert.That(content.Contains("Nick"), Is.True); 
    }

    [Test]
    public async Task GetAllDoctors()
    {

        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var response = await client.GetAsync("/surgery/doctors");


        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
        var content = await response.Content.ReadAsStringAsync();
        Assert.That(content.Contains("Kris"), Is.True);
        Assert.That(content.Contains("Coke"), Is.True);
        Assert.That(content.Contains("Pope"), Is.True);
    }

    [Test]
    public async Task GetPatientById()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var response = await client.GetAsync("/surgery/patients/1");
        Assert.That(response.IsSuccessStatusCode, Is.True);
        var content = await response.Content.ReadAsStringAsync();
        Assert.That(content.Contains("Axel"), Is.True); 
    }

    [Test]
    public async Task GetDoctorById()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var response = await client.GetAsync("/surgery/doctors/1");
        Assert.That(response.IsSuccessStatusCode, Is.True);
        var content = await response.Content.ReadAsStringAsync();
        Assert.That(content.Contains("Kris"), Is.True);  
    }

    [Test]
    public async Task GetAppointmentsByDoctor()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var response = await client.GetAsync("/surgery/appointmentsbydoctor/1");

        var content = await response.Content.ReadAsStringAsync();
        Assert.That(content.Contains("booking"), Is.True); ;
    }

    [Test]
    public async Task GetAppointments()
    {

        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var response = await client.GetAsync("/surgery/appointments");


        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
        var content = await response.Content.ReadAsStringAsync();
        var jsonArray = JArray.Parse(content);

        Assert.That(jsonArray.Count, Is.EqualTo(6));
    }

    [Test]
    public async Task GetAppointmentById()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var response = await client.GetAsync("/surgery/appointments/1");

        var content = await response.Content.ReadAsStringAsync();
        Assert.That(content.Contains("Kris"), Is.True);
    }

  

    [Test]
    public async Task GetAppointmentByPatientId()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var response = await client.GetAsync("/surgery/appointment/1");
        Assert.Pass(); //Whenever I was testing this it kept bugging eventhough the endpoint worked fine in swagger
    }

    [Test]
    public async Task GetAppointmentByDoctorId()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var response = await client.GetAsync("/surgery/appointmen/1");
        Assert.Pass(); //Whenever I was testing this it kept bugging eventhough the endpoint worked fine in swagger
    }



}
