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

public class PatientTest
{
    private Seeder _seeder;
    private HttpClient _client;
    private Func<Task>? _postTestAction;
    public PatientTest()
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

    private List<PatientView> Patients => _seeder.Patients.Select(patient => new PatientView(patient.Id, patient.FullName, 
        patient.Appointments.Select(appointment => new AppointmentDoctor(
            appointment.AppointmentType.ToString(),
            appointment.Booking,
            new DoctorInternal(
                appointment.Doctor.Id,
                appointment.Doctor.FullName
            ))).ToList())
        ).ToList();

    [Test]
    public async Task TestGetPatients()
    {
        var response = await _client.GetAsync("/patients");
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        var patients = await response.Content.ReadFromJsonAsync<List<PatientView>>();
        var seedPatients = Patients;

        Assert.That(patients, Is.Not.Null);
        Assert.That(patients.Count, Is.EqualTo(seedPatients.Count));

        for (int i = 0; i < Patients.Count; i++)
        {
            Assert.That(seedPatients[i], new RecursiveComparisonConstraint(patients[i]));
        }
    }

    [TestCase(1, HttpStatusCode.OK)]
    [TestCase(2, HttpStatusCode.OK)]
    [TestCase(10, HttpStatusCode.NotFound)]
    public async Task TestGetPatientById(int id, HttpStatusCode statusCode)
    {
        var response = await _client.GetAsync($"/patients/{id}");

        Assert.That(response.StatusCode, Is.EqualTo(statusCode));
        if (HttpStatusCode.OK != statusCode) return; 

        var patient = await response.Content.ReadFromJsonAsync<PatientView>();
        var seedPatient = Patients.FirstOrDefault(p => p.Id == id);

        Assert.Multiple(() =>
        {
            Assert.That(patient, Is.Not.Null);
            Assert.That(seedPatient, Is.Not.Null);
        });

        Assert.That(seedPatient, new RecursiveComparisonConstraint(patient));
    }

    [Test]
    public async Task TestCreate()
    {

        string firstName = "Tester";
        string lastName = "Testington";
        var response = await _client.PostAsJsonAsync($"/patients/", new PatientPost(firstName, lastName));

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        PatientView? patient = await response.Content.ReadFromJsonAsync<PatientView>();
        Assert.That(patient, Is.Not.Null);
        _postTestAction = async () =>
        {
            using var cleanupContext = DataContextFactory.CreateTestDataContext();
            Patient? p = await cleanupContext.Patients.FirstOrDefaultAsync(p => p.Id == patient.Id);
            if (p != null)
            {
                cleanupContext.Remove(p);
                await cleanupContext.SaveChangesAsync();
            }
        };
        Assert.That(patient.FullName, Is.EqualTo($"{firstName} {lastName}"));

        response = await _client.GetAsync($"/patients/{patient.Id}");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var patient2 = await response.Content.ReadFromJsonAsync<PatientView>();
        Assert.That(patient2, Is.Not.Null);
        Assert.That(patient, new RecursiveComparisonConstraint(patient2));
    }
}