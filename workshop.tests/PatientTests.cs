using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Net.WebSockets;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using workshop.wwwapi.Data;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.tests;

public class Tests
{
    [Test]
    public async Task GetAllPatients()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var testPatients = new List<Patient>()
        {
            new Patient { Id = 1, FullName = "Victor Adamson" },
            new Patient { Id = 2, FullName = "Name Namesson" },
            new Patient { Id = 3, FullName = "John Smith" },
            new Patient { Id = 4, FullName = "Person MacPersonface" },
            new Patient { Id = 5, FullName = "Phill Collins" }
        };

        var response = await client.GetAsync("/surgery/patients");
        var responsePayload = response.Content.ReadFromJsonAsync<IEnumerable<Patient>>();

        Assert.That(responsePayload.Result.Count(), Is.EqualTo(testPatients.Count));
        for(int i = 0; i < testPatients.Count; i++)
        {
            Assert.That(responsePayload.Result.ElementAtOrDefault(i).Id, Is.EqualTo(testPatients[i].Id));
            Assert.That(responsePayload.Result.ElementAtOrDefault(i).FullName, Is.EqualTo(testPatients[i].FullName));
        }
    }
    [Test]
    public async Task GetAllDoctors()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var testDoctors = new List<Doctor>()
        {
            new Doctor { Id = 1, FullName = "Old Beardo"},
            new Doctor { Id = 2, FullName = "Dr Strangelove"},
            new Doctor { Id = 3, FullName = "Krieger"}
        };

        var response = await client.GetAsync("/surgery/doctors");
        var responsePayload = response.Content.ReadFromJsonAsync<IEnumerable<Doctor>>();

        Assert.That(responsePayload.Result.Count(), Is.EqualTo(testDoctors.Count));
        for (int i = 0; i < testDoctors.Count; i++)
        {
            Assert.That(responsePayload.Result.ElementAtOrDefault(i).Id, Is.EqualTo(testDoctors[i].Id));
            Assert.That(responsePayload.Result.ElementAtOrDefault(i).FullName, Is.EqualTo(testDoctors[i].FullName));
        }
    }
    [Test]
    public async Task GetAllAppointments()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var testAppointments = new List<Appointment>()
        {
            new Appointment { DoctorId = 1, PatientId = 1 },
            new Appointment { DoctorId = 1, PatientId = 2 },
            new Appointment { DoctorId = 3, PatientId = 3 },
            new Appointment { DoctorId = 2, PatientId = 4 },
            new Appointment { DoctorId = 3, PatientId = 4 },
            new Appointment { DoctorId = 2, PatientId = 5 }
        };

        var response = await client.GetAsync("/surgery/appointments");
        var responsePayload = response.Content.ReadFromJsonAsync<IEnumerable<Appointment>>();

        Assert.That(responsePayload.Result.Count(), Is.EqualTo(testAppointments.Count));
        for (int i = 0; i < testAppointments.Count; i++)
        {
            Assert.That(responsePayload.Result.ElementAtOrDefault(i).DoctorId, Is.EqualTo(testAppointments[i].DoctorId));
            Assert.That(responsePayload.Result.ElementAtOrDefault(i).PatientId, Is.EqualTo(testAppointments[i].PatientId));
        }
    }
    //Endpoint tests start here:
    [TestCase(1)]
    public async Task AppointmentEndpointStatus(int id)
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var response = await client.GetAsync("/surgery/appointments");
        var response2 = await client.GetAsync($"/surgery/appointmentsbydoctor/{id}");
        var response3 = await client.GetAsync($"/surgery/appointmentsbypatient/{id}");
        
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.IsTrue(response2.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.IsTrue(response3.StatusCode == System.Net.HttpStatusCode.OK);
    }
    [Test]
    public async Task CreateAppointmentTest()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var appointment = new Appointment { PatientId = 3, DoctorId = 2 };

        var response = await client.PostAsJsonAsync("/surgery/appointments", appointment);

        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
    }
    [TestCase(1)]//There are 3 seeded doctors
    [TestCase(2)]
    [TestCase(3)]
    public async Task DoctorEndpointStatus(int id)
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var response = await client.GetAsync("/surgery/doctors");
        var response2 = await client.GetAsync($"/surgery/doctors/{id}");
        

        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.IsTrue(response2.StatusCode == System.Net.HttpStatusCode.OK);
    }
    [Test]
    public async Task CreateDoctorTest()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var doctor = new Doctor { FullName = "Hannibal Lecter" };

        var response = await client.PostAsJsonAsync("/surgery/doctors", doctor);

        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
    }
    [TestCase(1)]//There are 5 seeded patients
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    public async Task PatientEndpointStatus(int id)
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var response = await client.GetAsync("/surgery/patients");
        var response2 = await client.GetAsync($"/surgery/patients/{id}");
        
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.IsTrue(response2.StatusCode == System.Net.HttpStatusCode.OK);
    }
    [Test]
    public async Task CreatePatient()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var patient = new Patient { FullName = "John Doe" };

        var response = await client.PostAsJsonAsync("/surgery/patients", patient);

        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
    }
}