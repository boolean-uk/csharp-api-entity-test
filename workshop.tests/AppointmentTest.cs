using System.Net;
using System.Net.Http.Json;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using workshop.tests.Tools;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Enums;
using workshop.wwwapi.Models;

namespace workshop.tests;

public class AppointmentTest
{
    private Seeder _seeder;
    private HttpClient _client;
    private Func<Task>? _postTestAction;
    public AppointmentTest()
    {
        _seeder = new Seeder();
    }

    [SetUp]
    public void SetUp()
    {
        var factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder => { });
        _client = factory.CreateClient();
        _postTestAction = null;
    }

    [TearDown]
    public void Dispose()
    {
        if (_postTestAction != null) _postTestAction();
        _client?.Dispose();
    }

    private List<AppointmentView> Appointments => _seeder.Appointments.Select(appointment =>
    {
        Doctor doctor = _seeder.Doctors.FirstOrDefault(d => d.Id == appointment.DoctorId)!;
        Patient patient = _seeder.Patients.FirstOrDefault(d => d.Id == appointment.PatientId)!;

        return new AppointmentView(
                appointment.AppointmentType.ToString(),
                appointment.Booking,

                new DoctorInternal(
                    doctor.Id,
                    doctor.FullName
                ),
                new PatientInternal(
                    patient.Id,
                    patient.FullName
                )
            );
    }).ToList();
    

    [Test]
    public async Task TestGetAppointments()
    {
        var response = await _client.GetAsync("/appointments");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var appointments = await response.Content.ReadFromJsonAsync<List<AppointmentView>>();
        var seedAppointments = Appointments;

        Assert.That(appointments, Is.Not.Null);
        Assert.That(seedAppointments, Is.Not.Null);
        Assert.That(appointments.Count, Is.EqualTo(seedAppointments.Count));

        for (int i = 0; i < seedAppointments.Count; i++)
        {
            Assert.That(seedAppointments[i], new RecursiveComparisonConstraint(appointments[i]));
        }
    }

    public async Task TestGetAppointmentsQueried()
    {
        int doctorId = 1;
        int patientId = 1;
        var response = await _client.GetAsync($"/appointments?doctorId={doctorId}");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var appointments = await response.Content.ReadFromJsonAsync<List<AppointmentView>>();
        var seedAppointments = Appointments.Where(a => a.Doctor.Id == doctorId).ToList();

        Assert.That(appointments, Is.Not.Null);
        Assert.That(appointments.Count, Is.EqualTo(seedAppointments.Count));

        for (int i = 0; i < seedAppointments.Count; i++)
        {
            Assert.That(seedAppointments[i], new RecursiveComparisonConstraint(appointments[i]));
        }

        response = await _client.GetAsync($"/appointments?patientId={patientId}");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        appointments = await response.Content.ReadFromJsonAsync<List<AppointmentView>>();
        seedAppointments = Appointments.Where(a => a.Patient.Id == patientId).ToList();

        Assert.That(appointments, Is.Not.Null);
        Assert.That(appointments.Count, Is.EqualTo(seedAppointments.Count));

        for (int i = 0; i < seedAppointments.Count; i++)
        {
            Assert.That(seedAppointments[i], new RecursiveComparisonConstraint(appointments[i]));
        }

        response = await _client.GetAsync($"/appointments?patientId={patientId}&doctorId={doctorId}");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        appointments = await response.Content.ReadFromJsonAsync<List<AppointmentView>>();
        seedAppointments = Appointments.Where(a => a.Patient.Id == patientId && a.Doctor.Id == doctorId).ToList();

        Assert.That(appointments, Is.Not.Null);
        Assert.That(appointments.Count, Is.EqualTo(seedAppointments.Count));

        for (int i = 0; i < seedAppointments.Count; i++)
        {
            Assert.That(seedAppointments[i], new RecursiveComparisonConstraint(appointments[i]));
        }
    }

    [TestCase(1, 1, HttpStatusCode.OK)]
    [TestCase(2, 1, HttpStatusCode.OK)]
    [TestCase(10, 1, HttpStatusCode.NotFound)]
    public async Task TestGetAppointmentById(int doctorId, int patientId, HttpStatusCode statusCode)
    {
        var response = await _client.GetAsync($"/appointments/{doctorId}/{patientId}");

        Assert.That(response.StatusCode, Is.EqualTo(statusCode));
        if (HttpStatusCode.OK != statusCode) return; 

        var appointment = await response.Content.ReadFromJsonAsync<AppointmentView>();
        var seedAppointment = Appointments.FirstOrDefault(p => p.Doctor.Id == doctorId && p.Patient.Id == patientId);

        Assert.Multiple(() =>
        {
            Assert.That(appointment, Is.Not.Null);
            Assert.That(seedAppointment, Is.Not.Null);
        });

        Assert.That(seedAppointment, new RecursiveComparisonConstraint(appointment));
    }

    [Test]
    public async Task TestCreate()
    {

        int doctorId = 3;
        int patientId = 2;
        int daysTillBooking = 2;
        string appointmentType = AppointmentType.Visitation.ToString();
        var response = await _client.PostAsJsonAsync($"/appointments/", new AppointmentPost(doctorId, patientId, daysTillBooking, appointmentType));

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        AppointmentView? appointment = await response.Content.ReadFromJsonAsync<AppointmentView>();
        Assert.That(appointment, Is.Not.Null);
        _postTestAction = async () =>
        {
            using var cleanupContext = DataContextFactory.CreateTestDataContext();
            Appointment? p = await cleanupContext.Appointments.FirstOrDefaultAsync(p => p.DoctorId == appointment.Doctor.Id && p.PatientId == appointment.Patient.Id);
            if (p != null)
            {
                cleanupContext.Remove(p);
                await cleanupContext.SaveChangesAsync();
            }
        };
        Assert.That(appointment.AppointmentType, Is.EqualTo(appointmentType));

        response = await _client.GetAsync($"/appointments/{appointment.Doctor.Id}/{appointment.Patient.Id}");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var appointment2 = await response.Content.ReadFromJsonAsync<AppointmentView>();
        Assert.That(appointment2, Is.Not.Null);
        Assert.That(appointment, new RecursiveComparisonConstraint(appointment2));
    }
}