using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using workshop.wwwapi.DTOs;

namespace workshop.tests;

public class DoctorTests
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

    // Remeber that this test will only work the first time since the next test creates another Doctor, so the Assert.That(doctors.Length, Is.EqualTo(2)); would be false.
    [Test, Order(1)]
    public async Task GetSeedDoctorsTest()
    {
        var response = await _client.GetAsync("/doctor");
        response.EnsureSuccessStatusCode();

        var doctors = await response.Content.ReadFromJsonAsync<DoctorDTO[]>();

        Assert.That(doctors, Is.Not.Null);
        Assert.That(doctors.Length, Is.EqualTo(2));

        var d1 = doctors[0];

        Assert.That(d1.Id, Is.EqualTo(1));
        Assert.That(d1.FirstName, Is.EqualTo("Alexander"));
        Assert.That(d1.LastName, Is.EqualTo("Solberg"));

        var d2 = doctors[1];

        Assert.That(d2.Id, Is.EqualTo(2));
        Assert.That(d2.FirstName, Is.EqualTo("Hermine"));
        Assert.That(d2.LastName, Is.EqualTo("Aasheim"));
    }

    [Test, Order(2)]
    public async Task CreateDoctorTest()
    {
        var createDoctorDto = new CreateDoctorDTO
        {
            FirstName = "Fillip",
            LastName = "Nilsen"
        };

        var response = await _client.PostAsJsonAsync("/doctor", createDoctorDto);
        response.EnsureSuccessStatusCode();

        var createdDoctor = await response.Content.ReadFromJsonAsync<DoctorDTO>();

        Assert.That(createdDoctor, Is.Not.Null);
        Assert.That(createDoctorDto.FirstName, Is.EqualTo(createdDoctor.FirstName));
        Assert.That(createDoctorDto.LastName, Is.EqualTo(createdDoctor.LastName));
    }
}
