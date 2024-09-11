using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.AppointmentDTOs;

namespace workshop.tests;

public class AppointmentTests
{

    private WebApplicationFactory<Program> _factory;
    private HttpClient _client;

    [SetUp]
    public void Setup()
    {
        // Setup the WebApplicationFactory and HttpClient for each test
        _factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        _client = _factory.CreateClient();
    }

    [TearDown]
    public void TearDown()
    {
        _client.Dispose();
        _factory.Dispose();
    }

    [Test]
    public async Task GetSeededAppointments()
    {
        // Act
        var response = await _client.GetAsync("/surgery/appointments");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

        var appointments = await response.Content.ReadFromJsonAsync<List<GetAppointmentDTO>>();
        Assert.IsNotNull(appointments);
        Assert.IsTrue(appointments.Count > 0);
    }

    [Test]
    public async Task GetAppointmentsByDoctor()
    {
       
        var doctorId = new Guid("dab46f4b-eeb2-4fd9-a76c-330fa1fdb537");

        var response = await _client.GetAsync($"/surgery/appointmentsbydoctor/{doctorId}");

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var appointments = await response.Content.ReadFromJsonAsync<List<Appointment>>();

        Assert.IsNotNull(appointments);
        Assert.IsTrue(appointments.Count() > 0);
    }

    [Test]
    public async Task GetAppointmentsByPatient()
    {

        var patientId = new Guid("33b8ff19-ca60-4f49-a79b-33071b196a04");

        var response = await _client.GetAsync($"/surgery/appointmentsbypatient/{patientId}");

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var appointments = await response.Content.ReadFromJsonAsync<List<Appointment>>();

        Assert.IsNotNull(appointments);
        Assert.IsTrue(appointments.Count() > 0);
    }
}