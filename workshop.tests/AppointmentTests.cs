using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using workshop.wwwapi.DTOs;

namespace workshop.tests;

public class AppointmentTests
{
    private WebApplicationFactory<Program> _factory;
    private HttpClient _client;

    [SetUp]
    public void Setup()
    {
        _factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        _client = _factory.CreateClient();
    }

    [TearDown]
    public void TearDown()
    {
        _client.Dispose();
        _factory.Dispose();
    }

    // Remeber that this test will only work the first time since the next test creates another Appointment, so the Assert.That(appointments.Length, Is.EqualTo(2)); would be false.
    [Test, Order(1)]
    public async Task GetSeedAppointmentsTest()
    {
        var response = await _client.GetAsync("/appointment");
        response.EnsureSuccessStatusCode();

        var appointments = await response.Content.ReadFromJsonAsync<AppointmentDTO[]>();

        Assert.That(appointments, Is.Not.Null);
        Assert.That(appointments.Length, Is.EqualTo(2));

        var a1 = appointments[0];

        Assert.That(a1.Id, Is.EqualTo(1));
        Assert.That(a1.DoctorId, Is.EqualTo(1));
        Assert.That(a1.PatientId, Is.EqualTo(1));

        var a2 = appointments[1];

        Assert.That(a2.Id, Is.EqualTo(2));
        Assert.That(a2.DoctorId, Is.EqualTo(2));
        Assert.That(a2.PatientId, Is.EqualTo(2));
    }

    [Test, Order(2)]
    public async Task CreateAppointmentTest()
    {
        var createAppointmentDto = new CreateAppointmentDTO
        {
            DoctorId = 1,
            PatientId = 2,
            AppointmentDateTime = DateTime.UtcNow.AddDays(1)
        };

        var response = await _client.PostAsJsonAsync("/appointment", createAppointmentDto);
        response.EnsureSuccessStatusCode();

        var createdAppointment = await response.Content.ReadFromJsonAsync<AppointmentDTO>();

        Assert.That(createdAppointment, Is.Not.Null);
        Assert.That(createAppointmentDto.DoctorId, Is.EqualTo(createdAppointment.DoctorId));
        Assert.That(createAppointmentDto.PatientId, Is.EqualTo(createdAppointment.PatientId));
    }
}
