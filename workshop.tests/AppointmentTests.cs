using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;
using workshop.wwwapi;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;



namespace workshop.tests;

public class AppointmentTests
{

    [SetUp]
    public void SetUp()
    {

    }

    [Test]
    public async Task AppointmentEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/appointments");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }


    [Test]
    public async Task GetAppointmentResponse()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var expectedPayload = new List<Appointment>()
            {
                new Appointment { Booking = DateTime.Now.ToUniversalTime(), PatientId = 1, DoctorId = 1 },
                new Appointment { Booking = DateTime.Now.ToUniversalTime(), PatientId = 2, DoctorId = 2 },

                new Appointment { Booking = DateTime.Now.ToUniversalTime(), PatientId = 3, DoctorId = 2 },
                new Appointment { Booking = DateTime.Now.ToUniversalTime(), PatientId = 2, DoctorId = 1 }
            };

        var response = await client.GetAsync("/surgery/appointments");

        var responsePayload = response.Content.ReadFromJsonAsync<IEnumerable<Appointment>>();

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));


        Assert.That(responsePayload.Result.Count(), Is.EqualTo(4));

        Assert.That(responsePayload.Result.ElementAtOrDefault(0).Doctor.Id, Is.EqualTo(expectedPayload[0].DoctorId));
        Assert.That(responsePayload.Result.ElementAtOrDefault(0).Patient.Id, Is.EqualTo(expectedPayload[0].PatientId));

        Assert.That(responsePayload.Result.ElementAtOrDefault(1).Patient.Id, Is.EqualTo(expectedPayload[3].PatientId));
        Assert.That(responsePayload.Result.ElementAtOrDefault(1).Doctor.Id, Is.EqualTo(expectedPayload[3].DoctorId));


        Assert.That(responsePayload.Result.ElementAtOrDefault(2).Patient.Id, Is.EqualTo(expectedPayload[1].PatientId));
        Assert.That(responsePayload.Result.ElementAtOrDefault(2).Doctor.Id, Is.EqualTo(expectedPayload[1].DoctorId));

        Assert.That(responsePayload.Result.ElementAtOrDefault(3).Patient.Id, Is.EqualTo(expectedPayload[2].PatientId));
        Assert.That(responsePayload.Result.ElementAtOrDefault(3).Doctor.Id, Is.EqualTo(expectedPayload[2].DoctorId));

    }

    [Test]
    public async Task GetAppointmentByDoctorResponse()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var expectedPayload = new List<Appointment>()
            {
                new Appointment { Booking = DateTime.Now.ToUniversalTime(), PatientId = 2, DoctorId = 2 },
                new Appointment { Booking = DateTime.Now.ToUniversalTime(), PatientId = 3, DoctorId = 2 },
            };

        var response = await client.GetAsync("/surgery/appointmentsbydoctor/2");

        var responsePayload = response.Content.ReadFromJsonAsync<IEnumerable<Appointment>>();

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        Assert.That(responsePayload.Result.Count(), Is.EqualTo(2));

        Assert.That(responsePayload.Result.ElementAtOrDefault(0).Patient.Id, Is.EqualTo(expectedPayload[0].PatientId));

        Assert.That(responsePayload.Result.ElementAtOrDefault(1).Patient.Id, Is.EqualTo(expectedPayload[1].PatientId));

    }

    [Test]
    public async Task GetAppointmentByPatientResponse()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var expectedPayload = new List<Appointment>()
            {
               new Appointment { Booking = DateTime.Now.ToUniversalTime(), PatientId = 2, DoctorId = 2 },
               new Appointment { Booking = DateTime.Now.ToUniversalTime(), PatientId = 2, DoctorId = 1 }
            };

        var response = await client.GetAsync("/surgery/appointmentsbypatient/2");

        var responsePayload = response.Content.ReadFromJsonAsync<IEnumerable<Appointment>>();

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));


        Assert.That(responsePayload.Result.Count(), Is.EqualTo(2));

        Assert.That(responsePayload.Result.ElementAtOrDefault(0).Doctor.Id, Is.EqualTo(expectedPayload[1].DoctorId));

        Assert.That(responsePayload.Result.ElementAtOrDefault(1).Doctor.Id, Is.EqualTo(expectedPayload[0].DoctorId));

    }


    [Test]
    public async Task GetOneAppointmentResponse()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var expectedPayload = new List<Appointment>()
            {
                new Appointment { Booking = DateTime.Now.ToUniversalTime(), PatientId = 1, DoctorId = 1 },
            };

        var response = await client.GetAsync("/surgery/appointments/patients/1/doctors/1");

        var responsePayload = response.Content.ReadFromJsonAsync<Appointment>();

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        Assert.That(responsePayload.Result.Doctor.Id, Is.EqualTo(expectedPayload[0].DoctorId));
        Assert.That(responsePayload.Result.Patient.Id, Is.EqualTo(expectedPayload[0].PatientId));

    }


    [Test]
    public async Task CreateAppointmentResponse()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var expectedPayload = new List<Appointment>()
            {
                new Appointment { Booking = DateTime.Now.ToUniversalTime(), PatientId = 1, DoctorId = 2 },
            };

        var obj = new
        {
            DoctorId = 2,
            PatientId = 1
        };

        JsonContent content = JsonContent.Create(obj);

        var response = await client.PostAsync("/surgery/appointments", content);

        var responsePayload = response.Content.ReadFromJsonAsync<Appointment>();

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        Assert.That(responsePayload.Result.Doctor.Id, Is.EqualTo(expectedPayload[0].DoctorId));
        Assert.That(responsePayload.Result.Patient.Id, Is.EqualTo(expectedPayload[0].PatientId));

    }
}