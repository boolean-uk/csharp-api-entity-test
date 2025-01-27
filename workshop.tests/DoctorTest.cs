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
using workshop.wwwapi.Models;

namespace workshop.tests;

public class DoctorTest
{
    private Seeder _seeder;
    private HttpClient _client;
    private Func<Task>? _postTestAction;
    public DoctorTest()
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

    private List<DoctorView> Doctors => _seeder.Doctors.Select(doctor => new DoctorView(doctor.Id, doctor.FullName, 
        doctor.Appointments.Select(appointment => new AppointmentPatient(
            appointment.AppointmentType.ToString(),
            appointment.Booking,
            new PatientInternal(
                appointment.Patient.Id,
                appointment.Patient.FullName
            ))).ToList())
        ).ToList();

    [Test]
    public async Task TestGetDoctors()
    {
        var response = await _client.GetAsync("/doctors");
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        var doctors = await response.Content.ReadFromJsonAsync<List<DoctorView>>();
        var seedDoctors = Doctors;

        Assert.That(doctors, Is.Not.Null);
        Assert.That(doctors.Count, Is.EqualTo(seedDoctors.Count));

        for (int i = 0; i < seedDoctors.Count; i++)
        {
            Assert.That(seedDoctors[i], new RecursiveComparisonConstraint(doctors[i]));
        }
    }

    [TestCase(1, HttpStatusCode.OK)]
    [TestCase(2, HttpStatusCode.OK)]
    [TestCase(10, HttpStatusCode.NotFound)]
    public async Task TestGetDoctorById(int id, HttpStatusCode statusCode)
    {
        var response = await _client.GetAsync($"/doctors/{id}");

        Assert.That(response.StatusCode, Is.EqualTo(statusCode));
        if (HttpStatusCode.OK != statusCode) return; 

        var doctor = await response.Content.ReadFromJsonAsync<DoctorView>();
        var seedDoctor = Doctors.FirstOrDefault(p => p.Id == id);

        Assert.Multiple(() =>
        {
            Assert.That(doctor, Is.Not.Null);
            Assert.That(seedDoctor, Is.Not.Null);
        });

        Assert.That(seedDoctor, new RecursiveComparisonConstraint(doctor));
    }

    [Test]
    public async Task TestCreate()
    {

        string firstName = "Tester";
        string lastName = "Testington";
        var response = await _client.PostAsJsonAsync($"/doctors/", new DoctorPost(firstName, lastName));

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        DoctorView? doctor = await response.Content.ReadFromJsonAsync<DoctorView>();
        Assert.That(doctor, Is.Not.Null);
        _postTestAction = async () =>
        {
            using var cleanupContext = DataContextFactory.CreateTestDataContext();
            Doctor? p = await cleanupContext.Doctors.FirstOrDefaultAsync(p => p.Id == doctor.Id);
            if (p != null)
            {
                cleanupContext.Remove(p);
                await cleanupContext.SaveChangesAsync();
            }
        };
        Assert.That(doctor.FullName, Is.EqualTo($"{firstName} {lastName}"));

        response = await _client.GetAsync($"/doctors/{doctor.Id}");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var doctor2 = await response.Content.ReadFromJsonAsync<DoctorView>();
        Assert.That(doctor2, Is.Not.Null);
        Assert.That(doctor, new RecursiveComparisonConstraint(doctor2));
    }
}