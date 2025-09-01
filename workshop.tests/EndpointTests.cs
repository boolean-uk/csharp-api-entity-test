using System.Net.Http.Json;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTOs.Appointment;
using workshop.wwwapi.DTOs.Doctor;
using workshop.wwwapi.DTOs.Patient;

namespace workshop.tests;

public class EndpointTests
{
    private TestWebApplication _testWebApplication;
    private HttpClient _client;

    private Seeder _seeder = new Seeder();

    [SetUp]
    public void SetUp()
    {
        _testWebApplication = new TestWebApplication();
        _client = _testWebApplication.CreateClient();
    }

    [TearDown]
    public void TearDown()
    {
        _client.Dispose();
        _testWebApplication.Dispose();
    }

    [Test]
    public async Task GetPatientsTest()
    {
        // Arrange
        var expected = _seeder.Patients;

        // Act
        var response = await _client.GetAsync("surgery/patients");
        var patients = await response.Content.ReadFromJsonAsync(typeof(List<PatientPost>)) as List<PatientPost>;
        Assert.Multiple(() =>
        {
            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(patients, Has.Count.EqualTo(expected.Count));
        });
        for (var i = 0; i < patients.Count; i++)
        {
            Assert.That(patients[i].FullName, Is.EqualTo(expected[i].FullName));
        }
    }

    [Test]
    public async Task GetDoctorsTest()
    {
        // Arrange
        var expected = _seeder.Doctors;

        // Act
        var response = await _client.GetAsync("surgery/doctors");
        var doctors = await response.Content.ReadFromJsonAsync(typeof(List<DoctorPost>)) as List<DoctorPost>;
        Assert.Multiple(() =>
        {
            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(doctors, Has.Count.EqualTo(expected.Count));
        });
        for (var i = 0; i < doctors.Count; i++)
        {
            Assert.That(doctors[i].FullName, Is.EqualTo(expected[i].FullName));
        }
    }

    [Test]
    public async Task GetAppointmentsTest()
    {
        // Arrange
        var expected = _seeder.Appointments;

        // Act
        var response = await _client.GetAsync("surgery/appointments");
        var appointments =
            await response.Content.ReadFromJsonAsync(typeof(List<AppointmentPost>)) as List<AppointmentPost>;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(appointments, Has.Count.EqualTo(expected.Count));
        });
        for (var i = 0; i < appointments.Count; i++)
        {
            Assert.That(appointments[i].Booking, Is.EqualTo(expected[i].Booking));
        }
    }
}