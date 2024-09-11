using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.AppointmentDTOs;

namespace workshop.tests;

public class DoctorTests
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
    public async Task GetSeededDoctors()
    {
        // Act
        var response = await _client.GetAsync("/surgery/doctors");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

        var doctors = await response.Content.ReadFromJsonAsync<List<GetDoctorDTO>>();
        Assert.IsNotNull(doctors);
        Assert.IsTrue(doctors.Count > 0);
        Assert.IsTrue(doctors.Any(d => d.FullName == "Dr. Bob Smith"));
        Assert.IsTrue(doctors.Any(d => d.FullName == "Dr. Alice Johnson"));
    }

    [Test]
    public async Task GetDoctor()
    {
        var doctorId = new Guid("63a45eab-a7b4-4fa3-aa13-ef1297aaf4f3");
        var requestUrl = $"/surgery/doctors/{doctorId}";

        var response = await _client.GetAsync(requestUrl);

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var doctor = await response.Content.ReadFromJsonAsync<Doctor>();

        Assert.IsNotNull(doctor);
        Assert.AreEqual(doctorId, doctor.Id);
        Assert.AreEqual("Dr. Bob Smith", doctor.FullName);
    }

    [Test]
    public async Task CreateDoctor()
    {
        var newDoctorJson = new
        {
            FullName = "Dr. Who"
        };

        var content = new StringContent(
            JsonConvert.SerializeObject(newDoctorJson),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _client.PostAsync("/surgery/doctors", content);

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var createdDoctor = await response.Content.ReadFromJsonAsync<Doctor>();

        Assert.AreEqual("Dr. Who", createdDoctor.FullName); 
    }
}