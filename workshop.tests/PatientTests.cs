using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;
using workshop.wwwapi.Endpoints;
using wwwapi.DTO;

namespace workshop.tests;

public class Tests
{
    private HttpClient client;

    [SetUp]
    public void setup()
    {
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        client = factory.CreateClient();
    }

    [Test]
    public async Task GetAllPatientsEndpointStatus()
    {
        // Arrange

        // Act
        var response = await client.GetAsync("/surgery/patients");
        var responseData = await response.Content.ReadAsStringAsync();
        List<PatientReturnDTO> PatientDTO = JsonConvert.DeserializeObject<List<PatientReturnDTO>>(responseData);

        //Can i access the data in some way??

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        Assert.That(responseData, Is.EqualTo(null));
    }

    [Test]
    public async Task GetPatientsById_ReturnsOK()
    {
        var response = await client.GetAsync("/surgery/patients/1");
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    }

    [Test]
    public async Task CreatePatient_ReturnsOK()
    {
        var newPatient = new patientPayload("Test1");
        var content = new StringContent(JsonConvert.SerializeObject(newPatient), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/surgery/patients", content);
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        //If i implemented a delete patient, the test should prob delete it from db after
    }

    [Test]
    public async Task GetDoctors_ReturnsOK()
    {
        var response = await client.GetAsync("/surgery/doctors");
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    }

    [Test]
    public async Task GetAppointmentsByDoctor_ReturnsOK()
    {
        var response = await client.GetAsync("/surgery/appointmentsbydoctor/1");
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    }
}