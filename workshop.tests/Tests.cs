using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Enums;
using workshop.wwwapi.ViewModel;

namespace workshop.tests;

public class Tests
{

    private WebApplicationFactory<Program> _factory;
    private HttpClient _client;

    [SetUp]
    public void SetUp()
    {
        _factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {

        });
        _client = _factory.CreateClient();
    }

    [Test]
    public async Task GetAllPatients_ReturnsSeededData()
    {

        // Act
        var response = await _client.GetAsync("/patients");
        var content = await response.Content.ReadAsStringAsync();
        var patients = JsonConvert.DeserializeObject<List<PatientDTO>>(content);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(patients, Is.Not.Empty);
    }

    [Test]
    public async Task CreatePatient_ReturnsCreatedStatus()
    {
        // Arrange
        var newPatient = new PatientDTO
        {
            FullName = "Nigel",
        };
        var json = JsonConvert.SerializeObject(newPatient);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/patients", content);
        var responseContent = await response.Content.ReadAsStringAsync();
        var createdPatient = JsonConvert.DeserializeObject<PatientDTO>(responseContent);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(createdPatient, Is.Not.Null);
        Assert.That(createdPatient.FullName, Is.EqualTo(newPatient.FullName));
    }

    [Test]
    public async Task GetAllAppointments_ReturnsSeededData()
    {
        // Arrange

        // Act
        var response = await _client.GetAsync("/appointments");
        var content = await response.Content.ReadAsStringAsync();
        var appointments = JsonConvert.DeserializeObject<List<AppointmentDTO>>(content);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(appointments, Is.Not.Empty);
    }

    // Will only work once per doctorid and patientid combination
    [Test]
    public async Task CreateAppointment_ReturnsCreatedStatus()
    {
        // Arrange
        var newAppointment = new CreateAppointment
        {
            Booking = DateTime.UtcNow,
            DoctorId = 15, 
            PatientId = 14, 
            AppointmentType = AppointmentType.InPerson
        };
        var json = JsonConvert.SerializeObject(newAppointment);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/appointments", content);
        var responseContent = await response.Content.ReadAsStringAsync();
        var createdAppointment = JsonConvert.DeserializeObject<AppointmentDTO>(responseContent);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(createdAppointment, Is.Not.Null);
        Assert.That(createdAppointment.Doctor, Is.TypeOf<DoctorDTO>());
        Assert.That(createdAppointment.Patient, Is.TypeOf<PatientDTO>());
    }

    [Test]
    public async Task GetAllPrescriptions_ReturnsSeededData()
    {
        // Arrange


        // Act
        var response = await _client.GetAsync("/prescriptions");
        var content = await response.Content.ReadAsStringAsync();
        var prescriptions = JsonConvert.DeserializeObject<List<PrescriptionDTO>>(content);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(prescriptions, Is.Not.Empty); 
    }

    [Test]
    public async Task CreatePrescription_ReturnsCreatedStatus()
    {
        // Arrange
        var newPrescription = new CreatePrescription
        {
            IssueDate = DateTime.UtcNow,
            DoctorId = 1,
            PatientId = 4
        };
        var json = JsonConvert.SerializeObject(newPrescription);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/prescriptions", content);
        var responseContent = await response.Content.ReadAsStringAsync();
        var createdPrescription = JsonConvert.DeserializeObject<PrescriptionDTO>(responseContent);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(createdPrescription, Is.Not.Null);
        Assert.That(createdPrescription.Appointment, Is.TypeOf<AppointmentDTO>());
    }

    [TearDown]
    public void TearDown()
    {
        _client.Dispose();
        _factory.Dispose();
    }


}